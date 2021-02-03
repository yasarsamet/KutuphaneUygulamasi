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
        private IOdüncAlDal _ödüncal;
        private IKitaplarDal _kitapal;

        public OduncAlService(IOdüncAlDal ödüncal, IKitaplarDal kitapal)
        {
            _ödüncal = ödüncal;
            _kitapal = kitapal;
        }

        public IResult Add(OduncAl kitapal)
        {
            _ödüncal.Add(kitapal);
            return new SuccessResult(Messages.Added);
        }

        public IResult Delete(OduncAl kitapal)
        {
            _ödüncal.Delete(kitapal);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<OduncAl> GetById(int id)
        {
            return new SuccessDataResult<OduncAl>(_ödüncal.Get(p => p.id == id));
        }
        public IDataResult<List<OduncAl>> GetList()
        {
            DateTime şimdikizaman = DateTime.Now;
            //DateTime bTarih = Convert.ToDateTime(dateTimePicker1.Text);
            //DateTime kTarih = Convert.ToDateTime(dateTimePicker2.Text);
            //TimeSpan Sonuc = bTarih - kTarih;            
            return new SuccessDataResult<List<OduncAl>>(_ödüncal.GetList().ToList());
        }
        public IDataResult<List<TeslimTarih>> GetTeslimTarihi()
        {
            var model = from i in _ödüncal.GetList()
                        join y in _kitapal.GetList() on i.KitabId equals y.Id
                        where i.Durumu == "Teslim Edilmedi"
                        select new TeslimTarih
                        {
                            KitapAdı = y.KitapAdı,
                            BarkodNo = y.BarkodNo,
                            OdüncTarihi = i.OdüncTarihi,
                            OgrenciId = i.OgrenciId,
                            TeslimTarihi = i.TeslimTarihi
                        };
            return new SuccessDataResult<List<TeslimTarih>>(model.ToList());
        }

        public int Istatistik(int id)
        {
            var result = _ödüncal.GetList();
            var sayı = result.Count(m => m.OgrenciId == id);
            return sayı;
        }

        public IDataResult<OduncAl> KitapDurumu(int id)
        {
            return new SuccessDataResult<OduncAl>(_ödüncal.Get(p => p.id == id));
        }

        public int TeslimEtmedigimKitapSayısı(int id)
        {
            var result = _ödüncal.GetList().Count(x => x.Durumu == "Teslim Etmedim" && x.id == id);
            return result;
        }

        public IResult Update(OduncAl kitapal)
        {
            _ödüncal.Update(kitapal);
            //_ödüncal.GetList().FirstOrDefault
            return new SuccessResult(Messages.Updated);
        }

    }
}
