using Race.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Race
{
    internal class Bolid                        // клас Bolid
    {
        internal Track track { get; set; }      // трек, до якого прив'язаний боліт
        internal int demage { get; set; }       // властивість 'пошкодження боліду'

        public Bolid()                          // конструктор
        {
            demage = 0;                         // на початок гри пошкодження = 0

        }
        internal void CheckHealth()             // метод - перевірка пошкоджень (здоров'я) боліду
        {
            if(demage < 0)                      // якщо пошкодження < 0%, то болід розбитий
                demage = 0;

            else if (demage >= 100)             // якщо пошкодження > 100 %, то 
            {
                demage = 100;
                track.parent.toolStripStatusLabel1.Text = "Demage: " + demage + " %";   // виводиться інформація в StatusStrip
                track.parent.timer1.Stop();                                             // зупинка таймеру побудови треку
                MessageBox.Show("You crashed your car!!");                              //  виводиться інформація про програш
                track.parent.Close();
            }
            track.parent.toolStripStatusLabel1.Text = "Demage: " + demage + " %";       // виводиться інформація про пошкодження в StatusStrip
            track.parent.toolStripProgressBar1.Value = demage;

        }
    }

}
