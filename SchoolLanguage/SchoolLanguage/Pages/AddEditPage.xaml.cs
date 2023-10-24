using Microsoft.Win32;
using SchoolLanguage.Components;
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

namespace SchoolLanguage.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Service _service;
        public AddEditPage(Service _service)
        {
            InitializeComponent();
            this.DataContext = _service;
        }

        private void SaveBtm_Click(object sender, RoutedEventArgs e)
        {
            if(_service.ID == 0)
            {
                App.db.Service.Add(_service);
            }
            App.db.SaveChanges();
        }

        private void SohBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if(openFile.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllText(OpenFile.FileName);
                MainImage.Source = new BitmapImage(NewsStyleUriParser Uri(OpenFile.FileName));
            }
        }
    }
}