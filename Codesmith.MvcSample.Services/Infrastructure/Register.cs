using Codesmith.MvcSample.DataAccess;
using Codesmith.MvcSample.DataAccess.Contracts;
using SimpleInjector;

namespace Codesmith.MvcSample.Services.Infrastructure
{
    public class Register
    {
        public static void RegisterServices(Container container)
        {
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
        }
    }
}
