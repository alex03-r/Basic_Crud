using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bd_mvc_adonet.Models;

namespace bd_mvc_adonet.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            return View(ma.RecuperarTodos());
        }
        public ActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(collection["codigo"]),
                Describcion = collection["describcion"],
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Alta(art);
            return RedirectToAction("Index");
        }
        public ActionResult Baja(int cod)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            ma.Borrar(cod);
            return RedirectToAction("Index");
        }

        public ActionResult Modificacion(int cod)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = ma.Recuperar(cod);
            return View(art);
        }

        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            MantenimientoArticulo ma = new MantenimientoArticulo();
            Articulo art = new Articulo
            {
                Codigo = int.Parse(collection["codigo"].ToString()),
                Describcion = collection["describcion"].ToString(),
                Precio = float.Parse(collection["precio"].ToString())
            };
            ma.Modificar(art);
            return RedirectToAction("Index");
        }
    }
}