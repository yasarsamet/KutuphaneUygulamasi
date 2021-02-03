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

        private IOgrenciDal _ogrencıdal;
        public OgrenciService(IOgrenciDal ogrencıdal)
        {
            _ogrencıdal = ogrencıdal;
        }
        public IResult Add(Ogrenci ogrenci)
        {
            ogrenci.Sifre = BCrypt.Net.BCrypt.HashPassword(ogrenci.Sifre);            
            _ogrencıdal.Add(ogrenci);
            return new SuccessResult(Messages.Added);
        }
        public IResult Delete(Ogrenci ogrenci)
        {
            _ogrencıdal.Delete(ogrenci);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Ogrenci> EmailKontrol(string Email)
        {
            return new SuccessDataResult<Ogrenci>(_ogrencıdal.Get(p=>p.Email == Email));
        }

        public IDataResult<Ogrenci> GetById(int id)
        {

            return new SuccessDataResult<Ogrenci>(_ogrencıdal.Get(p => p.Id == id));
        }
        public IDataResult<List<Ogrenci>> GetList()
        {
            return new SuccessDataResult<List<Ogrenci>>(_ogrencıdal.GetList().ToList());
        }

        public IDataResult<Ogrenci> Login(string Email, string sifre)
        {
            var result = _ogrencıdal.Get(m => m.Email == Email);
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
                _ogrencıdal.Update(ogrenci);
                return new SuccessResult(Messages.Updated);
            }
            else
            { 
                // kendini doğrulama kısımı için
                _ogrencıdal.Update(ogrenci);
                return new SuccessResult(Messages.Updated);
            }
            
        }
    }
}
