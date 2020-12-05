using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Red_final
{
    class Program
    {
        static void Main(string[] args)
        {
          
            Random azar = new Random();

          
            int[,] entradas = { { 1, 1 }, { 1, 0 }, { 0, 1 }, { 0, 0 } };
            int[] salidas = { 1, 0, 0, 0 };

           
            double P0 = azar.NextDouble();
            double P1 = azar.NextDouble();
            double U = azar.NextDouble();

            bool proceso = true;

            int iteracion = 0;

            double tasaAprende = 0.3;
            while (proceso)
            {
                iteracion++;
                proceso = false;

                for (int cont = 0; cont <= 3; cont++)
                {
                    double operacion = entradas[cont, 0] * P0 + entradas[cont, 1] * P1 + U;
                    int salidaEntera;
                    if (operacion > 0.7)
                        salidaEntera = 1;
                    else
                        salidaEntera = 0;

                    int error = salidas[cont] - salidaEntera;

                    if (error != 0)
                    {
                        P0 += tasaAprende * error * entradas[cont, 0];
                        P1 += tasaAprende * error * entradas[cont, 1];
                        U += tasaAprende * error * 1;
                        proceso = true;
                    }
                }
            }

            for (int cont = 0; cont <= 3; cont++)
            {
                double operacion = entradas[cont, 0] * P0 + entradas[cont, 1] * P1 + U;


                int salidaEntera;
                if (operacion > 0.7)
                    salidaEntera = 1;
                else
                    salidaEntera = 0;

                Console.WriteLine("Entradas: " + entradas[cont, 0].ToString() + " y " + entradas[cont, 1].ToString() + " = " +
                salidas[cont].ToString() + " perceptron: " + salidaEntera.ToString());
            }

            Console.WriteLine("Pesos encontrados P0= " + P0.ToString() + " P1= " + P1.ToString() + " U= " + U.ToString());
            Console.WriteLine("Iteraciones requeridas: " + iteracion.ToString());
            Console.ReadKey();
        }
    }
}

