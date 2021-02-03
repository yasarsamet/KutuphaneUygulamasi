using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using KütüphaneUygulaması.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.Controllers
{
    [Authorize]
    public class KitapAl : Controller
    {
        private readonly IOduncAlService _iOduncAlservice = null;
        private readonly IOgrenciService _iOgrenciservice= null;
        private readonly IKitaplarService _iKitaplarservice = null;
        private readonly IRafService _iRafservice= null;
        private readonly IYazarService _iYazarservice= null;
        private readonly IKitapYazarService _iKitapYazarservice= null;
        private readonly IRezervasyonService _iRezervasyonservice = null;
        private readonly IMapper _mapper;

        public KitapAl(IOduncAlService Kitapalservice,IKitaplarService Kitabservice,IOgrenciService Ogrenciservice, IMapper mapper,IRafService Rafservice,IYazarService YazarService,IKitapYazarService KitapYazarservice,IRezervasyonService RezervasyonService)
        {
            _iKitapYazarservice = KitapYazarservice;
            _iOduncAlservice = Kitapalservice;
            _iYazarservice = YazarService;
            _iRezervasyonservice = RezervasyonService;
            _iKitaplarservice = Kitabservice;
            _iOgrenciservice = Ogrenciservice;
           _iRafservice = Rafservice;
            _mapper = mapper;
        }
        public IActionResult Istatistik()
        {
            try
            {
                IstatistikViewModel entity = new IstatistikViewModel();
                int resultSayi = _iOduncAlservice.Istatistik(Convert.ToInt32(HttpContext.Session.GetString("loginid")));
                var resultToplamKitapSayisi = _iKitaplarservice.GetList();
                var TeslimEtmedigimKitaplar = _iOduncAlservice.TeslimEtmedigimKitapSayisi(Convert.ToInt32(HttpContext.Session.GetString("loginid")));
                if (resultToplamKitapSayisi.Success)
                {
                    if (resultSayi==0)
                    {
                        entity.AldigimToplamKitapSayisi = 0;
                    }
                    else
                    {
                        entity.AldigimToplamKitapSayisi = resultSayi;
                    }
                    if (TeslimEtmedigimKitaplar ==0)
                    {
                        entity.TeslimEtmedigimKitapSayisi = 0;
                    }
                    else
                    {
                        entity.TeslimEtmedigimKitapSayisi = TeslimEtmedigimKitaplar;
                    }
                    entity.ToplamKitapSayisi = resultToplamKitapSayisi.Data.Count();
                    return View(entity);
                }
                return View();
            }
            catch(Exception e)
            {
                return null;
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index","Ogrenci");
        }
        [HttpGet]
        public IActionResult Index()
        {
            var resultRaf = _iRafservice.GetList();
            var resultOduncAl = _iOduncAlservice.GetList();
            var resultKitap = _iKitaplarservice.GetList();
            var resultYazar = _iYazarservice.GetList();
            var resultRezervasyon = _iRezervasyonservice.GetList();
            var resultKitapYazar = _iKitapYazarservice.GetList();                     
            KitapListesiViewModel entity = new KitapListesiViewModel();         
            
            if (resultKitap.Success && resultYazar.Success && resultYazar.Success)
            {
                entity.OduncAlListesi = resultOduncAl.Data;
                entity.Yazarlistesi = resultYazar.Data;
                entity.KitapYazarListesi = resultKitapYazar.Data;
                entity.Kitaplistesi = resultKitap.Data;
                entity.RafListesi = resultRaf.Data;
                entity.RezervasyonListesi = resultRezervasyon.Data;
            }
            return View(entity);
        }                        
        [HttpGet]
        public IActionResult Kitaplarım()
        {            
            ViewBag.id = Convert.ToInt32(HttpContext.Session.GetString("loginid"));
            var resultOduncAl = _iOduncAlservice.GetList();
            var resultKitap = _iKitaplarservice.GetList();
            var resultYazar = _iYazarservice.GetList();            
            var resultKitapYazar = _iKitapYazarservice.GetList();
            if (resultOduncAl.Success && resultKitap.Success && resultYazar.Success && resultKitapYazar.Success)
            {
                KitapAldiklarimViewModel entity = new KitapAldiklarimViewModel();
                entity.Kitaplistesi = resultKitap.Data;
                entity.OduncAlListesi = resultOduncAl.Data;
                entity.Yazarlistesi = resultYazar.Data;
                entity.KitapYazarListesi = resultKitapYazar.Data;               
                return View(entity);
            }
            return View();
        }        
       public IActionResult Rezervasyon(int kitapId)
        {
            RezervasyonViewModel entity = new RezervasyonViewModel();
            entity.IsDeleted = false;
            entity.OgrenciId = Convert.ToInt32(HttpContext.Session.GetString("loginid"));
            entity.KitabId = kitapId;
            entity.RezervasyonId = 1;
            entity.Zaman = DateTime.Now;
            entity.Tarih = DateTime.Now.ToString("yyyy-MM-dd");
            Rezervasyon entityrezervasyon = new Rezervasyon();
            entityrezervasyon = _mapper.Map<Rezervasyon>(entity);
            _iRezervasyonservice.Add(entityrezervasyon);
            return RedirectToAction("Index");
        }
        public JsonResult Düzenle(int id)
        {
            var result = _iOduncAlservice.GetById(id);
            return Json(result.Data);
        }
        public IActionResult DüzenleOnayla(string newdatet, int oduncId)
        {
            try
            {
                var model = _iOduncAlservice.GetById(oduncId);
                if (model.Success)
                {
                    model.Data.TeslimTarihi = newdatet;
                    _iOduncAlservice.Update(model.Data);
                }
                return RedirectToAction("Kitaplarım");
            }catch(Exception e)
            {
                return RedirectToAction("Kitaplarım");
            }
        }

        //[ChildActionOnly]
        public IActionResult TeslimTarihiYaklasan()
        {
            var result = _iOduncAlservice.GetTeslimTarihi();
            if (result.Success)
            {                
                return PartialView("_TeslimPartialView",result.Data);
            }
            return null;
        }
        public JsonResult Raf(int id)
        {
            var model = _iRafservice.GetById(id);
            return Json(model.Data);
        }      
        public IActionResult RezervasyonEttigimKitaplar()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("loginid"));
            var result = _iRezervasyonservice.GetById(Id);
            if (result!=null)
            {
                RezervasyonEttigimKitaplarViewModel entity = new RezervasyonEttigimKitaplarViewModel();
                entity.RezervasyonKitapListesi = result.Data;
                return View(entity);
            }
            else
            {
                return null;
            }
        }
        public IActionResult RezervasyonSil(int rezervasyonid)
        {
            _iRezervasyonservice.Update(rezervasyonid);
            return RedirectToAction("RezervasyonEttigimKitaplar");
        }

    }
}

