using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones.ViewModels
{
    public class PlaceGroup
    {
        public List<PlaceData> PlaceItems { get; set; }

        public PlaceGroup()
        {
            PlaceItems = new List<PlaceData>();
        }
    }
}
