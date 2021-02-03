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
    public class KitapService : IKitaplarService
    {
        private IKitaplarDal _kitablar;      
        public KitapService(IKitaplarDal kitablar)
        {
            _kitablar = kitablar;
        }
        public IResult Add(Kitaplar kitap)
        {
            _kitablar.Add(kitap);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Kitaplar kitap)
        {
            _kitablar.Delete(kitap);
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<Kitaplar> GetById(int id)
        {
            return new SuccessDataResult<Kitaplar>(_kitablar.Get(p => p.Id == id));
        }
        public IDataResult<List<Kitaplar>> GetList()
        {           
            return new SuccessDataResult<List<Kitaplar>>(_kitablar.GetList().ToList());
        }        

        public IResult Update(Kitaplar kitap)
        {
            _kitablar.Update(kitap);
            return new SuccessResult(Messages.Updated);
        }
    }
}
