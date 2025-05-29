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

        int n, m, r;
        int[] U, X, Y;

        if (choice == "1")
        {
            Console.Write("Введіть шлях до файлу: ");
            string path = Console.ReadLine();
            string[] lines = File.ReadAllLines(path);
            n = Convert.ToInt32(lines[0]);
            U = new int[n];
            for (int i = 0; i < n; i++)
            {
                U[i] = Convert.ToInt32(lines[i + 1]);
            }
            m = Convert.ToInt32(lines[n + 1]);
            X = new int[m];
            for (int i = 0; i < m; i++)
            {
                X[i] = Convert.ToInt32(lines[n + 2 + i]);
            }
            r = Convert.ToInt32(lines[n + m + 2]);
            Y = new int[r];
            for (int i = 0; i < r; i++)
            {
                Y[i] = Convert.ToInt32(lines[n + m + 3 + i]);
            }
        }
        else if (choice == "2")
        {
            Console.Write("Введіть розмір множини U: ");
            n = Convert.ToInt32(Console.ReadLine());
            U = new int[n];
            Console.WriteLine("Введіть елементи множини U:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Елемент " + i + ": ");
                U[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Введіть розмір множини X: ");
            m = Convert.ToInt32(Console.ReadLine());
            X = new int[m];
            Console.WriteLine("Введіть елементи множини X:");
            for (int i = 0; i < m; i++)
            {
                Console.Write("Елемент " + i + ": ");
                X[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Введіть розмір множини Y: ");
            r = Convert.ToInt32(Console.ReadLine());
            Y = new int[r];
            Console.WriteLine("Введіть елементи множини Y:");
            for (int i = 0; i < r; i++)
            {
                Console.Write("Елемент " + i + ": ");
                Y[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        else if (choice == "3")
        {
            Console.Write("Введіть розмір множини U: ");
            n = Convert.ToInt32(Console.ReadLine());
            U = new int[n];
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                U[i] = rnd.Next(1, 100); // Як у прикладі 3.2
            }
            Console.Write("Введіть розмір множини X: ");
            m = Convert.ToInt32(Console.ReadLine());
            X = new int[m];
            for (int i = 0; i < m; i++)
            {
                X[i] = U[rnd.Next(0, n)]; // Випадкові елементи з U
            }
            Console.Write("Введіть розмір множини Y: ");
            r = Convert.ToInt32(Console.ReadLine());
            Y = new int[r];
            for (int i = 0; i < r; i++)
            {
                Y[i] = U[rnd.Next(0, n)]; // Випадкові елементи з U
            }
        }
        else
        {
            Console.WriteLine("Невірний вибір. Завершення програми.");
            Console.ReadKey();
            return;
        }

        // Перевірка, чи X і Y є підмножинами U
        for (int i = 0; i < m; i++)
        {
            int found = 0;
            for (int j = 0; j < n; j++)
            {
                if (X[i] == U[j])
                {
                    found = 1;
                    break;
                }
            }
            if (found == 0)
            {
                Console.WriteLine("Елемент " + X[i] + " множини X не належить U!");
                Console.ReadKey();
                return;
            }
        }
        for (int i = 0; i < r; i++)
        {
            int found = 0;
            for (int j = 0; j < n; j++)
            {
                if (Y[i] == U[j])
                {
                    found = 1;
                    break;
                }
            }
            if (found == 0)
            {
                Console.WriteLine("Елемент " + Y[i] + " множини Y не належить U!");
                Console.ReadKey();
                return;
            }
        }

        // Виведення множин
        Console.WriteLine("\nМножина U:");
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0,5}", U[i]);
        }
        Console.WriteLine("\nМножина X:");
        for (int i = 0; i < m; i++)
        {
            Console.Write("{0,5}", X[i]);
        }
        Console.WriteLine("\nМножина Y:");
        for (int i = 0; i < r; i++)
        {
            Console.Write("{0,5}", Y[i]);
        }

        // Об’єднання X ∪ Y
        Console.WriteLine("\n\nОб’єднання X ∪ Y:");
        int[] union = new int[m + r];
        int unionSize = 0;
        for (int i = 0; i < m; i++)
        {
            union[unionSize] = X[i];
            unionSize++;
        }
        for (int i = 0; i < r; i++)
        {
            int found = 0;
            for (int j = 0; j < m; j++)
            {
                if (Y[i] == X[j])
                {
                    found = 1;
                    break;
                }
            }
            if (found == 0)
            {
                union[unionSize] = Y[i];
                unionSize++;
            }
        }
        for (int i = 0; i < unionSize; i++)
        {
            Console.Write("{0,5}", union[i]);
        }

        // Перетин X ∩ Y
        Console.WriteLine("\n\nПеретин X ∩ Y:");
        int[] intersection = new int[m];
        int intersectionSize = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < r; j++)
            {
                if (X[i] == Y[j])
                {
                    intersection[intersectionSize] = X[i];
                    intersectionSize++;
                    break;
                }
            }
        }
        for (int i = 0; i < intersectionSize; i++)
        {
            Console.Write("{0,5}", intersection[i]);
        }

        // Різниця X \ Y
        Console.WriteLine("\n\nРізниця X \\ Y:");
        int[] diffXY = new int[m];
        int diffXYSize = 0;
        for (int i = 0; i < m; i++)
        {
            int found = 0;
            for (int j = 0; j < r; j++)
            {
                if (X[i] == Y[j])
                {
                    found = 1;
                    break;
                }
            }
            if (found == 0)
            {
                diffXY[diffXYSize] = X[i];
                diffXYSize++;
            }
        }
        for (int i = 0; i < diffXYSize; i++)
        {
            Console.Write("{0,5}", diffXY[i]);
        }

        // Різниця Y \ X
        Console.WriteLine("\n\nРізниця Y \\ X:");
        int[] diffYX = new int[r];
        int diffYXSize = 0;
        for (int i = 0; i < r; i++)
        {
            int found = 0;
            for (int j = 0; j < m; j++)
            {
                if (Y[i] == X[j])
                {
                    found = 1;
                    break;
                }
            }
            if (found == 0)
            {
                diffYX[diffYXSize] = Y[i];
                diffYXSize++;
            }
        }
        for (int i = 0; i < diffYXSize; i++)
        {
            Console.Write("{0,5}", diffYX[i]);
        }

        // Доповнення X
        Console.WriteLine("\n\nДоповнення X:");
        int[] complementX = new int[n];
        int complementXSize = 0;
        for (int i = 0; i < n; i++)
        {
            int found = 0;
            for (int j = 0; j < m; j++)
            {
                if (U[i] == X[j])
                {
                    found = 1;
                    break;
                }
            }
            if (found == 0)
            {
                complementX[complementXSize] = U[i];
                complementXSize++;
            }
        }
        for (int i = 0; i < complementXSize; i++)
        {
            Console.Write("{0,5}", complementX[i]);
        }

        // Доповнення Y
        Console.WriteLine("\n\nДоповнення Y:");
        int[] complementY = new int[n];
        int complementYSize = 0;
        for (int i = 0; i < n; i++)
        {
            int found = 0;
            for (int j = 0; j < r; j++)
            {
                if (U[i] == Y[j])
                {
                    found = 1;
                    break;
                }
            }
            if (found == 0)
            {
                complementY[complementYSize] = U[i];
                complementYSize++;
            }
        }
        for (int i = 0; i < complementYSize; i++)
        {
            Console.Write("{0,5}", complementY[i]);
        }

        // Прямий добуток X × Y (прямокутний масив)
        Console.WriteLine("\n\nПрямий добуток X × Y:");
        int[,] cartesian = new int[m * r, 2];
        int k = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < r; j++)
            {
                cartesian[k, 0] = X[i];
                cartesian[k, 1] = Y[j];
                k++;
            }
        }
        for (int i = 0; i < m * r; i++)
        {
            Console.Write("({0,2},{1,2}) ", cartesian[i, 0], cartesian[i, 1]);
            if ((i + 1) % 3 == 0) Console.WriteLine(); // Для зручності
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}
