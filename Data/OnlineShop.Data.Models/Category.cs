namespace OnlineShop.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using OnlineShop.Data.Common.Models;

    public class Category : IAuditInfo, IDeletableEntity
    {
        public Category()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ChidrenCategories = new HashSet<Category>();
            this.Products = new HashSet<Product>();
            this.Tables = new HashSet<Table>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string FullImageName { get; set; }

        public Category ParentCategory { get; set; }

        public string ParentCategoryId { get; set; }

        public virtual ICollection<Category> ChidrenCategories { get; set; }

        public virtual ICollection<Table> Tables { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
