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

namespace ProjectUWP.views.Category
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryFormPage : Page
    {
        public CategoryViewModel CategoryViewModel { get; set; }
        public CategoryFormPage()
        {
            CategoryViewModel = new CategoryViewModel();
            this.InitializeComponent();
        }

        public async void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (await CategoryViewModel.CreateCategoryAsync())
            {
                CategoryViewModel.LoadAllAsync();
                this.Frame.GoBack();
            }
            else
            {
                //give feedback
                //flyout
            }
        }
    }
}
