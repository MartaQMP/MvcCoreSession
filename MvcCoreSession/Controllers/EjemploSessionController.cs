using Microsoft.AspNetCore.Mvc;
using MvcCoreSession.Helpers;
using MvcCoreSession.Models;

namespace MvcCoreSession.Controllers
{
    public class EjemploSessionController : Controller
    {
        public IActionResult Index()
        {

            byte[] datos = HttpContext.Session.Get("MASCOTA");
            if(datos != null)
            {
                Mascota mascota = (Mascota)HelperBinarySession.ByteToObject(datos);
                ViewBag.Mascota = mascota;
            }
            return View();
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
    }
}
