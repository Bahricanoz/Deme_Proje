using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        public List<Customer> GetCustomerWithJob()
        {
            using (var c = new Context()) //  Bu satırda, bir Context adlı sınıfın bir örneği oluşturuluyor. Bu sınıf, veritabanı işlemlerini yönetmek için kullanılır. 
            {
                return c.customers.Include(x => x.Job).ToList();
                //Include methodu : verilerin ilişkili tabloları da yüklemesini istediğimizde kullanılır.
            }
        }
    }
}
