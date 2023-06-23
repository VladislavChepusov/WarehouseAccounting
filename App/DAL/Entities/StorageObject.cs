using System.ComponentModel.DataAnnotations;

namespace App.DAL.Entities
{
    public class StorageObject
    {
        [Key]
        protected Guid ID { get; set; }
        protected double width { get; set; }
        protected double height { get; set; }
        protected double depth { get; set; }
        protected double weight { get; set; }
        protected double volume { get; set; }
        protected DateOnly expirationDate { get; set; }


        public StorageObject(double _width, double _height, double _depth)
        {
            ID = Guid.NewGuid();
            width = _width;
            height = _height;
            depth = _depth;
        }
    }
}
