using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRafService
    {
        IDataResult<Raf> GetById(int id);
        IDataResult<List<Raf>> GetList();
        IResult Add(Raf raf);
        IResult Delete(Raf raf);
        IResult Update(Raf Raf);
    }
}
