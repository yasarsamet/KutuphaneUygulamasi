using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IYazarService
    {
        IDataResult<Yazar> GetById(int id);
        IDataResult<List<Yazar>> GetList();
        IResult Add(Yazar yazar);
        IResult Delete(Yazar yazar);
        IResult Update(Yazar yazar);
    }
}
