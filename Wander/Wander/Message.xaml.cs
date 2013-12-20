using Wander.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.ApplicationModel.Resources;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace Wander
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class Message : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private String textPassed;
        private WanderLib.Sight sight;
        private DataController dataController;

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public Message()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
            dataController = DataController.getInstance();
            updateStringsWithCurrentLanguage();
            
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {

        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);

            textPassed = e.Parameter.ToString();
            List<WanderLib.Waypoint> sights = new List<WanderLib.Waypoint>();

            sights = dataController.giveAllWaypointsOnRoute();

            foreach(WanderLib.Waypoint s in sights)
            {
                if (s.GetType() == (typeof(WanderLib.Sight)))
                {
                    if (((WanderLib.Sight)s).name == textPassed)
                    {
                        sight = ((WanderLib.Sight)s);
                        if (sight.information == "")
                        {
                            ResourceLoader rl = new ResourceLoader();
                            tekstboxtest.DataContext = rl.GetString("noDescription");
                        }
                        else
                            tekstboxtest.Text = sight.information;
                        pageTitle.Text = sight.name;
                        List<string> l = new List<string>();
                        if (sight.media == null)
                        {
                            System.Diagnostics.Debug.WriteLine("NULL");
                        }
                        else
                        {
                            List<string> locationsPhoto = new List<string>();
                            List<string> locationsAudio = new List<string>();
                            List<string> locationsVideo = new List<string>();
                            List<WanderLib.Media.Media.Type> list = new List<WanderLib.Media.Media.Type>(sight.media.Values);
                            foreach (var pair in sight.media)
                            {
                                if (pair.Value == WanderLib.Media.Media.Type.PHOTO)
                                {
                                    locationsPhoto.Add(pair.Key.fileLocation);
                                }
                                else if (pair.Value == WanderLib.Media.Media.Type.VIDEO)
                                {
                                    locationsVideo.Add(pair.Key.fileLocation);
                                }
                                else if (pair.Value == WanderLib.Media.Media.Type.AUDIO)
                                {
                                    locationsAudio.Add(pair.Key.fileLocation);
                                }
                                else System.Diagnostics.Debug.WriteLine("Er is een unsupported file found.");
                            }
                            mediaElement.Source = new Uri("ms-appx:///Assets/VideoVoorSample.mp4");
                            imageElement.ItemsSource = locationsPhoto;
                        }
                        mediaElement.AutoPlay = false;
                        break;
                    }
                }
            }   
        }

        void ContextControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Make sure that the navigation buttons are updated by forcing focus to the FlipView
            imageElement.Focus(Windows.UI.Xaml.FocusState.Pointer);

        }

        #endregion

        private void MediaElement_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            mediaElement.IsFullWindow = !mediaElement.IsFullWindow;
        }

        private async void geluid_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Source = new Uri("ms-appx:///Assets/Farmer Dan - The Combine Harvester.mp3");
        }

        private async void video_Click(object sender, RoutedEventArgs e)
        {
            if (mediaElement.Source == new Uri("ms-appx:///Assets/VideoVoorSample.mp4"))
            {
                mediaElement.Source = new Uri("ms-appx:///Assets/Pop It, Dont Drop It Extended Loop (Team Service Announcement).mp4");
            }
            else if (mediaElement.Source != new Uri("ms-appx:///Assets/VideoVoorSample.mp4"))
            {
                mediaElement.Source = new Uri("ms-appx:///Assets/VideoVoorSample.mp4");
            }
        }

        public void updateStringsWithCurrentLanguage()
        {
            ResourceLoader rl = new ResourceLoader();
            video.Content = rl.GetString("Video");
            geluid.Content = rl.GetString("geluid");
        }

   
    }
}
