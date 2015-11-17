using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones.ViewModels
{
    public class HouseGroup
    {
        public List<HouseData> HouseItems { get; set; }
        public HouseGroup()
        {
            HouseItems = new List<HouseData>();
        }
    }
}
