using DomainLayer.Models;
using ProjectUWP.views.Category;
using ProjectUWP.views.product;
using ProjectUWP.views.ShoppingList;
using ProjectUWP.views.User;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjectUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            Category cat = new Category();
        }
        public void goback(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void NavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            NavigationViewItemBase itemBase = args.InvokedItemContainer;

            NavigationViewItem item = itemBase as NavigationViewItem;
            if (item != null)
            {
                switch (item.Tag)
                {
                    case "products":
                        inner_Frame.Navigate(typeof(ProductPage));
                        break;
                    case "categories":
                        inner_Frame.Navigate(typeof(CategoryPage));
                        break;
                    case "user":
                        inner_Frame.Navigate(typeof(UserPage));
                        break;
                    case "shopping-list":
                        inner_Frame.Navigate(typeof(ShoppingListPage));
                        break;
                }
            }

        }
    }
}
