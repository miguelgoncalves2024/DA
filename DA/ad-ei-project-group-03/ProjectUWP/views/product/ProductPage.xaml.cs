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
using ProjectUWP.viewModels;
using ProjectUWP.views.product;
using ProjectUWP.views.Category;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjectUWP.views.product
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 

   
    public sealed partial class ProductPage : Page
    {
        public ProductViewModel ProductViewModel { get; set; }
        public ProductPage()
        {
            ProductViewModel = new ProductViewModel();
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ProductViewModel.LoadAllAsync();
            base.OnNavigatedTo(e);
        }
        public void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ProductsFormPage));
        }
        //public void AppBarButton_Click_Back(object sender, RoutedEventArgs e)
        //{
        //    Frame.Navigate(typeof(ProductPage));
        //}

    }
}
