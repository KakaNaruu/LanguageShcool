﻿using SchoolLanguage.Components;
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
    /// Логика взаимодействия для ServiceListPage.xaml
    /// </summary>
    public partial class ServiceListPage : Page
    {
        public ServiceListPage()
        {
            InitializeComponent();
            if (App.isAdmin == false)
            {
                DobavTb.Visibility = Visibility.Hidden;
            }
            var services = App.db.Service.ToList();
            foreach (var service in services)
            {
                ServiceWrapPanel.Children.Add(new ServerUserControl(service));
            }
        }
        private void Refresh()
        {
            IEnumerable<Service> services = App.db.Service;
            if(SortCb.SelectedIndex != 0)
            {
                if (SortCb.SelectedIndex == 1)
                    services = services.OrderBy(x => x.TotalCost);
                else
                    services = services.OrderByDescending(x => x.TotalCost);
            }
            ServiceWrapPanel.Children.Clear();
            foreach (var service in services)
            {
                ServiceWrapPanel.Children.Add(new ServerUserControl(service));
            }
            if (DiscountFilterCb.SelectedIndex != 0)
            {
                if (DiscountFilterCb.SelectedIndex == 1)
                    services = services.Where(x => x.Discount >= 0 && x.Discount < 5);
                if (DiscountFilterCb.SelectedIndex == 2)
                    services = services.Where(x => x.Discount >= 5 && x.Discount < 15);
                if (DiscountFilterCb.SelectedIndex == 3)
                    services = services.Where(x => x.Discount >= 15 && x.Discount < 30);
                if (DiscountFilterCb.SelectedIndex == 4)
                    services = services.Where(x => x.Discount >= 30 && x.Discount < 70);
                if (DiscountFilterCb.SelectedIndex == 5)
                    services = services.Where(x => x.Discount >= 70 && x.Discount < 100);
            }
            services = services.Where(x => x.Title.ToLower().Contains(SearchTb.Text.ToLower()) || x.Description.ToLower().Contains(SearchTb.Text.ToLower()));
            ServiceWrapPanel.Children.Clear();
            foreach (var service in services)
            {
                ServiceWrapPanel.Children.Add(new ServerUserControl(service));
            }
            CountDateTb.Text = "Записи: " + services.Count().ToString() + "из 100";
        }
        private void DiscCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void DiscountFilterCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Refresh();
        }

        private void SearchTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Refresh(); 
        }

        private void DobavTb_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new PageComponent("Добавление услуги", new AddEditPage()));
        }
    }
} 