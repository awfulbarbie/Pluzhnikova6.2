using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lab6._4_console_
{
    internal class Program
    {
        static int[][] Input()
        {
            int n = 0;
            while (true)
            {
                Console.WriteLine("Введите размерность массива [n]");
                try
                {
                    n = int.Parse(Console.ReadLine());
                    if (n <= 0)
                    {
                        Console.WriteLine("Ошибка! Размерность массива не может иметь отрицательное или нулевое значение");
                        continue;
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Ошибка! Неверный формат ввода данных");

                }
            }

            Console.WriteLine("Введите элемнты массива: ");
            int[][] array = new int[n][];                         //Ступенчатый массив - массив массивов, в котором длина каждого массива может быть разной.
                                                                  //Ступенчатый массив может быть использован для составления таблицы из строк разной длины.
            try
            {
                for (int i = 0; i < n; i++)
                {
                    array[i] = new int[n];
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write($"a[{i},{j}] = ");
                        array[i][j] = int.Parse(Console.ReadLine());
                    }

                }
            }
            catch
            {
                Console.WriteLine("Некорректные данные!");
                Environment.Exit(0); //остановка программы
            }
            return array;

        }

        static void Print1(int[][] array)
        {
            for (int i = 0; i < array.Length; i++, Console.WriteLine())
                for (int j = 0; j < array[i].Length; j++)
                    Console.Write("{0,5} ", array[i][j]);   //5 - ширина ячейки для одного элемента
        }

        static void Print2(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                Console.Write("{0,5} ", array[i]);
        }

        static int Min(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                }
                else if (array[i] == min)
                {
                    Environment.Exit(0);        //остановка программы
                }
            }
            return min;
        }

        static int[] Multiply(int[][] array)
        {
            int[] mult = new int[array.GetLength(0)];       //Размерность массива mult равна размерности строки массива array
            for (int i = 0; i < array.GetLength(0); i++)
            {
                mult[i] = 1;
                for(int j = 0; j < array[i].Length; j++)
                {
                    mult[i] *= array[j][i];
                }
            }
            return mult;
        }

        static void Main(string[] args)
        {
            int[][] Array = Input();
            Console.WriteLine("Исходный массив:");
            Print1(Array);
            int[] mult = new int[Array.Length];
            mult = Multiply(Array);
            Console.WriteLine("Новый массив:");
            Print2(mult);
            Console.WriteLine();
            int min = Min(mult);
            Console.WriteLine($"Минимальный элемент нового массива: {min}");

        }
    }
}
