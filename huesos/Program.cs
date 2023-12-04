using System;
using System.IO;
using System.Linq;

class Hueso
{
    public string Nombre { get; set; }
    public double Peso { get; set; }
    public double Densidad { get; set; }
    public double Longitud { get; set; }
    public double Diametro { get; set; }

    public Hueso(string nombre, double peso, double densidad, double longitud, double diametro)
    {
        Nombre = nombre;
        Peso = peso;
        Densidad = densidad;
        Longitud = longitud;
        Diametro = diametro;
    }
}

class Esqueleto
{
    Hueso[] huesos = new Hueso[206];

    public void CargarDatos()
    {
        // Código para inicializar los 206 huesos
        //...
        huesos[0] = new Hueso("Fémur", 1.5, 2.0, 45, 3);
        huesos[1] = new Hueso("Tibia", 1.1, 1.8, 39, 2);
        huesos[2] = new Hueso("Peroné", 0.8, 1.7, 36, 1.5);

        // Add more dummy bones
        huesos[3] = new Hueso("Húmero", 1.3, 1.9, 32, 2.5);
        huesos[4] = new Hueso("Cúbito", 0.9, 1.6, 28, 2);
        huesos[5] = new Hueso("Radio", 0.7, 1.5, 26, 1);

        // Initialize remaining bones with random dummy data
        Random rnd = new Random();
        for (int i = 6; i < huesos.Length; i++)
        {
            huesos[i] = new Hueso("Hueso " + (i + 1),
                               rnd.NextDouble() * 2,
                               rnd.NextDouble() * 3,
                               rnd.Next(5, 50),
                               rnd.NextDouble() * 5);
        }


    }

    public void Ordenar(string criterio)
    {
        if (criterio == "nombre")
        {
            Array.Sort(huesos, CompararPorNombre);
        }
        else if (criterio == "peso")
        {
            Array.Sort(huesos, CompararPorPeso);
        }
        else if (criterio == "densidad")
        {
            Array.Sort(huesos, CompararPorDensidad);
        }
        //else if (criterio == "longitud")
        //{
        //    Array.Sort(huesos, CompararPorLongitud);
        //}
        //else if (criterio == "diametro")
        //{
        //    Array.Sort(huesos, CompararPorDiametro);
        //}
    }

    public void Imprimir()
    {
        foreach (Hueso h in huesos)
        {
            Console.WriteLine(h.Nombre + " " + h.Peso + " " + h.Densidad + " " + h.Longitud + " " + h.Diametro);
        }
    }

    public void Exportar(string rutaArchivo, string criterio)
    {
        Ordenar(criterio);
        using (StreamWriter archivo = new StreamWriter(rutaArchivo))
        {
            foreach (Hueso h in huesos)
            {
                archivo.WriteLine(h.Nombre + ";" + h.Peso + ";" + h.Densidad + ";" + h.Longitud + ";" + h.Diametro);
            }
        }
    }

    // Métodos para comparar por criterio
    int CompararPorNombre(Hueso x, Hueso y)
    {
        return x.Nombre.CompareTo(y.Nombre);
    }

    int CompararPorPeso(Hueso x, Hueso y)
    {
        return x.Peso.CompareTo(y.Peso);
    }
    int CompararPorDensidad(Hueso x, Hueso y)
    {
        return x.Densidad.CompareTo(y.Densidad);
    }

    // Otros métodos de comparación...   
    // agregar preguntar el folder donde debe dejar el archivo 
    // imprimir el resultado y tareas que esta haciendo
}

public class Program
{
    public static void Main()
    {
        Esqueleto esqueleto = new Esqueleto();
        esqueleto.CargarDatos();
        esqueleto.Ordenar("nombre");
        esqueleto.Exportar("d:\\video\\esqueleto_ordenado.txt", "peso");
    }
}
