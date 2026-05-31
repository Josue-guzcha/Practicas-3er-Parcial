using System;
 
namespace MetodosOrdenamiento
{
    class MergeSort
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 64, 25, 12, 22, 11 };
 
            Console.WriteLine("=== MERGESORT (Ordenamiento por Mezcla) ===\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo, 0, arreglo.Length - 1);
 
            Console.Write("\nArreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        // ─────────────────────────────────────────────────────────────
        // MERGESORT
        // Si el subarreglo tiene más de un elemento:
        //   - Calcula el punto medio
        //   - Ordena recursivamente la mitad izquierda
        //   - Ordena recursivamente la mitad derecha
        //   - Fusiona ambas mitades ya ordenadas
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a, int inicio, int fin)
        {
            if (inicio < fin)
            {
                int medio = (inicio + fin) / 2;
 
                // Dividir y ordenar cada mitad
                Ordenar(a, inicio, medio);
                Ordenar(a, medio + 1, fin);
 
                // Fusionar las dos mitades ordenadas
                Fusionar(a, inicio, medio, fin);
 
                Console.Write($"  Fusión [{inicio}..{fin}]: ");
                Imprimir(a);
            }
        }
 
        // ─────────────────────────────────────────────────────────────
        // FUSIONAR
        // Recibe dos mitades adyacentes ya ordenadas y las combina:
        //   - Copia cada mitad en arreglos temporales
        //   - Compara elemento por elemento
        //   - Coloca el menor de vuelta en el arreglo original
        //   - Copia los elementos restantes que quedaron
        // ─────────────────────────────────────────────────────────────
        static void Fusionar(int[] a, int inicio, int medio, int fin)
        {
            int n1 = medio - inicio + 1;
            int n2 = fin - medio;
 
            // Arreglos temporales para cada mitad
            int[] izq = new int[n1];
            int[] der = new int[n2];
 
            // Copiar datos a los temporales
            for (int i = 0; i < n1; i++) izq[i] = a[inicio + i];
            for (int j = 0; j < n2; j++) der[j] = a[medio + 1 + j];
 
            // Fusionar comparando elemento por elemento
            int k = inicio, x = 0, y = 0;
 
            while (x < n1 && y < n2)
            {
                if (izq[x] <= der[y]) a[k++] = izq[x++];
                else                  a[k++] = der[y++];
            }
 
            // Copiar los elementos restantes de cada mitad
            while (x < n1) a[k++] = izq[x++];
            while (y < n2) a[k++] = der[y++];
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 