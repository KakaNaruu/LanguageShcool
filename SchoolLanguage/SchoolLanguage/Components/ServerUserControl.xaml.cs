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

namespace SchoolLanguage.Components
{
    /// <summary>
    /// Логика взаимодействия для ServerUserControl.xaml
    /// </summary>
    public partial class ServerUserControl : UserControl
    {
        Service service;
        public ServerUserControl(Service _service)
        {
            InitializeComponent();
            service = _service;
            if (App.isAdmin == false)
            {
                RedactRb.Visibility = Visibility.Hidden;
                DeleteTb.Visibility = Visibility.Hidden;
            }
            CostTb.Text = service.Cost.ToString("0");
            TitleTb.Text = service.Title;
            costTimeTb.Text = service.CostTime;
            DiscountTb.Text = service.DiscoubtWhy;
            CostTb.Visibility = service.CostVisibility;
            ImageTb.Source = GetImageSource(service.MainImage);
            MainBorder.Background = service.DiscountBrush;
        }
        private BitmapImage GetImageSource(byte[] byteImage)
        { 
            BitmapImage bitmapImage = new BitmapImage();
            try
            {
                MemoryStream byteStream = new MemoryStream(byteImage);
               
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = byteStream;
                bitmapImage.EndInit();
                return bitmapImage;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error"+ ex.Message);
            }
            return bitmapImage;
        }

        private void DeleteTb_Click(object sender, RoutedEventArgs e)
        {
            if(service.ClientService != null)
            {
                MessageBox.Show("Удаление запрещено");
            }
            else
            {
                App.db.Service.Remove(service);
                App.db.SaveChanges();
            }
        }
    }
}
