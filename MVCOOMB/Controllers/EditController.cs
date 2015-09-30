using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidades;
using MvcOMB.Models;
using Servicios;

namespace MvcOMB.Controllers
{
  public class EditController : Controller
  {
    // GET: Edit
    public ActionResult EditarLibro(string isbn13)
    {
      ProductServices serv = new ProductServices();
      Libro libro;

      libro = serv.GetLibroFromId(isbn13);
      if (libro == null)
        return HttpNotFound("No se encontro el ISBN");

      return View(libro);
    }

    [HttpPost]
    public ActionResult EditarLibro(Libro libro, string isbn13)
    {
      ProductServices serv = new ProductServices();

      //  obtenemos el libro original
      Libro original = serv.GetLibroFromId(isbn13);

      //  intentamos actualizarlo solo con los campos que editamos...
      if (TryUpdateModel(original, "", new string[] {"ISBN10", "Titulo", "Editorial", "Autores", "Precio" }))
      {
        serv.UpdateLibro(original);
      }
      return View(original);
    }
  }
}