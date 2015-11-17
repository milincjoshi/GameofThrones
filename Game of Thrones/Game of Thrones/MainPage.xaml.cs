using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Game_of_Thrones.ViewModels;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using Coding4Fun.Toolkit.Controls;
using Game_of_Thrones.Resources;

namespace Game_of_Thrones
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
              InitializeComponent();


            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;

            //// Add a new background Image
            BitmapImage bitmapImage = new BitmapImage(new Uri("PanoramaBackground.png", UriKind.Relative));
            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = bitmapImage;
            PanoControl.Background = imageBrush;
      
            ApplicationBar = new ApplicationBar();
          
           
            //adding an iconbutton
            ApplicationBarIconButton About = new ApplicationBarIconButton();
            About.Text = AppResources.About;
            About.Click += About_Click;
            About.IconUri = new Uri("/Assets/Icons/appbar.information.circle.png", UriKind.Relative);

            //adding another icon button
            ApplicationBarIconButton Exit = new ApplicationBarIconButton();
            Exit.Text = AppResources.Exit;
            Exit.Click += Exit_Click;
            Exit.IconUri = new Uri("/Assets/Icons/appbar.stop.png", UriKind.Relative);

            //ApplicationBar.Buttons.Add(Home);
            ApplicationBar.Buttons.Add(About);
            ApplicationBar.Buttons.Add(Exit);


        }

        void Exit_Click(object sender, EventArgs e)
        {
            //terminating app on exit click
            Application.Current.Terminate();
        }

        void About_Click(object sender, EventArgs e)
        {
            //code for about prompt
            AboutPrompt AboutAuthor = new AboutPrompt();
            AboutAuthor.Show("Milin Joshi", "@milincjoshi", "milincjoshi@yahoo.com", "http://milincjoshi.wordpress.com");
        }

        
        // Load data for the ViewModel Items
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void LongListSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // Taking a selector for selecting the file to be played
            LongListSelector selector = sender as LongListSelector;

            //verifying its a selector
            if (selector == null)
                return;

            //refrencing selected item as HouseData data
            HouseData Data = selector.SelectedItem as HouseData;

            //retrievinh housedata title
            string Houseretrieve = Data.HouseTitle;

            //navigating to list page on click
            NavigationService.Navigate(new Uri("/ListPage.xaml?id=" + Houseretrieve + "", UriKind.Relative));
        }

        private void LongListSelector_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            //selecting for character select
            LongListSelector selector = sender as LongListSelector;
            
            //verifying its a selector
            if (selector == null)
                return;

            //refrencing selected data as Character Data CData
            CharacterData CData = selector.SelectedItem as CharacterData;
            string Characterretrieve = CData.CharacterName;

            //navigating to info page for character info
            NavigationService.Navigate(new Uri("/InfoPage.xaml?id="+Characterretrieve+"",UriKind.Relative));
        }

     
    }
}