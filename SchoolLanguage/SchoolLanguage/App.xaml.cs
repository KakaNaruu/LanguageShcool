﻿using SchoolLanguage.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolLanguage
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Components.SchoolLanguageEntities db = new Components.SchoolLanguageEntities();
        public static bool isAdmin = false;
        public static MainWindow mainWindow;
        public static AddEditPage servicePage;
    }
}
