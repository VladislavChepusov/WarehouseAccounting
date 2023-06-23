using App.DAL.Entities;
using App.DAL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.Utils
{
    public class DbHelper
    {

        public static void InitialMigrate()
        {
            using var dbContext = new MyDbContext();
            try
            {
                dbContext.Database.OpenConnection(); // открываем соединение с базой данных
                if (dbContext.Database.CanConnect()) // проверяем возможность подключения
                {
                    dbContext.Database.Migrate(); // Выполнение миграций при запуск
                }
                else
                {
                    Console.WriteLine("Не удалось подключиться к БД!");
                }
            }
            catch (Exception ex)
            {
                try
                {
                    dbContext.Database.Migrate(); // Выполнение миграций при запуск
                }
                catch
                {
                    Console.WriteLine($"Ошибка при подключении к БД: {ex.Message}");
                }
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
                return dbContext.Pallets.Include(x => x.Boxes).ToList();
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

        public static async Task SaveDataToDatabaseBox(List<Box> dataList) 
        {
            using var dbContext = new MyDbContext();
            var existingItems = await dbContext.Boxes.Select(x => x.BoxID).ToListAsync();
            var newItems = dataList.Where(x => !existingItems.Contains(x.BoxID)).ToList();
            var existingItemsToUpdate = dataList.Where(x => existingItems.Contains(x.BoxID)).ToList();
            await dbContext.Boxes.AddRangeAsync(newItems);
            dbContext.Boxes.UpdateRange(existingItemsToUpdate);
            await dbContext.SaveChangesAsync();
        }

        public static async Task SaveDataToDatabasePallet(List<Pallet> dataList)
        {
            using var dbContext = new MyDbContext();
            var existingItems = await dbContext.Pallets.Select(x => x.PalletID).ToListAsync();
            var newItems = dataList.Where(x => !existingItems.Contains(x.PalletID)).ToList();
            var existingItemsToUpdate = dataList.Where(x => existingItems.Contains(x.PalletID)).ToList();
            await dbContext.Pallets.AddRangeAsync(newItems);
            dbContext.Pallets.UpdateRange(existingItemsToUpdate);
            await dbContext.SaveChangesAsync();
        }


        //public static async Task SaveDataToDatabase<T>(List<T> dataList) where T : class, IEntity
        //{
        //    using var dbContext = new MyDbContext();
        //    var existingItems = await dbContext.Set<T>().Select(x => x.).ToListAsync();
        //    var newItems = dataList.Where(x => !existingItems.Contains(x.ID)).ToList();
        //    var existingItemsToUpdate = dataList.Where(x => existingItems.Contains(x.ID)).ToList();
        //    await dbContext.Set<T>().AddRangeAsync(newItems);
        //    dbContext.Set<T>().UpdateRange(existingItemsToUpdate);
        //    await dbContext.SaveChangesAsync();
        //}
    }
}
