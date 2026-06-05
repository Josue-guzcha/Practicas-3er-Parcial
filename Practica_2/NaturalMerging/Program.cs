using System;
using System.Collections.Generic;
 
namespace MetodosOrdenamiento
{
    class NaturalMerging
    {
        static void Main(string[] args)
        {
            int[] arreglo = { 15, 3, 22, 8, 47, 1, 30, 12 };
 
            Console.WriteLine("=== NATURAL MERGING (Mezcla Natural) ===");
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
        // NATURAL MERGING
        // Repite hasta que el arreglo esté completamente ordenado:
        //   - Detecta corridas naturales (secuencias ya ordenadas)
        //   - Mezcla pares de corridas consecutivas
        // A diferencia del Straight Merging, aprovecha el orden
        // que ya existe en los datos, por eso es más eficiente
        // cuando hay secuencias parcialmente ordenadas.
        // ─────────────────────────────────────────────────────────────
        static void Ordenar(int[] a)
        {
            int n      = a.Length;
            int pasada = 1;
            bool ordenado = false;
 
            while (!ordenado)
            {
                Console.WriteLine($"\n-- Pasada {pasada} --");
                ordenado = true;
                int i = 0;
 
                while (i < n)
                {
                    // Encontrar el fin de la primera corrida natural
                    int inicio1 = i;
                    while (i < n - 1 && a[i] <= a[i + 1]) i++;
                    int fin1 = i;
                    i++;
 
                    if (i >= n) break; // No hay segunda corrida
 
                    // Encontrar el fin de la segunda corrida natural
                    int inicio2 = i;
                    while (i < n - 1 && a[i] <= a[i + 1]) i++;
                    int fin2 = i;
                    i++;
 
                    Console.WriteLine($"  Mezclando corrida [{inicio1}..{fin1}] con [{inicio2}..{fin2}]");
 
                    // Mezclar las dos corridas encontradas
                    MezclarCorridas(a, inicio1, fin1, inicio2, fin2);
                    ordenado = false; // Hubo mezcla, seguir revisando
                }
 
                Console.Write($"  Resultado: ");
                Imprimir(a);
                pasada++;
            }
        }
 
        // ─────────────────────────────────────────────────────────────
        // MEZCLAR CORRIDAS
        // Fusiona dos corridas naturales adyacentes:
        //   Primera corrida:  a[inicio1 .. fin1]
        //   Segunda corrida:  a[inicio2 .. fin2]
        // Usa un arreglo temporal y copia el resultado de vuelta
        // ─────────────────────────────────────────────────────────────
        static void MezclarCorridas(int[] a, int inicio1, int fin1, int inicio2, int fin2)
        {
            int tam = fin2 - inicio1 + 1;
            int[] temp = new int[tam];
 
            int i = inicio1, j = inicio2, k = 0;
 
            while (i <= fin1 && j <= fin2)
                temp[k++] = (a[i] <= a[j]) ? a[i++] : a[j++];
 
            while (i <= fin1) temp[k++] = a[i++];
            while (j <= fin2) temp[k++] = a[j++];
 
            // Copiar resultado de vuelta al arreglo original
            for (int x = 0; x < tam; x++)
                a[inicio1 + x] = temp[x];
        }
 
        static void Imprimir(int[] a)
        {
            Console.WriteLine("[ " + string.Join(", ", a) + " ]");
        }
    }
}
 