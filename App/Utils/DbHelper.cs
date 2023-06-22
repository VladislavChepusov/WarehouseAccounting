using App.DAL.Entities;
using App.DAL;
using Microsoft.EntityFrameworkCore;

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


        public static async Task  SaveDataToDatabase<T>(List<T> dataList) where T : class, IEntity
        {
               
            using var dbContext = new MyDbContext();
            var existingItems = await dbContext.Set<T>().Select(x => x.ID).ToListAsync();
            var newItems = dataList.Where(x => !existingItems.Contains(x.ID));

            await dbContext.Set<T>().AddRangeAsync(newItems);
            await dbContext.SaveChangesAsync();

        }


        //public static void SaveDataToDatabase(List<Pallet> dataList, string tableName)
        //{

        //    using var dbContext = new MyDbContext();

        //    var existingItems = dbContext.Pallets.Select(x => x.ID).ToList();

        //    // Добавляем в таблицу только объекты, которых еще нет в базе данных
        //    var newItems = dataList.Where(x => !existingItems.Contains(x.ID));
        //    dbContext.Pallets.AddRange(newItems);

        //    //  dbContext.Pallets.AddRange(dataList);
        //    dbContext.SaveChanges();
        //}

       

    }
}
