using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Race
{
    internal class Road             // клас Road - дорога
    {
        // перерахування об'єктів на дорозі
        public enum Roads { ROAD, BIKE, CAR, POLICE, TRACKTOR, BUS, TRUCK, COIN, CARFIX, FINISH }

        // масив Pictures об'єктів на дорозі
        public Bitmap[] Road_parts = {  new Bitmap(Properties.Resources.road),
                                        new Bitmap(Properties.Resources.bike),
                                        new Bitmap(Properties.Resources.car),
                                        new Bitmap(Properties.Resources.police),
                                        new Bitmap(Properties.Resources.tracktor),
                                        new Bitmap(Properties.Resources.bus),
                                        new Bitmap(Properties.Resources.truck),
                                        new Bitmap(Properties.Resources.coin),
                                        new Bitmap(Properties.Resources.carfix),
                                        new Bitmap(Properties.Resources.finish)};

        public Roads type;              // тип об'єкта на дорозі
        public Image cover;             // фон картинки об'єкта на дорозі

        public Road(int p)              // конструктор об'єкта на дорозі
        {
            this.type = (Roads)p;                              // встановлення типу об'єкта на дорозі
            this.cover = Road_parts[p];                        // встановлення картинки об'єкта на дорозі
        }   
    }
}
