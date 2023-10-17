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
    //Constructor Method (Yapıcı Metod) : Bulunduğu sınıf ile aynı adı alan metoddur
    // İşlevi: Bulunduğu sınıftan bir nesnesi oluşturmak , nesne üzerindeki başlangıç ayarlarmalarını yapmaktır
    // bir sınıfın bağımlılığı nedir : hazır yazılmış başka sınıfları kendi kodunuz içinde kullandığınızdan, kullandığınız bu diğer sınıflara da dependency denir.
    // eger biz projemizde constructor metod kullanmazsak hata alırız 
    //biri constructor enjeksiyonunu kullanarak bağımlılıkları (IAboutDal) enjekte ederken, diğeri bunu yapmamış gibi görünüyor. Constructor enjeksiyonu, bağımlılıkları sınıfın kurucu yöntemi aracılığıyla enjekte ederek sınıfın dış bağımlılıklarını ayarlayan bir enjeksiyon yöntemidir.
    public class ProductManager : IProductService
    {
        IProductDal _productdal;

        public ProductManager(IProductDal productdal)
        {
            _productdal = productdal;
        }

        public Product GetById(int id)
        {
            return _productdal.GetById(id);
        }

        public List<Product> GetList()
        {
            return _productdal.GetList();
        }

        public void TAdd(Product p)
        {
            _productdal.Add(p);
        }

        public void TDelete(Product p)
        {
            _productdal.Delete(p);
        }

        public void TUpdate(Product p)
        {
            _productdal.Update(p);
        }
    }
}
