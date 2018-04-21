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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TaskManager Manager { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Manager = new TaskManager(Grid, TaskLabel);
        }

        private void Task1Click(object sender, RoutedEventArgs e)
        {
            Manager.Task1();
        }

        private void Task2Click(object sender, RoutedEventArgs e)
        {
            Manager.Task2();
        }

        private void Task3Click(object sender, RoutedEventArgs e)
        {
            Manager.Task3();
        }

        private void Task4Click(object sender, RoutedEventArgs e)
        {
            Manager.Task4();
        }

        private void Task5Click(object sender, RoutedEventArgs e)
        {
            Manager.Task5();
        }
    }
}
