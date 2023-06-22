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
    }
}
