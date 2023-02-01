// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int Input(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}
int[,] GetRandomArr(int row, int col, int min, int max)
{
    int[,] randomArr = new int[row, col];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++) randomArr[i, j] = new Random().Next(min, max);
    }
    return randomArr;
}

int[,] SortingArray(int[,] array)
{
    int temp = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1) - 1; j++)
        {
            for (int k = j + 1; k < array.GetLength(1); k++)
            {
                if (array[i, j] < array[i, k])
                {
                    temp = array[i, j];
                    array[i, j] = array[i, k];
                    array[i, k] = temp;
                }
            }
        }
    }
    return array;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++) Console.Write(arr[i, j] + "\t");
        Console.WriteLine();
    }
}

int row = Math.Abs(Input("Введите количество строк: "));
int col = Math.Abs(Input("Введите количество столбцов: "));
int minEl = Input("Введите минимальное значение для генерации случайных чисел: ");
int maxEl = Input("Введите максимальное значение для генерации случайных чисел: ");
int[,] randArr = GetRandomArr(row, col, minEl, maxEl);
PrintArray(randArr);
Console.WriteLine();
PrintArray(SortingArray(randArr));