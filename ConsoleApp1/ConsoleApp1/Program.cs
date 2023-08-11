using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempString;
            int cantAlumnos;

            string[] nombres;
            string[] apellidos;
            int[] legajos;
            DateTime[] fechas;

            Console.WriteLine("Desea ingresar alumnos manualmente [si]");
            string respuesta = Console.ReadLine();

            if (respuesta == "si")
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Cuantos alumnos quere ingresar?");
                    tempString = Console.ReadLine();
                } while (!int.TryParse(tempString, out cantAlumnos));

                nombres = new string[cantAlumnos];
                apellidos = new string[cantAlumnos];
                legajos = new int[cantAlumnos];
                fechas = new DateTime[cantAlumnos];

                for (int n = 0; n < cantAlumnos; n++)
                {
                    string tempStringB;
                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese numero de legajo");
                        tempStringB = Console.ReadLine();
                    } while (!int.TryParse(tempStringB, out legajos[n]));

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese un apellido");
                        apellidos[n] = Console.ReadLine();

                    } while (apellidos[n].Length < 4 || apellidos[n].Length > 15);

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese un nombre");
                        nombres[n] = Console.ReadLine();

                    } while (nombres[n].Length < 4 || nombres[n].Length > 15);

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Ingrese una fecha");
                    } while (!DateTime.TryParse(Console.ReadLine(), out fechas[n]));

                }
            }
            else
            {
                nombres = new string[]{ "Lucas", "Tadeo", "Ignacio" };
                apellidos = new string[] { "Abratti", "Cardelli", "Cordero" };
                legajos = new int[] { 999, 888, 000 };
                fechas = new DateTime[] { new DateTime(), new DateTime(), new DateTime() };
            }


            Console.WriteLine("Desea mostrar los alumnos en orden creciente? [si]");
            respuesta = Console.ReadLine();

            BubbleSort(nombres, apellidos, legajos, fechas);
            DibujarTabla(nombres, apellidos, legajos, fechas, respuesta == "si" ? true : false);
            Console.ReadKey();
        }

        static void BubbleSort(string[] nombres, string[] apellidos, int[] legajos, DateTime[] fechas)
        {
            string tempStr;
            int tempInt;
            DateTime tempDate;
            for (int n = 0; n < legajos.Length - 1; n++)
            {
                for (int i = 0; i < legajos.Length - 1; i++)
                {
                    if (legajos[i] > legajos[i + 1])
                    {
                        tempInt = legajos[i + 1];
                        legajos[i + 1] = legajos[i];
                        legajos[i] = tempInt;

                        tempStr = nombres[i + 1];
                        nombres[i + 1] = nombres[i];
                        nombres[i] = tempStr;

                        tempStr = apellidos[i + 1];
                        apellidos[i + 1] = apellidos[i];
                        apellidos[i] = tempStr;

                        tempDate = fechas[i + 1];
                        fechas[i + 1] = fechas[i];
                        fechas[i] = tempDate;
                    }
                }
            }
        }

        static void DibujarTabla(string[] nombres, string[] apellidos, int[] legajos, DateTime[] fechas, bool creciente)
        {
            int cantAlumnos = legajos.Length;
            int i = 0;
            if (creciente)
            {
                for (int n = 0; n < cantAlumnos; n++)
                {
                    Console.Write($"{n + i} |{nombres[n].PadLeft(15)} | {apellidos[n].PadLeft(15)} | {legajos[n].ToString().PadLeft(5)} | {fechas[n].ToShortDateString()}| \n");
                }
            }
            else
            {
                for (int n = cantAlumnos - 1; n >= 0; n--)
                {
                    Console.Write($"{n} |{nombres[n].PadLeft(15)} | {apellidos[n].PadLeft(15)} | {legajos[n].ToString().PadLeft(5)} | {fechas[n].ToShortDateString()}| \n");
                }
            }
        }
    }

}
