// Задача 50. Напишите программу, 
// которая на вход принимает позиции элемента 
// в двумерном массиве, и возвращает значение 
// этого элемента или же указание, что такого элемента нет.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4 

// 1, 7 -> такого числа в массиве нет

int GetValueFromUser(string messageForUser)
{
  int value = 0;
  bool flag = false;

  while (!flag)
  {
    Console.Write(messageForUser);
    flag = int.TryParse(Console.ReadLine(), out value);
  }

  return value;
}

string JoinMatrix(double[,] matrix)
{
  int rows = matrix.GetLength(0);
  int columns = matrix.GetLength(1);

  string result = String.Empty; // ""
  for (int i = 0; i < rows; i++)
  {
    for (int j = 0; j < columns; j++)
    {
      result += $"{matrix[i, j],4} ";
    }
    result += "\n";
  }

  return result;
}

void FillMatrix(double[,] matrix, int min = 0, int max = 10)
{
  int rows = matrix.GetLength(0);
  int columns = matrix.GetLength(1);

  for (int i = 0; i < rows; i++)
  {
    for (int j = 0; j < columns; j++)
    {
      matrix[i, j] = Math.Round(new Random().NextDouble() * new Random().Next(min, max), 2);
    }
  }
}

int lines = GetValueFromUser($"Введите количество строк: ");
int columns = GetValueFromUser($"Введите количество столбцов: ");
if (lines <= 0 || columns <= 0)
{
  Console.WriteLine("Массив не является двумерным.");
  return;
}
double[,] matrix = new double[lines, columns];

FillMatrix(matrix);
Console.WriteLine(JoinMatrix(matrix));

Console.WriteLine($"Для поиска значения в позиции массива:");
int indexLine = GetValueFromUser($"Введите номер строки: ");
int indexColumn = GetValueFromUser($"Введите номер столбца: ");

if (indexLine > matrix.GetLength(0) || indexLine <= 0 || indexColumn > matrix.GetLength(1) || indexColumn <= 0)
{
  Console.WriteLine("Такого элемента в массиве нет!");
  return;
}

double element = matrix[indexLine - 1, indexColumn - 1];
Console.WriteLine($"Значение на позиции [{indexLine}, {indexColumn}] = {element}");