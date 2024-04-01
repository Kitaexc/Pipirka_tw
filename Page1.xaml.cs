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
using static MaterialDesignThemes.Wpf.Theme;

namespace Praktika_Dva
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        ClientTagsTableAdapter clientTags = new ClientTagsTableAdapter();
        public Page1()
        {
            InitializeComponent();
            ClientTags.ItemsSource = clientTags.GetData();
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

        private void ClientTags_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ClientTags.SelectedItem == null) return;

            var row = (DataRowView)ClientTags.SelectedItem;

            One.Text = row["TagName"].ToString();
        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {
            object id = (ClientTags.SelectedItem as DataRowView).Row[0];
            clientTags.UpdateQuery(One.Text, Convert.ToInt32(id));
            ClientTags.ItemsSource = clientTags.GetData();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (ClientTags.SelectedItem as DataRowView).Row[0];
            clientTags.DeleteQuery(Convert.ToInt32(id));
            ClientTags.ItemsSource = clientTags.GetData();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            clientTags.InsertQuery(One.Text);
            ClientTags.ItemsSource = clientTags.GetData();
        }
    }
}
