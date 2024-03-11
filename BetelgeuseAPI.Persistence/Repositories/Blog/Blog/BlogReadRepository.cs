using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BetelgeuseAPI.Application.DTOs.Response;
using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Application.Repositories.Blog.CreateBlog;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Repositories.Blog.CreateBlog
{
    public class BlogReadRepository : ReadRepository<IdentityContext, Blogs>, IBlogReadRepository
    {
        private readonly IdentityContext _context;

        public BlogReadRepository(IdentityContext context) : base(context)
        {
            _context = context;
        }
  
        public  IQueryable<BlogResponseDto> GetFilteredBlogsAsync(Expression<Func<Blogs, bool>> filterExpression)
        {
            return _context.Blogs
                .Where(filterExpression)
                .Select(ux => new BlogResponseDto
                {
                    Id = ux.Id,
                    Title = ux.Title,
                    Description = ux.Description,
                    Content = ux.Content,
                    BlogCategoriesID = ux.BlogCategoriesID,
                    Image = ux.BlogImage.Path,
                    userEmailAddress = ux.BlogImage.AppUser.Email,
                    userName = ux.BlogImage.AppUser.UserName,
                    MetaData = new MetaDataResponseDto
                    {
                        ShortDescription = ux.MetaData.ShortDescription,
                        MetaTitle = ux.MetaData.MetaTitle,
                        MetaDescription = ux.MetaData.MetaDescription,
                        MetaKeywords = ux.MetaData.MetaKeywords,
                        Url = ux.MetaData.Url,
                    }
                });
        }
        public async Task<string> BlogUrlControl(string url)
        {
            var existingBlog = await _context.Blogs.Where(ux => ux.MetaData.Url == url).FirstOrDefaultAsync();
            if (existingBlog != null)
            {
                int counter = 1;
                string originalUrl = url;
                while (existingBlog != null)
                {
                    url = $"{originalUrl}-{counter}";
                    existingBlog = await _context.Blogs.Where(ux => ux.MetaData.Url == url).FirstOrDefaultAsync();
                    counter++;
                }
            }
            return url;
        }
    }
}