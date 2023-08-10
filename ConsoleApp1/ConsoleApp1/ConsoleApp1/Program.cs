using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string tempString;
            int cantAlumnos;
            do
            {
                Console.Clear();
                Console.WriteLine("Cuantos alumnos quere ingresar?");
                tempString = Console.ReadLine();
            } while (!int.TryParse(tempString, out cantAlumnos));

            string[] nombres = new string[cantAlumnos];
            string[] apellidos = new string[cantAlumnos];
            int[] legajos = new int[cantAlumnos];
            DateTime[] fechas = new DateTime[cantAlumnos];

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
            DibujarTabla(nombres, apellidos, legajos, fechas);
            Console.ReadKey();
        }

        static void BubbleSort(string[] nombres, string[] apellidos, int[] legajos, DateTime[] fechas)
        {
            string tempS;
            int tempI;
            DateTime tempDate;
            for(int i = 0; i < legajos.Length; i++)
            {

            }

        }

        static void DibujarTabla(string[] nombres, string[] apellidos, int[] legajos, DateTime[] fechas)
        {
            int cantAlumnos = legajos.Length;
            for(int i = 0; i < cantAlumnos; i++)
            {
                for (int n = 0; n < cantAlumnos; n++)
                {
                    Console.Write($"{n + i} |{nombres[n].PadLeft(15)} | {apellidos[n].PadLeft(15)} | {legajos[n].ToString().PadLeft(5)} | {fechas[n].ToString()}| \n");
                }
            }
        }
    }

}
