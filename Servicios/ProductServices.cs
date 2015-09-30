using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Data;
using Entidades;

namespace Servicios
{
  public class ProductServices
  {
    public Libro GetLibroFromIsbn(string isbn)
    {
      OMBContext ctx = DB.Contexto;

      return ctx.Libros.Find(isbn);
    }

    public bool ActualizarLibro(Libro libro)
    {
      OMBContext ctx = DB.Contexto;

      try
      {
        ctx.MostrarCambios();
        ctx.Entry(libro).State = EntityState.Modified;
        ctx.SaveChanges();
      }
      catch (Exception)
      {
        return false;
      }
      return true;
    }
  }
}
