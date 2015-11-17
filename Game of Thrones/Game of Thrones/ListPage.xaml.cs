using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using Coding4Fun.Toolkit.Controls;
using Game_of_Thrones.Resources;

namespace Game_of_Thrones
{
    public partial class ListPage : PhoneApplicationPage
    {
        public ListPage()
        {
            InitializeComponent();
        }

        private void HouseMembersListDesign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LongListSelector selector = sender as LongListSelector;

             //verifying its a selector.
             if (selector == null)
                 return;
         
             //getting selected item from list
             chrctr character = selector.SelectedItem as chrctr;
             string chrctrsend = character.Title;
             NavigationService.Navigate(new Uri("/InfoPage.xaml?id="+chrctrsend+"",UriKind.Relative));
        }

        void Home_Click(object sender, EventArgs e)
        {
            //navigating to home on home click
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        void Exit_Click(object sender, EventArgs e)
        {
            //terminating app on clicking exit
            Application.Current.Terminate();
        }

        void About_Click(object sender, EventArgs e)
        {
            //showing about on about prompt
            AboutPrompt AboutAuthor = new AboutPrompt();
            AboutAuthor.Show("Milin Joshi", "@milincjoshi", "milincjoshi@yahoo.com", "http://milincjoshi.wordpress.com");
        }
        private void HouseMembersListDesign_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationBar = new ApplicationBar();

            //adding application bar icon button
            ApplicationBarIconButton Home = new ApplicationBarIconButton();
            Home.Text = AppResources.Home;
            Home.IconUri = new Uri("/Assets/Icons/appbar.home.png",UriKind.Relative);
            Home.Click += Home_Click;

            ApplicationBarIconButton About = new ApplicationBarIconButton();
            About.Text = AppResources.About;
            About.Click += About_Click;
            About.IconUri = new Uri("/Assets/Icons/appbar.information.circle.png", UriKind.Relative);

            ApplicationBarIconButton Exit = new ApplicationBarIconButton();
            Exit.Text = AppResources.Exit;
            Exit.Click += Exit_Click;
            Exit.IconUri = new Uri("/Assets/Icons/appbar.stop.png", UriKind.Relative);

            ApplicationBar.Buttons.Add(Home);
            ApplicationBar.Buttons.Add(About);
            ApplicationBar.Buttons.Add(Exit);

            //using querystring to retrieve the house,character or place clicked
            string header = string.Format("" + NavigationContext.QueryString["id"] + "");

            if (header.Contains("House"))
            {
                //Split members of the house
                Members.Header = AppResources.Members;

                //Assign Header of Pivot as "House Name"
                PivotTitle.Title = string.Format("" + NavigationContext.QueryString["id"] + "");
                
                //Separting Word "House" from PivotTitle
                string House = PivotTitle.Title.ToString();
                int i = House.IndexOf(" ");
                House = House.Substring(i + 1);

                //Reading from the textfile
                StreamReader myReader = new StreamReader("Assets/ftr.txt");
                char seperator = ' ';

                string line = "a";

                //creating new instance of chrctr list type
                //doing this matches the datatypes of characterdata and the list "Mychrctr" we are making
                List<chrctr> Mychrctr = new List<chrctr>();

                //Reading until the end of the file
                while (line != null)
                {
                    line = myReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    if (line.Contains("House") && line.Contains(House))
                    {
                        //splitting line from spaces
                        string[] InitialHouseMembersList = line.Split(seperator);

                        //adding array members of initialhousememberlist to housememberslist for display
                        string img;

                        //img = "/Assets/CharacterImages/" + InitialHouseMembersList[0] + ".jpg";
                        img = "Assets\\CharacterImages\\" + InitialHouseMembersList[0] + ".jpg";

                        //flag code for setting the  image
                        String[] filenames = System.IO.Directory.GetFiles("Assets\\CharacterImages");

                        int f = 0;

                        foreach (var item in filenames)
                        {
                            if (item == img)
                            {
                                f = 1;
                                break;
                            }

                        }
                        if (f == 0)
                        {
                            img = "\\Assets\\CharacterImages\\x.jpg";
                        }
                        //flag code ends



                        Mychrctr.Add(new chrctr(InitialHouseMembersList[0], img));
                    }

                }

                HouseMembersListDesign.ItemsSource = Mychrctr;
            }

            else if (header.Contains("Parents"))
            {
                //get parents of the member clicked
                string iheader = header;
                string iheader1, iheader2;
                int i = iheader.IndexOf("-");
                //iheader1 is string representing relationship
                iheader1 = iheader.Substring(0, i);

                //iheader2 is string representing person
                iheader2 = iheader.Substring(i + 1);

                PivotTitle.Title = iheader2;
                
                Members.Header = AppResources.Parents;
                
                assign("Parents", iheader2);
          

            }
            else if (header.Contains("Spouse"))
            {
                   string iheader = header;
                string iheader1, iheader2;
                int i = iheader.IndexOf("-");
             
                //iheader1 is string representing relationship
                iheader1 = iheader.Substring(0, i);

                //iheader2 is string representing person
                iheader2 = iheader.Substring(i + 1);

                PivotTitle.Title = iheader2;
                
                Members.Header = AppResources.Spouse;
                
                assign("Spouse", iheader2);
                
            }
            else if (header.Contains("Children"))
            {

                //get children of the member cliicked
                //get parents of the member clicked
                string iheader = header;
                string iheader1, iheader2;
                int i = iheader.IndexOf("-");
                //iheader1 is string representing relationship
                iheader1 = iheader.Substring(0, i);

                //iheader2 is string representing person
                iheader2 = iheader.Substring(i + 1);

                PivotTitle.Title = iheader2;
                
                Members.Header = AppResources.Children;
                
                assign("Children", iheader2);
                //

                //
            }
            else if (header.Contains("Siblings"))
            {
                //get sibling of the member cicked
                //get parents of the member clicked
                string iheader = header;
                string iheader1, iheader2;
                int i = iheader.IndexOf("-");
                //iheader1 is string representing relationship
                iheader1 = iheader.Substring(0, i);

                //iheader2 is string representing person
                iheader2 = iheader.Substring(i + 1);

                PivotTitle.Title = iheader2;

                Members.Header = AppResources.Siblings;
                
                assign("Sibling", iheader2);
               
            }
        }
         public void assign(string arg1,string arg2)
         {
             StreamReader myReader = new StreamReader("Assets/ftr.txt");
             char seperator = ' ';
             string line = "a";

             //creating new instance of chrctr list type
             List<chrctr> Mychrctr = new List<chrctr>();

             //Reading until the end of the file
             while (line != null)
             {
                 line = myReader.ReadLine();

                 if (line == null)
                 {
                     break;
                 }

                 string[] a = line.Split(' ');

                 if (line.Contains(arg1) && a[0]==arg2)
                 {
                     //splitting line from spaces
                     string[] InitialHouseMembersList = line.Split(seperator);
                 
                     string img;
                   //  img = "/Assets/CharacterImages/" + InitialHouseMembersList[2] + ".jpg";
                     img = "Assets\\CharacterImages\\" + InitialHouseMembersList[2] + ".jpg";


                     //flag code for setting the  image
                     String[] filenames = System.IO.Directory.GetFiles("Assets\\CharacterImages");

                     int f = 0;

                     foreach (var item in filenames)
                     {
                         if (item == img)
                         {
                             f = 1;
                             break;
                         }

                     }
                     if (f==0)
                     {
                         img = "\\Assets\\CharacterImages\\x.jpg";
                     }
                     //flag code ends


                     //adding array members of initialhousememberlist to housememberslist for display
                     Mychrctr.Add(new chrctr(InitialHouseMembersList[2],img));
                 }

             }

             //Binding mychrctr to housememberslistdesign list
             HouseMembersListDesign.ItemsSource = Mychrctr;
             
         }
         public class chrctr
         {
             public string Photo { get; set; }
             public string Title { get; set; }
             public chrctr(string title, string imageUri)
             {
                 this.Title = title;
                 this.Photo = imageUri;
             }
         }


    }
}
