using AutoMapper;
using Entities.Concrete;
using KütüphaneUygulaması.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KütüphaneUygulaması.Automapper
{
    public class AutomapperProfile:Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Ogrenci, OgrenciEklemeViewModel>().ReverseMap();
            CreateMap<ProfilEditViewModel, Ogrenci>().ReverseMap();
            CreateMap<OduncAl, ÖdüncAlViewModel>().ReverseMap();
            CreateMap<OduncAl, ÖdüncAlViewModel>().ReverseMap();

            CreateMap<TeslimTarihiAlertViewModel, TeslimTarih>().ReverseMap();
            CreateMap<TeslimTarih, TeslimTarihiAlertViewModel>().ReverseMap();
                
            CreateMap<TeslimTarihiAlertViewModel, OduncAl>().ReverseMap();

            CreateMap<RezervasyonViewModel, Rezervasyon>().ReverseMap();
        }
    }
}
