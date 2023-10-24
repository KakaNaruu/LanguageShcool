using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SchoolLanguage.Components
{
    public partial class Service
    {
        public decimal  TotalCost
        {
            get
            {
                if (Discount != null)
                    return Cost - (Cost * (decimal)Discount / 100);
                else
                    return Cost;
            }
        }
        public string CostTime
        { 
            get
            {
                if (Discount == null)
                    return $"{Cost : 0} рублей за {DurationInSeconds / 60} минут";
                else
                    return $"{Cost - (Cost * (decimal)Discount / 100):0} рублей за {DurationInSeconds / 60}";
            }
        }
        public Visibility CostVisibility
        {
            get
            {
                if (Discount == null)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        }
        public string DiscoubtWhy
        {
            get
            {
                if (Discount ==null)
                    return null;
                else
                    return $"* скидка {Discount}%";
            }
        }
        public Brush DiscountBrush
        {
            get
            {
                if (Discount != null)
                    return new SolidColorBrush(Colors.LightGreen);
                else
                    return new SolidColorBrush(Colors.White);
            }
        }
    }
}
