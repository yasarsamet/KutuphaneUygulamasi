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

        private IRafDal _irafdal;
        public RafService(IRafDal rafdal)
        {
            _irafdal = rafdal;
        }
        public IResult Add(Raf raf)
        {
            _irafdal.Add(raf);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(Raf raf)
        {
            _irafdal.Delete(raf);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Raf> GetById(int id)
        {
            return new SuccessDataResult<Raf>(_irafdal.Get(p => p.Id == id));
        }

        public IDataResult<List<Raf>> GetList()
        {
            return new SuccessDataResult<List<Raf>>(_irafdal.GetList().ToList());
        }

        public IResult Update(Raf Raf)
        {
            _irafdal.Update(Raf);
            return new SuccessResult(Messages.Updated);
        }
    }
}
