// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая 
// будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[] FillSizesArray(string message)
{
    string[] stringSizeArr = message.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    int[] sizeArr = new int[stringSizeArr.Length];
    for (int i = 0; i < sizeArr.Length; i++) sizeArr[i] = int.Parse(stringSizeArr[i]);
    return sizeArr;
}

int[,,] GetRandomArray(int[] sizes, int min, int max)
{
    int[,,] array = new int[sizes[0], sizes[1], sizes[2]];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            int k = 0;
            while (k < array.GetLength(2))
            {
                int element = new Random().Next(min, max);
                if (FindRepitElements(array, element)) continue;
                array[i, j, k] = element;
                k++;
            }

        }
    }
    return array;
}

bool FindRepitElements(int[,,] randomArray, int randomElement)
{
    for (int i = 0; i < randomArray.GetLength(0); i++)
    {
        for (int j = 0; j < randomArray.GetLength(1); j++)
        {
            for (int k = 0; k < randomArray.GetLength(2); k++)
            {
                if (randomArray[i, j, k] == randomElement) return true;
            }
        }
    }
    return false;
}

void PrintArray(int[,,] arr)
{
    for (int k = 0; k < arr.GetLength(2); k++)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            for (int j = 0; j < arr.GetLength(1); j++) Console.Write($"{arr[i, j, k]}({i},{j},{k}) ");
            Console.WriteLine();
        }
    }
}

Console.Write("Введите размеры массива через пробел (3 размера): ");
int[] sizesArray = FillSizesArray(Console.ReadLine());
if (sizesArray.Length != 3) Console.WriteLine("Должно быть 3 размера массива. Программа не может быть выполнена.");
else
{
    Console.WriteLine("Введите минимальное и максимальное значение для генерации массива через пробел (2 значения в промежутке от 10 до 99): ");
    int[] minMaxArray = FillSizesArray(Console.ReadLine());
    if (minMaxArray.Length != 2) Console.WriteLine("Должно быть 2 значения!");
    else if (minMaxArray[0] > minMaxArray[1]) Console.WriteLine("Минимальное значение больше максимального!");
    else if (sizesArray[0] * sizesArray[1] * sizesArray[2] > minMaxArray[1] - minMaxArray[0]) Console.WriteLine("Размерность массива больше диапазона генерируемых чисел!");
    else if (minMaxArray[0] < 9 || minMaxArray[1] > 99) Console.WriteLine("Диапазон не в промежутке от 10 до 99!");
    else
    {
        int[,,] randArr = GetRandomArray(sizesArray, minMaxArray[0], minMaxArray[1]);
        Console.WriteLine();
        PrintArray(randArr);
    }
}