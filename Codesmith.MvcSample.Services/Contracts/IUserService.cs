using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codesmith.MvcSample.Services
{
    public interface IUserService
    {
        void GetUserById(int userId);
    }
}
