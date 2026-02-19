using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;
using System;
using System.Collections.Generic;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        public IActionResult SessionSimple(string accion)
        {
            if (accion != null)
            {
                if (string.Equals(accion, "almacenar", StringComparison.OrdinalIgnoreCase))
                {
                    //GUARDAMOS DATOS EN SESSION
                    HttpContext.Session.SetString("nombre", "Programeitor");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                    ViewData["MENSAJE"] = "DATOS ALMACENADOS EN LA SESSION";
                }
                else if (string.Equals(accion, "mostrar", StringComparison.OrdinalIgnoreCase))
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
                if (string.Equals(accion, "almacenar", StringComparison.OrdinalIgnoreCase))
                {
                    Mascota mascota = new Mascota
                    {
                        Nombre = "Zeus",
                        Edad = 5,
                        Raza = "Husky"
                    };

                    //Para almacenar la mascota en ssesion CONVERTIR A BYTE
                    byte[] data = HelperBinarySession.ObjetoByte(mascota);
                    HttpContext.Session.Set("MASCOTA", data);
                    ViewData["MENSAJE"] = "Mascota almacenada";
                }
                else if (string.Equals(accion, "mostrar", StringComparison.OrdinalIgnoreCase))
                {
                    byte[]? data = HttpContext.Session.Get("MASCOTA");
                    if (data != null)
                    {
                        Mascota? m = HelperBinarySession.ByteObjeto(data) as Mascota;
                        ViewData["MASCOTA"] = m;
                    }
                }
            }
            return View();
        }

        public IActionResult SessionMascotaJson(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota
                    {
                        Nombre = "ZeusJson",
                        Edad = 5,
                        Raza = "Husky"
                    };

                    //Para almacenar la mascota en ssesion CONVERTIR A JSON
                    string json = HelperJsonSession.SerializeObject<Mascota>(mascota);
                    HttpContext.Session.SetString("MASCOTA_JSON", json);
                    ViewData["MENSAJE"] = "Mascota almacenada en JSON";
                }

                else if (accion.ToLower() == "mostrar")
                {
                    string json = HttpContext.Session.GetString("MASCOTA_JSON");
                    if (json != null)
                    {
                        Mascota? m = HelperJsonSession.DeserializeObject<Mascota>(json);
                        ViewData["MASCOTA"] = m;
                    }
                }
            } 
            return View();
        }

        public IActionResult SessionMascotaCollection(string accion)
        {
            if (accion != null)
            {
                if (string.Equals(accion, "almacenar", StringComparison.OrdinalIgnoreCase))
                {
                    List<Mascota> mascotas = new List<Mascota>
                    {
                        new Mascota { Nombre = "Zeus", Edad = 5, Raza = "Husky" },
                        new Mascota { Nombre = "Luna", Edad = 3, Raza = "Poodle" },
                        new Mascota { Nombre = "Rocky", Edad = 4, Raza = "Bulldog" }
                    };

                    byte[] masByte = HelperBinarySession.ObjetoByte(mascotas);
                    HttpContext.Session.Set("MASCOTAS", masByte);
                    ViewData["MENSAJE"] = "Mascotas almacenadas";
                }
                else if (string.Equals(accion, "mostrar", StringComparison.OrdinalIgnoreCase))
                {
                    byte[] data = HttpContext.Session.Get("MASCOTAS");
                    if (data != null)
                    {
                        List<Mascota>? mascotas = HelperBinarySession.ByteObjeto(data) as List<Mascota>;
                        ViewData["MASCOTAS"] = mascotas;
                        return View(mascotas);
                    }
                }
            }
            return View();
        }
    }
}