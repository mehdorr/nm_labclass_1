using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nm_labclass_1
{
    class Program
    {

        static void printMatrix(double[,] A, double[,] B, int x, int y, int z)
        {
            for (int i = 0; i < x; i++)
            {
                Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop + 2);
                for (int j = 0; j < y; j++)
                {
                    if (j == 3)
                    {
                        Console.Write(" | [" + A[i, j].ToString("0.00") + "]");
                        continue;
                    }
                    Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                    Console.Write("[" + A[i, j].ToString("0.00") + "]");
                }
                Console.SetCursorPosition(Console.WindowWidth/2, Console.CursorTop);
                for (int j = 0; j < z; j++)
                {
                    Console.SetCursorPosition(Console.CursorLeft + 2, Console.CursorTop);
                    Console.Write("[" + B[i, j].ToString("0.00") + "]");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int j = 0; j < Console.WindowWidth; j++)
            {
                Console.Write("+");
            }
        }

        static void multiplyMatrix(double[,] A, double[,] B, int x, int y, int z, int c)
        {
            for (int i = 1; i < z; i++)
            {
                for (int j = c - 1; j >= 0; j--)
                {
                    B[i, j] = B[i, j] - A[i, 0] / A[0, 0] * B[0, j];
                }
            }

            for (int i = 1; i < x; i++)
            {
                if (i == x - 2)
                {
                    for (int j = y - 1; j >= 0; j--)
                    {
                        A[i, j] = A[i, j] - A[i, 0] / A[0, 0] * A[i - 1, j];
                    }
                }
                if (i == x - 1)
                {
                    for (int j = y - 1; j >= 0; j--)
                    {
                        A[i, j] = A[i, j] - A[i, 0] / A[0, 0] * A[i - 2, j];
                    }
                }
            }
        }

        static void Mnozenie1(double[,] Macierz, double[,] MacierzOdwrotna, int w, int k, int w1, int k1)
        {
            for (int i = 1; i < w1; i++)
            {
                for (int u = k1 - 1; u >= 0; u--)
                {
                    MacierzOdwrotna[i, u] = MacierzOdwrotna[i, u] - Macierz[i, 0] / Macierz[0, 0] * MacierzOdwrotna[0, u];
                }
            }
            for (int i = 1; i < w; i++)
            {
                if (i == w - 2)
                {
                    for (int u = k - 1; u >= 0; u--)
                    {
                        Macierz[i, u] = Macierz[i, u] - Macierz[i, 0] / Macierz[0, 0] * Macierz[i - 1, u];
                    }
                }
                if (i == w - 1)
                {
                    for (int u = k - 1; u >= 0; u--)
                    {
                        Macierz[i, u] = Macierz[i, u] - Macierz[i, 0] / Macierz[0, 0] * Macierz[i - 2, u];
                    }
                }
            }



            for (int i = 0; i < w1; i++)
            {
                if (i == 1)
                {
                    continue;
                }
                else
                {
                    for (int u = k1 - 1; u >= 0; u--)
                    {
                        MacierzOdwrotna[i, u] = MacierzOdwrotna[i, u] - Macierz[i, 1] / Macierz[1, 1] * MacierzOdwrotna[1, u];
                    }
                }
            }
            for (int i = 0; i < w; i++)
            {
                if (i == w - w)
                {
                    for (int u = k - 1; u >= 1; u--)
                    {
                        Macierz[i, u] = Macierz[i, u] - Macierz[i, 1] / Macierz[1, 1] * Macierz[i + 1, u];
                    }
                }
                if (i == w - 2)
                {
                    continue;
                }
                if (i == w - 1)
                {
                    for (int u = k - 1; u >= 1; u--)
                    {
                        Macierz[i, u] = Macierz[i, u] - Macierz[i, 1] / Macierz[1, 1] * Macierz[i - 1, u];
                    }
                }
            }



            for (int i = 0; i < w1; i++)
            {
                if (i == 2)
                {
                    continue;
                }
                else
                {
                    for (int u = k1 - 1; u >= 0; u--)
                    {
                        MacierzOdwrotna[i, u] = MacierzOdwrotna[i, u] - Macierz[i, 2] / Macierz[2, 2] * MacierzOdwrotna[2, u];
                    }
                }
            }
            for (int i = 0; i < w; i++)
            {
                if (i == w - w)
                {
                    for (int u = k - 1; u >= 2; u--)
                    {
                        Macierz[i, u] = Macierz[i, u] - Macierz[i, 2] / Macierz[2, 2] * Macierz[i + 2, u];
                    }
                }
                if (i == w - 1)
                {
                    continue;
                }
                if (i == w - 2)
                {
                    for (int u = k - 1; u >= 2; u--)
                    {
                        Macierz[i, u] = Macierz[i, u] - Macierz[i, 2] / Macierz[2, 2] * Macierz[i + 1, u];
                    }
                }
            }


            for (int i = 0; i < w1; i++)
            {
                for (int q = k1 - 1; q >= 0; q--)
                {
                    MacierzOdwrotna[i, q] = MacierzOdwrotna[i, q] / Macierz[i, i];
                }
            }
            int j = k - 1;
            for (int i = 0; i < w; i++)
            {
                Macierz[i, j] = Macierz[i, j] / Macierz[i, i];
                Macierz[i, i] = Macierz[i, i] / Macierz[i, i];
            }
        }



        //static void mnozW(double[,] T, int n, int m, double war, int nr)
        //{
        //    for(int i = 0; i < m; i++)
        //    {
        //        T[nr, i] = war * T[nr, i];
        //    }
        //}

        //static void dodajW(double[,] T, int n, int m, int nr1, int nr2)
        //{
        //    for(int i = 0; i < m; i++)
        //    {
        //        T[nr1, i] = T[nr1, i] + T[nr2, i];
        //    }
        //}

        //static void elGauss(double[,] T, int n, int m)
        //{
        //    double var;
        //    for(int j = 0; j < m - 1; j++)
        //    {
        //        for(int i = j + 1; i < n; i++)
        //        {
        //            var = -T[j, j] / T[i, j];
        //            mnozW(T, n, m, var, i);
        //            dodajW(T, n, m, i, j);
        //        }
        //    }
        //    double[] Tab = new double[n];
        //    int k;
        //    double licz, mian;
        //    for(int i = n - 1; i >= 0; i--)
        //    {
        //        licz = T[i, m - 1];
        //        k = 0;
        //        for(int j = m - 2; j > 1; j--)
        //        {
        //            k++;
        //            licz -= T[i, j] * Tab[n - k];
        //        }
        //        mian = T[i, i];
        //        Tab[i] = licz / mian;
        //    }
        //}

        static void Main(string[] args)
        {
            double[,] matrixOriginal = new double[3, 4] {
                {1,2,3,4},
                {3,4,6,8},
                {7,8,19,-10}
            };

            double[,] matrixBig = new double[4, 5] {
                {1,2,3,4,3},
                {3,4,6,8,6},
                {7,8,19,-10,5},
                {2,7,4,-4,-2}
            };

            double[,] matrixInverse = new double[3, 3] {
                {1,0,0},
                {0,1,0},
                {0,0,1}
            };

            //printMatrix(matrixOriginal, matrixInverse, 3, 4, 3);
            //elGauss(matrixOriginal, 3, 4);
            //printMatrix(matrixOriginal, matrixInverse, 3, 4, 3);

            printMatrix(matrixOriginal, matrixInverse, 3, 4, 3);
            Mnozenie1(matrixOriginal, matrixInverse, 3, 4, 3, 3);
            printMatrix(matrixOriginal, matrixInverse, 3, 4, 3);

            Console.ReadLine();
        }
    }
}
