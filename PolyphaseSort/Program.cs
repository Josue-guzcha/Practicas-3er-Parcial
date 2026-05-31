using System;
using System.Collections.Generic;
 
namespace MetodosOrdenamiento
{
    class PolyphaseSort
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 15, 3, 22, 8, 47, 1, 30, 12 };
 
            Console.WriteLine("=== POLYPHASE SORT (Ordenamiento Polifásico) ===");
            Console.WriteLine("(Método Externo - simulado en memoria)\n");
            Console.Write("Arreglo inicial: ");
            Imprimir(arreglo);
 
            Ordenar(arreglo);
 
            Console.Write("\nArreglo ordenado: ");
            Imprimir(arreglo);
 
            Console.WriteLine("\nPresiona cualquier tecla para salir...");
            Console.ReadKey();
        }
 
        static void Ordenar(int[] a)
        {
            int n = a.Length;
            if (n <= 1) return;
 
            // Paso 1: Generar corridas y distribuirlas en 2 listas
            List<Queue<int>> cintas = new List<Queue<int>>()
            {
                new Queue<int>(),
                new Queue<int>()
            };
 
            Console.WriteLine("-- Paso 1: Distribuyendo corridas --");
            int cintaActual = 0;
            int i = 0;
 
            while (i < n)
            {
                // Recoger una corrida natural
                List<int> corrida = new List<int>();
                corrida.Add(a[i]);
                while (i < n - 1 && a[i] <= a[i + 1])
                {
                    i++;
                    corrida.Add(a[i]);
                }
                i++;
 
                // Encolar la corrida completa como bloque
                foreach (int v in corrida)
                    cintas[cintaActual].Enqueue(v);
                cintas[cintaActual].Enqueue(int.MaxValue); // Fin de corrida
 
                cintaActual = (cintaActual + 1) % 2;
            }
 
            Console.Write("  Cinta 0: "); ImprimirCinta(cintas[0]);
            Console.Write("  Cinta 1: "); ImprimirCinta(cintas[1]);
 
            // Paso 2: Mezclar corridas hasta tener una sola
            int pasada = 1;
            while (true)
            {
                Queue<int> salida = new Queue<int>();
                bool huboCambios = false;
 
                while (cintas[0].Count > 0 && cintas[1].Count > 0)
                {
                    huboCambios = true;
                    // Mezclar una corrida de cada cinta
                    List<int> corrida0 = ExtraerCorrida(cintas[0]);
                    List<int> corrida1 = ExtraerCorrida(cintas[1]);
                    List<int> mezclada = MezclarDos(corrida0, corrida1);
 
                    foreach (int v in mezclada) salida.Enqueue(v);
                    salida.Enqueue(int.MaxValue);
                }
 
                // Pasar sobrantes de la cinta que quedó con datos
                foreach (int v in cintas[0]) salida.Enqueue(v);
                foreach (int v in cintas[1]) salida.Enqueue(v);
 
                Console.WriteLine($"\n-- Pasada {pasada} --");
                Console.Write("  Resultado: "); ImprimirCinta(salida);
 
                // Verificar si ya quedó una sola corrida
                if (ContarCorridas(salida) <= 1) 
                {
                    // Copiar al arreglo final
                    int idx = 0;
                    foreach (int v in salida)
                        if (v != int.MaxValue && idx < n)
                            a[idx++] = v;
                    break;
                }
 
                // Redistribuir la salida en las dos cintas para la siguiente pasada
                cintas[0].Clear();
                cintas[1].Clear();
                cintaActual = 0;
 
                while (salida.Count > 0)
                {
                    List<int> corrida = ExtraerCorrida(salida);
                    foreach (int v in corrida) cintas[cintaActual].Enqueue(v);
                    cintas[cintaActual].Enqueue(int.MaxValue);
                    cintaActual = (cintaActual + 1) % 2;
                }
 
                pasada++;
                if (!huboCambios) break;
            }
        }
 
        static List<int> ExtraerCorrida(Queue<int> cinta)
        {
            List<int> corrida = new List<int>();
            while (cinta.Count > 0 && cinta.Peek() != int.MaxValue)
                corrida.Add(cinta.Dequeue());
            if (cinta.Count > 0) cinta.Dequeue(); // Quitar marcador
            return corrida;
        }
 
        static List<int> MezclarDos(List<int> a, List<int> b)
        {
            List<int> resultado = new List<int>();
            int i = 0, j = 0;
            while (i < a.Count && j < b.Count)
                resultado.Add(a[i] <= b[j] ? a[i++] : b[j++]);
            while (i < a.Count) resultado.Add(a[i++]);
            while (j < b.Count) resultado.Add(b[j++]);
            return resultado;
        }
 
        static int ContarCorridas(Queue<int> cinta)
        {
            int count = 0;
            foreach (int v in cinta)
                if (v == int.MaxValue) count++;
            return count;
        }
 
        static void ImprimirCinta(Queue<int> cinta)
        {
            Console.Write("[ ");
            foreach (int v in cinta)
                Console.Write(v == int.MaxValue ? "| " : v + " ");
            Console.WriteLine("]");
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
