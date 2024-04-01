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
    /// Логика взаимодействия для Page5.xaml
    /// </summary>
    public partial class Page5 : Page
    {
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public Page5()
        {
            InitializeComponent();
            Orders.ItemsSource = orders.GetData();
            
        }

        private void BlockTextBoxesExcept(System.Windows.Controls.TextBox exception)
        {
            One.IsEnabled = true;
            Two.IsEnabled = true;
            Three.IsEnabled = true;
            Four.IsEnabled = true;
            Five.IsEnabled = true;
        }

        private void Clients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (Orders.SelectedItem == null) return;

            var row = (DataRowView)Orders.SelectedItem;

            One.Text = row["ID_Client"].ToString();
            Two.Text = row["ID_Product"].ToString();
            Three.Text = row["OrderDate"].ToString();
            Four.Text = row["Quantity"].ToString();
            Five.Text = row["TotalPrice"].ToString();
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            object id = (Orders.SelectedItem as DataRowView).Row[0];
            orders.UpdateQuery(Convert.ToInt32(One.Text), Convert.ToInt32(Two.Text), Convert.ToString(Three.Text), Convert.ToInt32(Four.Text), Convert.ToDecimal(Five.Text), Convert.ToInt32(id));
            Orders.ItemsSource = orders.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (Orders.SelectedItem as DataRowView).Row[0];
            orders.DeleteQuery(Convert.ToInt32(id));
            Orders.ItemsSource = orders.GetData();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            orders.InsertQuery(Convert.ToInt32(One.Text), Convert.ToInt32(Two.Text), Convert.ToString(Three.Text), Convert.ToInt32(Four.Text), Convert.ToDecimal(Five.Text));
            Orders.ItemsSource = orders.GetData();
        }
    }
}
