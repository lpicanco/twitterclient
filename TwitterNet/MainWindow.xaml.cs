using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwitterNet.Services;

namespace TwitterNet
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TwitterFacade facade;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            // Exibe a tela de login.
            LoginWindow login = new LoginWindow();
            login.ShowInTaskbar = false;

            if (login.ShowDialog().Value)
            {
                facade = login.Facade;

                UpdateData();
            }
            else
            {
                this.Close();
            }
        }

        private void UpdateData()
        {
            UpdateStatusList();
            HomeList.ItemsSource = facade.ListTwitters();
            RepliesList.ItemsSource = facade.ListReplies();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            facade.UpdateStatus(txtStatus.Text);
            UpdateStatusList();
        }

        private void UpdateStatusList()
        {
            StatusList.ItemsSource = facade.ListUserTwitters();
        }
    }
}
