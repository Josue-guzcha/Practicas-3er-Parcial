using System;
using System.Diagnostics; // Para medir el tiempo de ejecución
 
namespace MetodosOrdenamiento
{
    class InsertionSort
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 64, 25, 12, 22, 11 };
 
            Console.WriteLine("=== INSERTION SORT (Ordenamiento por Inserción) ===\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo);
 
            Console.Write("Arreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        // ─────────────────────────────────────────────────────────────
        // INSERTION SORT
        // Para cada elemento desde la posición 1 en adelante:
        //   - Lo guarda en una variable temporal (temp)
        //   - Mueve hacia la derecha todos los elementos anteriores
        //     que sean mayores que temp
        //   - Inserta temp en el hueco que quedó
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] array)
        {
            Stopwatch cronometro = new Stopwatch();
            cronometro.Start();
 
            for (int i = 1; i < array.Length; i++)
            {
                int temp = array[i]; // Elemento actual a insertar
                int j    = i - 1;
 
                // Mover elementos mayores que temp una posición a la derecha
                while ((j >= 0) && (array[j] > temp))
                {
                    array[j + 1] = array[j];
                    j--;
                }
 
                // Insertar temp en su posición correcta
                array[j + 1] = temp;
 
                // Mostrar el arreglo después de cada inserción
                Console.Write($"  Paso {i}: ");
                Imprimir(array);
            }
 
            cronometro.Stop();
            Console.WriteLine($"\nTiempo de ejecución: {cronometro.Elapsed.TotalMilliseconds} ms");
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 