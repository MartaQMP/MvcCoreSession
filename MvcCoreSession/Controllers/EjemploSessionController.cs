using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Extensions;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        HelperSessionContextAccessor helper;

        public EjemploSessionController(HelperSessionContextAccessor helper)
        {
            this.helper = helper;
        }

        public IActionResult Index()
        {
            List<Mascota> mascotas = this.helper.GetMascotaSession();
            return View(mascotas);
        }

        public IActionResult SessionSimple(string accion)
        {
            if(accion != null)
            {
                if(accion .ToLower()== "almacenar")
                {
                    // GUARDAMOS DATOS EN SESSION
                    HttpContext.Session.SetString("nombre", "Marta");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                    ViewBag.Mensaje = "Datos alamcenados en session";

                }else if(accion.ToLower() == "mostrar")
                {
                    // RECUPERAMOS LOS DATOS DE SESSION
                    ViewBag.Nombre = HttpContext.Session.GetString("nombre");
                    ViewBag.Hora = HttpContext.Session.GetString("hora");
                }
            }
            return View();
        }

        public IActionResult SessionMascotaBytes(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota
                    {
                        Nombre = "Kitty",
                        Raza = "Perro",
                        Edad = 15
                    };
                    byte[] datos = HelperBinarySession.ObjectToByte(mascota);
                    HttpContext.Session.Set("MASCOTA", datos);
                    ViewBag.Mensaje = "Mascota almacenada";

                    HttpContext.Session.SetString("nombre", "Marta");
                    HttpContext.Session.SetString("hora", DateTime.Now.ToLongTimeString());
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] datos = HttpContext.Session.Get("MASCOTA");
                    Mascota mascota = (Mascota)HelperBinarySession.ByteToObject(datos);
                    ViewBag.Mascota = mascota;
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
                        Nombre = "Betty",
                        Raza = "Perro",
                        Edad = 13
                    };
                    // QUEREMOS GUARDAR EL OBJETO MASCOTA COMO STRING EN SESSION
                    string mascotaJson = HelperJsonSession.SerializableObject<Mascota>(mascota);
                    HttpContext.Session.SetString("MASCOTAJSON", mascotaJson);
                    ViewBag.Mensaje = "Mascota almacenada";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    string json = HttpContext.Session.GetString("MASCOTAJSON");
                    Mascota mascota = HelperJsonSession.DeserializeObject<Mascota>(json);
                    ViewBag.Mascota = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionMascotaGenericos (string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    Mascota mascota = new Mascota
                    {
                        Nombre = "Lola",
                        Raza = "Perro",
                        Edad = 4
                    };
                    HttpContext.Session.SetObject("MASCOTAGENERICA", mascota);
                    ViewBag.Mensaje = "Mascota almacenada";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    Mascota mascota = HttpContext.Session.GetObject<Mascota>("MASCOTAGENERICA");
                    ViewBag.Mascota = mascota;
                }
            }
            return View();
        }

        public IActionResult SessionMascotaCollectionBytes(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota>
                    {
                        new Mascota{ Nombre = "Simba", Raza = "Leon", Edad= 10 },
                        new Mascota{ Nombre = "Sebastian", Raza = "Cangrejo", Edad= 2 },
                        new Mascota{ Nombre = "Timon", Raza = "Suricata", Edad= 1 },
                        new Mascota{ Nombre = "Pumba", Raza = "Jabali", Edad= 40 },
                    };
                    byte[] datos = HelperBinarySession.ObjectToByte(mascotas);
                    HttpContext.Session.Set("Mascotas", datos);
                    ViewBag.Mensaje = "Mascotas guardadas";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    byte[] datos = HttpContext.Session.Get("Mascotas");
                    List<Mascota> mascotas = (List<Mascota>)HelperBinarySession.ByteToObject(datos);
                    return View(mascotas);
                }
            }
            return View();
        }

        public IActionResult SessionMascotaCollectionGenericos(string accion)
        {
            if (accion != null)
            {
                if (accion.ToLower() == "almacenar")
                {
                    List<Mascota> mascotas = new List<Mascota>
                    {
                        new Mascota{ Nombre = "Simba", Raza = "Leon", Edad= 10 },
                        new Mascota{ Nombre = "Sebastian", Raza = "Cangrejo", Edad= 2 },
                        new Mascota{ Nombre = "Timon", Raza = "Suricata", Edad= 1 },
                        new Mascota{ Nombre = "Pumba", Raza = "Jabali", Edad= 40 },
                    };
                    HttpContext.Session.SetObject("MASCOTASGENERICAS", mascotas);
                    ViewBag.Mensaje = "Mascotas guardadas";
                }
                else if (accion.ToLower() == "mostrar")
                {
                    List<Mascota> mascotas = HttpContext.Session.GetObject<List<Mascota>>("MASCOTASGENERICAS");
                    return View(mascotas);
                }
            }
            return View();
        }
    }
}
