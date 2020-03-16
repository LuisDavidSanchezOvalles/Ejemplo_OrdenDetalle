using System;
using System.Collections.Generic;
using System.Text;
using PruebaOrden1.DAL;
using PruebaOrden1.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace PruebaOrden1.BLL
{
    public class OrdenesBLL
    {
        public static bool Guardar(Orden orden)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                if (db.Ordenes.Add(orden) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static bool Modificar(Orden orden)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                db.Database.ExecuteSqlRaw($"Delete FROM ProductoDetalle Where OrdenId = {orden.OrdenId}");

                foreach (var item in orden.Productos)
                {
                    db.Entry(item).State = EntityState.Added;
                }
                db.Entry(orden).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static Orden Buscar(int id)
        {
            Orden orden = new Orden();
            Contexto db = new Contexto();

            try
            {
                orden = db.Ordenes.Include(o => o.Productos).Where(o => o.OrdenId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return orden;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto db = new Contexto();

            try
            {
                var eliminar = OrdenesBLL.Buscar(id);
                db.Entry(eliminar).State = EntityState.Deleted;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return paso;
        }

        public static List<Orden> GetList(Expression<Func<Orden,bool>> orden)
        {
            List<Orden> Lista = new List<Orden>();
            Contexto db = new Contexto();

            try
            {
                Lista = db.Ordenes.Where(orden).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                db.Dispose();
            }
            return Lista;
        }
    }
}
