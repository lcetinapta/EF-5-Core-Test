using System;
using Microsoft.EntityFrameworkCore;

namespace EFTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var context = new BloggingContext();

            context.Blogs.Add(new Blog());
            context.SaveChanges();
        }
    }
}
