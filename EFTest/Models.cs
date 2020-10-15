using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace EFTest
{
    public interface IValueObject
    {

    }
    public interface IEntityBase
    {
        public int Id { get; set; }
    }

    public class Blog: IEntityBase
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public Author Author { get; set; }
        public List<Post> Posts { get; } = new List<Post>();
    }

    public class Author:IEntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<Address> PrimaryAddress { get; set; }
    }

    [Owned]
    public class Address: IValueObject
    {
        public string City { get; set; }
        public string PostNo { get; set; }
    }

    public class Post:IEntityBase
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public Blog Blog { get; set; }
    }

}
