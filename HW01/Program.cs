// Задача 47. Задайте двумерный массив размером m × n, 
// заполненный случайными вещественными числами.

// m = 3, n = 4.

// 0,5 7 -2 -0,2

// 1 -3,3 8 -9,9

// 8 7,8 -7,1 9

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