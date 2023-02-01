// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int[,] GetRandomArr(int row, int col, int min, int max)
{
    int[,] randomArr = new int[row, col];
    for (int i = 0; i < row; i++)
    {
        for (int j = 0; j < col; j++) randomArr[i, j] = new Random().Next(min, max);
    }
    return randomArr;
}

int[] SummArray(int[,] array)
{
    int[] summArray = new int[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int summa = 0;
        for (int j = 0; j < array.GetLength(1); j++) summa += array[i, j];
        summArray[i] = summa;
    }
    return summArray;
}

int SerchIndexMinimumSumma(int[] sumArray)
{
    int min = sumArray[1];
    int indexMinSumm = 0;
    for (int i = 0; i < sumArray.Length; i++)
    {
        if (sumArray[i] < min)
        {
            min = sumArray[i]; 
            indexMinSumm = i;
        }
    }
    return indexMinSumm;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++) Console.Write(arr[i, j] + "\t");
        Console.WriteLine();
    }
}

int[,] randomArray = GetRandomArr(5, 4, 1, 99);
PrintArray(randomArray);
int [] summArr = SummArray(randomArray);
Console.WriteLine($"Полученные суммы строк двумерного массива: {String.Join(", ", summArr)}.");
int indexMinimumSummArray = SerchIndexMinimumSumma(summArr);
Console.WriteLine($"Номер строки полученного массива с наименьшей суммой элементов = {indexMinimumSummArray+1}.");
