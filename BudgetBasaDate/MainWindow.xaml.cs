using BudgetBasaDate.MoneyBudgetDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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

namespace BudgetBasaDate
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BudgetTableTableAdapter budget = new BudgetTableTableAdapter();
        TypeTableAdapter type = new TypeTableAdapter();
        public MainWindow()
        {
            InitializeComponent();
            MYDataGrid.ItemsSource = budget.GetData();
            TypeBox.ItemsSource = type.GetData();
            TypeBox.DisplayMemberPath = "Type";
            TypeBox.SelectedValuePath = "id";
            PublicCost();
        }
        public void Apdate()
        {
            TypeBox.ItemsSource = type.GetData();
        }
        public void PublicCost()
        {
            List list = new List();
            int cost = 100000;
            Itog.Text = Convert.ToString(cost);
        }
        public void Error()
        {
            MessageBox.Show("Вы что-то сделали не так. Перепроверьте");
        }
        private void MYDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (MYDataGrid.SelectedItem != null)
                {
                    NameVVod.Text = Convert.ToString((MYDataGrid.SelectedItem as DataRowView).Row[1]);
                    TypeBox.Text = Convert.ToString((MYDataGrid.SelectedItem as DataRowView).Row[2]);
                    MoneyVVod.Text = Convert.ToString((MYDataGrid.SelectedItem as DataRowView).Row[3]);
                }
                else
                {
                    Error();
                }
            }
            catch
            {
                Error();
            }
        }

        private void addtype_Click(object sender, RoutedEventArgs e)
        {
            TypeWindow tip = new TypeWindow();
            tip.Show();
            Apdate();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            int i = 1;
            int cost;
            bool MinusPlus;
            try
            {
                if (NameVVod.Text != "" && TypeBox.SelectedIndex != null && MoneyVVod.Text != "")
                {
                    if (Convert.ToInt32(MoneyVVod.Text) < 0)
                    {
                        cost = -1 * Convert.ToInt32(MoneyVVod.Text);
                        MinusPlus = false;
                    }
                    else
                    {
                        cost = Convert.ToInt32(MoneyVVod.Text);
                        MinusPlus = true;
                    }
                    budget.InsertQuery(NameVVod.Text, (int)TypeBox.SelectedValue, cost, MinusPlus);
                    MYDataGrid.ItemsSource = budget.GetData();
                }
                else
                {
                    Error();
                }
            }
            catch
            {
                Error();
            }
        }

        private void del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MYDataGrid.SelectedItem != null)
                {
                    int id = (int)(MYDataGrid.SelectedItem as DataRowView).Row[0];
                    budget.DeleteQuery(id);
                    MYDataGrid.ItemsSource = budget.GetData();
                }
                else
                {
                    Error();
                }
            }
            catch
            {
                Error();
            }
        }

        private void rem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int cost;
                bool MinusPlus;
                if (NameVVod.Text != "" && TypeBox.SelectedIndex != null && MoneyVVod.Text != "")
                {
                Object id = (MYDataGrid.SelectedItem as DataRowView).Row[0];
                    if (Convert.ToInt32(MoneyVVod.Text) < 0)
                    {
                        cost = -1 * Convert.ToInt32(MoneyVVod.Text);
                        MinusPlus = false;
                    }
                    else
                    {
                        cost = Convert.ToInt32(MoneyVVod.Text);
                        MinusPlus = true;
                    }

                    budget.UpdateQuery(NameVVod.Text, (int)TypeBox.SelectedValue, cost, MinusPlus, (int)id);
                    MYDataGrid.ItemsSource = budget.GetData();
                }
                else
                {
                    Error();
                }
            }
            catch
            {
                Error();
            }
        }
    }
}
