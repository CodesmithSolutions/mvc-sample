using AutoMapper;
using AutoMapper.Configuration;
using SimpleInjector;

namespace Codesmith.MvcSample.Web.Infrastructure
{
    public class AutoMapperProvider
    {
        private readonly Container _container;

        public AutoMapperProvider(Container container)
        {
            _container = container;
        }

        public IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(_container.GetInstance);

            mce.AddMaps(new[]
            {
                "Codesmith.MvcSample.Web",
                "Codesmith.MvcSample.Services",
                "Codesmith.MvcSample.DataAccess"
            });

            var mc = new MapperConfiguration(mce);
            mc.AssertConfigurationIsValid();

            IMapper m = new Mapper(mc, t => _container.GetInstance(t));

            return m;
        }
    }
}