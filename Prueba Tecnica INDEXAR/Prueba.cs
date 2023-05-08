using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Tecnica_INDEXAR
{
    class Prueba
    {
        static void Main(string[] args)
        {

            int opcion;

            do
            {
                Console.WriteLine("---- Menú ----");
                Console.WriteLine("1. Ejercicio 1");
                Console.WriteLine("2. Ejercicio 2");
                Console.WriteLine("3. Ejercicio 3");
                Console.WriteLine("4. Ejercicio 4");
                Console.WriteLine("5. Ejercicio 5");
                Console.WriteLine("6. Salir");
                Console.Write("Ingrese una opción: ");


                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:

                        Console.WriteLine("--- Ejercicio 1 ---");
                        Console.WriteLine("Ingrese una palabra: ");
                        string palabra = Console.ReadLine();

                        esPalindromo(palabra);
                        break;

                    case 2:

                        Console.WriteLine("--- Ejercicio 2 ---");

                        Console.WriteLine("Ingrese un numero: ");
                        string limit = Console.ReadLine();
                        Fibonacci(int.Parse(limit));
                        break;

                    case 3:

                        Console.WriteLine("--- Ejercicio 3 ---");
                        string expresion = "5 1 2 + 4 * + 3 -";
                        Console.WriteLine("Resultado: " + EvaluarNotacionPolaca(expresion));

                        break;

                    case 4:

                        Console.WriteLine("--- Ejercicio 4 ---");

                        double a = 1;
                        double b = -3;
                        double c = 2;

                        double[] soluciones = CalcularEcuacionCuadratica(a, b, c);

                        Console.WriteLine("Las soluciones de la ecuación " + a + "x^2 + " + b + "x + " + c + " son: ");
                        Console.WriteLine("x1 = " + soluciones[0]);
                        Console.WriteLine("x2 = " + soluciones[1]);

                        break;

                    case 5:

                        Console.WriteLine("--- Ejercicio 5 ---");

                        Console.WriteLine("Ingrese el peso: ");
                        string peso = Console.ReadLine();

                        Console.WriteLine("Ingrese la altura: ");
                        string altura = Console.ReadLine();

                        CalcularIMC(Convert.ToDouble(peso), Convert.ToDouble(altura));

                        break;

                    case 6:

                        Console.WriteLine("Gracias por usar el programa.");
                        break;

                    default:
                        break;
                }

            } while (opcion != 6);

        }

        public static bool esPalindromo(string palabra)
        {
            int longitud = palabra.Length;
            for (int i = 0; i < longitud / 2; i++)
            {
                if (palabra[i] != palabra[longitud - i - 1])
                {
                    Console.WriteLine("La palabra no es Polindromo");
                    return false;

                }
            }
            Console.WriteLine("La palabra es Polindromo");
            return true;

        }

        public static void Fibonacci(int limite)
        {
            int a = 0;
            int b = 1;
            int c = 0;

            Console.Write(a + " " + b + " ");

            for (int i = 2; i < limite; i++)
            {
                c = a + b;
                Console.Write(c + " ");
                a = b;
                b = c;
            }
        }


        public static int EvaluarNotacionPolaca(string expresion)
        {
            string[] elementos = expresion.Split(' ');
            Stack<int> pila = new Stack<int>();

            foreach (string elemento in elementos)
            {
                int valor;
                if (Int32.TryParse(elemento, out valor))
                {
                    pila.Push(valor);
                }
                else
                {
                    int operando2 = pila.Pop();
                    int operando1 = pila.Pop();

                    switch (elemento)
                    {
                        case "+":
                            pila.Push(operando1 + operando2);
                            break;
                        case "-":
                            pila.Push(operando1 - operando2);
                            break;
                        case "*":
                            pila.Push(operando1 * operando2);
                            break;
                        case "/":
                            pila.Push(operando1 / operando2);
                            break;
                    }
                }
            }

            return pila.Pop();
        }

        public static double[] CalcularEcuacionCuadratica(double a, double b, double c)
        {
            //Primero, se calcula el discriminante b^2 - 4ac.
            double discriminante = b * b - 4 * a * c;


            //Si el discriminante es negativo, la ecuación no tiene soluciones reales y se devuelve un arreglo con dos valores NaN
            if (discriminante < 0)
            {
                // La ecuación no tiene soluciones reales
                return new double[] { double.NaN, double.NaN };
            }
            else if (discriminante == 0)
            {
                // La ecuación tiene una única solución real
                double x = -b / (2 * a);
                return new double[] { x, x };
            }
            else
            {
                // La ecuación tiene dos soluciones reales distintas
                double x1 = (-b + Math.Sqrt(discriminante)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminante)) / (2 * a);
                return new double[] { x1, x2 };
            }
        }

        public static double CalcularIMC(double peso, double altura)
        {
            // Calcula el IMC dividiendo el peso en kg por el cuadrado de la altura en metros
            double alturaMetros = altura / 100.0;
            double imc = peso / (alturaMetros * alturaMetros);

            Console.WriteLine("Su IMC es: " + imc);
            

            if (imc < 18)
            {
                Console.WriteLine("Su clasificacion es: Bajo Peso. Necesario valorar signos de desnutricion");
            }
            if(imc > 18 && imc < 24.9)
            {
                Console.WriteLine("Su clasificacion es: Normal");
            }
            if (imc > 25 && imc < 26.9) 
            {
                Console.WriteLine("Su clasificacion es: Sobrepeso");
            }
            if (imc > 27 && imc < 29.9)
            {
                Console.WriteLine("Su clasificacion es: Obesidad grado I. Riesgo relativo alto para desarrollar enfermedades cardiovasculares");
            }
            if (imc > 30 && imc < 39.9)
            {
                Console.WriteLine("Su clasificacion es: Obesidad grado II. Riesgo relativo muy alto para desarrollar enfermedades cardiovasculares");
            }
            if (imc > 40)
            {
                Console.WriteLine("Su clasificacion es: Obesidad grado III Extrema o morbida. Riesgo relativo extremadamente alto para desarrollar enfermedades cardiovasculares");
            }


            return imc;
        }

    }
}
