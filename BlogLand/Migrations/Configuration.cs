namespace BlogLand.Migrations
{
    using DAL;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlogLand.DAL.BlogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BlogLand.DAL.BlogContext context)
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Programming", Description = "This category repsresent0s programming topics",
                    UrlSlug = "programming"
                },
                new Category
                {
                    Name = "Business", Description = "This category repsresents business topics",
                    UrlSlug = "business"
                },
                new Category
                {
                    Name = "Finance", Description = "This category repsresents finance topics",
                    UrlSlug = "finance"
                }
            };
            categories.ForEach(c => context.Categories.AddOrUpdate(p => p.Name, c));
            context.SaveChanges();
            var posts = new List<Post>
            {
                //Programming posts
                new Post
                {
                    Title = "Java Script", UrlSlug = "java_script", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2005-10-03 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Programming").Single().ID,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    Title = "C# programming", UrlSlug = "c_sharp_programming", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2010-03-05 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Programming").Single().ID,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    Title = "Database Regulation", UrlSlug = "database_regulation", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2002-10-03 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Programming").Single().ID,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    Title = "Python Language", UrlSlug = "python_language", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2005-03-03 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Programming").Single().ID,
                    Tags = new List<Tag>()
                },
                //Business posts
                new Post
                {
                    Title = "Business opportunities", UrlSlug = "business_opportunities", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2002-03-03 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Business").Single().ID,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    Title = "Business Chances", UrlSlug = "business_chances", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2010-03-01 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Business").Single().ID,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    Title = "Business Future", UrlSlug = "business_future", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2002-02-03 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Business").Single().ID,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    Title = "Business Megapolises", UrlSlug = "business_megapolises", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2002-10-03 15:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Business").Single().ID,
                    Tags = new List<Tag>()
                },
                //Finance posts

                 new Post
                {
                    Title = "Finance opportunities", UrlSlug = "finance_opportunities", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2001-03-03 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Finance").Single().ID,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    Title = "Finance Chances", UrlSlug = "finance_chances", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2015-03-01 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Finance").Single().ID,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    Title = "Finance Future", UrlSlug = "finance_future", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2002-04-04 18:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Finance").Single().ID,
                    Tags = new List<Tag>()
                },
                new Post
                {
                    Title = "Finance Megapolises", UrlSlug = "finance_megapolises", Description = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages. The purpose of programming is to find a sequence of instructions that will automate performing a specific task or solving a given problem. The process of programming thus often requires expertise in many different subjects, including knowledge of the application domain, specialized algorithms, and formal logic. " +
                    "Related tasks include testing, debugging, and maintaining the source code, implementation of the build system, and management of derived artifacts such as machine code of computer programs. These might be considered part of the programming process, but often the term software development is used for this larger process with the term programming, implementation, or coding reserved for the actual writing of source code.Software engineering combines engineering techniques with software development practices.",
                    ShortDescription = "Computer programming (often shortened to programming) is a process that leads from an original formulation of a computing problem to executable computer programs. Programming involves activities such as analysis, developing understanding, generating algorithms, verification of requirements of algorithms including their correctness and resources consumption, and implementation (commonly referred to as coding[1][2]) of algorithms in a target programming language. Source code is written in one or more programming languages.",
                    PostedOn = DateTime.Parse("2002-10-05 15:57:56.673"), CategoryID = context.Categories.Where(c => c.Name == "Finance").Single().ID,
                    Tags = new List<Tag>()
                },

            };
            posts.ForEach(s => context.Posts.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var tags = new List<Tag>
            {
                new Tag
                {
                    Name = "C#", UrlSlug = "c_sharp", Description = "programming language"
                },
                  new Tag
                {
                    Name = "Java Script", UrlSlug = "java_script", Description = "programming language"
                },
                    new Tag
                {
                    Name = "Html", UrlSlug = "html", Description = "programming language"
                },
                      new Tag
                {
                    Name = "Management", UrlSlug = "management", Description = "Business field"
                },
                      new Tag
                {
                    Name = "Marketing", UrlSlug = "marketing", Description = "Business field"
                },
                      new Tag
                {
                    Name = "StartUp", UrlSlug = "startup", Description = "Business field"
                },
                      new Tag
                {
                    Name = "Investment", UrlSlug = "investment", Description = "Financial field"
                },
                      new Tag
                {
                    Name = "Banks", UrlSlug = "banks", Description = "Finance field"
                },
                      new Tag
                {
                    Name = "Speculation", UrlSlug = "speculation", Description = "Finance field"
                },
                      new Tag
                {
                    Name = "Wall Street", UrlSlug = "wall_street", Description = "Finance field"
                },
            };
            tags.ForEach(s => context.Tags.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            AddOrUpdateTag(context, "Finance Megapolises", "Banks");
            AddOrUpdateTag(context, "Finance Future", "Speculation");
            AddOrUpdateTag(context, "Finance Chances", "Wall Street");
            AddOrUpdateTag(context, "Business Megapolises", "StartUp");
            AddOrUpdateTag(context, "Business Future", "Marketing");
            AddOrUpdateTag(context, "Python Language", "Java Script");
            AddOrUpdateTag(context, "C# programming", "C#");
            AddOrUpdateTag(context, "Database Regulation", "Html");
            context.SaveChanges();
        }

        void AddOrUpdateTag(BlogContext context, string postTitle, string tagName)
        {
            var ps = context.Posts.SingleOrDefault(p => p.Title == postTitle);
            var tg = ps.Tags.SingleOrDefault(i => i.Name == tagName);
            if (tg == null)
                ps.Tags.Add(context.Tags.Single(i =>
                i.Name == tagName));
        }
    }
}
