﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace IoTapp.PanoramasTemas
{
    public partial class PanLib : PhoneApplicationPage
    {
        public PanLib()
        {
            InitializeComponent();
            MessageBox.Show("En esta sección solo se presentan las librerias más usadas en IoT,  como Ethernet, LiquidCrystal, EEPROM, Servo  y WiFi. ");
        }
    }
}