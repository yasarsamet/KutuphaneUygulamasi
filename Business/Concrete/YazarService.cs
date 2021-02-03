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
    public class YazarService : IYazarService
    {
        private IYazarDal _yazar;
        public YazarService(IYazarDal yazar)
        {
            _yazar = yazar;
        }
        public IResult Add(Yazar yazar)
        {
            _yazar.Add(yazar);
            return new SuccessResult(Messages.Added);
        }
 
        public IResult Delete(Yazar yazar)
        {
            _yazar.Delete(yazar);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Yazar> GetById(int id)
        {
            return new SuccessDataResult<Yazar>(_yazar.Get(p => p.id == id));
        }

        public IDataResult<List<Yazar>> GetList()
        {
            return new SuccessDataResult<List<Yazar>>(_yazar.GetList().ToList());
        }

        public IResult Update(Yazar yazar)
        {
            _yazar.Update(yazar);
            return new SuccessResult(Messages.Updated);
        }
    }
}
