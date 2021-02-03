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
    public class KitapYazarService : IKitapYazarService
    {
        private IKitapYazarDal _kitapyazar;
        public KitapYazarService(IKitapYazarDal kitapyazar)
        {
            _kitapyazar= kitapyazar;
        }
        public IResult Add(KitapYazar kitapyazar)
        {
            _kitapyazar.Add(kitapyazar);
            return new SuccessResult(Messages.Added);            
        }

        public IResult Delete(KitapYazar kitapyazar)
        {
            _kitapyazar.Delete(kitapyazar);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<KitapYazar> GetById(int id)
        {
            return new SuccessDataResult<KitapYazar>(_kitapyazar.Get(p => p.Id == id));
        }

        public IDataResult<List<KitapYazar>> GetList()
        {
            return new SuccessDataResult<List<KitapYazar>>(_kitapyazar.GetList().ToList());
        }

        public IResult Update(KitapYazar kitapyazar)
        {
            _kitapyazar.Update(kitapyazar);
            return new SuccessResult(Messages.Updated);
        }
    }
}
