
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество строк: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Введите количество столбцов: ");
        int cols = int.Parse(Console.ReadLine());

        Console.Write("Введите минимальное значение элемента: ");
        int minValue = int.Parse(Console.ReadLine());

        Console.Write("Введите максимальное значение элемента: ");
        int maxValue = int.Parse(Console.ReadLine());

        MyMatrix matrix = new MyMatrix(rows, cols, minValue, maxValue);

        Console.WriteLine("Исходная матрица:");
        matrix.Show();

        Console.WriteLine("\nИзменение размера матрицы...");
        matrix.ChangeSize(4, 7);
        Console.WriteLine("Измененная матрица:");
        matrix.Show();

        Console.WriteLine("\nЧасть матрицы:");
        matrix.ShowPartially(1, 3, 2, 4);

        Console.WriteLine("\nУстановка значения в матрице:");
        matrix[0, 0] = 100;
        matrix.Show();
    }
}

class MyMatrix
{
    private int[,] matrix;
    private int stroki;
    private int stolbi;
    private int minValue;
    private int maxValue;

    public MyMatrix(int stroki, int stolbi, int minValue, int maxValue)
    {
        this.stroki = stroki;
        this.stolbi = stolbi;
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.matrix = FillMatrix();
    }

    private int[,] FillMatrix()
    {
        int[,] newMatrix = new int[stroki, stolbi];
        Random rand = new Random();

        for (int i = 0; i < stroki; i++)
        {
            for (int j = 0; j < stolbi; j++)
            {
                newMatrix[i, j] = rand.Next(minValue, maxValue + 1);
            }
        }

        return newMatrix;
    }

    public void Fill()
    {
        this.matrix = FillMatrix();
    }

    public void ChangeSize(int newStroki, int newStolbi)
    {
        int[,] newMatrix = new int[newStroki, newStolbi];

        for (int i = 0; i < Math.Min(stroki, newStroki); i++)
        {
            for (int j = 0; j < Math.Min(stolbi, newStolbi); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        if (newStroki > stroki || newStolbi > stolbi)
        {
            Random rand = new Random();
            for (int i = Math.Min(stroki, newStroki); i < newStroki; i++)
            {
                for (int j = Math.Min(stolbi, newStolbi); j < newStolbi; j++)
                {
                    newMatrix[i, j] = rand.Next(minValue, maxValue + 1);
                }
            }
        }

        this.stroki = newStroki;
        this.stolbi = newStolbi;
        this.matrix = newMatrix;
    }

    public void ShowPartially(int startRow, int endRow, int startCol, int endCol)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startCol; j <= endCol; j++)
            {
                Console.Write("{0}\t",matrix[i, j]);
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        ShowPartially(0, stroki - 1, 0, stolbi - 1);
    }

    public int this[int index1, int index2]
    {
        get { return matrix[index1, index2]; }
        set { matrix[index1, index2] = value; }
    }
}
