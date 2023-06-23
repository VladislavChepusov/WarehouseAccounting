using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace App.DAL.Entities
{
    public class StorageObject /*: IEntity*/
    {
        [Key]
        protected Guid ID { get; set; }
        protected double width { get; set; }
        protected double height { get; set; }
        protected double depth { get; set; }
        protected double weight { get; set; }
        //protected double volume => width * height * depth;
        protected double volume { get; set; }
        protected DateOnly expirationDate { get; set; }


        public StorageObject(double _width, double _height, double _depth)
        {
            ID = Guid.NewGuid();
            width = _width;
            height = _height;
            depth = _depth;
        }

        //public Guid Id
        //{
        //    get { return ID; }
        //}

        //public double Width
        //{
        //    get { return width; }
        //}

        //public double Height
        //{
        //    get { return height; }
        //}

        //public double Depth
        //{
        //    get { return depth; }
        //}

        //public double Weight
        //{
        //    get { return weight; }
        //}

        //public double Volume
        //{
        //    get { return volume; }
        //}

        //public DateOnly ExpirationDate
        //{
        //    get { return expirationDate; }
        //}

        //Guid IEntity.ID
        //{
        //    get { return ID; }
        //    set { ID = value; }
        //}
    }

    //public interface IEntity
    //{
    //    Guid ID { get; set; }
    //}
}
