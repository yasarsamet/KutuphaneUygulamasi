using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using KütüphaneUygulaması.Models;
using KütüphaneUygulaması.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace KütüphaneUygulaması.Controllers
{
    [Authorize]
    public class OgrenciController : Controller
    {

        private readonly IOgrenciService _ogrenciservice = null;
        private readonly IMapper _mapper;

        public OgrenciController(IOgrenciService ogrenciservice, IMapper mapper)
        {
            _ogrenciservice = ogrenciservice;
            _mapper = mapper;
        }   
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            try
            {
                var result = _ogrenciservice.Login(model.email, model.sifre);
                if (!ModelState.IsValid)
                {
                    return View();
                }
                if (result != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,model.email)
                    };
                    var useridentity = new ClaimsIdentity(claims, "Login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                    await HttpContext.SignInAsync(principal);
                    HttpContext.Session.SetString("emailadresi", model.email);                    
                    HttpContext.Session.SetString("loginid", result.Data.Id.ToString());
                    return RedirectToAction("Index","Kitapal");
                }
                else
                {
                    ViewBag.hata = "Error";
                    ModelState.AddModelError("email", "Hata giriş");
                    return RedirectToAction("Index","Ogrenci");
                
                }
            }
            catch(Exception es)
            {

            }
            return null;
            }

        [AllowAnonymous]
        [HttpGet]
        public  IActionResult OgrenciEkleme()
        {
            OgrenciEklemeViewModel model = new OgrenciEklemeViewModel();           
            return View(model);
        }
        [AllowAnonymous] // Herkes erişebilir dedik
        [HttpPost]
        public IActionResult OgrenciEkleme(OgrenciEklemeViewModel model)
        {
            Random random = new Random();
            string code = "";
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            var emailresult = _ogrenciservice.EmailKontrol(model.Email);
            if (emailresult.Data==null)
            {
                Ogrenci entity = new Ogrenci();
                model.Durumu = "Aktif";
                model.OgrenciId = 1;
                for (int i = 0; i < 6; i++)
                {
                    code += Convert.ToString(random.Next(0, 9));
                }
                SmtpClient client = new SmtpClient("smtp.live.com", 587);
                MailMessage gidecekmesaj = new MailMessage();
                gidecekmesaj.To.Add(model.Email);
                gidecekmesaj.From = new MailAddress("Mail Adresi");
                gidecekmesaj.Subject = "Onay Kodu";
                gidecekmesaj.Body = "Hesabını Aktifleştirmek için size gönderdiğimiz onay kodunu yazınız. " +
                    "Onay Kodu: " + "" + code + "";
                NetworkCredential guvenlik = new NetworkCredential("Mail adresi", "Mail adresin şifresi");
                client.Credentials = guvenlik;
                client.EnableSsl = true;
                client.Send(gidecekmesaj);

                HttpContext.Session.SetString("onaykodu", code.ToString());
                HttpContext.Session.SetString("emailadresi", model.Email);

                entity =_mapper.Map<Ogrenci>(model);
                var result = _ogrenciservice.Add(entity);               
                return RedirectToAction("SifreDogrulama", "Ogrenci");
            }
            else
            {                
                return RedirectToAction("OgrenciEkleme", "Ogrenci");
            }
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SifreDogrulama()
        {            
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult SifreDogrulama(string code)
        {
            string GelenOnayKodu = HttpContext.Session.GetString("onaykodu");
            string EmailAdresi = HttpContext.Session.GetString("emailadresi");
            var result = _ogrenciservice.EmailKontrol(EmailAdresi);
            if (code == GelenOnayKodu && EmailAdresi!=null )
            {
                result.Data.Durumu = "Aktif";
                _ogrenciservice.Update(result.Data,0);                
            }
            else if(code != GelenOnayKodu && EmailAdresi!=null)
            {
                result.Data.Durumu = "Aktif Değil";
                _ogrenciservice.Update(result.Data,0);                
            }
            return RedirectToAction("Index", "Ogrenci");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ForgetPasswordViewModel model = new ForgetPasswordViewModel();
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult ForgotPassword(ForgetPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                Random random = new Random();
                string code = "";
                for (int i = 0; i < 6; i++)
                {
                    code += Convert.ToString(random.Next(0, 9));
                }
                var result = _ogrenciservice.EmailKontrol(model.email);
                if (result.Data !=null)
                {
                    SmtpClient client = new SmtpClient("smtp.live.com", 587);
                    MailMessage gidecekmesaj = new MailMessage();
                    gidecekmesaj.To.Add(model.email);
                    gidecekmesaj.From = new MailAddress("samet_1.999@hotmail.com");
                    gidecekmesaj.Subject = "Onay Kodu";
                    gidecekmesaj.Body = "Hesabını Aktifleştirmek için size gönderdiğimiz onay kodunu yazınız. " +
                        "Onay Kodu: " + "" + code + "";
                    NetworkCredential guvenlik = new NetworkCredential("samet_1.999@hotmail.com", "yasarsamet0037178?");
                    client.Credentials = guvenlik;
                    client.EnableSsl = true;
                    client.Send(gidecekmesaj);

                    HttpContext.Session.SetString("onaykodu", code.ToString());
                    HttpContext.Session.SetString("emailadresi", model.email);
                    return RedirectToAction("SifreResetleme", "Ogrenci");
                }
                else
                {
                    //bu kullanıcı yoktur
                    return RedirectToAction("Index","Ogrenci");
                }
            }
            catch(Exception es)
            {
                return RedirectToAction("Index", "Ogrenci");
            }            
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult SifreResetleme()
        {
            NewPasswordViewModel model = new NewPasswordViewModel();
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult SifreResetleme(string codem, NewPasswordViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || codem==null)
                {
                    return View();
                }
                string GelenOnayKodu = HttpContext.Session.GetString("onaykodu");
                string EmailAdresi = HttpContext.Session.GetString("emailadresi");
                if (GelenOnayKodu == codem)
                {
                    var result = _ogrenciservice.EmailKontrol(EmailAdresi);
                    result.Data.Sifre = model.Sifre;
                    _ogrenciservice.Update(result.Data,1); // 1 ise resetleme 0 ise aktif aktif değil değişimi
                }
                else
                {
                  // gelen kodu yanlış girdiğinde   s   
                }
                return RedirectToAction("Index", "Ogrenci");
            }
            catch(Exception es)
            {
                return null;
            }
        }
        [HttpGet]
        public IActionResult ProfilEdit()
        {
            int Id = Convert.ToInt32(HttpContext.Session.GetString("loginid"));
            var result = _ogrenciservice.GetById(Id);
            if (result.Success)
            {
                ProfilEditViewModel entitys = new ProfilEditViewModel();
                entitys = _mapper.Map<ProfilEditViewModel>(result.Data);
                return View(entitys);

            }
            return null;
        }  
        [HttpPost]
        public IActionResult ProfilEdit(ProfilEditViewModel model)
        {
            try
            {
                Ogrenci entity = new Ogrenci();
                entity = _mapper.Map<Ogrenci>(model);
                _ogrenciservice.Update(entity, 1);
                return RedirectToAction("Index", "KitapAl");
            }
            catch (Exception)
            {
                return null;
            }
            
        }        
    }
}