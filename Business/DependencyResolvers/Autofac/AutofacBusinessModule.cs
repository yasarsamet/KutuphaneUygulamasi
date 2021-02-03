using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)  
        {
            builder.RegisterType<OgrenciService>().As<IOgrenciService>();
            builder.RegisterType<EfOgrenciDal>().As<IOgrenciDal>();

            builder.RegisterType<OduncAlService>().As<IOduncAlService>();
            builder.RegisterType<EfOdüncAlDal>().As<IOdüncAlDal>();

            builder.RegisterType<KitapService>().As<IKitaplarService>();
            builder.RegisterType<EfKitaplarDal>().As<IKitaplarDal>();

            builder.RegisterType<RafService>().As<IRafService>();
            builder.RegisterType<EfRafDal>().As<IRafDal>();


            builder.RegisterType<YazarService>().As<IYazarService>();
            builder.RegisterType<EfYazarDal>().As<IYazarDal>();

            builder.RegisterType<KitapYazarService>().As<IKitapYazarService>();
            builder.RegisterType<EfKitapYazarDal>().As<IKitapYazarDal>();

            builder.RegisterType<RezervasyonService>().As<IRezervasyonService>();
            builder.RegisterType<EfRezervasyonDal>().As<IRezervasyonDal>();
        }
    }
}
