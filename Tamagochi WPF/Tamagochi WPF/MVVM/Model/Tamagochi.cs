﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tamagochi_WPF.MVVM.Model
{
    internal class Tamagochi
    {
        public string Name{ get; set; }
        public byte Happines { get; set; }
        public byte Poisoning { get; set; }
        public byte Hunger { get; set; }
        public byte Heal { get; set; }
        public DateTime StartTime { get; }
        public DateTime CurrentTime { get; set; }  
        public Tamagochi(string name)
        {
            Name = name;
            Happines = 100;
            Poisoning = 0;
            Hunger = 100;
            Heal = 100;
            DateTime StartTime = DateTime.Now;  
        }

    }
}