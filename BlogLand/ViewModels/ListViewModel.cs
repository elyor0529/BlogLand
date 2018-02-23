using BlogLand.DAL;
using BlogLand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogLand.ViewModels
{
    public class ListViewModel
    {
        public ListViewModel(BlogRepository repository, int p)
        {
            Posts = repository.Posts(p - 1, 10);
            TotalPosts = repository.GetTotalPosts();
        }
        public ListViewModel(BlogRepository repository, int p, string text, string type)
        {
            switch (type)
            {
                case "Category":
                    Posts = repository.PostsOnCategory(text, p - 1, 10);
                    TotalPosts = repository.TotalPostsOnCategory(text);
                    Category = repository.Category(text);
                    break;
                case "Search":
                    Posts = repository.PostsOnSearch(text, p - 1, 10);
                    TotalPosts = repository.TotalPostsOnSearch(text);
                    Search = text;
                    break;
                default:
                    Posts = repository.PostsOnTag(text, p - 1, 10);
                    TotalPosts = repository.TotalPostsOnTag(text);
                    Tag = repository.Tag(text);
                    break;
            }
        }

        public IList<Post> Posts { get; private set; }
        public int TotalPosts { get; private set; }
        public Category Category { get; private set; }
        public Tag Tag { get; private set; }
        public string Search { get; private set; }
    }
}