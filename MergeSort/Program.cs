using System;
using System.Linq;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var tamanhoConjunto = new Random();
            var valorRandomico = new Random();
            var conjuntoDesordenado = new int[tamanhoConjunto.Next(1,100)];

            for (int i = 0; i < conjuntoDesordenado.Length; i++)
            {
                conjuntoDesordenado[i] = valorRandomico.Next(1, 101);
            }

            Console.WriteLine("Dados desordenados no array:\n");
            MostrarTodosOsValoresContidosNoArray(conjuntoDesordenado);

            MergeSort(conjuntoDesordenado);

            Console.WriteLine("\n\nDados Ordenados no array:\n");
            MostrarTodosOsValoresContidosNoArray(conjuntoDesordenado);
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }

        private static void MergeSort(Span<int> conjuntoDesordenado)
        {
            var centro = conjuntoDesordenado.Length / 2;

            if (conjuntoDesordenado.Length > 1)
            {
                MergeSort(conjuntoDesordenado.Slice(0, centro));
                MergeSort(conjuntoDesordenado.Slice(centro));
                Merge(conjuntoDesordenado, centro);
            }
        }

        private static void Merge(Span<int> resultado, int comecoDoLadoDireito)
        {
            var conjuntoDesordenado = resultado.ToArray();
            var ladoEsquerdo = 0;
            var ladoDireito = comecoDoLadoDireito;
            var limite = 0;

            while (ladoEsquerdo < comecoDoLadoDireito && ladoDireito < conjuntoDesordenado.Length)
            {
                if (conjuntoDesordenado[ladoEsquerdo] <= conjuntoDesordenado[ladoDireito])
                {
                    resultado[limite] = conjuntoDesordenado[ladoEsquerdo];
                    ladoEsquerdo++;
                }
                else
                {
                    resultado[limite] = conjuntoDesordenado[ladoDireito];
                    ladoDireito++;
                }
                    
                limite++;
            }

            while (ladoEsquerdo < comecoDoLadoDireito)
            {
                resultado[limite] = conjuntoDesordenado[ladoEsquerdo];
                ladoEsquerdo++;
                limite++;
            }

            while (ladoDireito < conjuntoDesordenado.Length)
            {
                resultado[limite] = conjuntoDesordenado[ladoDireito];
                ladoDireito++;
                limite++;
            }
        }

        private static void MostrarTodosOsValoresContidosNoArray(int[] conjuntoDesordenado)
        {
            var txt = string.Join(',', conjuntoDesordenado);
            Console.Write(txt);
        }
    }
}
