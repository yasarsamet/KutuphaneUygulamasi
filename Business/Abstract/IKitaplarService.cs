using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IKitaplarService
    {
        IDataResult<Kitaplar> GetById(int id);
        IDataResult<List<Kitaplar>> GetList();        
        IResult Add(Kitaplar kitap);    
        IResult Delete(Kitaplar kitap);
        IResult Update(Kitaplar kitap);


    }
}
