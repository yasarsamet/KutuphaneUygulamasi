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
        private readonly IOduncAlService _ıOduncAlservice = null;
        private readonly IOgrenciService _ıOgrenciservice= null;
        private readonly IKitaplarService _ıKitaplarservice = null;
        private readonly IRafService _ıRafservice= null;
        private readonly IYazarService _ıYazarservice= null;
        private readonly IKitapYazarService _ıKitapYazarservice= null;
        private readonly IRezervasyonService _ıRezervasyonservice = null;
        private readonly IMapper _mapper;

        public KitapAl(IOduncAlService Kitapalservice,IKitaplarService Kitabservice,IOgrenciService Ogrenciservice, IMapper mapper,IRafService Rafservice,IYazarService YazarService,IKitapYazarService KitapYazarservice,IRezervasyonService RezervasyonService)
        {
            _ıKitapYazarservice = KitapYazarservice;
            _ıOduncAlservice = Kitapalservice;
            _ıYazarservice = YazarService;
            _ıRezervasyonservice = RezervasyonService;
            _ıKitaplarservice = Kitabservice;
            _ıOgrenciservice = Ogrenciservice;
           _ıRafservice = Rafservice;
            _mapper = mapper;
        }
        public IActionResult Istatistik()
        {
            try
            {
                IstatistikViewModel entity = new IstatistikViewModel();
                int resultSayı = _ıOduncAlservice.Istatistik(Convert.ToInt32(HttpContext.Session.GetString("loginid")));
                var resultToplamKitapSayisi = _ıKitaplarservice.GetList();
                var TeslimEtmediğimKitaplar = _ıOduncAlservice.TeslimEtmedigimKitapSayısı(Convert.ToInt32(HttpContext.Session.GetString("loginid")));
                if (resultToplamKitapSayisi.Success)
                {
                    if (resultSayı==0)
                    {
                        entity.AldigimToplamKitapSayisi = 0;
                    }
                    else
                    {
                        entity.AldigimToplamKitapSayisi = resultSayı;
                    }
                    if (TeslimEtmediğimKitaplar ==0)
                    {
                        entity.TeslimEtmedigimKitapSayisi = 0;
                    }
                    else
                    {
                        entity.TeslimEtmedigimKitapSayisi = TeslimEtmediğimKitaplar;
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
            var resultRaf = _ıRafservice.GetList();
            var resultOdüncAl = _ıOduncAlservice.GetList();
            var resultKitap = _ıKitaplarservice.GetList();
            var resultYazar = _ıYazarservice.GetList();
            var resultRezervasyon = _ıRezervasyonservice.GetList();
            var resultKitapYazar = _ıKitapYazarservice.GetList();                     
            KitapListesiViewModel entity = new KitapListesiViewModel();         
            
            if (resultKitap.Success && resultYazar.Success && resultYazar.Success)
            {
                entity.OdüncAlListesi = resultOdüncAl.Data;
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
            var resultOdüncAl = _ıOduncAlservice.GetList();
            var resultKitap = _ıKitaplarservice.GetList();
            var resultYazar = _ıYazarservice.GetList();            
            var resultKitapYazar = _ıKitapYazarservice.GetList();
            if (resultOdüncAl.Success && resultKitap.Success && resultYazar.Success && resultKitapYazar.Success)
            {
                KitapAldıklarımViewModel entity = new KitapAldıklarımViewModel();
                entity.Kitaplistesi = resultKitap.Data;
                entity.OdüncAlListesi = resultOdüncAl.Data;
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
            _ıRezervasyonservice.Add(entityrezervasyon);
            return RedirectToAction("Index");
        }
        public JsonResult Düzenle(int id)
        {
            var result = _ıOduncAlservice.GetById(id);
            return Json(result.Data);
        }
        public IActionResult DüzenleOnayla(string newdatet, int oduncId)
        {
            try
            {
                var model = _ıOduncAlservice.GetById(oduncId);
                if (model.Success)
                {
                    model.Data.TeslimTarihi = newdatet;
                    _ıOduncAlservice.Update(model.Data);
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
            var result = _ıOduncAlservice.GetTeslimTarihi();
            if (result.Success)
            {                
                return PartialView("_TeslimPartialView",result.Data);
            }
            return null;
        }
        public JsonResult Raf(int id)
        {
            var model = _ıRafservice.GetById(id);
            return Json(model.Data);
        }      
        public IActionResult RezervasyonEttigimKitaplar()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("loginid"));
            var result = _ıRezervasyonservice.GetById(Id);
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
            _ıRezervasyonservice.Update(rezervasyonid);
            return RedirectToAction("RezervasyonEttigimKitaplar");
        }

    }
}

