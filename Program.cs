using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleApp21._1
{
    internal class Program
    {
        static int N1;
        static int N2;
        static int[,] field;
        static int G1 = 0;
        static int G2 = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Задайте необходимый размер участка для садовников");
            Console.Write("Длина: ");
            N1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ширина: ");
            N2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            field  = new int[N1, N2];
            int fieldSize = N1 * N2;
            //Random random = new Random();

            Thread gard1 = new Thread(gardener1);
            Thread gard2 = new Thread(gardener2);

            gard1.Start();
            gard2.Start();
            gard1.Join();
            gard2.Join();

            for (int i = 0; i < N1; i++)
            {

                for (int j = 0; j < N2; j++)
                {
                    //number[i, j] = random.Next(10, 100);
                    //number[i, j] = 1 - (i + j) % 2;
                    Console.Write("{0,3}", field[i, j]);

                }
                Console.WriteLine();
            }

            foreach (int g in field)
            if (g == 1)
            {
                G1++;
            }
            else if (g == 2)
            {
                G2++;
            }
            Console.WriteLine();
            Console.WriteLine("Первый садовник обработал {0} % участка сада ({1} ячеек из {2} шт)", (G1 * 100) / fieldSize, G1, fieldSize);
            Console.WriteLine("Второй садовник обработал {0} % участка сада ({1} ячеек из {2} шт)", (G2 * 100) / fieldSize, G2, fieldSize);
            Console.ReadKey();
        }

        public static void gardener1()
        {
            for (int i = 0; i < N1; i++)
            {
                for (int j = 0; j < N2; j++)
                {
                    if (field[i, j] == 0)
                        field[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        public static void gardener2()
        {
            for (int i = N2 - 1; i > 0; i--)
            {
                for (int j = N1 - 1; j > 0; j--)
                {
                    if (field[j, i] == 0)
                        field[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
