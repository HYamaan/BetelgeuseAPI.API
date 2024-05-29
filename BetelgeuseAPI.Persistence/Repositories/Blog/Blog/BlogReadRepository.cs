using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BetelgeuseAPI.Application.DTOs.Response;
using BetelgeuseAPI.Application.DTOs.Response.Account;
using BetelgeuseAPI.Application.DTOs.Response.Blog;
using BetelgeuseAPI.Application.DTOs.Response.Category;
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
  
        public  IQueryable<BlogResponseDto> GetFilteredBlogs(Expression<Func<Blogs, bool>> filterExpression)
        {
            return _context.Blogs
                .Where(filterExpression)
                .OrderByDescending(blog => blog.ViewCount)
                .Select(ux => new BlogResponseDto
                {
                    Id = ux.Id,
                    Title = ux.Title,
                    Description = ux.Description,
                    Content = ux.Content,
                    BlogCategoryID = ux.BlogCategoryId,
                    BlogImage = ux.BlogImage.Path,
                    CreatedDate=ux.CreatedDate.ToString("d MMM yyyy"),
                    ViewCount = ux.ViewCount,
                    Author = new BlogAppUserDto
                    {
                        Id = ux.BlogImage.AppUser.Id,
                        UserName = ux.BlogImage.AppUser.UserName,
                        Email = ux.BlogImage.AppUser.Email,
                        slug = ux.BlogImage.AppUser.Id,
                        Image = ux.BlogImage.AppUser.UserProfileImage.Select(ux => ux.Path).FirstOrDefault()
                    },
                    BlogCategory = new GetAllCategoryResponseDto
                    {
                        CategoryID = ux.BlogCategory.Id,
                        Name = ux.BlogCategory.Name,
                        ParentCategoryID = ux.BlogCategory.ParentCategoryID,
                        ParentCategoryName = ux.BlogCategory.ParentCategory.Name
                    },
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

        public IQueryable<BlogAllResponseDto> GetBlogs(Expression<Func<Blogs, bool>> filterExpression)
        {
            return _context.Blogs
                .Where(filterExpression)
                .OrderByDescending(blog => blog.ViewCount)
                .Select(ux => new BlogAllResponseDto
                {
                    Id = ux.Id,
                    Title = ux.Title,
                    Content = ux.Content,
                    BlogCategoryId = ux.BlogCategoryId,
                    CategoryName = ux.BlogCategory.Name,
                    BlogImage = ux.BlogImage.Path,
                    CreatedDate = ux.CreatedDate.ToString("d MMM yyyy"),
                    ViewCount = ux.ViewCount,
                    ReviewCount = 0,
                    AuthorName = ux.BlogImage.AppUser.UserName
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