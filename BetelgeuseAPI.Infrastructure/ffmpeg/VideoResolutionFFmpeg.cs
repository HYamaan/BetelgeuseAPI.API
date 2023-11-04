
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace BetelgeuseAPI.Infrastructure.ffmpeg
{
    public class VideoResolutionFFMPEG
    {
        private static List<(string pathOrContainerName, string fileName)> transformedFilePaths = new List<(string, string)>();

        public static List<(string pathOrContainerName, string fileName)> TransformedFilePaths
        {
            get { return transformedFilePaths; }
        }



        public static async Task VideoResolution(string pathOrContainerName, string newFileName, IFormFile file,string rootPath)
        {
            
            await Task.Run(async () =>
            {
                string temporaryFilePath = Path.GetTempFileName();
                var directory = Path.GetDirectoryName(temporaryFilePath)!;
                var destinationPath = Path.Combine(directory, newFileName);
                using (var stream = new FileStream(destinationPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream); // IFormFile'ı geçici dosyaya kopyalayın.
                }

                string[] inputVideos =
                {
                    destinationPath // Geçici dosyanın yolu
                };

                string ffmpegPath = Path.Combine(rootPath, "ffmpeg", "ffmpeg.exe");
                

                int[] targetWidths = { 1280, 854, 640, 426 };
                int[] targetHeights = { 720, 480, 360, 240 };
          
                foreach (var inputVideo in inputVideos)
                {
                    var resolution = await GetVideoResolutionAsync(inputVideo, rootPath);

                    if (resolution == null)
                    {
                        Console.WriteLine($"Video çözünürlüğü alınamadı: {inputVideo}");
                        continue;
                    }

                    Console.WriteLine($"Giriş video çözünürlüğü ({inputVideo}): {resolution.Item1}x{resolution.Item2}");

                    var tasks = new List<Task>();

                    foreach (var targetWidth in targetWidths)
                    {
                        tasks.Add(StartTransformationAsync(inputVideo, targetWidth, targetHeights[targetWidths.ToList().IndexOf(targetWidth)], resolution.Item1, resolution.Item2, ffmpegPath, pathOrContainerName));
                    }

                    await Task.WhenAll(tasks);

                    Console.WriteLine($"Tüm dönüşüm işlemleri tamamlandı ({inputVideo}).");
                }
                File.Delete(temporaryFilePath);
            });
        }


        static async Task<Tuple<int, int>> GetVideoResolutionAsync(string inputVideo,string rootPath)
        {
            string ffprobePath = Path.Combine(rootPath, "ffmpeg", "ffprobe.exe");
            string ffprobeCommand = $"-v error -select_streams v:0 -show_entries stream=width,height -of csv=s=x:p=0 {inputVideo}";

            using Process ffprobeProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ffprobePath,
                    Arguments = ffprobeCommand,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            ffprobeProcess.Start();
            string output = await ffprobeProcess.StandardOutput.ReadToEndAsync();
            ffprobeProcess.WaitForExit();
            ffprobeProcess.Close();

            string[] resolution = output.Trim().Split('x');

            if (resolution.Length == 2 && int.TryParse(resolution[0], out int width) && int.TryParse(resolution[1], out int height))
            {
                return Tuple.Create(width, height);
            }

            return null;
        }

        static async Task StartTransformationAsync(string inputVideo, int targetWidth, int targetHeight, int sourceWidth, int sourceHeight, string ffmpegPath, string pathOrContainerName)
        {
            string inputVideoName = Path.GetFileNameWithoutExtension(inputVideo);
            string fileName = $@"{inputVideoName}_{targetWidth}x{targetHeight}.mp4";
            string outputVideo = $@"{pathOrContainerName}\{fileName}";
            transformedFilePaths.Add((pathOrContainerName, fileName));
            string scaleFilter = GetScaleFilter(targetWidth, targetHeight, sourceWidth, sourceHeight);

            string ffmpegCommand = $"-i {inputVideo} {scaleFilter} -c:a copy -preset ultrafast {outputVideo}";

            using Process process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = ffmpegCommand,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.ErrorDataReceived += (sender, e) =>
            {
                if (!string.IsNullOrEmpty(e.Data))
                {
                    Console.WriteLine($"FFmpeg Error: {e.Data}");
                }
            };

            process.Start();
            process.BeginErrorReadLine();
            await process.WaitForExitAsync();

            Console.WriteLine($"Video {targetWidth}x{targetHeight} çözünürlüğüne dönüştürüldü ve kaydedildi: {outputVideo}");
        }

        static string GetScaleFilter(int targetWidth, int targetHeight, int sourceWidth, int sourceHeight)
        {
            if (sourceWidth < targetWidth || sourceHeight < targetHeight)
            {
                return "";
            }

            return $"-vf scale={targetWidth}:{targetHeight}";
        }
    }
    public static class Parallel
    {
        public static async Task ForEachAsync<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, Task> body)
        {
            var tasks = source.Select(async item =>
            {
                await body(item);
            });

            await Task.WhenAll(tasks);
        }
    }
}
