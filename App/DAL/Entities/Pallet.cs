using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Pallet : StorageObject
    {
        public virtual ICollection<Box>? Boxes { get; set; }
        //  public List<Box> Boxes { get; set; } = new List<Box>();

        public Pallet(double width, double height, double depth)
            : base(width, height, depth)
        {
            Weight = 30;
            Boxes = new List<Box>();
        }
    }
}
