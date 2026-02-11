using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int cantidad = SolicitarNumero("Cantidad de personas (mínimo 1): ", 1);

        List<string> nombres = new List<string>();
        List<int> edades = new List<int>();

        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine($"\nPersona {i + 1}:");
            Console.Write("Nombre: ");
            nombres.Add(Console.ReadLine()?.Trim() ?? "Sin nombre");
            edades.Add(SolicitarNumero("Edad: ", 0, 120));
        }

        Console.WriteLine("\n" + new string('=', 40));

        if (cantidad == 1)
        {
            Console.WriteLine($"Nombre: {nombres[0]}");
            Console.WriteLine($"Edad: {edades[0]}");
            Console.WriteLine($"Es {(edades[0] >= 18 ? "MAYOR" : "MENOR")} de edad");
        }
        else
        {
            Console.WriteLine("LISTA GENERAL:");
            MostrarLista(nombres, edades);

            List<string> mayoresNombres = new List<string>();
            List<int> mayoresEdades = new List<int>();
            List<string> menoresNombres = new List<string>();
            List<int> menoresEdades = new List<int>();

            for (int i = 0; i < cantidad; i++)
            {
                if (edades[i] >= 18)
                {
                    mayoresNombres.Add(nombres[i]);
                    mayoresEdades.Add(edades[i]);
                }
                else
                {
                    menoresNombres.Add(nombres[i]);
                    menoresEdades.Add(edades[i]);
                }
            }

            if (mayoresNombres.Count > 0)
            {
                Console.WriteLine("\nMAYORES DE EDAD:");
                MostrarLista(mayoresNombres, mayoresEdades);
            }

            if (menoresNombres.Count > 0)
            {
                Console.WriteLine("\nMENORES DE EDAD:");
                MostrarLista(menoresNombres, menoresEdades);
            }
        }

        Console.WriteLine("\nFin del programa");
    }

    static int SolicitarNumero(string mensaje, int min = int.MinValue, int max = int.MaxValue)
    {
        int numero;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out numero) && numero >= min && numero <= max)
                return numero;
            Console.WriteLine($"Error: Ingrese un número entre {min} y {max}");
        }
    }

    static void MostrarLista(List<string> nombres, List<int> edades)
    {
        Console.WriteLine(new string('-', 30));
        for (int i = 0; i < nombres.Count; i++)
            Console.WriteLine($"{nombres[i],-15} {edades[i]} años");
    }
}
