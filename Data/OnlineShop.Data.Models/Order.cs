using OnlineShop.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Data.Models
{
    public class Order : IAuditInfo, IDeletableEntity
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
            this.OrderProducts = new HashSet<OrderProduct>();
        }

        public string Id { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }

        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
