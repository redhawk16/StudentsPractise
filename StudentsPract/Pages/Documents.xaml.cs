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
        }

        private void ContractsAdd_Click(object sender, RoutedEventArgs e)
        {
            //(new Contracts_add()).ShowDialog();
            new Pages.Contracts.Contracts().ShowDialog();
        }

        private void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(((FContracts)((TextBlock)sender).DataContext).contract_link);
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
                    Contracts_List.Add(new FContracts { contract_name = dirInfo.Name, contract_link = directories.Trim() });
                }
                contracts_list.ItemsSource = Contracts_List;
            }
        }

        private class FContracts
        {
            public string contract_name { get; set; }
            public string contract_link { get; set; }
        }
    }
}
