using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using BetelgeuseAPI.Application.Abstractions.Services.Helpers;
using System.Text;

namespace BetelgeuseAPI.Persistence.Helpers;

public class FileCheckHelper: IFileCheckHelper
{
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FileCheckHelper(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<bool> CheckVideoFormat(IFormFile file)
    {
        if (file.ContentType != "video/mp4" || Path.GetExtension(file.FileName).ToLower() != ".mp4")
        {
            return false;
        }

        string tempFilePath = Path.GetTempFileName();
        try
        {
            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            
            bool isValidFormat = await CheckFormatWithFFprobe(tempFilePath);
            File.Delete(tempFilePath);
            return isValidFormat;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> CheckPdfFormat(IFormFile file)
    {
        if (file.ContentType != "application/pdf" || Path.GetExtension(file.FileName).ToLower() != ".pdf")
        {
            return false;
        }
        string tempFilePath = Path.GetTempFileName();

        try
        {
            using (var stream = new FileStream(tempFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            using (var reader = new BinaryReader(File.OpenRead(tempFilePath)))
            {
                byte[] header = reader.ReadBytes(4);
                string pdfHeader = Encoding.ASCII.GetString(header); 

                if (pdfHeader.StartsWith("%PDF"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception)
        {
            return false;
        }
        finally
        {
            File.Delete(tempFilePath);
        }
    }
    public async Task<bool> CheckPPTFormat(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return false;
        }

        var fileExtension = Path.GetExtension(file.FileName);
        if (fileExtension != ".pptx" && fileExtension != ".ppt")
        {
            return false;
        }
        try
        {
            using (var stream = file.OpenReadStream())
            {
                var buffer = new byte[4];
                await stream.ReadAsync(buffer, 0, buffer.Length);
                if (buffer[0] == 0x50 && buffer[1] == 0x4B && buffer[2] == 0x03 && buffer[3] == 0x04)
                {
                    return true; 
                }
                else
                {
                    return false; 
                }
            }
        }
        catch
        {
            return false; 
        }
    }

    public async Task<bool> CheckImageFormat(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            return false;
        }

        var fileExtension = Path.GetExtension(file.FileName);
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
        if (!allowedExtensions.Contains(fileExtension.ToLower()))
        {
            return false;
        }

        try
        {
            using (var stream = file.OpenReadStream())
            {
                var buffer = new byte[4];
                await stream.ReadAsync(buffer, 0, buffer.Length);

                if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg")
                {
                    if (buffer[0] == 0xFF && buffer[1] == 0xD8 && buffer[2] == 0xFF)
                    {
                        return true;
                    }
                }
                else if (fileExtension.ToLower() == ".png")
                {
                    if (buffer[0] == 0x89 && buffer[1] == 0x50 && buffer[2] == 0x4E && buffer[3] == 0x47)
                    {
                        return true;
                    }
                }
                else if (fileExtension.ToLower() == ".gif")
                {
                    if (buffer[0] == 0x47 && buffer[1] == 0x49 && buffer[2] == 0x46 && buffer[3] == 0x38)
                    {
                        return true;
                    }
                }
                else if (fileExtension.ToLower() == ".bmp")
                {
                    if (buffer[0] == 0x42 && buffer[1] == 0x4D)
                    {
                        return true;
                    }
                }

                return false;
            }
        }
        catch
        {
            return false;
        }
    }

    private async Task<bool> CheckFormatWithFFprobe(string filePath)
    {
        try
        {
            string ffprobePath = Path.Combine(_webHostEnvironment.WebRootPath, "ffmpeg", "ffprobe.exe");
            string arguments = $"-v error -select_streams v:0 -show_entries stream=codec_name -of default=noprint_wrappers=1:nokey=1 \"{filePath}\"";

            using (Process ffprobeProcess = new Process())
            {
                ffprobeProcess.StartInfo.FileName = ffprobePath;
                ffprobeProcess.StartInfo.Arguments = arguments;
                ffprobeProcess.StartInfo.UseShellExecute = false;
                ffprobeProcess.StartInfo.RedirectStandardOutput = true;
                ffprobeProcess.StartInfo.RedirectStandardError = true;

                ffprobeProcess.Start();
                string output = await ffprobeProcess.StandardOutput.ReadToEndAsync();
                string errorOutput = await ffprobeProcess.StandardError.ReadToEndAsync();
                ffprobeProcess.WaitForExit();

                Console.WriteLine($"ffprobe Error Output: {errorOutput}");

                return output.Contains("h264") || output.Contains("mpeg4") || output.Contains("avc1");
            }
        }
        catch (Exception)
        {
            return false;
        }
    }


}