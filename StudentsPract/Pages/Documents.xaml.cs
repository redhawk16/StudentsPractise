using System.Windows;
using System.Windows.Controls;

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
        }

        private void ContractsAdd_Click(object sender, RoutedEventArgs e)
        {
            //(new Contracts_add()).ShowDialog();
            new Pages.Contracts.Contracts().ShowDialog();
        }
    }
}
