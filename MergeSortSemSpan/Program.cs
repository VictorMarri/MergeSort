using System;
using System.Collections.Generic;
using System.Linq;

namespace MergeSortSemSpan
{
    public static class Program
    {
        //Solução criada baseado na documentação MegeSort na Wikipedia

        static void Main(string[] args)
        {
            var numerosRandomicos = new Random();
            var conjunto = new int[] { 17,38,77,1,3,2,7,4,5,7,8};
            
            conjunto.StartMergeSort();

            var txt = string.Join(',', conjunto);
            Console.WriteLine(txt);

            Console.ReadKey();
        }

        private static void StartMergeSort(this int[] conjunto)
        {
            var numerosAleatorios = MergeSort(conjunto);

            for (int i = 0; i < numerosAleatorios.Length; i++)
            {
                conjunto[i] = numerosAleatorios[i];
            }
        }

        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1) return numbers;

            var esquerda = new List<int>();
            var direita = new List<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 >0)
                {
                    esquerda.Add(numbers[i]);
                }
                else
                {
                    direita.Add(numbers[i]);
                }
            }

            esquerda = MergeSort(esquerda.ToArray()).ToList();
            direita = MergeSort(direita.ToArray()).ToList();

            return Merge(esquerda, direita);
        }

        private static int[] Merge(List<int> esquerda, List<int> direita)
        {
            var resultado = new List<int>();

            //Caso o valor da divisao dos vetores seja impar, e no final algum dos vetores pode ficar com valores sobrando
            while (esquerda.Any() && direita.Any())
            {
                if (esquerda.First() <= direita.First())
                    MoverValorDoArrayInicialParaOArrayResultado(esquerda, resultado);
                else
                    MoverValorDoArrayInicialParaOArrayResultado(direita, resultado);
            }

            while (esquerda.Any())
            {
                MoverValorDoArrayInicialParaOArrayResultado(esquerda, resultado);
            }

            while (direita.Any())
            {
                MoverValorDoArrayInicialParaOArrayResultado(direita, resultado);
            }

            return resultado.ToArray();
        }

        private static void MoverValorDoArrayInicialParaOArrayResultado(List<int> lista, List<int> resultado)
        {
            resultado.Add(lista.First());
            lista.RemoveAt(0);
        }
    }
}
