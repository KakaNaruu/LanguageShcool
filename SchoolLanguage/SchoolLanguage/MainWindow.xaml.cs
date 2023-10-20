using SchoolLanguage.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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
using SchoolLanguage.Components;
namespace SchoolLanguage
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigation.mainWindow = this;
            //var path = "\\\\NAS36D451\\user-domain$\\stud\\222121\\Desktop\\Task\\Сессия 1\\services_s_import\\";
            //foreach (var item in App.db.Service.ToArray())
            //{
            //    var fullPath = path + item.MainImagePath.Trim();
            //    var imageByte = File.ReadAllBytes(fullPath);
            //    item.MainImage = imageByte;
            //}
            //App.db.SaveChanges();

            Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordPb.Password == "0000")
            {
                App.isAdmin = true;
                Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
                PasswordPb.Clear();
            }
        }

        private void QTb_Click(object sender, RoutedEventArgs e)
        {
            Navigation.BackPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            App.isAdmin = false;
            Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
        }
    }
}
