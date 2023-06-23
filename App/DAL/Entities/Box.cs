using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Box : StorageObject
    {
 
        private DateOnly productionDate { get; set; }

        private Guid palletID;

        public Box() : base(0, 0, 0){   }

        public Box(Guid IdPallet,double width, double height, double depth,
            double weight, DateOnly productionDate, DateOnly expirationDate)
            : base(width, height, depth)
        {
            this.BoxVolume = width * height * depth;
            this.BoxID = Guid.NewGuid();
            this.PalletID = IdPallet;
            this.weight = weight;
            this.productionDate = productionDate;
            this.expirationDate = expirationDate;
        }

        public Guid BoxID
        {
            get { return ID; }
            private set { ID = value; }  
        }
  
        public Guid PalletID
        {
            get { return palletID; }
            set { palletID = value; }
        }

        public double BoxWidth
        {
            get { return width; }
            private set { width = value; }
        }

        public double BoxHeight
        {
            get { return height; }
            private set { height = value; }
        }

        public double BoxDepth
        {
            get { return depth; }
            private set { depth = value; }
        }

        public double BoxWeight
        {
            get { return weight; }
            set { weight = value; }
        }

        public double BoxVolume
        {
            get { return volume; }
            set { volume = value; }
        }

        public DateOnly BoxExpirationDate
        {
            get { return expirationDate; }
            set { expirationDate = value; }
        }

        public DateOnly BoxProductionDate
        {
            get { return productionDate; }
            set { productionDate = value; }
        }
    }
}
