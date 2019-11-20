﻿using StudentsPract.Adapters;
using StudentsPract.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
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

namespace StudentsPract.Pages
{
    /// <summary>
    /// Логика взаимодействия для Groups.xaml
    /// </summary>
    public partial class Groups : UserControl
    {
        SQLiteAdapter sqliteAdapter = new SQLiteAdapter(); // create instance for SQLiteAdapter
        DataGridHelper dataGridHelper = new DataGridHelper(); // create instance for DataGridHelper

        string table_name = "groups";

        public Groups()
        {
            InitializeComponent();

            load_data_grid(); // DataGrid Binding
        }

        #region DataGrid Methods

        #region DataGrid: Editing
        private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e) // Editing DataGrid Row
        {
            dataGridHelper.EditDataGrid<Group>(e, table_name, dataGrid);
            load_data_grid();
        }
        #endregion

        #region DataGrid: Deleting
        private void dataGrid_PreviewKeyDown(object sender, KeyEventArgs e) // Deleting DataGrid Row
        {
            dataGridHelper.DeleteDataGrid<Group>(e, table_name, dataGrid);
        }
        #endregion

        #region DataGrid: Filtering
        public void FilterValue(object sender, EventArgs e)
        {
            dataGridHelper.FilterDataGrid<Group>(sender, e, dataGrid);
        }
        #endregion

        #endregion

        private void load_data_grid()
        {
            List<Group> values = new List<Group>();
            List<List<string>> tmp = sqliteAdapter.GetValue(table_name);

            foreach (List<string> column in tmp)
            {
                values.Add(new Group
                {
                    id = column[0],
                    group = column[1],
                    direction = column[2],
                    form_study = column[3],
                    enroll_year = column[4],
                    end_year = column[5]
                });
            }

            for (int i = 0; i < values.Count; i++) if (!group.Items.Contains(values[i].group)) group.Items.Add(values[i].group); // ComboBox repeat values check

            dataGrid.ItemsSource = values; // Binding items in DataGrid
        }
    }

    class Group
    {
        public string id { get; set; }
        public string group { get; set; }
        public string direction { get; set; }
        public string form_study { get; set; }
        public string enroll_year { get; set; }
        public string end_year { get; set; }
    }
}
