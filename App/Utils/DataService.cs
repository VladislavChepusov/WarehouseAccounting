using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Utils
{
    public class DataService
    {

        public static DateOnly GetDateOnly()
        {
            DateOnly input;
            do
            {
                string userInput = Console.ReadLine();

                if (DateOnly.TryParse(userInput, out input))
                {
                    return input;
                }
                else
                {
                    Console.Write("Некорректный ввод! Формат dd/mm/yyyy : ");
                }
            } while (true);
        }

        public static double GetPositiveDouble()
        {
            double input;
            do
            {
                string userInput = Console.ReadLine();

                if (double.TryParse(userInput, out input) && input > 0)
                {
                    // Если пользователь ввел корректный ввод, функция возвращает этот ввод
                    return input;
                }
                else
                {
                    Console.Write("Некорректный ввод! Введите положительное число: ");
                }
            } while (true);
        }


        public static Pallet CreatePallet()
        {
            Console.Write("Введите ширину паллеты: ");
            double width = GetPositiveDouble();
            Console.Write("Введите высоту паллеты: ");
            double height = GetPositiveDouble();
            Console.Write("Введите глубины паллеты: ");
            double depth = GetPositiveDouble();

            Pallet pallet = new Pallet(width, height, depth);
            return pallet;
        }


        public static Box CreateBox()
        {

            Console.Write("Введите ширину коробки: ");
            double width = GetPositiveDouble();
            Console.Write("Введите высоту коробки: ");
            double height = GetPositiveDouble();
            Console.Write("Введите глубины коробки: ");
            double depth = GetPositiveDouble();
            Console.Write("Введите вес коробки: ");
            double weight = GetPositiveDouble();
            Console.Write("Для ввода срока годности - 1 для даты производства - 2 : ");
            DateOnly productionDate = new DateOnly();
            DateOnly expirationDate = new DateOnly();
            bool isRunning = true;
            while (isRunning)
            {
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                        Console.Write("Введите дату срока годности коробки в формате dd.mm.yyyy : ");
                        expirationDate = GetDateOnly();
                        productionDate = expirationDate.AddDays(-100);
                        isRunning = false;
                        break;

                    case "2":
                        Console.Write("Введите дату производства коробки в формате dd.mm.yyyy : ");
                        productionDate = GetDateOnly();
                        expirationDate = productionDate.AddDays(100);
                        isRunning = false;
                        break;

                    default:
                        Console.Write("Некорректный ввод. Попробуйте снова : ");
                        break;
                }
            }

            Box box = new Box(width, height, depth, weight, productionDate, expirationDate);
            return box;

        }
    }
}
