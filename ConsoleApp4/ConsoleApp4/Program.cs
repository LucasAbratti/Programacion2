using System.Diagnostics;
using System.IO;

namespace ConsoleApp4
{
    class Programm
    {
        static void Main(string[] args)
        {

            string[] options = new string[] {"[1] Escribir archivo", "[2] Leer archivo", "[3] Cerrar programa" };
            bool quitProgram = false;
            int currentSelection = 0;
            ConsoleKey key;

            FileStream archivo;
            StreamWriter grabador;
            StreamReader lector;
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
                        archivo = new FileStream("content.txt", FileMode.Append);
                        grabador = new StreamWriter(archivo);

                        Console.WriteLine("Ingrese algo\n");
                        string ingreso = Console.ReadLine();

                        grabador.WriteLine(ingreso);
                        grabador.Close();
                        break;
                    case 1:
                        archivo = new FileStream("content.txt", FileMode.Open);
                        lector = new StreamReader(archivo);

                        while (lector.EndOfStream == false)
                        {
                            string cadena = lector.ReadLine();
                            Console.WriteLine(cadena);
                        }

                        lector.Close();
                        Console.ReadKey();
                        archivo.Close();    
                        break;
                    case 2:
                        Console.WriteLine("Cerrando Programa");
                        quitProgram = true;
                        break;
                }

                Console.Clear();

            } while (!quitProgram);        
        }
    }
}
