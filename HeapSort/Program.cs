using System;
 
namespace MetodosOrdenamiento
{
    class HeapSort
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 64, 25, 12, 22, 11 };
 
            Console.WriteLine("=== HEAPSORT (Ordenamiento de Árbol) ===\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo);
 
            Console.Write("Arreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        // ─────────────────────────────────────────────────────────────
        // HEAPSORT
        // Paso 1: Construir el Max-Heap
        //   - Reorganiza el arreglo para que el mayor quede en a[0]
        //   - Se hace desde la mitad hacia el inicio
        // Paso 2: Extraer elementos del heap
        //   - Intercambia la raíz (mayor) con el último elemento
        //   - Reduce el tamaño del heap en 1
        //   - Restaura la propiedad de heap (Heapify)
        //   - Repite hasta que el heap tenga 1 elemento
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a)
        {
            int n = a.Length;
 
            // Paso 1: Construir el Max-Heap
            Console.WriteLine("-- Construyendo Max-Heap --");
            for (int i = n / 2 - 1; i >= 0; i--)
                Heapify(a, n, i);
 
            Console.Write("Max-Heap: ");
            Imprimir(a);
 
            // Paso 2: Extraer elementos uno por uno
            Console.WriteLine("\n-- Extrayendo elementos --");
            for (int i = n - 1; i > 0; i--)
            {
                // Mover la raíz (el mayor) al final
                int aux = a[0];
                a[0]    = a[i];
                a[i]    = aux;
 
                // Restaurar heap en el arreglo reducido
                Heapify(a, i, 0);
 
                Console.Write($"  Paso {n - i}: ");
                Imprimir(a);
            }
        }
 
        // ─────────────────────────────────────────────────────────────
        // HEAPIFY
        // Ajusta el subárbol con raíz en índice 'i' para que
        // cumpla la propiedad de Max-Heap:
        //   - El padre siempre debe ser mayor que sus hijos
        // Si encuentra un hijo mayor, intercambia y sigue bajando
        // ─────────────────────────────────────────────────────────────
        static void Heapify(int[] a, int n, int i)
        {
            int mayor = i;       // Asumir que la raíz es el mayor
            int izq   = 2*i + 1; // Índice hijo izquierdo
            int der   = 2*i + 2; // Índice hijo derecho
 
            // ¿El hijo izquierdo es mayor que la raíz?
            if (izq < n && a[izq] > a[mayor])
                mayor = izq;
 
            // ¿El hijo derecho es mayor que el actual mayor?
            if (der < n && a[der] > a[mayor])
                mayor = der;
 
            // Si la raíz no era el mayor, intercambiar y seguir bajando
            if (mayor != i)
            {
                int aux  = a[i];
                a[i]     = a[mayor];
                a[mayor] = aux;
 
                Heapify(a, n, mayor); // Recursivo hacia abajo
            }
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 

