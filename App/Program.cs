using App.DAL.Entities;
using App.Utils;

internal class Program
{
    private static void Main(string[] args)
    {
        DbHelper.InitialMigrate();
        List<Box> boxes = DbHelper.loadingBoxes();
        List<Pallet> pallets = DbHelper.loadingPalet();

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
            Console.WriteLine("q - Выход");

            Console.Write("\nВыберите пункт меню: ");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "1":
                    Box bx = DataService.CreateBox();
                    boxes.Add(bx);
                    Console.WriteLine($"Успешно! ID Коробки: {bx.ID}");
                    break;

                case "2":
                    Pallet pl = DataService.CreatePallet();
                    pallets.Add(pl);
                    Console.WriteLine($"Успешно! ID Паллеты: {pl.ID}");
                    break;

                case "3":
                    foreach (Box pal in boxes)
                    {
                        Console.WriteLine("____________________________");
                        Console.WriteLine($"{pal.ID} {pal.Height} {pal.Width} {pal.Depth} {pal.Weight} {pal.Volume}   ");
                    }
                    break;

                case "4":
                    foreach (Pallet pal in pallets)
                    {
                        Console.WriteLine("____________________________");
                        Console.WriteLine($"{pal.ID} {pal.Height} {pal.Width} {pal.Depth} {pal.Weight} {pal.Volume}  {pal.Boxes} ");
                    }
                    break;

                case "5":

                    break;

                case "6":
                    break;

                case "7":
                    Task.Run(async () => await DbHelper.SaveDataToDatabase(pallets));
                    Task.Run(async () => await DbHelper.SaveDataToDatabase(boxes));
                    Console.WriteLine("Данные сохраненны!");
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