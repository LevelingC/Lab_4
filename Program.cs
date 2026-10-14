
using System;

namespace Lab5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Розрахунок вартості паркування ===");
            // Введення вихідних даних
            Console.Write("Кількість хвилин стоянки: ");
            string minutesInput = Console.ReadLine();
            Console.Write("Парковка в центрі міста? (так/ні): ");
            string centerInput = Console.ReadLine().Trim().ToLower();
            // Перевірка коректності введення
            if (!int.TryParse(minutesInput, out int minutes) || minutes < 0)
            {
                Console.WriteLine("Введіть невід'ємне,ціле число");
            }
            else if (centerInput != "так" && centerInput != "ні")
            {
                Console.WriteLine("Помилка: введіть «так» або «ні».");
            }
            else
            {
                bool isCenter = centerInput == "так";
                double rate = isCenter ? 35.0 : 20.0;
                double cost;
                int chargedHours = 0;
                // Розрахунок вартості паркування
                if (minutes <= 15)
                {
                    cost = 0.0;
                }
                else if (minutes > 480)
                {
                    cost = 200.0;
                }
                else
                {
                    chargedHours = (int)Math.Ceiling((minutes - 15) / 60.0);
                    cost = chargedHours * rate;
                    //Визначення категорії через switch
                    string category = cost switch
                    {
                        0 => "безкоштовне паркування",
                        >= 100 and < 200 when isCenter => "звичайна вартість у центрі",
                        >= 100 and < 200 => "звичайна вартість",
                        >= 200 => "висока або добова вартість",
                        _ => "низька вартість"
                    };
                    // Виведення результатів
                    Console.WriteLine();
                    Console.WriteLine($"Тривалість стоянки: {minutes} хв.");
                    Console.WriteLine($"Розташування: {(isCenter ? "центр міста" : "поза центром")}");
                    if (minutes > 15 && minutes <= 480)
                    {
                        Console.WriteLine($"Кількість розпочатих оплачуваних годин: {chargedHours}");
                        Console.WriteLine($"Тариф за годину: {rate:F2} грн");
                    }
                    Console.WriteLine($"До сплати: {cost:F2} грн");
                    Console.WriteLine($"Категорія: {category}");
                }
            }
        }
    }
}
