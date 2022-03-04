using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Northwind.Core.Domain.Entities
{
    public class Products : IEntity
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        [Required (ErrorMessage ="Product Name can not be null or empty")]
        public string ProductName { get; set; }
        public int? SupplierId { get; set; }
        public int? CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public Categories Category { get; set; }
        public Suppliers Supplier { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
       // public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int Id { get; set; } = 1;
    }
}
