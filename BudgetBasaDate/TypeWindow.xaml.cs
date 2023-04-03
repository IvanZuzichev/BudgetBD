using BudgetBasaDate.MoneyBudgetDataSetTableAdapters;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using static BudgetBasaDate.MoneyBudgetDataSet;

namespace BudgetBasaDate
{
    /// <summary>
    /// Логика взаимодействия для TypeWindow.xaml
    /// </summary>
    public partial class TypeWindow : Window
    {
        TypeTableAdapter typez = new TypeTableAdapter();
        public TypeWindow()
        {
            InitializeComponent();
            Gridd.ItemsSource = typez.GetData();
        }
        public void Error()
        {
            MessageBox.Show("Вы что-то сделали не так. Перепроверьте");
        }
        private void AddType2_Click(object sender, RoutedEventArgs e)
        {
            if (IDtypeBox.Text != "" && typeBox.Text != "")
            {
                typez.InsertQuery(Convert.ToInt32(IDtypeBox.Text), typeBox.Text);
                Gridd.ItemsSource = null;
                Gridd.ItemsSource = typez.GetData();
                Close();
            }
            else
            {
                Error();
            }
        }
    }
}
