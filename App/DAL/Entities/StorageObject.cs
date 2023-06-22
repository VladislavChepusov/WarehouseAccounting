using System.ComponentModel.DataAnnotations;

namespace App.DAL.Entities
{
    public class StorageObject : IEntity
    {
        [Key]
        public Guid ID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public double Volume => Width * Height * Depth;
        public DateOnly ExpirationDate { get; set; }


        public StorageObject(double width, double height, double depth)
        {
            ID = Guid.NewGuid();
            Width = width;
            Height = height;
            Depth = depth;
        }
    }

    public interface IEntity
    {
        Guid ID { get; set; }
    }
}
