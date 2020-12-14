namespace OnlineShop.Web.ViewModels.CategoriesModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    using OnlineShop.Data.Models;
    using OnlineShop.Services.Mapping;

    public class CategoryCreateInputModel : IMapTo<Category>
    {
        [Required]
        public string Name { get; set; }
    }
}
