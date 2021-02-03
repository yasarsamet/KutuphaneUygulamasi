using Business.Abstract;
using Business.Contants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RafService : IRafService
    {

        private IRafDal _ırafdal;
        public RafService(IRafDal ırafdal)
        {
            _ırafdal = ırafdal;
        }
        public IResult Add(Raf raf)
        {
            _ırafdal.Add(raf);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Raf raf)
        {
            _ırafdal.Delete(raf);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Raf> GetById(int id)
        {
            return new SuccessDataResult<Raf>(_ırafdal.Get(p => p.Id == id));
        }

        public IDataResult<List<Raf>> GetList()
        {
            return new SuccessDataResult<List<Raf>>(_ırafdal.GetList().ToList());
        }

        public IResult Update(Raf Raf)
        {
            _ırafdal.Update(Raf);
            return new SuccessResult(Messages.Updated);
        }
    }
}
