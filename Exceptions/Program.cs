using System;
using System.Text;
using System.Collections.Generic;

using Exceptions;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Ingrese un número positivo mayor a 0 (cero): ");

        try
        {
            int numero = Int16.Parse(Console.ReadLine());
            if (esPositivo(numero))
            {
                Console.WriteLine("Valor correcto.");
            }
        }catch(FormatException){
            Console.WriteLine("El dato ingresado no es un número.");
        }
        catch (ValorNegativoException vne)
        {
            Console.WriteLine(vne.Message); //"El dato ingresado no es un número positivo."
        }
        finally
        {
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Comprueba que el valor sea un número positivo.
    /// </summary>
    /// <param name="numero">Valor entero que desea analizar</param>
    /// <returns>Verdadero si el valor es positivo</returns>
    private static bool esPositivo(int numero)
    {
        if (numero < 1) {
            throw new ValorNegativoException("El dato ingresado no es un número positivo.");
        }
        return true;
    }
}