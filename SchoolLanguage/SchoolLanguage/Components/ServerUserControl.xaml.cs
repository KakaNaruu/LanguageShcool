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

namespace SchoolLanguage.Components
{
    /// <summary>
    /// Логика взаимодействия для ServerUserControl.xaml
    /// </summary>
    public partial class ServerUserControl : UserControl
    {
        public ServerUserControl(Image image, string title, decimal cost,string costTime, string discount)
        {
            InitializeComponent();
            if(App.isAdmin == false)
            {
                RedactRb.Visibility = Visibility.Hidden;
                DeleteTb.Visibility = Visibility.Hidden;
            }
            //ImageTb = image;
            CostTb.Text = cost.ToString("0");
            TitleTb.Text = title;
            costTimeTb.Text = costTime;
            DiscountTb.Text = discount;
            CostTb.Visibility = CostTb.Visibility;
        }
    }
}
