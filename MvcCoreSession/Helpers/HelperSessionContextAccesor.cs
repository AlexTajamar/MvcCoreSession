using MvcCoreSession.Extensions;
using MvcCoreSession.Models;

namespace MvcCoreSession.Helpers
{
    public  class HelperSessionContextAccesor
    {
        private  IHttpContextAccessor contextAccessor;
        public HelperSessionContextAccesor(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }   

        public List<Mascota> GetMacotasSession() {

            List<Mascota> mascotas = this.contextAccessor.HttpContext.Session.GetObject<List<Mascota>>("MASCOTAGENLIST");
            return mascotas;

        }
    }
}
