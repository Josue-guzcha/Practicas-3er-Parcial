using System;
 
namespace MetodosOrdenamiento
{
    class RadixSort
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 170, 45, 75, 90, 802, 24, 2, 66 };
 
            Console.WriteLine("=== RADIX SORT (Ordenamiento por Dígitos) ===\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo);
 
            Console.Write("\nArreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        // ─────────────────────────────────────────────────────────────
        // RADIX SORT
        // Encuentra el valor máximo para saber cuántos dígitos hay.
        // Luego aplica CountingSort para cada posición de dígito:
        //   exp = 1   → ordena por unidades
        //   exp = 10  → ordena por decenas
        //   exp = 100 → ordena por centenas
        //   ... y así hasta cubrir todos los dígitos del número mayor
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a)
        {
            // Encontrar el valor máximo
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
                if (a[i] > max) max = a[i];
 
            int pasada = 1;
 
            // Procesar dígito por dígito
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                Console.Write($"  Pasada {pasada} (exp={exp}): ");
                CountingSortPorDigito(a, exp);
                Imprimir(a);
                pasada++;
            }
        }
 
        // ─────────────────────────────────────────────────────────────
        // COUNTING SORT POR DÍGITO
        // Para el dígito en posición 'exp':
        //   - Cuenta cuántas veces aparece cada dígito (0-9)
        //   - Calcula las posiciones finales de cada dígito
        //   - Construye el arreglo ordenado por ese dígito
        //   - Copia el resultado al arreglo original
        // ─────────────────────────────────────────────────────────────
        static void CountingSortPorDigito(int[] a, int exp)
        {
            int n        = a.Length;
            int[] salida = new int[n];  // Arreglo temporal de salida
            int[] conteo = new int[10]; // Contador para dígitos 0-9
 
            // Contar ocurrencias de cada dígito en esta posición
            for (int i = 0; i < n; i++)
                conteo[(a[i] / exp) % 10]++;
 
            // Acumular posiciones: conteo[i] indica hasta qué posición
            // llegan los elementos con dígito i
            for (int i = 1; i < 10; i++)
                conteo[i] += conteo[i - 1];
 
            // Construir salida de derecha a izquierda (para estabilidad)
            for (int i = n - 1; i >= 0; i--)
            {
                int digito = (a[i] / exp) % 10;
                salida[conteo[digito] - 1] = a[i];
                conteo[digito]--;
            }
 
            // Copiar resultado al arreglo original
            for (int i = 0; i < n; i++)
                a[i] = salida[i];
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 