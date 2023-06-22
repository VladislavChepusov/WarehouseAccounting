using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Entities
{
    public class Box : StorageObject
    {
        public DateOnly ProductionDate { get; set; }

        public Box(double width, double height, double depth,
            double weight, DateOnly productionDate, DateOnly expirationDate)
            : base(width, height, depth)
        {
            Weight = weight;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
        }
    }
}
