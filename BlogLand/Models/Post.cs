using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogLand.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string UrlSlug { get; set; }
        public string Meta { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public DateTime? Modified { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public virtual IList<Tag> Tags { get; set; }
    }
}