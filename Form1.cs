namespace Race
{
    public partial class Form1 : Form
    {
        Track track;
        public Form1()                  // конструктор форми
        {
            InitializeComponent();
            track = new Track(this);    // створюється нова траса                
            timer1.Start();             // запускаються таймери
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)        // обробник подій для таймера 1
        {
            track.TrackBuilding2();         // будується траса
            track.CreateBlock();            // на трасу додаються додаткові перешкоди (авто)                    
            track.CreateFixes();            // на трасу додаються монети і СТО
            //track.metres++;               // підрахунок кілометражу
            track.CheckAccident();          // перевірка чи сталося ДТП з додатковими перешкодами
            track.myBolid.CheckHealth();    // перевірка ступеню пошкодження боліду
            track.CheckFixes();             // перевірка збирання монет та СТО
            track.CheckCars();              // перевірка наявності додаткових перешкод за межами форми
            track.CheckFixesOut();          // перевірка наявності монет та СТО за межами форми
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)       // обробник події - нажаття на клавіші
        {
            if (e.KeyCode == Keys.Left)             // якщо клавіша вліво (поворот/зміщення боліду)
            {
                if (myBolid.Location.X - track.turn < track.leftRoadBorder)                 // якщо болід досяг лівої границі траси
                {
                    myBolid.Location = new Point(track.leftRoadBorder, myBolid.Location.Y); // то болід не рухається
                }
                else
                {
                    myBolid.Location = new Point(myBolid.Location.X - track.turn, myBolid.Location.Y);  // інакше - болід зміщується вліво
                }
            }

            else if (e.KeyCode == Keys.Right)             // якщо клавіша вправо  (поворот/зміщення боліду)
            {
                if (myBolid.Location.X + track.turn > (track.rightRoadBorder - myBolid.Width))                 // якщо болід досяг правої границі траси
                {
                    myBolid.Location = new Point((track.rightRoadBorder - myBolid.Width), myBolid.Location.Y); // то болід не рухається
                }
                else
                {
                    myBolid.Location = new Point(myBolid.Location.X + track.turn, myBolid.Location.Y);  // інакше - болід зміщується вправо
                }
            }

            else if (e.KeyCode == Keys.Up)             // якщо клавіша вверх (розгін)
            {
                if ((track.speed + 1) > 10)             // якщо досягнута максимальна швидкість боліду
                {
                    track.speed = 10;                                                          // то швидкість не змінюється і становить 10 пікселів на 1 мілісекунду
                    track.turn = 15;                                                           // максимальне зміщення боліду встановлене   на рівні 15 пікселів    
                    toolStripStatusLabel3.Text = "  speed: " + track.speed * 20 + " km/h";      // вивденення інформації про швидкість в StatusStrip
                }
                else                                     // якщо максимальна швидкість не досягнута, то
                {
                    track.speed++;                                                              // то швидкість збільшується на одиницю
                    track.turn++;                                                               // при збільшенні швидкості болід зміщується швидше
                    toolStripStatusLabel3.Text = "  speed: " + track.speed * 20 + " km/h";      // вивденення інформації про швидкість в StatusStrip
                }
            }

            else if (e.KeyCode == Keys.Down)            // якщо клавіша вниз (гальмування)
            {
                if ((track.speed - 1) < 1)              // якщо досягнута мінімальна швидкість боліду       
                {
                    track.speed = 1;                    // то швидкість не змінюється 1 піксель на 1 мілісекунду
                    track.turn = 5;                     // максимальне зміщення боліду встановлене  на рівні 5 пікселів 
                    toolStripStatusLabel3.Text = "  speed: " + track.speed * 20 + " km/h";      // вивденення інформації про швидкість в StatusStrip
                }
                else
                {
                    track.speed--;                                                          // то швидкість зменшується на одиницю
                    track.turn--;                                                           // при зменшенні швидкості болід зміщується повільніше
                    toolStripStatusLabel3.Text = "  speed: " + track.speed * 20 + " km/h";  // вивденення інформації про швидкість в StatusStrip
                }

            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)     // метод - запобігання зміщення фокусу з боліду на інші елементи форми
        {
            var keys = new[] { Keys.Left, Keys.Right, Keys.Up, Keys.Down };
            if (keys.Contains(e.KeyData))
                e.IsInputKey = true;
        }

        private void timer2_Tick(object sender, EventArgs e)                            // обробник події таймеру - підрахунок часу до кінця гри
        {
            double second = track.racetime.Second;
            if (second == 0)
                second = 0;
            else
                track.racetime = new TimeOnly(0, 0, ((int)second - 1));
            toolStripStatusLabel2.Text = "race time: " + track.racetime.Second + " second(s)";
            toolStripProgressBar2.Value = (int)(second / 30 * 100);
        }
    }
}