using BlogLand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace BlogLand
{
    public static class ExtensionLinks
    {

        public static MvcHtmlString PostLink (this HtmlHelper helper, Post post)
        {
            return helper.ActionLink(post.Title, "Post", "Home", new { title = post.UrlSlug, year = post.PostedOn.Year, month = post.PostedOn.Month },new { title = post.Title });
        }

        public static MvcHtmlString CategoryLink(this HtmlHelper helper, Category category)
        {
            return helper.ActionLink(category.Name, "Category", "Home",new { category = category.UrlSlug }, new { title = String.Format("See all posts on this {0} category", category.Name) } );
        }

        public static MvcHtmlString TagLink(this HtmlHelper helper, Tag tag)
        {
            return helper.ActionLink(tag.Name, "Tagy", "Home",new { tag = tag.UrlSlug }, new { title = String.Format("See all posts on this {0} tag", tag.Name) });
        }

    }
}