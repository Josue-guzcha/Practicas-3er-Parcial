using System;
 
namespace MetodosOrdenamiento
{
    class SelectionSort
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 64, 25, 12, 22, 11 };
 
            Console.WriteLine("=== SELECTION SORT (Ordenamiento por Selección) ===\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo);
 
            Console.Write("Arreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        // ─────────────────────────────────────────────────────────────
        // SELECTION SORT
        // Para cada posición i del arreglo:
        //   - Busca el índice del elemento más pequeño
        //     en el resto del arreglo (desde i+1 hasta el final)
        //   - Si encontró uno menor, lo intercambia con a[i]
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a)
        {
            int n = a.Length;
 
            for (int i = 0; i < n - 1; i++)
            {
                // Asumir que el menor está en la posición actual
                int indiceMenor = i;
 
                // Buscar si hay alguno más pequeño en el resto
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < a[indiceMenor])
                        indiceMenor = j;
                }
 
                // Si encontró uno menor, intercambiar
                if (indiceMenor != i)
                {
                    int aux        = a[i];
                    a[i]           = a[indiceMenor];
                    a[indiceMenor] = aux;
                }
 
                // Mostrar el arreglo después de cada selección
                Console.Write($"  Paso {i + 1}: ");
                Imprimir(a);
            }
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 