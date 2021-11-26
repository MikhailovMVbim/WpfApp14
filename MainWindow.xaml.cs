using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Product> products;
        public MainWindow()
        {
            InitializeComponent();

            products = new ObservableCollection<Product>();
            products.Add(new Product()
            {
                ProductName = "Рыба",
                ProductPrice = 100,
                ProductCategory =ProductCategories.Еда
            });
            products.Add(new Product()
            {
                ProductName = "Холодильник",
                ProductPrice = 100,
                ProductCategory = ProductCategories.БытоваяТехника
            });
            lstBox.ItemsSource = products;

            List<string> categories = new List<string>();
            foreach (var item in Enum.GetValues(typeof(ProductCategories)))
            {
                categories.Add((item.ToString()));
            }
            newProductCategory.ItemsSource = categories;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((newProductName.Text!="") && (newProductPrice.Text != "")&&(newProductCategory.SelectedItem!=null))
            {
                products.Add(new Product()
                {
                    ProductName = newProductName.Text,
                    ProductPrice = Convert.ToInt32(newProductPrice.Text),
                    ProductCategory = (ProductCategories)Enum.Parse(typeof(ProductCategories), newProductCategory.SelectedItem.ToString())
                    
                });
            }
        }
    }
}
