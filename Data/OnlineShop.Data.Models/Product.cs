namespace OnlineShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using OnlineShop.Data.Common.Models;

    public class Product : IAuditInfo, IDeletableEntity
    {
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderProducts = new HashSet<OrderProduct>();
            this.ProductImages = new HashSet<ProductImages>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public double Price { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        public virtual ICollection<ProductImages> ProductImages { get; set; }

        public virtual Category Category { get; set; }

        public string CategoryId { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
