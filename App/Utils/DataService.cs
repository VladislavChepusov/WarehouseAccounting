using App.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace App.Utils
{
    public class DataService
    {
        private static DateOnly GetDateOnly()
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
                    Console.Write("\nНекорректный ввод! Формат dd/mm/yyyy : ");
                }
            } while (true);
        }

        private static double GetPositiveDouble()
        {
            double input;
            do
            {
                string userInput = Console.ReadLine();

                if (double.TryParse(userInput, out input) && input > 0)
                {
                    return input;
                }
                else
                {
                    Console.Write("\nНекорректный ввод! Введите положительное число: ");
                }
            } while (true);
        }

        private static Guid GetGuid()
        {
            Guid input;
            do
            {
                string userInput = Console.ReadLine();

                if (Guid.TryParse(userInput, out input))
                {
                    return input;
                }
                else
                {
                    Console.Write("\nНекорректный ввод! Введите GUID в формате XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX: ");
                }
            } while (true);
        }

        private static bool BoxFitsOnPallet(double boxWidth, double boxDepth, double palletWidth, double palletDepth)
        {
            if (boxWidth <= palletWidth && boxDepth <= palletDepth)
                return true;

            if (boxDepth <= palletWidth && boxWidth <= palletDepth)
                return true;

            return false;
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


        //public static Box? CreateBox(List<Pallet> pallets)
        public static (Box?, List<Pallet>) CreateBox(List<Pallet> pallets)
        {

            Console.Write("Введите ширину коробки: ");
            double width = GetPositiveDouble();
            Console.Write("Введите высоту коробки: ");
            double height = GetPositiveDouble();
            Console.Write("Введите глубину коробки: ");
            double depth = GetPositiveDouble();

            bool findPallet = true;
            Guid IdPallet = new Guid();
            Pallet pl = new Pallet();
            while (findPallet)
            {
                Console.Write("Введите ID паллеты: ");
                IdPallet = GetGuid();
                pl = FindById(pallets, IdPallet, "PalletID");
                if (pl != null)
                {
                    if (BoxFitsOnPallet(width, depth, pl.PalletWidth, pl.PalletDepth))
                        findPallet = false;
                    else
                    {
                        Console.Write("\nКоробка не помещается на паллете");
                        return (null , pallets);
                    }

                }
                else
                    Console.Write("\nПаллета не найдена");

            }

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
                        Console.Write("\nНекорректный ввод. Попробуйте снова : ");
                        break;
                }
            }

            Box box = new Box(IdPallet, width, height, depth, weight, productionDate, expirationDate);

            pl.AddBox(box);

            
                

            return (box ,pallets);

        }
        private static T FindById<T>(List<T> list, Guid id, String property) where T : class
        {
            return list.FirstOrDefault(x => x.GetType().GetProperty(property).GetValue(x, null).Equals(id));
        }


        public static List<Pallet> RefreshPallet(List<Pallet> pallets, Guid PalletID)
        {
            var pl = FindById(pallets, PalletID, "PalletID");


           


            pl.PalletWeight = 30 + pl.Boxes.Sum(box => box.BoxWeight);

            pl.PalletExpirationDate = pl.Boxes.Min(box => box.BoxExpirationDate);

            pl.PalletVolume = (pl.PalletDepth * pl.PalletWidth * pl.PalletHeight ) 
                + pl.Boxes.Sum(box => box.BoxVolume);



            Console.WriteLine("ТУУУУУТ");
            Console.WriteLine($"pl.PalletWeight 30 + {pl.Boxes.Sum(box => box.BoxWeight)} = {30 + pl.Boxes.Sum(box => box.BoxWeight)}");
            Console.WriteLine($"pl.PalletWeight {pl.PalletWeight}");



            Console.WriteLine($"pl.PalletVolume {pl.PalletDepth} * {pl.PalletWidth} * {pl.PalletHeight}" +
                $"+{pl.Boxes.Sum(box => box.BoxVolume)} = {(pl.PalletDepth * pl.PalletWidth * pl.PalletHeight)
                + pl.Boxes.Sum(box => box.BoxVolume)}");

            Console.WriteLine($"pl.PalletVolume {pl.PalletVolume}");

            return pallets;
        }



        public static (List<Pallet>, List<Box>) FillPallet(List<Pallet> pallets, List<Box> boxes)
        //public static void FillPallet(List<Pallet> pallets, List<Box> boxes)
        {
            bool findBox = true;
            Guid IdBox = new Guid();
            Box bx = new Box();
            while (findBox)
            {
                Console.Write("\nВведите ID коробки: ");
                IdBox = GetGuid();
                bx = FindById(boxes, IdBox, "BoxID");
                if (bx != null)
                    findBox = false;
                else
                    Console.Write("\nКоробка не найдена");
            }

            Guid OldIDPallet = bx.PalletID;
            Pallet OldPallet = FindById(pallets, OldIDPallet, "PalletID");

            bool findPallet = true;
            Guid NewIdPallet = new Guid();
            Pallet pl = new Pallet();
            while (findPallet)
            {
                Console.Write("\nВведите ID паллеты: ");
                NewIdPallet = GetGuid();

                if (NewIdPallet == OldIDPallet)
                {
                    Console.Write("\nКоробка уже на этой паллете");
                    return (pallets, boxes);
                }

                pl = FindById(pallets, NewIdPallet, "PalletID");
                if (pl != null)
                {
                    if (BoxFitsOnPallet(bx.BoxWidth, bx.BoxDepth, pl.PalletWidth, pl.PalletDepth))
                        findPallet = false;
                    else
                    {
                        Console.Write("\nКоробка не помещается на паллете");
                        return (pallets, boxes);
                    }

                }
                else
                    Console.Write("\nПаллета не найдена");
            }

            bx.PalletID = NewIdPallet;
            RefreshPallet(pallets, OldIDPallet);
            RefreshPallet(pallets, NewIdPallet);
            return (pallets, boxes);
        }
    }

}
