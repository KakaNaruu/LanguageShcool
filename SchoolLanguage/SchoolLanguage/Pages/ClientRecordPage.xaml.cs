using SchoolLanguage.Components;
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

namespace SchoolLanguage.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientRecordPage.xaml
    /// </summary>
    public partial class ClientRecordPage : Page
    {
        Service service;

        public ClientRecordPage(Service service)
        {
            InitializeComponent();
            this.service = service;
            this.DataContext = service;
            ClientCb.ItemsSource = App.db.Client.ToList();
            ClientCb.DisplayMemberPath = "FullName";
            DateDp.DisplayDateStart = DateTime.Today;
        }
        private void EntryBtn_Click(object sender, RoutedEventArgs e)
        {
            if(ClientCb.SelectedItem != null && DateDp.SelectedDate != null && StartTimeTb.Text != "")
            {
                var startDate = $"{DateDp.SelectedDate.Value.ToString("dd.MM.yyyy")} {StartTimeTb.Text}";
                if(DateTime.TryParse(startDate, out DateTime dateTimeStart))
                {
                    if(dateTimeStart > DateTime.Now)
                    {
                        var selectTClient = ClientCb.SelectedItem as Client;
                        App.db.ClientService.Add(new ClientService()
                        {
                            ClientID = selectTClient.ID,
                            ServiceID = service.ID,
                            StartTime = dateTimeStart,
                        });
                        App.db.SaveChanges();
                        MessageBox.Show("Запись добавлена!");
                    }
                    else
                    {
                        MessageBox.Show("Время прошло!");
                    }
                }
                else
                {
                    MessageBox.Show("Время введено неверно!");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
        private void StartTimeTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var time = StartTimeTb.Text.Split(':');
            var hour = int.Parse(time[0]);
            var minute = int.Parse(time[1]);
            TimeSpan timeStart = new TimeSpan(hour, minute, 0);
            TimeSpan timeJob = new TimeSpan(service.DurationInSeconds/3600, service.DurationInSeconds % 3600, 0);
            if (StartTimeTb.Text.Length == 5)
            {
                EndTimeTb.Text = (timeStart + timeJob).ToString();
            }
        }
    }
}