using Business.Abstract;
using Business.Contants;
using Core.Utilities.Result;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class OgrenciService : IOgrenciService
    {

        private IOgrenciDal _ogrencidal;
        public OgrenciService(IOgrenciDal ogrencidal)
        {
            _ogrencidal = ogrencidal;
        }
        public IResult Add(Ogrenci ogrenci)
        {
            ogrenci.Sifre = BCrypt.Net.BCrypt.HashPassword(ogrenci.Sifre);            
            _ogrencidal.Add(ogrenci);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Ogrenci ogrenci)
        {
            _ogrencidal.Delete(ogrenci);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Ogrenci> EmailKontrol(string Email)
        {
            return new SuccessDataResult<Ogrenci>(_ogrencidal.Get(p=>p.Email == Email));
        }

        public IDataResult<Ogrenci> GetById(int id)
        {

            return new SuccessDataResult<Ogrenci>(_ogrencidal.Get(p => p.Id == id));
        }
        public IDataResult<List<Ogrenci>> GetList()
        {
            return new SuccessDataResult<List<Ogrenci>>(_ogrencidal.GetList().ToList());
        }

        public IDataResult<Ogrenci> Login(string Email, string sifre)
        {
            var result = _ogrencidal.Get(m => m.Email == Email);
            if (result !=null)
            {               
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(sifre, result.Sifre);
                if (isValidPassword && result != null)
                {
                    return new SuccessDataResult<Ogrenci>(result);
                }
            }                        
            return null;
            
        }

        public IResult Update(Ogrenci ogrenci,int deger)
        {
            if (deger == 1)
            {
                ogrenci.Sifre = BCrypt.Net.BCrypt.HashPassword(ogrenci.Sifre);
                _ogrencidal.Update(ogrenci);
                return new SuccessResult(Messages.Updated);
            }
            else
            { 
                // kendini doğrulama kısımı için
                _ogrencidal.Update(ogrenci);
                return new SuccessResult(Messages.Updated);
            }
            
        }
    }
}
