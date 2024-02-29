using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace AgendaAmigos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flujo = "";
            int op = 0;
            while (op != 4)
            {

                Console.WriteLine("\t\tREGISTRO");
                Console.WriteLine("\n1. Crear Archivo\n2. Agregar amigo\n3. Eliminar amigo\n4. listado\n5. Salir");
                
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:

                        Console.Write("Ingrese nombre del Archivo -> ");
                        flujo = Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:

                        Console.Clear();
                        RegistrarPersona(flujo);
                        break;
                    case 3:

                        Console.Clear();
                        eliminarRegistros(flujo);
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        listado(flujo);
                        Console.ReadKey();
                        break;
                    default:

                        Console.WriteLine("Error opcion incorrecta!!");
                        break;
                }
                Console.Clear();
            }

            Console.ReadKey();
        }

        static void RegistrarPersona(string flujo)
        {
            char salir = 's';
            bool verificar = File.Exists(flujo);
            using (StreamWriter fichero = new StreamWriter(flujo,true))
            {
                if (!verificar)
                {
                    fichero.WriteLine("{0,-10} {1,-10} {2,-5} {3,-10} {4,-10} {5,-10} {6,-20}", "Nombre", "Apellido", "Edad", "Genero", "Ciudad", "Celular", "Correo");
                    fichero.WriteLine();
                }
                while (salir != 'n')
                {
                    Console.WriteLine("Ingrese nombre"); string nombre = Console.ReadLine(); Console.WriteLine("Ingrese Apellido"); string apellido = Console.ReadLine(); Console.WriteLine("Ingrese Edad"); string edad = Console.ReadLine(); Console.WriteLine("Ingrese Genero"); string genero = Console.ReadLine(); Console.WriteLine("Ingrese Ciudad"); string ciudad = Console.ReadLine(); Console.WriteLine("Ingrese Celular"); string celular = Console.ReadLine(); Console.WriteLine("Ingrese Correo"); string correo = Console.ReadLine();
                    fichero.WriteLine("{0,-10} {1,-10} {2,-5} {3,-10} {4,-10} {5,-10} {6,-20}", nombre, apellido, edad, genero, ciudad, celular, correo);
                    Console.WriteLine("Desea seguir resgistrando (S/N)");
                    salir = Console.ReadKey().KeyChar;
                    salir = char.ToLower(salir);
                    Console.Clear();
                }
            }
           
        }

        static void eliminarRegistros(string flujo)
        {
            char salir = 's';
            while (salir != 'n')
            {
                Console.WriteLine("Ingrese amigo a eliminar");
                string amigoAEliminar = Console.ReadLine();
                string nuevoarchivo = "lista.txt";

                using (StreamReader reader = new StreamReader(flujo))
                using (StreamWriter archivo = new StreamWriter(nuevoarchivo))
                {
                    string linea;
                    bool saltolinea = false;
                    while ((linea = reader.ReadLine()) != null)
                    {

                        if (linea.Contains(amigoAEliminar))
                        {
                            saltolinea = true;
                            continue;
                        }
                        if (saltolinea)
                        {
                            saltolinea = false;
                            continue;
                        }

                        archivo.WriteLine(linea);
                    }
                }
                File.Delete(flujo);
                File.Move(nuevoarchivo, flujo);
                Console.WriteLine("Desea seguir resgistrando (S/N)");
                salir = Console.ReadKey().KeyChar;
                salir = char.ToLower(salir);
                Console.Clear();
            }

        }

        static void listado(string flujo)
        {
           
            using (StreamReader fichero = new StreamReader(flujo))
            {
                string linea;
                while ((linea = fichero.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
        }
    }
}
