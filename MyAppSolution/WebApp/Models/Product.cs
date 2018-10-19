using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public decimal Price { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
