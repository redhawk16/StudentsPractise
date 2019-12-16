using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace StudentsPract.Pages
{
    /// <summary>
    /// Логика взаимодействия для Documents.xaml
    /// </summary>
    public partial class Documents : UserControl
    {
        public Documents()
        {
            InitializeComponent();

            LoadContracts();
            LoadOrders();
        }

        private void ContractsAdd_Click(object sender, RoutedEventArgs e)
        {
            //(new Contracts_add()).ShowDialog();
            new Pages.Contracts.Contracts().ShowDialog();
            LoadContracts();
        } 
        
        private void OrdersAdd_Click(object sender, RoutedEventArgs e)
        {
            //(new Contracts_add()).ShowDialog();
            new Pages.Orders.Orders().ShowDialog();
            LoadOrders();
        }

        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(((FContracts)((TextBlock)sender).DataContext).link);
            }
            catch { LoadContracts(); }
        }        
        
        private void DG_Hyperlink_Click_order(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start(((FOrders)((TextBlock)sender).DataContext).link);
            }
            catch { LoadOrders(); }
        }

        private void LoadContracts()
        {
            string path = $"{Directory.GetCurrentDirectory()}\\documents\\contracts\\";

            List<FContracts> Contracts_List = new List<FContracts>();

            if (Directory.Exists(path))
            {
                foreach (string directories in Directory.GetDirectories(path)) 
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(directories);
                    Contracts_List.Add(new FContracts { name = dirInfo.Name, link = directories.Trim() });
                }
                contracts_list.ItemsSource = Contracts_List;
            }
        }

        private void LoadOrders()
        {
            string path = $"{Directory.GetCurrentDirectory()}\\documents\\orders\\";

            List<FOrders> Orders_List = new List<FOrders>();

            if (Directory.Exists(path))
            {
                foreach (string directories in Directory.GetDirectories(path)) 
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(directories);
                    Orders_List.Add(new FOrders { name = dirInfo.Name, link = directories.Trim() });
                }
                orders_list.ItemsSource = Orders_List;
            }
        }

        private class FContracts
        {
            public string name { get; set; }
            public string link { get; set; }
        }        
        
        private class FOrders
        {
            public string name { get; set; }
            public string link { get; set; }
        }
    }
}
