using App;
using App.DAL;
using App.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

internal class Program
{
    public static void InitialMigrate()
    {
        using var dbContext = new MyDbContext();
        try
        {
            dbContext.Database.OpenConnection(); // открываем соединение с базой данных

            if (dbContext.Database.CanConnect()) // проверяем возможность подключения
            {
                //Console.WriteLine("Успешно подключились к БД!");
                dbContext.Database.Migrate(); // Выполнение миграций при запуск
            }
            else
            {
                Console.WriteLine("Не удалось подключиться к БД!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при подключении к БД: {ex.Message}");
        }
        finally
        {
            dbContext.Database.CloseConnection(); // закрываем соединение с базой данных
        }
    }

    public static List<Pallet> loadingPalet()
    {
        try
        {
            using var dbContext = new MyDbContext();
            return dbContext.Pallets.ToList();
        }
        catch (Exception ex)
        {
            return new List<Pallet>();
        }
    }

    public static List<Box> loadingBoxes()
    {
        try
        {
            using var dbContext = new MyDbContext();
            return dbContext.Boxes.ToList();
        }
        catch (Exception ex)
        {
            return new List<Box>();
        }
    }


    private static void Main(string[] args)
    {
        InitialMigrate();

        List<Box> boxes = loadingBoxes(); ;
        List<Pallet> pallets = loadingPalet();


        //foreach (Pallet pal in pallets)
        //{
        //    Console.WriteLine("____________________________");
        //    Console.WriteLine($"{pal.ID} {pal.Height} {pal.Width} {pal.Depth} {pal.Weight} {pal.Volume}  {pal.Boxes} ");
        //}


      



        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("Введите команду:");
            Console.WriteLine("1 - Создать коробку");
            Console.WriteLine("2 - Создать паллету");
            Console.WriteLine("3 - Посмотреть список коробок");
            Console.WriteLine("4 - Посмотреть список паллет");
            Console.WriteLine("5 - Добавить коробку на паллету");
            Console.WriteLine("6 - Вывод трех паллет, которые содержат коробки с наибольшим сроком годности");
            Console.WriteLine("7 - Сохранение данных");
            Console.WriteLine("* пункт 4 осуществляет группировку паллет по сроку годности и т.д.");
            Console.WriteLine("q Выход");

            Console.Write("Выберите пункт меню: ");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "1":
                    // Код для выполнения задачи 1
                    Console.WriteLine("Задача 1");
                    break;

                case "2":
                    // Код для выполнения задачи 2
                    Console.WriteLine("Задача 2");
                    break;

                case "q":
                    // Выход из цикла while
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                    break;
            }

            Console.WriteLine();
        }
    }
}