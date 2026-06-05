using System;
using System.Collections.Generic;
 
namespace MetodosOrdenamiento
{
    class BalancedMultiwayMerging
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 15, 3, 22, 8, 47, 1, 30, 12 };
 
            Console.WriteLine("=== BALANCED MULTIWAY MERGING (Mezcla Múltiple Equilibrada) ===");
            Console.WriteLine("(Método Externo - simulado en memoria, 3 vías)\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo);
 
            Console.Write("\nArreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        // ─────────────────────────────────────────────────────────────
        // BALANCED MULTIWAY MERGING
        // Similar al Straight Merging pero mezcla K bloques a la vez:
        //   - K = 3 vías en este ejemplo
        //   - Pasada 1: mezcla bloques de tamaño 1 de 3 en 3
        //   - Pasada 2: mezcla bloques de tamaño 3 de 3 en 3
        //   - El tamaño crece K veces en cada pasada (no solo x2)
        // Ventaja: menos pasadas que el Straight Merging de 2 vías
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a)
        {
            int n      = a.Length;
            int k      = 3;    // Número de vías
            int size   = 1;    // Tamaño del bloque inicial
            int pasada = 1;
 
            while (size < n)
            {
                Console.WriteLine($"\n-- Pasada {pasada} (bloques de {size}, mezclando {k} a la vez) --");
                int pos = 0;
 
                while (pos < n)
                {
                    // Recopilar hasta K bloques para mezclar juntos
                    List<int[]> bloques = new List<int[]>();
 
                    for (int v = 0; v < k && pos < n; v++)
                    {
                        int inicio  = pos;
                        int fin     = Math.Min(pos + size, n);
                        int[] bloque = new int[fin - inicio];
                        Array.Copy(a, inicio, bloque, 0, fin - inicio);
                        bloques.Add(bloque);
                        pos = fin;
                    }
 
                    // Mezclar todos los bloques recopilados en uno
                    int[] mezclado = MezclarKBloques(bloques);
 
                    // Copiar el resultado de vuelta al arreglo
                    int destino = pos - mezclado.Length;
                    Array.Copy(mezclado, 0, a, destino, mezclado.Length);
 
                    Console.Write($"  Bloque mezclado: [ {string.Join(", ", mezclado)} ]");
                    Console.WriteLine();
                }
 
                Console.Write($"  Resultado: ");
                Imprimir(a);
 
                size   *= k; // El tamaño crece K veces por pasada
                pasada++;
            }
        }
 
        // ─────────────────────────────────────────────────────────────
        // MEZCLAR K BLOQUES
        // Recibe una lista de K bloques ya ordenados.
        // En cada paso selecciona el elemento menor entre todos
        // los bloques y lo agrega al resultado.
        // Repite hasta agotar todos los bloques.
        // ─────────────────────────────────────────────────────────────
        static int[] MezclarKBloques(List<int[]> bloques)
        {
            List<int> resultado = new List<int>();
            int[] indices = new int[bloques.Count];
 
            while (true)
            {
                int minVal = int.MaxValue;
                int minIdx = -1;
 
                // Buscar el menor elemento entre todos los bloques
                for (int i = 0; i < bloques.Count; i++)
                {
                    if (indices[i] < bloques[i].Length && bloques[i][indices[i]] < minVal)
                    {
                        minVal = bloques[i][indices[i]];
                        minIdx = i;
                    }
                }
 
                if (minIdx == -1) break; // Todos los bloques agotados
 
                resultado.Add(minVal);
                indices[minIdx]++;
            }
 
            return resultado.ToArray();
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 