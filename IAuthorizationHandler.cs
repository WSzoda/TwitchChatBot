using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiraSodaBot
{
    public interface IAuthorizationHandler
    {
        public Task<string> Authorize();
        public Task<string> Renew();
    }
}
