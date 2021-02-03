    using Core.Utilities.Result;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOgrenciService
    {
        IDataResult<Ogrenci> GetById(int id);
        IDataResult<List<Ogrenci>> GetList();
        IResult Add(Ogrenci ogrenci);
        IResult Delete(Ogrenci ogrenci);
        IResult Update(Ogrenci ogrenci,int deger);
        IDataResult<Ogrenci> Login(string Email,string sifre);
        IDataResult<Ogrenci> EmailKontrol(string Email);
    }
}
