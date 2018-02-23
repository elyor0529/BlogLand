using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlogLand.Models;

namespace BlogLand.DAL
{
    public class BlogRepository
    {
        private readonly BlogContext _db;

        public BlogRepository()
        {
            _db = new BlogContext();
        }

        //Get all posts
        public IList<Post> Posts(int pageNo, int pageSize)
        {
            var posts = _db.Posts.Where(p => p.Published).OrderByDescending(p => p.PostedOn).Skip(pageNo * pageSize)
                .Take(pageSize).Include(p => p.Tags).Include(p => p.Category).ToList();
            return posts;
        }

        public int GetTotalPosts()
        {
            return _db.Posts.Count(p => p.Published);
        }

        //Get all post based on category

        public IList<Post> PostsOnCategory(string categoryslug, int pageNo, int pageSize)
        {
            var posts = _db.Posts.Where(p => p.Published && p.Category.UrlSlug.Equals(categoryslug))
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNo * pageSize).Take(pageSize).Include(p => p.Category).Include(p => p.Tags).ToList();
            return posts;
        }

        public int TotalPostsOnCategory(string categoryslug)
        {
            return _db.Posts.Count(p => p.Published && p.Category.UrlSlug.Equals(categoryslug));
        }

        public Category Category(string categoryslug)
        {
            return _db.Categories.FirstOrDefault(c => c.UrlSlug.Equals(categoryslug));
        }

        //return posts based on tag

        public IList<Post> PostsOnTag(string tagslug, int pageNo, int pageSize)
        {
            var posts = _db.Posts.Where(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagslug)))
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNo * pageSize).Take(pageSize).Include(p => p.Category).Include(p => p.Tags).ToList();
            return posts;
        }

        public int TotalPostsOnTag(string tagslug)
        {
            return _db.Posts.Count(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagslug)));
        }

        public Tag Tag(string tagslug)
        {
            return _db.Tags.FirstOrDefault(t => t.UrlSlug.Equals(tagslug));
        }

        // return posts based on search string

        public IList<Post> PostsOnSearch(string search, int pageNo, int pageSize)
        {
            var posts = _db.Posts.Where(p =>
                    p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) ||
                                    p.Tags.Any(t => t.Name.Equals(search))))
                .OrderByDescending(p => p.PostedOn).Skip(pageNo * pageSize).Take(pageSize).Include(p => p.Category)
                .Include(p => p.Tags).ToList();
            return posts;
        }

        public int TotalPostsOnSearch(string search)
        {
            return _db.Posts.Count(p => p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) ||
                                                        p.Tags.Any(t => t.Name.Equals(search))));
        }

        //get a post
        public Post GetPost(string slug, int year, int month)
        {
            var post = _db.Posts
                .Where(p => p.UrlSlug.Equals(slug) && p.PostedOn.Year == year && p.PostedOn.Month == month)
                .Include(p => p.Category).Include(p => p.Tags).FirstOrDefault();
            return post;
        }

        //for sidebar

        public IList<Category> Categories()
        {
            return _db.Categories.OrderBy(c => c.Name).ToList();
        }

        public IList<Tag> Tags()
        {
            return _db.Tags.OrderBy(t => t.Name).ToList();
        }
    }
}