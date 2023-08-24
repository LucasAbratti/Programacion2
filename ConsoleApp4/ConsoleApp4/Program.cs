using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ConsoleApp4
{
    class Programm
    {
        static void Main(string[] args)
        {

            string[] options = new string[] {"[1] Escribir archivo", "[2] Leer archivo", "[3] Buscar", "[3] Cerrar programa" };
            bool quitProgram = false;
            int currentSelection = 0;
            ConsoleKey key;
            do
            {
                do
                {
                    for (int i = 0; i < options.Length; i++)
                    {
                        if (i == currentSelection) Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(options[i]);
                        Console.ResetColor();
                    }

                    key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.DownArrow:
                            currentSelection++;
                            break;
                        case ConsoleKey.UpArrow:
                            currentSelection--;
                            break;
                    }
                    if (currentSelection < 0) currentSelection = 0;
                    else if (currentSelection > options.Length - 1) currentSelection = options.Length - 1;

                    Console.Clear();
                } while (key != ConsoleKey.Enter);

                switch (currentSelection)
                {
                    case 0:
                        do
                        {
                            WriteFile();
                            Console.WriteLine("Desea Ingresar otro alumno? [si]");

                        } while (Console.ReadLine() == "si");
                        break;
                    case 1:
                        ShowFormatedFile();
                        break;
                    case 2:
                        SearchInFile();
                        break;
                    case 3:
                        Console.WriteLine("Cerrando Programa");
                        quitProgram = true;
                        break;
                }

                Console.Clear();

            } while (!quitProgram);
        }
        static void IngresoAlumno(out int edad, out string nombre, out string apellido, out string direccion, out int legajo)
        {
            bool parsedSuccessfully = false;

            do
            {
                Console.WriteLine("\nIngrese la edad del alumno\n");
                parsedSuccessfully = int.TryParse(Console.ReadLine(), out edad);

            } while (!parsedSuccessfully);

            Console.WriteLine("\nIngrese el nombre del alumno\n");
            nombre = Console.ReadLine();
            Console.WriteLine("\nIngrese el nombre del apellido\n");
            apellido = Console.ReadLine();
            Console.WriteLine("\nIngrese la direccion del alumno\n");
            direccion = Console.ReadLine();

            parsedSuccessfully = false;
            do
            {
                Console.WriteLine("\nIngrese el numero de lagajo del alumno\n");
                parsedSuccessfully = int.TryParse(Console.ReadLine(), out legajo);

            } while (!parsedSuccessfully);
        
        }

        static string FormateoRenglon(string renglon)
        {
            const int PAD = 10;
            
            string[] valores = renglon.Split(';');
            string renglonFormateado = "";
            foreach(string s in valores)
            {
                renglonFormateado += $"{s.PadLeft(PAD)} |";
            }
            return renglonFormateado;
        }
        static void SearchInFile()
        {
            int legajo;
            bool parsedSuccessfully = false;

            do
            {
                Console.WriteLine("Ingrese legajo a buscar\n");
                parsedSuccessfully = int.TryParse(Console.ReadLine(), out legajo);

            } while (!parsedSuccessfully);
            

            string legajoS = GetAlumnoFromLegajo(4, legajo.ToString());

            if (legajoS == "")
            {
                Console.WriteLine("Legajo no encontrado");
            }
            else
            {
                Console.WriteLine(FormateoRenglon(legajoS));
            }
            Console.ReadKey();
        }

        static void WriteFile()
        {
            FileStream archivo;
            StreamWriter grabador;

            archivo = new FileStream("content.csv", FileMode.Append);
            grabador = new StreamWriter(archivo);

            IngresoAlumno(out int edad, out string nombre, out string apellido, out string direccion, out int legajo);
            string ingreso = $"{edad};{nombre};{apellido};{direccion};{legajo}";
            grabador.WriteLine(ingreso);
            grabador.Close();
        }

        static void ShowFormatedFile()
        {
            const string NOMBRE = "content.csv";
            FileStream archivo = new FileStream("content.csv", FileMode.Open);
            StreamReader lector = new StreamReader(archivo);

            if (!File.Exists(NOMBRE)) { Console.WriteLine($"Archivo inexistente: {NOMBRE}"); Console.ReadKey(); return; }



            while (lector.EndOfStream == false)
            {
                string cadena = FormateoRenglon(lector.ReadLine());
                Console.WriteLine(cadena);
            }

            lector.Close();
            archivo.Close();
            Console.ReadKey();
        }
        static string GetAlumnoFromLegajo(int index, string value)
        {
            const string NOMBRE = "content.csv";
            FileStream archivo = new FileStream("content.csv", FileMode.Open);
            StreamReader lector = new StreamReader(archivo);

            if (!File.Exists(NOMBRE)) { Console.WriteLine($"Archivo inexistente: {NOMBRE}"); Console.ReadKey(); return ""; }

            while (lector.EndOfStream == false)
            {
                string renglon = lector.ReadLine();
                string[] valores = renglon.Split(';');
                if (valores[index] == value)
                {
                    lector.Close();
                    archivo.Close();
                    return renglon;
                }
            }
            lector.Close();
            archivo.Close();
            return "";
        }
    }
}
