using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class StorageObject
    {
        [Key]
        public Guid ID { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Depth { get; set; }
        public double Weight { get; set; }
        public double Volume => Width * Height * Depth;
        public DateOnly ExpirationDate { get; set; }


        public StorageObject() {
            ID = Guid.NewGuid();
        }
    }
}
