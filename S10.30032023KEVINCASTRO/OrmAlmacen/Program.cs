
using OrmAlmacen.DAO;
using OrmAlmacen.Models;
using System;
using System.Diagnostics;

CrudProducto crudProducto  = new CrudProducto();
Producto producto = new Producto();

bool Continuar = true;
while (Continuar)
{
    Console.WriteLine("Menu");
    Console.WriteLine("Pulse 1 para regresar e insertar productos");
    Console.WriteLine("Pulse 2 para actualizar productos");
    Console.WriteLine("Pulse 3 para realizar una eliminación de productos");
    Console.WriteLine("Pulse 4 para obtener un listado de productos");
    var Menu = Convert.ToInt32(Console.ReadLine());


    switch (Menu)
    {
        case 1:
            int bucle = 1;
            while (bucle == 1)
            {
                Console.WriteLine("Ingresa el nombre de tu producto ");
                producto.Nombre = Console.ReadLine();
                Console.WriteLine("Ingresa la descripción de tu producto ");
                producto.Descipción = Console.ReadLine();
                Console.WriteLine("Ingresa el precio de tu producto ");
                producto.Precio = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine("Ingresa la cantidad de productos disponibles ");
                producto.Stock = Convert.ToInt32(Console.ReadLine());

                crudProducto.AgregarProducto(producto);
                Console.WriteLine("El producto se ingreso correctamente");
                Console.WriteLine("Pulse 1 para continuar añadiendo productos");
                Console.WriteLine("Pulse 0 para salir");

                bucle = Convert.ToInt32(Console.ReadLine());

            }
            break;
        case 2:
            Console.WriteLine("Actualizar Productos");
            Console.WriteLine("Ingresa el ID del producto a actualizar");
            var ProductoUnitarioU = crudProducto.ProductoUnitario(Convert.ToInt32(Console.ReadLine()));
            if (ProductoUnitarioU == null)
            {
                Console.WriteLine("El producto no existe");
            }
            else
            {
                Console.WriteLine($"Nombre {ProductoUnitarioU.Nombre} , Descripción {ProductoUnitarioU.Descipción}");


                Console.WriteLine("Para actulizar Nombre coloca el # 1");

                Console.WriteLine("Para actualizar la Descripción coloca el # 2");

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    Console.WriteLine("Ingrese el Nombre");
                    ProductoUnitarioU.Nombre = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ingrese la descripción");
                    ProductoUnitarioU.Descipción = Console.ReadLine();
                }
                crudProducto.ActualizarProducto(ProductoUnitarioU, Lector);
                Console.WriteLine("Actualizacion correcta");
            }
            break;
        case 3:
            Console.WriteLine("Ingresa el ID del producto a eliminar");
            var ProductoUnitarioD = crudProducto.ProductoUnitario(Convert.ToInt32(Console.ReadLine()));
            if (ProductoUnitarioD == null)
            {
                Console.WriteLine("Este producto no existe");
            }
            else
            {
                Console.WriteLine("Eliminar producto");
                Console.WriteLine($"Nombre {ProductoUnitarioD.Nombre} , Descipción {ProductoUnitarioD.Descipción}");
                Console.WriteLine("El producto encontrado es el correcto?");
                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(ProductoUnitarioD.Id);
                    Console.WriteLine(value: crudProducto.EliminarProducto(Id));
                }
                else
                {
                    Console.WriteLine("Inicia nuevamente");
                }

            }
            break;
        case 4:
            Console.WriteLine("Lista de productos");
            var ListarProducto = crudProducto.ListarProducto();
            foreach (var iteracionProducto in ListarProducto) 
            {
                Console.WriteLine($"{iteracionProducto.Id} , {iteracionProducto.Nombre} , {iteracionProducto.Descipción}");
            }
            break;
    }
    Console.WriteLine("Desea continuar ?");
    var cont = Console.ReadLine();
    if (cont.Equals("N"))
    {
        Continuar = false;
    }

}

