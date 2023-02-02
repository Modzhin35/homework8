// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int[,] FilArray(int rows, int cols)
{
    int[,] filArray = new int[rows, cols];
    int i = 0;
    int j = 0;
    int count = 1;
    while (count <= rows * cols)
    {
        filArray[i, j] = count;
        if (i <= j + 1 && i + j < rows - 1) j++;
        else if (i < j && i + j >= rows - 1) i++;
        else if (i >= j && i + j > rows - 1) j--;
        else i--;
        count++;
    }
    return filArray;
}

void PrintArray(int[,] arr)
{
    for (int i = 0; i < arr.GetLength(0); i++)
    {
        for (int j = 0; j < arr.GetLength(1); j++) Console.Write($"{arr[i, j]}\t");
        Console.WriteLine();
    }
}

int[,] arrayFil = FilArray(4, 4);
PrintArray(arrayFil);