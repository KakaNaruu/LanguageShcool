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
            //var path = "@C:\\Users\\222121\\AppData\\Local\\Temp\\Tempeb4bc23e-20d9-4d3c-aed0-39f29236dc2b_Task.zip\\Сессия 1\\services_s_import.zip\\Услуги школы";
            //foreach(var item in App.db.Service.ToArray())
            //{
            //    var fullPath = path + item.MainImagePage;
            //    var imageByte = File.ReadAllBytes(fullPath);
            //    item.MainImagePage = imageByte;
            //}
            //App.db.SaveChanges();

            MainImage.Navigate(new ServiceListPage());
        }
    }
}
