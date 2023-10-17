using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public Category GetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetList();
        }

        public void TAdd(Category p)
        {
            _categoryDal.Add(p);
        }

        public void TDelete(Category p)
        {
            _categoryDal.Delete(p);
        }

        public void TUpdate(Category p)
        {
            _categoryDal.Update(p);
        }
    }
}
