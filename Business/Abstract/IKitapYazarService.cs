using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IKitapYazarService 
    {
        IDataResult<KitapYazar> GetById(int id);
        IDataResult<List<KitapYazar>> GetList();
        IResult Add(KitapYazar kitapyazar);
        IResult Delete(KitapYazar kitapyazar);
        IResult Update(KitapYazar kitapyazar);
    }
}
