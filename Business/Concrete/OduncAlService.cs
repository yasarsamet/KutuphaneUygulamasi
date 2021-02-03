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
    public class OduncAlService : IOduncAlService
    {
        private IOduncAlDal _oduncal;
        private IKitaplarDal _kitapal;

        public OduncAlService(IOduncAlDal oduncal, IKitaplarDal kitapal)
        {
            _oduncal = oduncal;
            _kitapal = kitapal;
        }

        public IResult Add(OduncAl kitapal)
        {
            _oduncal.Add(kitapal);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(OduncAl kitapal)
        {
            _oduncal.Delete(kitapal);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<OduncAl> GetById(int id)
        {
            return new SuccessDataResult<OduncAl>(_oduncal.Get(p => p.id == id));
        }
        public IDataResult<List<OduncAl>> GetList()
        {
            DateTime şimdikizaman = DateTime.Now;
            //DateTime bTarih = Convert.ToDateTime(dateTimePicker1.Text);
            //DateTime kTarih = Convert.ToDateTime(dateTimePicker2.Text);
            //TimeSpan Sonuc = bTarih - kTarih;            
            return new SuccessDataResult<List<OduncAl>>(_oduncal.GetList().ToList());
        }
        public IDataResult<List<TeslimTarih>> GetTeslimTarihi()
        {
            var model = from i in _oduncal.GetList()
                        join y in _kitapal.GetList() on i.KitabId equals y.Id
                        where i.Durumu == "Teslim Edilmedi"
                        select new TeslimTarih
                        {
                            KitapAdi = y.KitapAdi,
                            BarkodNo = y.BarkodNo,
                            OduncTarihi = i.OduncTarihi,
                            OgrenciId = i.OgrenciId,
                            TeslimTarihi = i.TeslimTarihi
                        };
            return new SuccessDataResult<List<TeslimTarih>>(model.ToList());
        }

        public int Istatistik(int id)
        {
            var result = _oduncal.GetList();
            var sayi = result.Count(m => m.OgrenciId == id);
            return sayi;
        }

        public IDataResult<OduncAl> KitapDurumu(int id)
        {
            return new SuccessDataResult<OduncAl>(_oduncal.Get(p => p.id == id));
        }

        public int TeslimEtmedigimKitapSayisi(int id)
        {
            var result = _oduncal.GetList().Count(x => x.Durumu == "Teslim Etmedim" && x.id == id);
            return result;
        }

        public IResult Update(OduncAl kitapal)
        {
            _oduncal.Update(kitapal);
            //_oduncal.GetList().FirstOrDefault
            return new SuccessResult(Messages.Updated);
        }

    }
}
