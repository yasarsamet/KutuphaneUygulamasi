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
        private readonly IOduncAlService _iOdüncalservice = null;
        private readonly IOgrenciService _iOgrenciservice= null;
        private readonly IKitaplarService _iKitablarservice = null;
        private readonly IRafService _ıRafservice= null;
        private readonly IYazarService _iYazarservice= null;
        private readonly IKitapYazarService _iKitapYazarservice= null;
        private readonly IRezervasyonService _iRezervasyonservice = null;
        private readonly IMapper _mapper;
        public KitapAl(IOduncAlService Kitapalservice,IKitaplarService Kitabservice,IOgrenciService Ogrenciservice, IMapper mapper,IRafService Rafservice,IYazarService YazarService,IKitapYazarService KitapYazarservice,IRezervasyonService RezervasyonService)
        {
            _iKitapYazarservice = KitapYazarservice;
            _iOdüncalservice = Kitapalservice;
            _iYazarservice = YazarService;
            _iRezervasyonservice = RezervasyonService;
            _iKitablarservice = Kitabservice;
            _iOgrenciservice = Ogrenciservice;
           _ıRafservice = Rafservice;
            _mapper = mapper;
        }
        public IActionResult Istatistik()
        {
            try
            {
                IstatistikViewModel entity = new IstatistikViewModel();
                int resultSayı = _iOdüncalservice.Istatistik(Convert.ToInt32(HttpContext.Session.GetString("loginid")));
                var resultToplamKitapSayisi = _iKitablarservice.GetList();
                var TeslimEtmediğimKitaplar = _iOdüncalservice.TeslimEtmedigimKitapSayısı(Convert.ToInt32(HttpContext.Session.GetString("loginid")));
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
            var resultOdüncAl = _iOdüncalservice.GetList();
            var resultKitap = _iKitablarservice.GetList();
            var resultYazar = _iYazarservice.GetList();
            var resultRezervasyon = _iRezervasyonservice.GetList();
            var resultKitapYazar = _iKitapYazarservice.GetList();                     
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
            var resultOdüncAl = _iOdüncalservice.GetList();
            var resultKitap = _iKitablarservice.GetList();
            var resultYazar = _iYazarservice.GetList();            
            var resultKitapYazar = _iKitapYazarservice.GetList();
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
            _iRezervasyonservice.Add(entityrezervasyon);
            return RedirectToAction("Index");
        }
        public JsonResult Düzenle(int id)
        {
            var result = _iOdüncalservice.GetById(id);
            return Json(result.Data);
        }
        public IActionResult DüzenleOnayla(string newdatet, int oduncId)
        {
            try
            {
                var model = _iOdüncalservice.GetById(oduncId);
                if (model.Success)
                {
                    model.Data.TeslimTarihi = newdatet;
                    _iOdüncalservice.Update(model.Data);
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
            var result = _iOdüncalservice.GetTeslimTarihi();
            if (result.Success)
            {
                //TeslimTarihiAlertViewModel entity = new TeslimTarihiAlertViewModel();
                //entity = _mapper.Map<TeslimTarihiAlertViewModel>(result);
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

