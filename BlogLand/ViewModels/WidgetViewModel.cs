using BlogLand.DAL;
using BlogLand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogLand.ViewModels
{
    public class WidgetViewModel
    {
        public WidgetViewModel(BlogRepository repository)
        {
            Categories = repository.Categories();
            Tags = repository.Tags();
            Posts = repository.Posts(0, 10);
        }


        public IList<Category> Categories { get; private set; }
        public IList<Tag> Tags { get; private set; }
        public IList<Post> Posts { get; private set; }
    }
}