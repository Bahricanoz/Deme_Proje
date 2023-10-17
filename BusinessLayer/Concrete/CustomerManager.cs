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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public Customer GetById(int id)
        {
            return _customerDal.GetById(id);
        }

        public List<Customer> GetCustomerListWithJob()
        {
            return _customerDal.GetCustomerWithJob();
        }

        public List<Customer> GetList()
        {
            return _customerDal.GetList();
        }

        public void TAdd(Customer p)
        {
            _customerDal.Add(p);
        }

        public void TDelete(Customer p)
        {
            _customerDal.Delete(p);
        }

        public void TUpdate(Customer p)
        {
            _customerDal.Update(p);
        }
    }
}
