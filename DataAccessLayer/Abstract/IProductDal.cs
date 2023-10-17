using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    // Abstractlar bizim soyut ifadelerimizin olduğu klasördür abstart klasörü içinde interfaceleri tanımlarız
    // İnterfaceler imzamız gibi düşünebiliriz bunların içini sınıflarda doludurucaz
    public interface IProductDal : IGenericDal<Product>
    {
        
    }
}
