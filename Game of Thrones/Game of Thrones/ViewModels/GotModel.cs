using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Game_of_Thrones.ViewModels
{
    public class GotModel
    {    
      public HouseGroup Houses {get; set;}
      public CharacterGroup Characters{ get; set; }
      public PlaceGroup Places { get; set; }

      public bool IsDataLoaded;
      public void LoadData()
      {
          //Load data here
            
          Houses = CreateHouses();

          Characters = CreateCharacters();

          Places = CreatePlaces();

          IsDataLoaded = true;
      }

      private PlaceGroup CreatePlaces()
      {
          PlaceGroup PGroup = new PlaceGroup();
          String[] filenames = System.IO.Directory.GetFiles("Assets\\PlaceImages");

          foreach (var file in filenames)
          {
               string midfilename = file.Substring(19);
              int i = midfilename .IndexOf(".");
              string filename = midfilename.Substring(0, i);
             
              PGroup.PlaceItems.Add(new PlaceData() { PlaceName = filename , PlaceImage = file });
          }
          return PGroup;
      }

      private CharacterGroup CreateCharacters()
      {

          CharacterGroup CGroup = new CharacterGroup();
          
          //Getting all images from CharatcerImages folder
          String[] filenames = System.IO.Directory.GetFiles("Assets\\CharacterImages");
          
          //Spplitting name from file and adding it to CharacterGroup
          foreach (var file in filenames)
          {
              if (!file.Contains("x.jpg"))
              {
                  string midfilename = file.Substring(23);
                  int i = midfilename.IndexOf(".");
                  string filename = midfilename.Substring(0, i);

                  CGroup.CharacterItems.Add(new CharacterData() { CharacterName = filename, CharacterImage = file });
    
              }
              
          }

          
          
          return CGroup;
      }

      private HouseGroup CreateHouses()
      {
          //creating a basepath for retrieving image files
          string basepath = "/Assets/HouseImages/";

          //creating an instance of HouseGroup Class
          HouseGroup HGroup = new HouseGroup();

          //Using a StreamReader for getting House Names from the Text file Houses.txt
          StreamReader myReader = new StreamReader("Assets/Houses.txt");
          
          string line = "";

          //Reading until the end of the file
          while (line != null)
          {
              //reading lines one-byone from the text file
              line = myReader.ReadLine();
              if (line != null)
              {
                  int i = line.IndexOf("-");
              
                  string HouseName = line.Substring(4, i - 4);
          
                  string HouseQuote1 = line.Substring(i + 1);
          
                  string ImageCollection = HouseName.Substring(6).TrimEnd();
          
                  //Creating a new instance of HouseData Class and adding it to HouseGroup
                  HGroup.HouseItems.Add(new HouseData() { HouseTitle = HouseName, HouseQuote = HouseQuote1, HouseLogo = basepath + ImageCollection + ".png" });
              
              }
          }

          //Closing the Reader
          myReader.Close();

          return HGroup;
      }



    }
}
