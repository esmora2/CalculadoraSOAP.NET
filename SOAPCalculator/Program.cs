using SOAPCalculator.CalculatorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SOAPCalculator
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Crear el endpoint
            BasicHttpBinding binding = new BasicHttpBinding();
            EndpointAddress endpoint = new EndpointAddress("http://www.dneonline.com/calculator.asmx");

            // Crear el cliente del servicio
            CalculatorSoapClient client = new CalculatorSoapClient(binding, endpoint);

            while (true)
            {
                Console.WriteLine("\nCalculadora SOAP");
                Console.WriteLine("1. Sumar");
                Console.WriteLine("2. Restar");
                Console.WriteLine("3. Multiplicar");
                Console.WriteLine("4. Dividir");
                Console.WriteLine("5. Salir");
                Console.Write("\nSeleccione una opción: ");

                string opcion = Console.ReadLine();
                if (opcion == "5") break;

                Console.Write("Ingrese el primer número: ");
                int num1 = int.Parse(Console.ReadLine());
                Console.Write("Ingrese el segundo número: ");
                int num2 = int.Parse(Console.ReadLine());

                try
                {
                    int resultado = 0;
                    switch (opcion)
                    {
                        case "1":
                            resultado = client.Add(num1, num2);
                            Console.WriteLine($"Resultado de la suma: {resultado}");
                            break;
                        case "2":
                            resultado = client.Subtract(num1, num2);
                            Console.WriteLine($"Resultado de la resta: {resultado}");
                            break;
                        case "3":
                            resultado = client.Multiply(num1, num2);
                            Console.WriteLine($"Resultado de la multiplicación: {resultado}");
                            break;
                        case "4":
                            if (num2 == 0)
                            {
                                Console.WriteLine("Error: No se puede dividir por cero");
                                break;
                            }
                            resultado = client.Divide(num1, num2);
                            Console.WriteLine($"Resultado de la división: {resultado}");
                            break;
                        default:
                            Console.WriteLine("Opción no válida");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
