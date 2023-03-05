// Задача 52. Задайте двумерный массив из целых чисел. 
// Найдите среднее арифметическое элементов в каждом столбце.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

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

string JoinMatrix(int[,] matrix)
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

void FillMatrix(int[,] matrix, int min = 0, int max = 10)
{
  int rows = matrix.GetLength(0);
  int columns = matrix.GetLength(1);

  for (int i = 0; i < rows; i++)
  {
    for (int j = 0; j < columns; j++)
    {
      matrix[i, j] = new Random().Next(min, max);
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
int[,] matrix = new int[lines, columns];

FillMatrix(matrix);
Console.WriteLine(JoinMatrix(matrix));


for (int i = 0; i < columns; i++)
{
  double sum = 0;
  for (int j = 0; j < lines; j++)
  {
    sum += matrix[j, i];
  }
  Console.Write($"{Math.Round((sum / lines), 2)};  ");
}