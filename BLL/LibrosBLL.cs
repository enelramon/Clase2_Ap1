using System;
using Clase2.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Clase2.BLL
{
    public class LibrosBLL
    {

        public static bool Existe(int libroId)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Libros.Any(l => l.LibroId == libroId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        public static bool Guardar(Libros libros)
        {
            if (!Existe(libros.LibroId))
                return Insertar(libros);
            else
                return Modificar(libros);

        }

        private static bool Insertar(Libros libro)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Libros.Add(libro);
                paso = contexto.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        private static bool Modificar(Libros libro)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                contexto.Entry(libro).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int libroId)
        {
            Contexto contexto = new Contexto();
            bool paso = false;
            try
            {
                var libro = contexto.Libros.Find(libroId);
                if (libro != null)
                {
                    contexto.Libros.Remove(libro);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Libros? Buscar(int libroId)
        {
            Contexto contexto = new Contexto();
            Libros? libro;
            try
            {
                libro = contexto.Libros.Find(libroId);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return libro;
        }

        public static List<Libros> GetList(Expression<Func<Libros, bool>> criterio)
        {
            Contexto contexto = new Contexto();
            List<Libros> lista = new List<Libros>();
            try
            {
                lista = contexto.Libros.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }

}