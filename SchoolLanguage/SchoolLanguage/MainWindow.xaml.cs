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
            //var path = "\\\\NAS36D451\\user-domain$\\stud\\222121\\Desktop\\Task\\Сессия 1\\services_s_import\\";
            //foreach (var item in App.db.Service.ToArray())
            //{
            //    var fullPath = path + item.MainImagePath.Trim();
            //    var imageByte = File.ReadAllBytes(fullPath);
            //    item.MainImage = imageByte;
            //}
            //App.db.SaveChanges();

            MainImage.Navigate(new ServiceListPage());
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    if(PasswordPb.Password = "0000")
        //    {
        //        App.isAdmin = true;
        //        MainFrame.Navigation(new ServiceListPage());
        //        PasswordPb.Clear();
        //    }
        //}
    }
}
