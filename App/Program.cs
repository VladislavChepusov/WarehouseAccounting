using App.DAL.Entities;
using App.Utils;
using System.Reflection;

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
            Console.WriteLine("\nВведите команду:");
            Console.WriteLine("1 - Создать коробку");
            Console.WriteLine("2 - Создать паллету");
            Console.WriteLine("3 - Посмотреть список коробок");
            Console.WriteLine("4 - Посмотреть список паллет");
            Console.WriteLine("5 - Перенести коробку на паллету");
            Console.WriteLine("6 - Вывод трех паллет, которые содержат коробки с наибольшим сроком годности");
            Console.WriteLine("7 - Сохранение данных");
            Console.WriteLine("* пункт 4 осуществляет группировку паллет по сроку годности и т.д.");
            Console.WriteLine("q - Выход");

            Console.Write("\nВыберите пункт меню: ");
            string input = Console.ReadLine();

            switch (input.ToLower())
            {
                case "1":
                    if (pallets.Count > 0)
                    {
                        //Box bx = DataService.CreateBox(pallets);
                        Box bx = new Box() ;
                        (bx,pallets) = DataService.CreateBox(pallets);
                        if (bx != null)
                        {
                            boxes.Add(bx);
                            Console.WriteLine($"\nУспешно! ID Коробки: {bx.BoxID}");
                            DataService.RefreshPallet(pallets, bx.PalletID);
                        }

                    }
                    else
                        Console.WriteLine($"\nК сожалению у нас нету паллет для груза. Сначала создайте!");
                    break;

                case "2":
                    Pallet pl = DataService.CreatePallet();
                    pallets.Add(pl);
                    Console.WriteLine($"\nУспешно! ID Паллеты: {pl.PalletID}");
                    break;

                case "3":
                    foreach (Box pal in boxes)
                    {
                        Console.WriteLine("____________________________");
                        Type type = typeof(Box); // получаем тип класса Box
                        PropertyInfo[] properties = type.GetProperties(); // получаем все свойства класса Box

                        foreach (PropertyInfo property in properties)
                        {
                            object value = property.GetValue(pal); // получаем значение свойства объекта box
                            Console.WriteLine(property.Name + ": " + value); // выводим название свойства и его значение
                        }
                    }
                    break;

                case "4":
                    foreach (Pallet pal in pallets)
                    {
                        Console.WriteLine("____________________________");
                        Type type = typeof(Pallet); // получаем тип класса Box
                        PropertyInfo[] properties = type.GetProperties(); // получаем все свойства класса Box

                        foreach (PropertyInfo property in properties)
                        {
                            object value = property.GetValue(pal); // получаем значение свойства объекта box
                            Console.WriteLine(property.Name + ": " + value); // выводим название свойства и его значение
                        }

                        foreach (Box box in pal.Boxes)
                        {
                            Type type1 = typeof(Box); // получаем тип класса Box
                            PropertyInfo[] properties1 = type1.GetProperties(); // получаем все свойства класса Box

                            foreach (PropertyInfo property1 in properties1)
                            {
                                object value1 = property1.GetValue(box); // получаем значение свойства объекта box
                                Console.WriteLine(property1.Name + ": " + value1); // выводим название свойства и его значение
                            }
                        }


                    }
                    break;

                case "5":
                    if (pallets.Count > 1 && boxes.Count > 0)
                        (pallets, boxes) = DataService.FillPallet(pallets, boxes);
                    //DataService.FillPallet(pallets, boxes);
                    else
                        Console.WriteLine("\nНедостаточно коробок или паллет");
                    break;

                case "6":
                    break;

                case "7":
                    Task.Run(async () => await DbHelper.SaveDataToDatabaseBox(boxes));
                    pallets.ForEach(pallet => pallet.Boxes.Clear());
                    Task.Run(async () => await DbHelper.SaveDataToDatabasePallet(pallets));
                    Console.WriteLine("\nДанные сохраненны!");
                    break;

                case "q":
                    // Выход из цикла while
                    isRunning = false;
                    break;

                default:
                    Console.WriteLine("\nНекорректный ввод. Попробуйте снова.");
                    break;
            }

            Console.WriteLine();
        }
    }
}