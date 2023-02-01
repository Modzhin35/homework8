// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int Input(string Message)
{
    Console.Write(Message);
    return Convert.ToInt32(Console.ReadLine());
}
int[,] FirstRandomArr(int firstRow, int firstCol)
{
    int[,] firstRandArray = new int[firstRow, firstCol];
    for (int i = 0; i < firstRow; i++)
    {
        for (int j = 0; j < firstCol; j++) firstRandArray[i, j] = new Random().Next(0, 99);
    }
    return firstRandArray;
}

int[,] SecondRandomArr(int secondRow, int secondCol)
{
    int[,] secondRandArray = new int[secondRow, secondCol];
    for (int i = 0; i < secondRow; i++)
    {
        for (int j = 0; j < secondCol; j++) secondRandArray[i, j] = new Random().Next(0, 99);
    }
    return secondRandArray;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++) Console.Write(arr[i, j] + "\t");
        Console.WriteLine();
    }
}

int[,] Multiplication(int[,] firstRandArray, int[,] secondRandArray)
{
    int[,] multiplArray = new int[firstRandArray.GetLength(0), secondRandArray.GetLength(1)];
    for (int i = 0; i < firstRandArray.GetLength(0); i++)
    {
        for (int j = 0; j < secondRandArray.GetLength(1); j++)
        {
            for (int k = 0; k < secondRandArray.GetLength(0); k++) multiplArray[i, j] += firstRandArray[i, k] * secondRandArray[k, j];
        }
    }
    return multiplArray;
}

int firstRows = Math.Abs(Input("Введите количество строк 1-й матрицы: "));
int firstCols = Math.Abs(Input("Введите количество столбцов 1-й матрицы: "));
int secondRows = Math.Abs(Input("Введите количество строк 2-й матрицы: "));
int secondCols = Math.Abs(Input("Введите количество столбцов 2-й матрицы: "));
if (firstCols != secondRows) Console.Write("Матрицы нельзя перемножить!");
else
{
    int[,] firstArray = FirstRandomArr(firstRows, firstCols);
    PrintArray(firstArray);
    Console.WriteLine();
    int[,] secondArray = SecondRandomArr(secondRows, secondCols);
    PrintArray(secondArray);
    Console.WriteLine();
    Console.WriteLine("Произведение матриц:");
    int[,] multiplyArray = Multiplication(firstArray, secondArray);
    PrintArray(multiplyArray);
}