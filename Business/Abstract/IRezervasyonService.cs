using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRezervasyonService
    {
        IDataResult<List<RezervasyonEttiklerim>> GetById(int id);
        IDataResult<List<Rezervasyon>> GetList();
        IResult Add(Rezervasyon rezervasyon);
        IResult Delete(Rezervasyon rezervasyon);
        IResult Update(int id);
    }
}
