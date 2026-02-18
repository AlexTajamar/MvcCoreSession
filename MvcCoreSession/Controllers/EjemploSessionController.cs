using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        public IActionResult SessionSimple(string accion)

        {

            if (accion != null)

            {

                if (accion.ToLower() == "almacenar")

                {

                    //GUARDAMOS DATOS EN SESSION

                    HttpContext.Session.SetString("nombre", "Programeitor");

                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());

                    ViewData["MENSAJE"] = "DATOS ALMACENADOS EN LA SESSION";

                }
                else if (accion.ToLower() == "mostrar")

                {

                    //RECUPERAMOS LOS DATOS DE SESSION

                    ViewData["NOMBRE"] = HttpContext.Session.GetString("nombre");

                    ViewData["HORA"] = HttpContext.Session.GetString("hora");

                }

            }

            return View();

        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SessionMascota(string accion)
        {

            if (accion != null)

            {

                if (accion.ToLower() == "almacenar")

                {
                    Mascota mascota = new Mascota();
                    mascota.Nombre = "Zeus";
                    mascota.Edad = 5;
                    mascota.Raza = "Husky";

                    //Para almacenar la mascota en ssesion CONVERTIR A BYTE

                    byte[] data = HelperBinarySession.ObjetoByte(mascota);
                    HttpContext.Session.Set("MASCOTA", data);
                    ViewData["MENSAJE"] = "Mascota almacenada";
                   
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] data = HttpContext.Session.Get("MASCOTA");
                    Mascota m = (Mascota)HelperBinarySession.ByteObjeto(data);

                    ViewData["MASCOTA"] = m;


                }

            }
            return View();
        }
    }
}
