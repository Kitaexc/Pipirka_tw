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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        ClientsTableAdapter clients = new ClientsTableAdapter();
        public Page2()
        {
            InitializeComponent();
            Clients.ItemsSource = clients.GetData();
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
            if (Clients.SelectedItem == null) return;

            var row = (DataRowView)Clients.SelectedItem;

            One.Text = row["ClientName"].ToString();
            Two.Text = row["ClientSurName"].ToString();
            Three.Text = row["ID_Tag"].ToString();
            Four.Text = row["ClientNumberPhone"].ToString();
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            object id = (Clients.SelectedItem as DataRowView).Row[0];
            int thirdParameter;
            bool isParsed = Int32.TryParse(Three.Text, out thirdParameter);
            if (isParsed)
            {
                clients.UpdateQuery(One.Text, Two.Text, thirdParameter, Four.Text, Convert.ToInt32(id));
            }
            else
            {
                
                MessageBox.Show("Текст в третьем поле не является числом.");
            }
            Clients.ItemsSource = clients.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (Clients.SelectedItem as DataRowView).Row[0];
            clients.DeleteQuery(Convert.ToInt32(id));
            Clients.ItemsSource = clients.GetData();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            int thirdParameter;
            bool isParsed = int.TryParse(Three.Text, out thirdParameter);

            if (isParsed)
            {
                clients.InsertQuery(One.Text, Two.Text, thirdParameter, Four.Text);
            }
            else
            {
                MessageBox.Show("Введите корректное числовое значение в поле Three.");
            }

            Clients.ItemsSource = clients.GetData();
        }

    }
}
