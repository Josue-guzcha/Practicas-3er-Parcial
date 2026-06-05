using System;
 
namespace MetodosOrdenamiento
{
    class Intercambio
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 64, 25, 12, 22, 11 };
 
            Console.WriteLine("=== INTERCAMBIO (BubbleSort / Ordenamiento Burbuja) ===\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo);
 
            Console.Write("Arreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        // ─────────────────────────────────────────────────────────────
        // INTERCAMBIO - BUBBLE SORT
        // Recorre el arreglo comparando pares adyacentes:
        //   - Si a[j] > a[j+1] → los intercambia
        // En cada pasada completa, el número más grande
        // "burbujea" hasta su posición final al final del arreglo.
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a)
        {
            int n   = a.Length;
            int aux;
 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        // Intercambio de posiciones
                        aux      = a[j];
                        a[j]     = a[j + 1];
                        a[j + 1] = aux;
                    }
                }
 
                // Mostrar el arreglo después de cada pasada completa
                Console.Write($"  Pasada {i + 1}: ");
                Imprimir(a);
            }
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 