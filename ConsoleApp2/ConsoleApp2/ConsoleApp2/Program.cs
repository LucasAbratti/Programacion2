using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seleccione un programa: [1] CombineStrings | [2] Fac | [3] Factorial");
            string seleccion = Console.ReadLine();
            
            int numero, resultado;
            string tempString;
            
            switch (seleccion)
            {
                case "1":
                    string apellido, nombre, an;
                    Console.WriteLine("Ingrese su apellido:");
                    apellido = Console.ReadLine();
                    Console.WriteLine("Ingrese su nombre:");
                    nombre = Console.ReadLine();

                    CombineStrings(apellido, nombre, out an);
                    Console.WriteLine($"{apellido} + {nombre} = {an}");
                    break;
                case "2":
                    do
                    {
                        Console.WriteLine("Ingrese el numero que desea calcular:");
                        tempString = Console.ReadLine();
                    } while (!int.TryParse(tempString, out numero));

                    try
                    {
                        Fac(numero, out resultado);
                        Console.WriteLine($"El factorial de {numero} es {resultado}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadKey();
                    break;
                case "3":
                    do
                    {
                        Console.WriteLine("Ingrese el numero que desea calcular:");
                        tempString = Console.ReadLine();
                    } while (!int.TryParse(tempString, out numero));

                    try
                    {
                        resultado = Factorial(numero);
                        Console.WriteLine($"El factorial de {numero} es {resultado}");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    Console.ReadKey();
                    break;
            }

            Console.ReadKey();
        }

        static void CombineStrings(string a, string b, out string an)
        {
            an = $"{a},{b}";
        }

        static void Fac(int n, out int result)
        {
            result = n;
            for (int i = n - 1; i > 0 ; i-- )
            {
                result *= i;
            }
        }

        static int Factorial(int n)
        {
            if (n > 1)
            {
                return n * Factorial(n - 1);
            }
            else if(n <= 1 && n >= 0)
            {
                return 1;
            }
            else
            {
                throw new Exception("El numero a calcular tiene que ser mayor que 0");
            }
        }
    }
}
