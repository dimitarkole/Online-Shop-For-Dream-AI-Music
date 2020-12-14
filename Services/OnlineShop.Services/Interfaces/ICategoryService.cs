namespace OnlineShop.Services.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using OnlineShop.Web.ViewModels.CategoriesModel;

    public interface ICategoryService
    {
        IList<T> All<T>();

        T GetById<T>(string id);

        Task<string> Create(CategoryCreateInputModel model);

        Task Update(string id, CategoryEditInputModel model);

        Task Delete(string id);
    }
}
