using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using Data;

namespace Servicios
{
  public class ProductServices
  {
    public Libro GetLibroFromId(string isbn13)
    {
      OMBContext ctx = DB.Contexto;

      return ctx.Libros.Find(isbn13);
    }

    public bool UpdateLibro(Libro libro)
    {
      OMBContext ctx = DB.Contexto;
      try
      {
        ctx.Entry(libro).State = EntityState.Modified;
        ctx.SaveChanges();
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }
  }
}
