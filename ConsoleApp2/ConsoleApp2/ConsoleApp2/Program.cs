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
            Console.WriteLine("Seleccione un programa: [1] CombineStrings | [2] Fac | [3] Factorial | [4] Juego | [5] Messi");
            string seleccion = Console.ReadLine();
            
            int numero, resultado, numeroB, numeroC;
            string tempString;
            string pasos = "";

            Console.Clear();

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

                    Fac(numero, out resultado);
                    Console.WriteLine($"El factorial de {numero} es {resultado}");
                    
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
                case "4":
                    do
                    {
                        Console.WriteLine("Ingrese el valor para la variable A:");
                        tempString = Console.ReadLine();
                    } while (!int.TryParse(tempString, out numero));
                    do
                    {
                        Console.WriteLine("Ingrese el valor para la variable B:");
                        tempString = Console.ReadLine();
                    } while (!int.TryParse(tempString, out numeroB));
                    do
                    {
                        Console.WriteLine("Ingrese el valor para la variable C:");
                        tempString = Console.ReadLine();
                    } while (!int.TryParse(tempString, out numeroC));

                    resultado = Juego(numero, numeroB, numeroC, ref pasos);
                    Console.WriteLine($"El resultado entre {numero} , {numeroB}, {numero} es {resultado}\n\n{pasos}");
                    break;
                case "5":
                    do
                    {
                        Console.WriteLine("Ingrese el valor para la variable Suarez:");
                        tempString = Console.ReadLine();
                    } while (!int.TryParse(tempString, out numero));
                    do
                    {
                        Console.WriteLine("Ingrese el valor para la variable Dibu:");
                        tempString = Console.ReadLine();
                    } while (!int.TryParse(tempString, out numeroB));
                    do
                    {
                        Console.WriteLine("Ingrese el valor para la variable De Paul:");
                        tempString = Console.ReadLine();
                    } while (!int.TryParse(tempString, out numeroC));

                    resultado = Messi(numero, numeroB, numeroC, ref pasos);
                    Console.WriteLine($"El resultado entre {numero} , {numeroB}, {numero} es {resultado}\n\n{pasos}");
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

        static int Juego(int a, int b, int c, ref string pasosJuego)
        {
            pasosJuego += $"{a.ToString().PadLeft(4)} {b.ToString().PadLeft(4)} {c.ToString().PadLeft(4)} |\n";
            if (a + c > b)
            {
                return a + Juego(a - 2, c, b, ref pasosJuego);
            }
            else
            {
                return a + c;
            }
        }

        static int Messi(int suarez, int dibu, int depaul, ref string pasosMessi)
        {
            pasosMessi += $"{suarez.ToString().PadLeft(4)} {dibu.ToString().PadLeft(4)} {depaul.ToString().PadLeft(4)} |\n";
            if (suarez - depaul > 2)
            {
                return Messi(dibu - 1, depaul - 2, suarez, ref pasosMessi);
            }
            else
            {
                return depaul;
            }
        }
    }
}
