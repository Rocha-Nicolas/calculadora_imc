using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_de_IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string resp = null;
            // Declarar dos Listas
            //-Bajo peso
            List<string> nombres_bajoPeso = new List<string>();
            List<float> imc_bajoPeso= new List<float>();
            //-Peso saludable
            List<string> nombres_pesoSaludable = new List<string>();
            List<float> imc_pesoSaludable = new List<float>();
            //-Sobrepeso
            List<string> nombres_sobrepeso = new List<string>();
            List<float> imc_sobrepeso = new List<float>();
            //-obesidad
            List<string> nombres_obesidad = new List<string>();
            List<float> imc_obesidad = new List<float>();

            //-----Programa-----//

            while (resp != "no")
            {
                //-----Declaracion de variables del while-------
                float peso = 0;
                float altura = 0;
              
                //-------Ingreso de Datos---------

                // Solicitar al usuario que ingrese el nombre del paciente 
                Console.Write("Por favor, ingrese el nombre del paciente: ");
                string nombre = Console.ReadLine();

                // Solicitar al usuario que ingrese su peso en kilogramos
                do {
                    Console.Write("Por favor, ingrese su peso en kilogramos: ");
                    resp = Console.ReadLine();
                    if (esEntero(resp))
                        peso = float.Parse(resp);
                    else Console.WriteLine("Error, Peso ingresado incorrectamente");
                } while (peso <= 0);

                // Solicitar al usuario que ingrese su altura en centimetros
                do{
                    Console.Write("Por favor, ingrese su altura en centimetros: ");
                    resp = Console.ReadLine();
                    if (esEntero(resp))
                        altura = float.Parse(resp);
                    else Console.WriteLine("Error, altura ingresado incorrectamente");
                } while (altura <= 0);

                //------Proceso de datos ingresados 

                // Convertir la altura de centímetros a metros
                altura = altura / 100;

                // Calcular el IMC
                float imc = peso / (altura * altura);

                // Evaluar el resultado del IMC y guardar en su lista correspondiente 
                if (imc < 18.5)
                {
                    nombres_bajoPeso.Add(nombre);
                    imc_bajoPeso.Add(imc);
                }
                else if (18.5 <= imc && imc < 25)
                {
                    nombres_pesoSaludable.Add(nombre);
                    imc_pesoSaludable.Add(imc);
                }
                else if (imc >= 25 && imc < 30)
                {
                    nombres_sobrepeso.Add(nombre);
                    imc_sobrepeso.Add(imc);
                }
                else
                {
                    nombres_obesidad.Add(nombre);
                    imc_obesidad.Add(imc);
                }

                // Solicitar al usuario si desea ingresar otro paciente
                while (resp != "si" && resp != "no")
                {
                    Console.WriteLine("Desea ingresar otro paciente?: Si/No");
                    resp = Console.ReadLine().ToLower();
                    if (resp != "si" && resp != "no")
                        Console.WriteLine("Respuesta incorrecta");
                }
            }
            //------Muestra resultados de los pacientes
            Console.WriteLine("---Resultados de Pacientes: ---");

            if (nombres_bajoPeso.Count != 0)
            {
                Console.WriteLine("Los paceitnes con bajo peso son: ");

                for (int i = 0; i < nombres_bajoPeso.Count; i++)
                {
                    Console.WriteLine("Nombre: " + nombres_bajoPeso[i]);
                    Console.WriteLine("IMC: " + imc_bajoPeso[i].ToString("00.00"));
                    Console.WriteLine("---");
                }
                Console.WriteLine("------------------");
            }

            if (nombres_pesoSaludable.Count != 0)
            {
                Console.WriteLine("Los paceitnes con peso saludable son: ");

                for (int i = 0; i < nombres_pesoSaludable.Count; i++)
                {
                    Console.WriteLine("Nombre: " + nombres_pesoSaludable[i]);
                    Console.WriteLine("IMC: " + imc_pesoSaludable[i].ToString("00.00"));
                    Console.WriteLine("---");
                }
                Console.WriteLine("------------------");
            }

            if (nombres_sobrepeso.Count != 0)
            {
                Console.WriteLine("Los paceitnes con sobrepeso son: ");

                for (int i = 0; i < nombres_sobrepeso.Count; i++)
                {
                    Console.WriteLine("Nombre: " + nombres_sobrepeso[i]);
                    Console.WriteLine("IMC: " + imc_sobrepeso[i].ToString("00.00"));
                    Console.WriteLine("---");
                }
                Console.WriteLine("------------------");
            }

            if (nombres_obesidad.Count != 0)
            {
                Console.WriteLine("Los paceitnes con obesidad son: ");

                for (int i = 0; i < nombres_obesidad.Count; i++)
                {
                    Console.WriteLine("Nombre: "+ nombres_obesidad[i]);
                    Console.WriteLine("IMC: " + imc_obesidad[i].ToString("00.00"));
                    Console.WriteLine("---");
                }
                Console.WriteLine("------------------");
            }

            // Esperar a que el usuario presione una tecla para salir
            Console.ReadKey();
        }

        static bool esEntero(string valor)
        {
            int numero;
            if (int.TryParse(valor, out numero))
            {
                if (numero > 0)
                    return true;
                else return false;
            }
            else
            {
                return false;
            }
        }

    }
}
