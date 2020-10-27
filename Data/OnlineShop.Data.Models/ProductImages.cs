namespace OnlineShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using OnlineShop.Data.Common.Models;

    public class ProductImages : IAuditInfo, IDeletableEntity
    {
        public ProductImages()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string FullImageName { get; set; }

        public int Position { get; set; }

        public Product Product { get; set; }

        public string ProductId { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
