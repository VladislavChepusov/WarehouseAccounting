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
    }
}
