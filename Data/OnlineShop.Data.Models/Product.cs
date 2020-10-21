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
            this.OrderItems = new HashSet<OrderItem>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Text { get; set; }

        public double Price { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }


        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
