using MvcCoreSession.Extensions;
using MvcCoreSession.Models;

namespace MvcCoreSession.Helpers
{
    public class HelperSessionContextAccessor
    {
        private IHttpContextAccessor contextAccessor;

        public HelperSessionContextAccessor(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public List<Mascota> GetMascotaSession()
        {
            return this.contextAccessor.HttpContext.Session.GetObject<List<Mascota>>("MASCOTASGENERICAS");
        }
    }
}
