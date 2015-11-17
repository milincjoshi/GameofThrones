using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_of_Thrones.ViewModels
{
    public class CharacterGroup
    {
      public List<CharacterData> CharacterItems { get; set; }

      public CharacterGroup()
      {
          CharacterItems = new List<CharacterData>();
      }
    }
}
