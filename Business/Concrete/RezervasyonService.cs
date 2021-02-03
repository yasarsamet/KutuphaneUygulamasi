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
    public class RezervasyonService : IRezervasyonService
    {
        private IRezervasyonDal _rezervasyon;
        private IKitapYazarDal _KitapYazar;
        private IYazarDal _Yazar;
        private IKitaplarDal _Kitaplar;
        public RezervasyonService(IKitaplarDal kitab,IRezervasyonDal rezervasyon,IKitapYazarDal kitapyazar, IYazarDal yazar)
        {
            _rezervasyon = rezervasyon;
            _Kitaplar = kitab;
            _KitapYazar = kitapyazar;
            _Yazar = yazar;
        }
        public IResult Add(Rezervasyon rezervasyon)
        {
            _rezervasyon.Add(rezervasyon);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Rezervasyon rezervasyon)
        {           
            _rezervasyon.Delete(rezervasyon);
            return new SuccessResult(Messages.Deleted);
        }
        public IDataResult<List<RezervasyonEttiklerim>> GetById(int id)
        {
            var model = from x in _rezervasyon.GetList()
                        join y in _Kitaplar.GetList() on x.KitabId equals y.Id
                        join z in _KitapYazar.GetList() on y.Id equals z.KitapId
                        join t in _Yazar.GetList() on z.YazarId equals t.id
                        where x.OgrenciId == id && x.IsDeleted!=true
                        select new RezervasyonEttiklerim
                        {
                            Id=x.Id,
                            Adi = t.Adi,
                            KitapSayfası = y.KitapSayfası,
                            KitapAdı = y.KitapAdı,
                            KitapBasımTarihi = z.KitapBasımTarihi,
                            Tarih = x.Tarih
                        };
            return new SuccessDataResult<List<RezervasyonEttiklerim>>(model.ToList());
        }
        public IDataResult<List<Rezervasyon>> GetList()
        {
            return new SuccessDataResult<List<Rezervasyon>>(_rezervasyon.GetList().ToList());
        }
        public IResult Update(int id)
        {
            var model = _rezervasyon.Get(x => x.Id == id);
            model.IsDeleted = true;
            _rezervasyon.Update(model);
            return new SuccessResult(Messages.Updated);
        }
    }
}
