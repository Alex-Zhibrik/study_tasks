namespace ArrayTasks3
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }


        static int[][] CreateSpriralMatrix(int index)
        {

            /*
            5) Заполнить квадратную матрицу А размером N*N (N < 100) натуральными 
            числами по свертывающейся спирали.
             */

            if (index == 0)
            {
                throw new ArgumentNullException("Index is null");
            }

            var matrix = new int[index][];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[index];
            }

            int element = index * index;

            int y = matrix.Length - 1;
            int x = matrix[matrix.Length - 1].Length - 1;

            int counter = matrix.Length;

            while (element > 0)
            {
                for (int i = 0; i < counter; i++)
                {


                    matrix[y][x] = element--;

                    if (i == counter - 1)
                    {
                        y--;
                        break;
                    }

                    x--;
                }

                counter--;

                for (int i = 0; i < counter; i++)
                {
                    matrix[y][x] = element--;

                    if (i == counter - 1)
                    {
                        x++;
                        break;
                    }

                    y--;
                }

                for (int i = 0; i < counter; i++)
                {
                    matrix[y][x] = element--;

                    if (i == counter - 1)
                    {
                        y++;
                        break;
                    }

                    x++;
                }

                counter--;

                for (int i = 0; i < counter; i++)
                {
                    matrix[y][x] = element--;

                    if (i == counter - 1)
                    {
                        x--;
                        break;
                    }

                    y++;
                }
            }

            return matrix;
        }

        static void CreateMinFirst(int[][] matrix)
        {

            /*
            4)Переставляя строчки и столбцы матрицы, сделать так, чтобы наименьший элемент
            (один из) оказался в правом нижнем углу.
             */

            if (matrix == null || matrix.Length == 0)
            {
                throw new ArgumentNullException("Matrix is empty");
            }

            var coordinates = matrix.GetMinCoordinates();

            var minY = coordinates[0];
            var minX = coordinates[1];

            for (int i = minY; i < matrix.Length - 1; i++)
            {
                var temp = matrix[0];

                for (int j = 1; j < matrix.Length; j++)
                {
                    var temp2 = matrix[j];
                    matrix[j] = temp;
                    temp = temp2;

                }

                matrix[0] = temp;
            }

            for (int i = minX; i < matrix[0].Length - 1; i++)
            {
                var temp = matrix.GetColumn(0);

                for (int j = 1; j < matrix[0].Length; j++)
                {
                    var temp2 = matrix.GetColumn(j);
                    matrix.ReplaceColumn(temp, j);
                    temp = temp2;

                }

                matrix.ReplaceColumn(temp, 0);
            }

        }

        static int[] GetMaxMinRightLeftUp(int[][] matrix)
        {

            /*
            3)Дана действительная квадратная матрица порядка N. Найдите наибольшее и
            наименьшее значений элементов, расположенных в заштрихованной части матрицы.
            см. рисунок "в" (на рисунке заштрихован правый, левый треугольник и верхний)
             */

            matrix.CheckMatrix();

            var min = matrix[1][0];
            var max = matrix[1][0];

            var firstDiagonal = 0;
            var secondDiagonal = matrix.Length - 1;

            for (int y = 0; y < matrix.Length; y++)
            {
                for (int x = 0; x < matrix[y].Length; x++)
                {
                    if (y < matrix.Length / 2 && (x > firstDiagonal && x < secondDiagonal))
                    {
                        continue;
                    }
                    else if (x == firstDiagonal || x == secondDiagonal)
                    {
                        continue;
                    }

                    if (matrix[y][x] < min)
                    {
                        min = matrix[y][x];
                    }

                    if (matrix[y][x] > max)
                    {
                        max = matrix[y][x];
                    }
                }

                firstDiagonal++;
                secondDiagonal--;
            }

            return new int[] { max, min };
        }


        static int[] GetSumMultiplyRightLeft(int[][] matrix)
        {

            /*
            2)Дана действительная квадратная матрица порядка N. Найти сумму и 
            произведение элементов, расположенных в заштрихованной части матрицы.
            см. рисунок "б" (на рисунке заштрихован правый и левый треугольник)
             */

            matrix.CheckMatrix();

            var sum = 0;
            var multiply = 1;

            var firstDiagonal = 0;
            var secondDiagonal = matrix.Length - 1;

            for (int y = 0; y < matrix.Length; y++)
            {
                for (int x = 0; x < matrix[y].Length; x++)
                {
                    if (y < matrix.Length / 2 && (x < firstDiagonal || x > secondDiagonal))
                    {
                        sum += matrix[y][x];
                        multiply *= matrix[y][x];
                    }
                    else if (y >= matrix.Length / 2 && (x < secondDiagonal || x > firstDiagonal))
                    {
                        sum += matrix[y][x];
                        multiply *= matrix[y][x];
                    }
                }

                firstDiagonal++;
                secondDiagonal--;
            }

            return new int[] { sum, multiply };
        }

        static int[] GetSumMultiplyUpDown(int[][] matrix)
        {

            /*
            1)Дана действительная квадратная матрица порядка N. Найти сумму и 
            произведение элементов, расположенных в заштрихованной части матрицы.
            см. рисунок "а" (на рисунке заштрихован верхний и нижний треугольник)
             */

            matrix.CheckMatrix();

            var sum = 0;
            var multiply = 1;

            var firstDiagonal = 0;
            var secondDiagonal = matrix.Length - 1;

            for (int y = 0; y < matrix.Length; y++)
            {
                for (int x = 0; x < matrix[y].Length; x++)
                {
                    if (y < matrix.Length / 2 && x > firstDiagonal && x < secondDiagonal)
                    {
                        sum += matrix[y][x];
                        multiply *= matrix[y][x];
                    }
                    else if (y >= matrix.Length / 2 && x < firstDiagonal && x > secondDiagonal)
                    {
                        sum += matrix[y][x];
                        multiply *= matrix[y][x];
                    }
                }

                firstDiagonal++;
                secondDiagonal--;
            }

            return new int[] { sum, multiply };
        }




    }
    public static class Matrix
    {

        public static void ReplaceColumn(this int[][] matrix, int[] column, int x)
        {
            //Заменят столбец в матрице

            for (int y = 0; y < matrix.Length; y++)
            {
                matrix[y][x] = column[y];
            }
        }

        public static int[] GetColumn(this int[][] matrix, int x)
        {
            //получает столбец из матрицы 

            var column = new int[matrix.Length];

            for (int y = 0; y < matrix.Length; y++)
            {
                column[y] = matrix[y][x];
            }

            return column;
        }

        public static int[] GetMinCoordinates(this int[][] matrix)
        {

            //Получает координаты минимального числа в матрице

            var min = matrix[0][0];

            var minX = 0;
            var minY = 0;

            for (int y = 0; y < matrix.Length; y++)
            {
                for (int x = 0; x < matrix[y].Length; x++)
                {
                    if (matrix[y][x] < min)
                    {
                        min = matrix[y][x];

                        minX = x;
                        minY = y;
                    }
                }
            }

            return new int[] { minY, minX };
        }

        public static void CheckMatrix(this int[][] matrix)
        {

            /*
             Проверка условий для задачи 1-3, чтобы матрица не была равна нулю, была 
             квадратной и не меньше 3*3
             */


            if (matrix == null || matrix.Length == 0)
            {
                throw new ArgumentNullException("Matrix is null");
            }
            else if (matrix.Length != matrix[0].Length)
            {
                throw new ArgumentException("Matrix is no square");
            }
            else if (matrix.Length < 3)
            {
                throw new ArgumentException("Matrix is to small for get sum and multiply");
            }
        }

    }
}
