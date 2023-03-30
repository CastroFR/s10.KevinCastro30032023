using Microsoft.EntityFrameworkCore;
using OrmAlmacen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OrmAlmacen.DAO
{
    public class CrudProducto
    {
        public void AgregarProducto(Producto producto)
        {
            using (OrmAlmacenContext db = new OrmAlmacenContext())
            {
                Producto producto1 = new Producto();
                producto1.Nombre = producto.Nombre;
                producto1.Descipción = producto.Descipción;
                producto1.Precio = producto1.Precio;
                producto1.Stock = producto1.Stock;

                db.Add(producto1);
                db.SaveChanges();
            }
        }
        public Producto ProductoUnitario(int id)
        {
            using (OrmAlmacenContext bd = new OrmAlmacenContext())
            {
                var buscar = bd.Productos.FirstOrDefault(s => s.Id == id);
                return buscar;

            }

        }

        public void ActualizarProducto(Producto Parametroproducto, int Lector)
        {
            using (OrmAlmacenContext db = new OrmAlmacenContext())
            {
                var buscar = ProductoUnitario(Parametroproducto.Id);
                if (buscar == null)
                {
                    Console.WriteLine("Id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = Parametroproducto.Nombre;
                    }
                    else
                    {
                        buscar.Descipción = Parametroproducto.Descipción;
                    }

                    db.Update(buscar);
                    db.SaveChanges();
                }
            }
        }


        public string EliminarProducto(int id)
        {
            using (OrmAlmacenContext db = new OrmAlmacenContext())
            {

                var buscar = ProductoUnitario(id);
                if (buscar == null)
                {
                    return "El producto no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "El producto se elimino";
                }

            }
        }

        public List<Producto> ListarProducto()
        {
            using (OrmAlmacenContext db = new OrmAlmacenContext())
            {
                return db.Productos.ToList();
            }
        }

        //internal static object Listarproductos()
        //{
        //    throw new NotImplementedException();
        //}
    }
}