using AutoMapper;
using Business.Abstract;
using KütüphaneUygulaması.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.ViewComponents
{
    public class TeslimTarihiYaklasan:ViewComponent
    {
        private readonly IOduncAlService _service= null;        
        public TeslimTarihiYaklasan(IOduncAlService Kitapalservice)
        {
            _service = Kitapalservice;            
        }
        public IViewComponentResult Invoke()
        {                        
            var result = _service.GetTeslimTarihi();
            TeslimTarihiAlertViewModel entity = new TeslimTarihiAlertViewModel();
            if (result.Success)
            {
                entity.TeslimTarihiYaklasan = result.Data;
            }
            return View(entity);
        }
    }
}
