using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entidades;
using Servicios;

namespace MvcOMB.Controllers
{
  [Authorize]
  public class EditController : Controller
  {
    // GET: Edit
    public ActionResult EditarLibro(string isbn)
    {
      ProductServices serv = new ProductServices();
      Libro libro;

      libro = serv.GetLibroFromIsbn(isbn);
      if (libro == null)
        return HttpNotFound("Libro no encontrado");

      return View(libro);
    }

    [HttpPost]
    public ActionResult EditarLibro(Libro libro, string isbn13)
    {
      ProductServices serv = new ProductServices();
      Libro libroDominio;

      libroDominio = serv.GetLibroFromIsbn(isbn13);

      if (libroDominio != null)
      {
        if (TryUpdateModel(libroDominio, new string[]
                          {
                            nameof(libro.ISBN10), nameof(libro.Titulo),
                            "Autores", "Editorial", "Precio"
                          }))
        {
          if (!serv.ActualizarLibro(libroDominio))
            return new HttpStatusCodeResult(500);
        }
      }

      return View(libroDominio);
    }
  }
}