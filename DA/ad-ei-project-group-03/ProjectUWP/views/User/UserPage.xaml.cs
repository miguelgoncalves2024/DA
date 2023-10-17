using ProjectUWP.viewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectUWP.views.User
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserPage : Page
    {
        UserViewModel userViewModel {get; set;}

      //  public bool isLoggedIn = false;
        public UserPage()
        {
            userViewModel = new UserViewModel();
            this.InitializeComponent();
        }
        private void PassportSignInButton_Click(object sender, RoutedEventArgs e)
        {
            if (cb1.IsChecked==true)
            {
                Frame.Navigate(typeof(ManagerInfo));
            }
            else
            {
                Frame.Navigate (typeof(ClientInfo));
            }
        }
        private void RegisterButtonTextBlock_OnPointerPressed(object sender, PointerRoutedEventArgs e)
        {
            if (cb1.IsChecked == true)
            {
                Frame.Navigate(typeof(ManagerSignIn));
            }
            else
            {
                Frame.Navigate(typeof(ClientSignIn));
            }
        }
        private void HandleCheck(object sender, RoutedEventArgs e)
        {
            UsernameManager.Visibility = Visibility.Visible;
            UsernameManagerpass.Visibility = Visibility.Visible;
            UsernameClientpass.Visibility = Visibility.Collapsed;
            UsernameClient.Visibility = Visibility.Collapsed;
        }
        private void HandleUnchecked(object sender, RoutedEventArgs e)
        {
            UsernameManager.Visibility = Visibility.Collapsed;
            UsernameManagerpass.Visibility = Visibility.Collapsed;
            UsernameClient.Visibility = Visibility.Visible;
            UsernameClientpass.Visibility= Visibility.Visible;
        }
    }
}
