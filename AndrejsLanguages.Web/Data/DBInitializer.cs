using Microsoft.AspNetCore.Mvc.Rendering;
using AndrejsLanguages.Web.Models;

namespace AndrejsLanguages.Web.Data;

public static class DBInitializer
{
    public static void InitializeDatabase(LanguageDbContext LanguageContext)
    {
        if (LanguageContext.Products.Any())
            return;

        var languageType = new ProductType { Name = "Language" };
        var interpreterType = new ProductType { Name = "Interpreters" };

        var javaReview = new Review
        {
            Date = DateTime.Now,
            Text = "Java, a boilerplate-driven language designed for writing verbose, object-oriented, instant legacy code.",
            UserId = "andrej"
        };

        var javaLang = new Product
        {
            Description = "Verbose, object-oriented, instant legacy code",
            Name = "Java",
            ProductType = languageType,
            Reviews = new List<Review> { javaReview }
        };

        var goReview = new Review
        {
            Date = DateTime.Now,
            Text = "Go's mascot is the gopher. The gopher has no name. It has a jelly bean shaped body, microscopic limbs, gigantic eyes, and two teeth.",
            UserId = "andrej"
        };

        var goLang = new Product
        {
            Description = "Golang is created when waiting for C++ to compile",
            Name = "Go",
            ProductType = languageType,
            Reviews = new List<Review> { goReview }
        };

        var pythonReview = new Review
        {
            Date = DateTime.Now,
            Text = "Why did the python programmers wear glasses? Because he couldn't \"C#\" crearly.",
            UserId = "andrej"
        };

        var pythonInterpreter = new Product
        {
            Description = "Snake",
            Name = "Python",
            ProductType = interpreterType,
            Reviews = new List<Review> { pythonReview }
        };

        LanguageContext.Products.Add(javaLang);
        LanguageContext.Products.Add(goLang);
        LanguageContext.Products.Add(pythonInterpreter);

        LanguageContext.SaveChanges();
    }
}
