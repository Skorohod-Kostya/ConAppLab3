namespace ConAppTask2;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть спосіб введення даних:");
        Console.WriteLine("1. З файлу");
        Console.WriteLine("2. З клавіатури");
        Console.WriteLine("3. Випадкові числа");
        Console.Write("Ваш вибір (1-3): ");
        string choice = Console.ReadLine();

        int m, n;
        int[,] matrix;

        if (choice == "1")
        {
            Console.Write("Введіть шлях до файлу: ");
            string path = Console.ReadLine();
            string[] lines = File.ReadAllLines(path);
            m = Convert.ToInt32(lines[0]);
            n = Convert.ToInt32(lines[1]);
            matrix = new int[m, n];
            int index = 2;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = Convert.ToInt32(lines[index]);
                    index++;
                }
            }
        }
        else if (choice == "2")
        {
            Console.Write("Введіть кількість рядків: ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть кількість стовпців: ");
            n = Convert.ToInt32(Console.ReadLine());
            matrix = new int[m, n];
            Console.WriteLine("Введіть елементи масиву:");
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("Елемент [" + i + "," + j + "]: ");
                    matrix[i, j] = Convert.ToInt32(Console.ReadLine());
                }
            }
        }
        else if (choice == "3")
        {
            Console.Write("Введіть кількість рядків: ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть кількість стовпців: ");
            n = Convert.ToInt32(Console.ReadLine());
            matrix = new int[m, n];
            Random rnd = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(-50, 51);
                }
            }
        }
        else
        {
            Console.WriteLine("Невірний вибір. Завершення програми.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nПочатковий масив:");
        Console.Write("    ");
        for (int j = 0; j < n; j++)
        {
            Console.Write("{0,5}", j);
        }
        Console.WriteLine("\n   ------------------");
        for (int i = 0; i < m; i++)
        {
            Console.Write("{0,2}", i);
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,5}", matrix[i, j]);
            }
            Console.WriteLine();
        }

        double minRs = 999999; 
        int minRsColumn = -1;
        for (int j = 0; j < n; j++)
        {
            int hasNegative = 0;
            double sumPositive = 0;
            int countPositive = 0;
            for (int i = 0; i < m; i++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = 1;
                }
                if (matrix[i, j] > 0)
                {
                    sumPositive = sumPositive + matrix[i, j];
                    countPositive++;
                }
            }
            if (hasNegative == 1 && countPositive > 0)
            {
                double rs = sumPositive / countPositive;
                if (rs < minRs)
                {
                    minRs = rs;
                    minRsColumn = j;
                }
            }
        }

        if (minRsColumn == -1)
        {
            Console.WriteLine("\nНемає стовпців з від'ємними та позитивними елементами.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nНайменше Rs = " + minRs + " у стовпці " + minRsColumn);

        for (int i = 0; i < m; i++)
        {
            matrix[i, minRsColumn] = 0;
        }

        Console.WriteLine("\nМодифікований масив:");
        Console.Write("    ");
        for (int j = 0; j < n; j++)
        {
            Console.Write("{0,5}", j);
        }
        Console.WriteLine("\n   ------------------");
        for (int i = 0; i < m; i++)
        {
            Console.Write("{0,2}", i);
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0,5}", matrix[i, j]);
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }
}