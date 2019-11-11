using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDevelopment.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
    public class Product
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public String Description { get; set; }
    }
    public class Request
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public String Name { get; set; }
        public String Description { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}