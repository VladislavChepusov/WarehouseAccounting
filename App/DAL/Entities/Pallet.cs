using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Pallet : StorageObject
    {
 
        protected virtual ICollection<Box>? boxes { get; set; }
        public Pallet() : base(0, 0, 0)  { boxes = new List<Box>(); }

        public Pallet(double width, double height, double depth)
            : base(width, height, depth)
        {
            weight = 30;
            volume = width * height * depth;
            boxes = new List<Box>();
        }

        public Guid PalletID
        {
            get { return ID; }
            private set { ID = value; } 
        }

        public double PalletWidth
        {
            get { return width; }
            private set { width = value; }
        }

        public double PalletHeight
        {
            get { return height; }
            private set { height = value; }
        }

        public double PalletDepth
        {
            get { return depth; }
            private set { depth = value; }
        }

        public double PalletWeight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double PalletVolume
        {
            get { return volume; }
            set { volume = value; }
        }

        public DateOnly PalletExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        public ICollection<Box> Boxes
        {
            get { return boxes; }
            set { boxes = value; }
        }

        public void AddBox(Box box)
        {
            Boxes.Add(box);
        }

    }
}
