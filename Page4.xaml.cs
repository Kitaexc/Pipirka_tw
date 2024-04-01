using Praktika_Dva.DataSet2TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Praktika_Dva
{
    /// <summary>
    /// Логика взаимодействия для Page4.xaml
    /// </summary>
    public partial class Page4 : Page
    {
        ProductsTableAdapter products = new ProductsTableAdapter();
        public Page4()
        {
            InitializeComponent();
            Products.ItemsSource = products.GetData();
            BlockTextBoxesExcept(Five);
        }

        private void BlockTextBoxesExcept(System.Windows.Controls.TextBox exception)
        {
            One.IsEnabled = true;
            Two.IsEnabled = true;
            Three.IsEnabled = true;
            Four.IsEnabled = true;
            Five.IsEnabled = true;

            if (exception != null)
            {
                exception.IsEnabled = false;
            }
        }

        private void Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Products.SelectedItem == null) return;

            var row = (DataRowView)Products.SelectedItem;

            One.Text = row["ProductName"].ToString();
            Two.Text = row["ProductPrice"].ToString();
            Three.Text = row["ID_ProductType"].ToString();
            Four.Text = row["QuantityInStock"].ToString();
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            object id = (Products.SelectedItem as DataRowView).Row[0];
            int thirdParameter;
            bool isParsed = Int32.TryParse(Three.Text, out thirdParameter);
            if (isParsed)
            {
                products.UpdateQuery(One.Text, Convert.ToDecimal(Two.Text), thirdParameter, Convert.ToInt32(Four.Text), Convert.ToInt32(id));
            }
            else
            {

                MessageBox.Show("Текст в третьем поле не является числом.");
            }
            Products.ItemsSource = products.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (Products.SelectedItem as DataRowView).Row[0];
            products.DeleteQuery(Convert.ToInt32(id));
            Products.ItemsSource = products.GetData();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            int thirdParameter;
            
            bool isParsed = int.TryParse(Three.Text, out thirdParameter);
            

            if (isParsed)
            {
                products.InsertQuery(One.Text, Convert.ToDecimal(Two.Text), thirdParameter, Convert.ToInt32(Four.Text));
            }
            else
            {
                MessageBox.Show("Введите корректное числовое значение в поле Three.");
            }

            Products.ItemsSource = products.GetData();
        }

    }
}
