namespace ConAppTask1;
public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Виберіть спосіб введення даних:");
        Console.WriteLine("1. З файлу");
        Console.WriteLine("2. З клавіатури");
        Console.WriteLine("3. Випадкові числа");
        Console.Write("Ваш вибір (1-3): ");
        string choice = Console.ReadLine();

        int[] array;
        int size = 0;

        if (choice == "1")
        {
            Console.Write("Введіть шлях до файлу: ");
            string path = Console.ReadLine();
            string[] lines = File.ReadAllLines(path);
            size = lines.Length;
            array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = Convert.ToInt32(lines[i]);
            }
        }
        else if (choice == "2")
        {
            Console.Write("Введіть розмір масиву: ");
            size = Convert.ToInt32(Console.ReadLine());
            array = new int[size];
            Console.WriteLine("Введіть елементи масиву:");
            for (int i = 0; i < size; i++)
            {
                Console.Write("Елемент " + (i + 1) + ": ");
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        else if (choice == "3")
        {
            Console.Write("Введіть розмір масиву: ");
            size = Convert.ToInt32(Console.ReadLine());
            array = new int[size];
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                array[i] = rnd.Next(-50, 51); 
            }
        }
        else
        {
            Console.WriteLine("Невірний вибір. Завершення програми.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("\nПочатковий масив:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0,5}", array[i]);
        }

        
        int max1 = array[0];
        int max2 = array[0];
        int max3 = array[0];
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max1)
            {
                max3 = max2;
                max2 = max1;
                max1 = array[i];
            }
            else if (array[i] > max2)
            {
                max3 = max2;
                max2 = array[i];
            }
            else if (array[i] > max3)
            {
                max3 = array[i];
            }
        }
        int sum = max1 + max2 + max3;
        Console.WriteLine("\n\nСума трьох найбільших елементів: " + sum);

        
        for (int i = 0; i < array.Length; i++)
        {
            if ((i + 1) % 10 == 0) 
            {
                array[i] = array[i] + sum;
            }
            else if ((i + 1) % 5 == 0) 
            {
                array[i] = array[i] - sum;
            }
        }

        Console.WriteLine("\nМодифікований масив:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0,5}", array[i]);
        }
        Console.WriteLine();
        Console.ReadKey();
    }
}