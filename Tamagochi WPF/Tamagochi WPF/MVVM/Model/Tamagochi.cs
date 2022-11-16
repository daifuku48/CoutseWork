﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
//using Internal;

namespace Tamagochi_WPF
{
    class Tamagochi
    {
        private string name_;
        public string Name { get { return name_; } set { name_ = value; } }

        private int happines_;
        public int Happines { get { return happines_; } set { happines_ = value; } }

        private int poisoning_;
        public int Poisoning { get { return poisoning_; } set { poisoning_ = value; } }

        private int saturation_;
        public int Saturation { get { return saturation_; } set { saturation_ = value; } }

        private int heal_;
        public int Heal { get { return heal_; } set { heal_ = value; } }

        private bool is_alive_;
        public bool IsAlive { get { return is_alive_; } set { is_alive_ = value; } }

        public InventoryController Inventory = new InventoryController();

        public Tamagochi()
        {
            StateCreate();
        }

        public void StateCreate()
        {
            if (is_alive_) return;
            heal_ = 100;
            poisoning_ = 0;
            saturation_ = 100;
            happines_ = 100;
            is_alive_ = true;
        }
        // вызывается при создании персонажа. (╯✧▽✧)╯

        public void StateDestroy()
        {
            if (!is_alive_) return;
            heal_ = 0;
            poisoning_ = 0;
            saturation_ = 0;
            happines_ = 0;
            is_alive_ = false;
            name_ = "";
        }
        // вызыватся при смерти персонажа.

        public void StateUpdate()
        {
            if (heal_ <= 0)
            {
                is_alive_ = false;
                //StateDestroy();
            }

            if (saturation_ > 75)
            {
                heal_ += 5;
                happines_ += 3;
            }

            if (poisoning_ > 0)
            {
                heal_ -= 4;
                poisoning_ -= 1;
            }

            if (happines_ <= 25)
            { poisoning_ += 1; heal_ -= 10;}
               
                //poisoning_ = poisoning_ + Math.Abs(happines_);

            if (saturation_ <= 75)
                heal_ -= 10;

            happines_ -= 5;
            saturation_ -= 5;

            if (heal_ > 100) heal_ = 100;

            if (poisoning_ > 100) poisoning_ = 100;

            if (saturation_ > 100) saturation_ = 100;

            if (happines_ > 100) happines_ = 100;

            if (happines_ < 0) happines_ = 0;

            if (heal_ < 0) heal_ = 0;

            if (poisoning_ < 0) poisoning_ = 0;

            if (saturation_ < 0) saturation_ = 0;
        }
        // вызывается на каждый тик игрового времени (каждые 3_сек. наверное).

        public void Eat(IFood food_)
        {
            if (!is_alive_) return;

            if ((heal_ + food_.Heal) < 100)
                heal_ += food_.Heal;
            else
                heal_ = 100;

            if ((saturation_ + food_.Satiety) < 100)
                saturation_ += food_.Satiety;
            else
                saturation_ = 100;

            if ((poisoning_ + food_.Poison) < 100)
                poisoning_ += food_.Poison;
            else
                poisoning_ = 100;

            if ((happines_ + food_.Happy) < 100)
                happines_ += food_.Happy;
            else
                happines_ = 100;

            Console.WriteLine("Вы покушац");
        }
        // кушац. (o･ω･o)
    }
}
