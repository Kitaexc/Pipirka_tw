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
    /// Логика взаимодействия для Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        ProductTypesTableAdapter productTypes = new ProductTypesTableAdapter();
        public Page3()
        {
            InitializeComponent();
            ProductTypes.ItemsSource = productTypes.GetData();
            BlockTextBoxesExcept(One);
        }
        private void BlockTextBoxesExcept(System.Windows.Controls.TextBox exception)
        {
            if (One != exception) One.IsEnabled = false;
            if (Two != exception) Two.IsEnabled = false;
            if (Three != exception) Three.IsEnabled = false;
            if (Four != exception) Four.IsEnabled = false;
            if (Five != exception) Five.IsEnabled = false;
        }

        private void Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductTypes.SelectedItem == null) return;

            var row = (DataRowView)ProductTypes.SelectedItem;

            One.Text = row["PrType"].ToString();
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            object id = (ProductTypes.SelectedItem as DataRowView).Row[0];
            productTypes.UpdateQuery(One.Text, Convert.ToInt32(id));
            ProductTypes.ItemsSource = productTypes.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (ProductTypes.SelectedItem as DataRowView).Row[0];
            productTypes.DeleteQuery(Convert.ToInt32(id));
            ProductTypes.ItemsSource = productTypes.GetData();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            productTypes.InsertQuery(One.Text);
            ProductTypes.ItemsSource = productTypes.GetData();
        }

    }
}
