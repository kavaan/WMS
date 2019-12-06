using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using WMS.DataAccess;
using WMS.DataAccess.MSSQL;
using WMS.DataAccess.MSSQL.Context;
using WMS.DataAccess.MSSQL.Repositories;
using WMS.DataAccess.Repositories;
using WMS.Service.Definitions.Services;
using WMS.Service.Implementations.Services;
using WMS.WCFService.MappingConfig;

namespace WMS.WCFService.DI
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component.For<IMainService, MainService>(),
                Component.For<IUnitOfWork, SqlUnitOfWork>(),
                Component.For<IProductService, ProductService>(),
                Component.For<IProductRepository, ProductRepository>(),
                Component.For<IOrderService, OrderService>(),
                Component.For<IOrderRepository, OrderRepository>(),
                Component.For(typeof(IMapper)).Instance(new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(typeof(AutomapBootstrap))))),
                Component.For(typeof(WmsDbContext)).Instance(new WmsDbContext("Data Source=.;Initial Catalog=TestWmsDb;Integrated Security=True;MultipleActiveResultSets=True"))
                );
        }
    }
}