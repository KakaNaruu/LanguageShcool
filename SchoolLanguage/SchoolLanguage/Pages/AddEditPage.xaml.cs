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
        private Service service;
        public AddEditPage(Service _service)
        {
            InitializeComponent();
            this.DataContext = _service;
            service = _service;
        }

        private void SaveBtm_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (service.ID == 0)
            {
                if(App.db.Service.Any(x => x.Title == service.Title))
                {
                    errors.AppendLine("Такая услуга уже существует");
                }
                else
                {
                    App.db.Service.Add(service);
                }
            }
            if(service.DurationInSeconds > 14400)
            {
                errors.AppendLine("Длительность не может превышать 4х часов");
            }
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
            }
            else
            {
                App.db.SaveChanges();
                MessageBox.Show("Сохранено!");
                Navigation.NextPage(new PageComponent("Список услуг", new ServiceListPage()));
            }
        }
        private void SohBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {

                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };
            if(openFile.ShowDialog().GetValueOrDefault())
            {
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                service.MainImagePath = openFile.FileName;
            }
        }
        private void LongTb_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(char.IsDigit(e.Text[0])))
            {
                e.Handled = true;
            }
        }
    }
}