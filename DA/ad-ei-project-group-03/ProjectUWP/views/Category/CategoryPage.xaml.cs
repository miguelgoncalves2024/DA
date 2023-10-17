using ProjectUWP.viewModels;
using ProjectUWP.views.product;
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

namespace ProjectUWP.views.Category
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryPage : Page
    {
        public CategoryViewModel CategoryViewModel { get; set; }
        public CategoryPage()
        {
            this.InitializeComponent();
            CategoryViewModel = new CategoryViewModel();

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            CategoryViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }

        public void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CategoryFormPage));
        }
        public void AppBarButton_Click_Back(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductPage));
        }
    }
}
