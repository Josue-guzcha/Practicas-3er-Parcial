using System;
 
namespace MetodosOrdenamiento
{
    class QuickSort
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 64, 25, 12, 22, 11 };
 
            Console.WriteLine("=== QUICKSORT (Ordenamiento Rápido) ===\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo, 0, arreglo.Length - 1);
 
            Console.Write("\nArreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        // ─────────────────────────────────────────────────────────────
        // QUICKSORT
        // Si el subarreglo tiene más de un elemento:
        //   - Llama a Particion() para obtener el índice del pivote
        //   - Llama recursivamente a la mitad izquierda
        //   - Llama recursivamente a la mitad derecha
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a, int izquierda, int derecha)
        {
            if (izquierda < derecha)
            {
                // Obtener la posición final del pivote
                int indicePivote = Particion(a, izquierda, derecha);
 
                Console.Write($"  Pivote en [{indicePivote}]: ");
                Imprimir(a);
 
                // Ordenar la mitad izquierda (menores al pivote)
                Ordenar(a, izquierda, indicePivote - 1);
 
                // Ordenar la mitad derecha (mayores al pivote)
                Ordenar(a, indicePivote + 1, derecha);
            }
        }
 
        // ─────────────────────────────────────────────────────────────
        // PARTICION
        // Toma el último elemento como pivote.
        // Recorre el arreglo:
        //   - Si un elemento es menor o igual al pivote,
        //     lo mueve a la izquierda
        // Al final coloca el pivote en su posición correcta
        // y devuelve ese índice.
        // ─────────────────────────────────────────────────────────────
        static int Particion(int[] a, int izq, int der)
        {
            int pivote = a[der]; // Último elemento como pivote
            int i      = izq - 1;
 
            for (int j = izq; j < der; j++)
            {
                if (a[j] <= pivote)
                {
                    i++;
                    // Intercambio
                    int aux = a[i];
                    a[i]    = a[j];
                    a[j]    = aux;
                }
            }
 
            // Colocar el pivote en su posición correcta
            int tmp    = a[i + 1];
            a[i + 1]   = a[der];
            a[der]     = tmp;
 
            return i + 1;
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 