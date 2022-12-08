using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lab6._3_console_
{
    internal class Program
    {
        static int[,] Input(out int n, out int m)
        {
            while (true)
            {
                Console.WriteLine("Введите размерность двумерного массива (n - количество строк, m - количество столбцов)");
                try
                {
                    n = int.Parse(Console.ReadLine());
                    m = int.Parse(Console.ReadLine());
                    if (n <= 0 || m <= 0)
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
            int[,] array = new int[n, m];
            Console.WriteLine("Заполните массив:");
            try
            {
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        Console.Write("a[{0},{1}] = ", i, j);
                        array[i, j] = int.Parse(Console.ReadLine());
                    }
            }
            catch
            {
                Console.WriteLine("Неверные данные!");
                Environment.Exit(0); //остановка программы
            }

            return array;
        }

        static void Print(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++, Console.WriteLine())
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write("{0,5} ", array[i, j]);   //5 - ширина ячейки для одного элемента
        }
        static void result(int[,] array)
        {
            bool[] col_array = new bool[array.GetLength(1)];    //логический массив с размерностью, равной количеству столбцов массива array
     
            for (int i = 0; i < col_array.Length; i++)          //всем элементам массива присваивается значение true
            {
                col_array[i] = true;
            }

            for (int i = 0; i < array.GetLength(1); i++)
            {
                for (int j = 0; j < array.GetLength(0); j++)
                {
                    if (array[j, i] >= 0)                      //проверка всех элементов столбцов массива array,
                                                               //если условие выполняется, то элементу лог. массива присваивается значение false
                    {
                        col_array[i] = false;
                        break;
                    }
                }
            }

            int flag = 0;
            for (int i = 0; i < array.GetLength(1); i++)       //перебор всех элементов столбцов массива array,
                                                               //если элементы col_array = true, то вывод
            {
                if (col_array[i])
                {
                    string output = string.Empty;               //пустая строка
                    for (int j = 0; j < array.GetLength(0); j++)
                    {
                        output += array[j, i] + "\n";
                    }

                    Console.WriteLine((i + 1) + " столбец состоит из отрицательных чисел:\n" + output + "\n");
                    flag = 1;
                }
            }
            if (flag == 0)
            {
                Console.WriteLine("Нет столбцов, в которых все элементы являются отрицательными");
            }
        }

        static void Main(string[] args)
        {
            int n;
            int m;
            int[,] Array = Input(out n, out m);
            Console.WriteLine("Исходный массив:");
            Print(Array);
            result(Array);
        }
    }
}

