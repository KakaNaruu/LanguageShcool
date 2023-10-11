﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolLanguage.Components
{
    public partial class Service
    {
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

    }
}
