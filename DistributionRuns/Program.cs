using System;
using System.Collections.Generic;
 
namespace MetodosOrdenamiento
{
    class DistributionOfInitialRuns
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 15, 3, 22, 8, 47, 1, 30, 12 };
 
            Console.WriteLine("=== DISTRIBUTION OF INITIAL RUNS ===");
            Console.WriteLine("    (Distribución de Corridas Iniciales)");
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
        // DISTRIBUTION OF INITIAL RUNS
        // Usa "Reemplazo por Selección" para generar corridas:
        //   1. Carga una ventana de H elementos y la ordena
        //   2. Toma el menor de la ventana
        //      - Si es >= al último escrito → sigue en la misma corrida
        //      - Si es <  al último escrito → nueva corrida, otra cinta
        //   3. Reemplaza ese elemento con el siguiente de la entrada
        //   4. Repite hasta procesar todos los elementos
        // Luego mezcla las cintas para obtener el resultado final
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a)
        {
            int n         = a.Length;
            int tamVentana = Math.Min(4, n); // Ventana de 4 elementos
 
            // ── Paso 1: Inicializar la ventana ──────────────────────
            List<int> ventana = new List<int>();
            for (int i = 0; i < tamVentana; i++)
                ventana.Add(a[i]);
            ventana.Sort();
 
            Console.WriteLine($"-- Ventana inicial (tamaño {tamVentana}) --");
            Console.WriteLine("  [ " + string.Join(", ", ventana) + " ]");
 
            // ── Paso 2: Distribuir en cintas con reemplazo ──────────
            List<List<int>> cintas = new List<List<int>>()
            {
                new List<int>(),
                new List<int>()
            };
 
            int entrada       = tamVentana; // Siguiente elemento a leer
            int cintaDest     = 0;          // Cinta destino actual
            int ultimoEscrito = -1;         // Último valor escrito
            int numCorrida    = 1;
 
            Console.WriteLine("\n-- Distribuyendo corridas --");
 
            while (ventana.Count > 0)
            {
                int minVal = ventana[0]; // El menor de la ventana
 
                if (minVal >= ultimoEscrito)
                {
                    // Continúa la corrida actual
                    cintas[cintaDest].Add(minVal);
                    ultimoEscrito = minVal;
                }
                else
                {
                    // Nueva corrida → cambiar de cinta
                    numCorrida++;
                    cintaDest     = (cintaDest + 1) % 2;
                    cintas[cintaDest].Add(minVal);
                    ultimoEscrito = minVal;
                    Console.WriteLine($"  → Nueva corrida {numCorrida} en Cinta {cintaDest + 1}");
                }
 
                ventana.RemoveAt(0);
 
                // Leer el siguiente elemento de la entrada
                if (entrada < n)
                {
                    ventana.Add(a[entrada++]);
                    ventana.Sort();
                }
            }
 
            Console.Write("\n  Cinta 1: "); Console.WriteLine("[ " + string.Join(", ", cintas[0]) + " ]");
            Console.Write("  Cinta 2: "); Console.WriteLine("[ " + string.Join(", ", cintas[1]) + " ]");
 
            // ── Paso 3: Mezclar las cintas para el resultado final ──
            Console.WriteLine("\n-- Mezclando cintas --");
            List<int> resultado = MezclarCintas(cintas[0], cintas[1]);
            Console.WriteLine("  [ " + string.Join(", ", resultado) + " ]");
 
            for (int i = 0; i < n; i++) a[i] = resultado[i];
        }
 
        // Mezcla dos listas ordenadas en una sola ordenada
        static List<int> MezclarCintas(List<int> c1, List<int> c2)
        {
            List<int> resultado = new List<int>();
            int i = 0, j = 0;
 
            while (i < c1.Count && j < c2.Count)
                resultado.Add(c1[i] <= c2[j] ? c1[i++] : c2[j++]);
 
            while (i < c1.Count) resultado.Add(c1[i++]);
            while (j < c2.Count) resultado.Add(c2[j++]);
 
            return resultado;
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
