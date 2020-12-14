using OnlineShop.Data;
using OnlineShop.Services.Interfaces;
using OnlineShop.Web.ViewModels.CategoriesModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineShop.Services.Mapping;
using System.Linq;
using OnlineShop.Data.Models;

namespace OnlineShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<T> All<T>()
             => this.context.Categories
                .OrderBy(c => c.Name)
                .To<T>()
                .ToList();

        public async Task<string> Create(CategoryCreateInputModel model)
        {
            var category = model.To<Category>();
            await this.context.Categories.AddAsync(category);
            await this.context.SaveChangesAsync();

            return category.Id;
        }

        public async Task Delete(string id)
        {
            var category = this.context.Categories.Find(id);
            this.context.Categories.Remove(category);
            await this.context.SaveChangesAsync();
        }

        public T GetById<T>(string id)
            => this.context.Categories
                .Where(c => c.Id == id)
                .To<T>()
                .FirstOrDefault();

        public async Task Update(string id, CategoryEditInputModel model)
        {
            var category = this.context.Categories.Find(id);

            model.To<Category>(category);

            this.context.Categories.Update(category);
            await this.context.SaveChangesAsync();
        }
    }
}
