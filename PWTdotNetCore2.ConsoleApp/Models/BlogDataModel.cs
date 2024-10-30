using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//BlogDataModel for representing the data structure of a blog post.
//a common naming convention for a data model used in blog applications.
//can be used with Entity Framework Core, Dapper, or ADO.NET.
namespace PWTdotNetCore2.ConsoleApp.Models
{
    public class BlogDapperDataModel
    {
        public int BlogId { get; set; }

        public string BlogTitle { get; set; }

        public string BlogAuthor { get; set; }

        public string BlogContent { get; set; }

    }

    [Table("Tbl_Blog")]
    public class BlogDataModel
    {
        [Key]
        [Column("BlogId")]
        public int BlogId { get; set; }

        [Column("BlogTitle")]
        public string BlogTitle { get; set; }

        [Column("BlogAuthor")]
        public string BlogAuthor { get; set; }

        [Column("BlogContent")]
        public string BlogContent { get; set; }

        [Column("DeleteFlag")]
        public bool DeleteFlag { get; set; }

    }

}
