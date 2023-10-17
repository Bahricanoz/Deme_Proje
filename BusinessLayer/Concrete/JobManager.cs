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
    public class JobManager : IJobsService
    {
        IJobDal _jobDal;

        public JobManager(IJobDal jobDal)
        {
            _jobDal = jobDal;
        }

        public Job GetById(int id)
        {
            return _jobDal.GetById(id);
        }

        public List<Job> GetList()
        {
            return _jobDal.GetList();
        }

        public void TAdd(Job p)
        {
            _jobDal.Add(p);
        }

        public void TDelete(Job p)
        {
            _jobDal.Delete(p);
        }

        public void TUpdate(Job p)
        {
            _jobDal.Update(p);
        }
    }
}
