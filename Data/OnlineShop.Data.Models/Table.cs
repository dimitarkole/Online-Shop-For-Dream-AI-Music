using OnlineShop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Models
{
    public class Table : IAuditInfo, IDeletableEntity
    {
        public Table()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedOn = DateTime.UtcNow;
        }

        public string Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User{ get; set; }

    }
}
