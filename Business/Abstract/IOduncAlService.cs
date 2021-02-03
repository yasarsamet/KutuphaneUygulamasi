using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOduncAlService
    {

        IDataResult<OduncAl> GetById(int id);
        IDataResult<List<OduncAl>> GetList();
        IResult Add(OduncAl kitapal);
        IResult Delete(OduncAl kitapal);
        IResult Update(OduncAl kitapal);
        IDataResult<OduncAl> KitapDurumu(int id);

        int Istatistik(int id);

        IDataResult<List<TeslimTarih>> GetTeslimTarihi();
        int TeslimEtmedigimKitapSayisi(int metin);

    }
}
