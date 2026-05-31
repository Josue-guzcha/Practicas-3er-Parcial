using System;
 
namespace MetodosOrdenamiento
{
    class StraightMerging
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 15, 3, 22, 8, 47, 1, 30, 12 };
 
            Console.WriteLine("=== STRAIGHT MERGING (Mezcla Directa) ===");
            Console.WriteLine("(Método Externo - simulado en memoria)\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo);
 
            Console.Write("\nArreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        // ─────────────────────────────────────────────────────────────
        // STRAIGHT MERGING
        // Usa bloques de tamaño fijo que se duplican cada pasada:
        //   - Pasada 1: mezcla bloques de tamaño 1
        //   - Pasada 2: mezcla bloques de tamaño 2
        //   - Pasada 3: mezcla bloques de tamaño 4
        //   - ... hasta que el bloque sea mayor o igual al arreglo
        // En cada pasada recorre el arreglo mezclando pares de bloques
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a)
        {
            int n      = a.Length;
            int[] b    = new int[n]; // Buffer auxiliar
            int size   = 1;         // Tamaño del bloque inicial
            int pasada = 1;
 
            while (size < n)
            {
                Console.WriteLine($"\n-- Pasada {pasada} (bloques de tamaño {size}) --");
 
                // Mezclar bloques de tamaño 'size' de dos en dos
                for (int i = 0; i < n; i += size * 2)
                {
                    int izq   = i;
                    int medio = Math.Min(i + size, n);
                    int der   = Math.Min(i + size * 2, n);
 
                    MezclarRango(a, b, izq, medio, der);
                }
 
                Console.Write($"  Resultado: ");
                Imprimir(a);
 
                size   *= 2; // Duplicar tamaño del bloque
                pasada++;
            }
        }
 
        // ─────────────────────────────────────────────────────────────
        // MEZCLAR RANGO
        // Fusiona dos subarreglos adyacentes:
        //   [izq .. medio) y [medio .. der)
        // Los compara elemento por elemento y los coloca
        // en orden en el buffer b[], luego copia de vuelta a a[]
        // ─────────────────────────────────────────────────────────────
        static void MezclarRango(int[] a, int[] b, int izq, int medio, int der)
        {
            int i = izq, j = medio, k = izq;
 
            while (i < medio && j < der)
                b[k++] = (a[i] <= a[j]) ? a[i++] : a[j++];
 
            while (i < medio) b[k++] = a[i++];
            while (j < der)   b[k++] = a[j++];
 
            // Copiar resultado de vuelta al arreglo original
            for (int x = izq; x < der; x++) a[x] = b[x];
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 