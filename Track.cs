using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace Race
{
    internal class Track                // клас Track - гоночна траса
    {
        int width  = 600;               // ширина траси в pixels
        int height = 271;               // висота одного проліту траси в pixels
        public int metres = 0;          // пройдений кілометраж
        public int leftRoadBorder { get; set; } // ліва границя траси в pixels
        public int rightRoadBorder { get; set; } // права границя траси в pixels
        public int turn { get; set; }               // градус поворот - зміщення боліду вправо/вліво
        public int speed { get; set; }              // швидкість - прискорення/гальмування боліду
        PictureBox[] tracks = new PictureBox[4];                    // масив Pictures, з яких формується траса
        internal List<PictureBox> cars = new List<PictureBox>();    // список Pictures, додаткові перешкоди на трасі - автомобілі
        internal List<Road> typeCars = new List<Road>();            // список типів додаткових перешкод на трасі - автомобілів
        internal List<PictureBox> fixes = new List<PictureBox>();   // список Pictures, об'єкти на трасі, які потрібно збирати - СТО
        internal List<Road> typeFixes = new List<Road>();           // список типів об'єктів на трасі, які потрібно збирати - СТО
        internal Bolid myBolid = new Bolid();                       // болід гравця
        internal Form1 parent;                                      // батьківська форма, на якій це все буде розміщено
        internal TimeOnly racetime = new TimeOnly(0, 0, 30);        // час гри - по замовчуванню 30 секунд
        
        public Track(Form1 form)        // конструктор траси
        {
            parent = form;              // встановлення батьківської форми
            speed = 1;                  // швидкість - спочатку 1 піксель за одну мілісекунду
            myBolid.track = this;       // прив'язка боліду до треку
            myBolid.demage = 0;         // пошкодження - спочатку 0%
            leftRoadBorder = 128;       // встановлення лівої границі траси
            rightRoadBorder = 472;      // встановлення правої границі траси
            turn = 5;                   // поворот - спочатку зміщення на 5 пікселів при нажатті відповідної клавіші
            TrackBuilding1();           // виклик методу - первісна побудова треку
        }
        public void TrackBuilding1()            // метод - первісна побудова треку
        {
            Road trafficLane = new Road(0);
            for (int i = 0; i < 4; i++)                 // форма розрахована так, що на неї поміщається 4 одинакових картинки з треком
            {
                PictureBox temp = new PictureBox();
                temp.Parent = parent;
                temp.Size = new Size(width, height);
                temp.Location = new Point(0, i * height - height);
                temp.BackgroundImage = trafficLane.cover;
                temp.SizeMode = PictureBoxSizeMode.StretchImage;
                tracks[i] = temp;
            }
        }
        public void TrackBuilding2()                // метод - побудова треку в процесі гонки
        {
            for (int i = 0; i < 4; i++)             // для кожної картинки з треком встановлюються координати
            {
                if ((tracks[i].Location.Y + speed) > parent.ClientSize.Height)      // якщо картинка вийшла за межі форми внизу - переміщається вверх
                    tracks[i].Location = new Point(0, (-height + speed));
                else                                                                    // якщо не вийшла - то зміщується вниз враховуючи швидкість
                    tracks[i].Location = new Point(0, tracks[i].Location.Y + speed);
            }
            foreach (var car in cars)               // для кожної додаткової перешкоди (авто) на треку встановлюються координати
            {
                if ((car.Location.Y + speed) > parent.ClientSize.Height)            // якщо авто вийшло за межі треку - об'єкт знищується
                    car.Dispose();
                else
                    car.Location = new Point(car.Location.X, car.Location.Y + speed);// якщо не вийшло за межі треку - то зміщується вниз враховуючи швидкість
            }
            foreach (var fix in fixes)               // для кожної СТО на треку встановлюються координати
            {
                if ((fix.Location.Y + speed) > parent.ClientSize.Height)            // якщо СТО вийшло за межі треку - об'єкт знищується
                    fix.Dispose();
                else
                    fix.Location = new Point(fix.Location.X, fix.Location.Y + speed);// якщо не вийшло за межі треку - то зміщується вниз враховуючи швидкість
            }
            if (racetime.Second < 3)                                                // якщо до кінця гри менше 3 секунд - з'являється фініншна лінія враховуючи швидкість
                parent.finish.Location = new Point(parent.finish.Location.X,
                                                   parent.finish.Location.Y + speed);
            if (parent.finish.Location.Y > 0)                               // якщо вже з'явилася фінішна лінія 
            {
                if (parent.finish.Location.Y >= parent.myBolid.Location.Y)  // і координати боліду і фініншної прямої збігаються
                {
                    parent.timer1.Stop();                                   // таймери зупиняються
                    parent.timer2.Stop();
                    parent.myBolid.BringToFront();                          // болід відображається поверх фінішної прямої
                    MessageBox.Show("Congrats!!! You reached finish!!");    // привітання гравцю
                    parent.Close();                                         // форма закривається
                };
            }

        }

        public void CreateBlock()           // метод - створення додаткових перешкод на трасі (автомобілів)
        {
            if (racetime.Second < 3)        // якщо до кінця гонки менше 3 сек - створення припиняється
                return;

            foreach (var item in cars)      // цикл для запобігання створення перешкод на одній лінії
            {
                if (item.Location.Y < 0)
                    return;
            }

            Random r1 = new Random();               // створення буде відбуватися випадково
            Random r2 = new Random();
            Road car = new Road(r2.Next(1, 7));     // випадковий вибір перешкоди
            if(r1.Next(25) ==  0)                   // ймовірність створення перешкод - 1:25
            {
                PictureBox temp = new PictureBox();         // створення picturebox з автомобілем
                temp.Parent = parent;
                temp.Image = car.cover;
                temp.Size = new Size(55, 86);
                temp.Location = new Point(leftRoadBorder + r1.Next(rightRoadBorder - leftRoadBorder - temp.Width), -86);
                temp.SizeMode = PictureBoxSizeMode.StretchImage;
                temp.BringToFront();
                temp.BackColor = Color.Transparent;         //   прозорість png - не працює. Чому???
                cars.Add(temp);                             // додавання інформації про перешкоду в колекцію
                typeCars.Add(car);  
            }
        }

        public void CreateFixes()               // метод - створення ремонтних можливостей для авто на трасі 
        {
            if (racetime.Second < 3)            // якщо до кінця гонки менше 3 сек - створення припиняється
                return;

            foreach (var item in fixes)         // цикл для запобігання створення перешкод на одній лінії
            {
                if (item.Location.Y < 0)
                    return;
            }

            Random r1 = new Random();           // створення буде відбуватися випадково
            Random r2 = new Random();
            if (r1.Next(125) == 0)              // ймовірність створення перешкод - 1:125
            {
                PictureBox temp = new PictureBox();     // створення picturebox з ремонтом
                temp.Parent = parent;
                temp.Size = new Size(50, 50);
                temp.Location = new Point(leftRoadBorder + r1.Next(rightRoadBorder - leftRoadBorder - temp.Width), -50);
                temp.SizeMode = PictureBoxSizeMode.StretchImage;
                temp.BringToFront();
                temp.BackColor = Color.Transparent; 

                int rnd = r2.Next(1, 5);            
                if (rnd >= 1 && rnd <= 3)                           // створення монети - ймовірність 75%
                {
                    Road fix = new Road((int)(Road.Roads.COIN));
                    temp.Image = fix.cover;
                    fixes.Add(temp);                                // додавання об'єкту до колекції
                    typeFixes.Add(fix);
                }
                else if (rnd == 4)
                {
                    Road fix = new Road((int)(Road.Roads.CARFIX));   // створення СТО - ймовірність 25%
                    temp.Image = fix.cover;
                    fixes.Add(temp);                                // додавання об'єкту до колекції
                    typeFixes.Add(fix);
                }
            }
        }

        public void CheckAccident()                                 // метод - перевірка чи сталося ДТП
        {
            for (int i = (cars.Count - 1); i >= 0; i--)             // цикл для перевіки ДПТ з усіма наявними авто на дорозі
            {
                // якщо координати боліду і додаткової перешкоди на дорозі (авто) перетинаються:
                if (Math.Abs(cars[i].Location.Y - parent.myBolid.Location.Y) < Math.Min(cars[i].Height, parent.myBolid.Height) &&
                   (Math.Abs(cars[i].Location.X - parent.myBolid.Location.X) < Math.Min(cars[i].Width, parent.myBolid.Width)))
                {
                    if (typeCars[i].type == Road.Roads.BIKE)            // якщо мотоцикл - пошкодження боліду + 5%
                        myBolid.demage += 5;
                    else if (typeCars[i].type == Road.Roads.CAR)        // якщо авто - пошкодження боліду + 15%    
                        myBolid.demage += 15;
                    else if(typeCars[i].type == Road.Roads.POLICE)      // якщо поліція - пошкодження боліду + 20% 
                        myBolid.demage += 20;
                    else if(typeCars[i].type == Road.Roads.TRACKTOR)    // якщо трактор - пошкодження боліду + 25% 
                        myBolid.demage += 25;
                    else if(typeCars[i].type == Road.Roads.BUS)         // якщо автобус - пошкодження боліду + 30% 
                        myBolid.demage += 30;
                    else if(typeCars[i].type == Road.Roads.TRUCK)       // якщо вантажівка - пошкодження боліду + 40% 
                        myBolid.demage += 40;

                    cars[i].Dispose();                                  // додаткова перешкода зникає і видаляється з колекцій
                    typeCars.RemoveAt(i);
                    cars.Remove(cars[i]);
                }  
            }
        }

        public void CheckFixes()                                 // метод - перевірка чи збираються ремонти на дорозі
        {
            for (int i = (fixes.Count - 1); i >= 0; i--)         // цикл для перевіки збирання ремонту з усіма наявними на дорозі   
            {
                // якщо координати боліду і ремонту на дорозі  перетинаються:
                if (Math.Abs(fixes[i].Location.Y - parent.myBolid.Location.Y) < Math.Min(fixes[i].Height, parent.myBolid.Height) &&
                   (Math.Abs(fixes[i].Location.X - parent.myBolid.Location.X) < Math.Min(fixes[i].Width, parent.myBolid.Width)))
                {
                    if (typeFixes[i].type == Road.Roads.COIN)        // якщо монета - пошкодження боліду ремонтується на + 5%
                        myBolid.demage -= 5;
                    else if (typeFixes[i].type == Road.Roads.CARFIX) // якщо СТО - пошкодження боліду ремонтується на + 25%
                        myBolid.demage -= 25;

                    fixes[i].Dispose();                             // об'єкт ремонту зникає і видаляється з колекцій
                    typeFixes.RemoveAt(i);
                    fixes.Remove(fixes[i]);
                }
            }
        }

        public void CheckCars()                                 // метод - видалення додаткових перешкод з колекцій
        {
            for (int i = (cars.Count - 1); i >= 0; i--)                     
            {
                if ((parent.ClientSize.Height - cars[i].Location.Y) < 50)   // якщо додаткова перешкода залишає межі форми 
                {
                    //MessageBox.Show("Delete index" + i);
                    cars[i].Dispose();                                  // то вона видаляється з колекцій
                    typeCars.RemoveAt(i);
                    cars.Remove(cars[i]);
                }
            }
        }

        public void CheckFixesOut()                                 // метод - видалення СТО з колекцій
        {
            for (int i = (fixes.Count - 1); i >= 0; i--)
            {
                if ((parent.ClientSize.Height - fixes[i].Location.Y) < 50)   // якщо СТО залишає межі форми 
                {
                    //MessageBox.Show("Delete index" + i);
                    fixes[i].Dispose();                                  // то вона видаляється з колекцій
                    typeFixes.RemoveAt(i);
                    fixes.Remove(fixes[i]);
                }
            }
        }
    }
}
