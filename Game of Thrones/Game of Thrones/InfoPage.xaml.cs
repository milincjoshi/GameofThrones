using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media.Imaging;
using Coding4Fun.Toolkit.Controls;
using System.IO;
using Game_of_Thrones.Resources;
using System.Globalization;
using System.Threading;

namespace Game_of_Thrones
{
    public partial class InfoPage : PhoneApplicationPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }
        void Home_Click(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
        void Exit_Click(object sender, EventArgs e)
        {
            Application.Current.Terminate();
        }

        void About_Click(object sender, EventArgs e)
        {
            AboutPrompt AboutAuthor = new AboutPrompt();
            AboutAuthor.Show("Milin Joshi", "@milincjoshi", "milincjoshi@yahoo.com", "http://milincjoshi.wordpress.com");
        }
        private void Parents_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ListPage.xaml?id=Parents-" + charactername.Text + "", UriKind.Relative));
        }

        private void Spouse_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ListPage.xaml?id=Spouse-" + charactername.Text + "", UriKind.Relative));
        }

        private void Children_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ListPage.xaml?id=Children-" + charactername.Text + "", UriKind.Relative));
        }

        private void Siblings_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ListPage.xaml?id=Siblings-" + charactername.Text + "", UriKind.Relative));
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationBar = new ApplicationBar();

            ApplicationBarIconButton Home = new ApplicationBarIconButton();
            Home.Text = AppResources.Home;
            Home.IconUri = new Uri("/Assets/Icons/appbar.home.png", UriKind.Relative);
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

            charactername.Text = string.Format(NavigationContext.QueryString["id"]);

            //string imgsrc = "/Assets/CharacterImages/" + charactername.Text + ".jpg";
            string imgsrc = "Assets\\CharacterImages\\" + charactername.Text+ ".jpg";

            //flag code for setting the  image except x
            String[] filenames = System.IO.Directory.GetFiles("Assets\\CharacterImages");


            //Language code
            CultureInfo currentCulture = Thread.CurrentThread.CurrentUICulture;
            StreamReader myReader;
            MessageBox.Show(currentCulture.ToString());
            //English
            if (currentCulture.ToString().Contains("en"))
            {
                myReader = new StreamReader("Assets/Language/en.txt");
            }
            //Spanish
            else if (currentCulture.ToString().Contains("es"))
            {
                myReader = new StreamReader("Assets/Language/spanish-es.txt");
            }
            //French
            else if (currentCulture.ToString().Contains("fr"))
            {
                myReader = new StreamReader("Assets/Language/french-fr.txt");
            }
            //German
            else if (currentCulture.ToString().Contains("de"))
            {
                myReader = new StreamReader("Assets/Language/german-de.txt");
            }
            //Afrikaans
            else if (currentCulture.ToString().Contains("af"))
            {
                myReader = new StreamReader("Assets/Language/afrikaans-af.txt");
            }
            //portugese
            else if (currentCulture.ToString().Contains("pt"))
            {
                myReader = new StreamReader("Assets/Language/portugese.txt");
            }
            else
            {
                myReader = new StreamReader("Assets/Language/en.txt");
            
            }
            
            int f = 0;

            foreach (var item in filenames)
            {
                if (item == imgsrc)
                {
                    f = 1;
                    break;
                }

            }
            if (f == 0)
            {
                imgsrc = "\\Assets\\CharacterImages\\x.jpg";
            }
            //flag code ends

            characterimg.Source = new BitmapImage(new Uri(imgsrc, UriKind.Relative));


            

            //reading from info file
            //StreamReader myReader = new StreamReader("Assets/Info.txt");
            string line = "a";

            try
            {
                while (line != null)
                {
                    line = myReader.ReadLine();
                    if (line.Contains(charactername.Text + " Info"))
                    {
                        int i = line.IndexOf(",");
                        line = line.Substring(i + 2);
                        infobox.Text = line;
                        break;
                    }
                    else
                    {
                        infobox.Text = "Information about this Character coming soon...";
                    }
                }
            }
            catch (Exception)
            {
                infobox.Text = "Information about this character coming soon...";
            }

            }
        
    }
}