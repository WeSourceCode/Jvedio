﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Jvedio.Update
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public EventWaitHandle ProgramStarted { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            bool createNew;
            ProgramStarted = new EventWaitHandle(false, EventResetMode.AutoReset, "Jvedio.Update", out createNew);
            if (!createNew)
            {
                App.Current.Shutdown();
                Environment.Exit(0);
            }
            base.OnStartup(e);
        }
    }
}
