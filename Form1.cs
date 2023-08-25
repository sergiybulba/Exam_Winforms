namespace Race
{
    public partial class Form1 : Form
    {
        Track track;
        public Form1()                  // ����������� �����
        {
            InitializeComponent();
            track = new Track(this);    // ����������� ���� �����                
            timer1.Start();             // ������������ �������
            timer2.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)        // �������� ���� ��� ������� 1
        {
            track.TrackBuilding2();         // �������� �����
            track.CreateBlock();            // �� ����� ��������� �������� ��������� (����)                    
            track.CreateFixes();            // �� ����� ��������� ������ � ���
            //track.metres++;               // ��������� ����������
            track.CheckAccident();          // �������� �� ������� ��� � ����������� �����������
            track.myBolid.CheckHealth();    // �������� ������� ����������� �����
            track.CheckFixes();             // �������� �������� ����� �� ���
            track.CheckCars();              // �������� �������� ���������� �������� �� ������ �����
            track.CheckFixesOut();          // �������� �������� ����� �� ��� �� ������ �����
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)       // �������� ��䳿 - ������� �� ������
        {
            if (e.KeyCode == Keys.Left)             // ���� ������ ���� (�������/������� �����)
            {
                if (myBolid.Location.X - track.turn < track.leftRoadBorder)                 // ���� ���� ����� ��� ������� �����
                {
                    myBolid.Location = new Point(track.leftRoadBorder, myBolid.Location.Y); // �� ���� �� ��������
                }
                else
                {
                    myBolid.Location = new Point(myBolid.Location.X - track.turn, myBolid.Location.Y);  // ������ - ���� �������� ����
                }
            }

            else if (e.KeyCode == Keys.Right)             // ���� ������ ������  (�������/������� �����)
            {
                if (myBolid.Location.X + track.turn > (track.rightRoadBorder - myBolid.Width))                 // ���� ���� ����� ����� ������� �����
                {
                    myBolid.Location = new Point((track.rightRoadBorder - myBolid.Width), myBolid.Location.Y); // �� ���� �� ��������
                }
                else
                {
                    myBolid.Location = new Point(myBolid.Location.X + track.turn, myBolid.Location.Y);  // ������ - ���� �������� ������
                }
            }

            else if (e.KeyCode == Keys.Up)             // ���� ������ ����� (�����)
            {
                if ((track.speed + 1) > 10)             // ���� ��������� ����������� �������� �����
                {
                    track.speed = 10;                                                          // �� �������� �� ��������� � ��������� 10 ������ �� 1 ���������
                    track.turn = 15;                                                           // ����������� ������� ����� �����������   �� ��� 15 ������    
                    toolStripStatusLabel3.Text = "  speed: " + track.speed * 20 + " km/h";      // ���������� ���������� ��� �������� � StatusStrip
                }
                else                                     // ���� ����������� �������� �� ���������, ��
                {
                    track.speed++;                                                              // �� �������� ���������� �� �������
                    track.turn++;                                                               // ��� �������� �������� ���� �������� ������
                    toolStripStatusLabel3.Text = "  speed: " + track.speed * 20 + " km/h";      // ���������� ���������� ��� �������� � StatusStrip
                }
            }

            else if (e.KeyCode == Keys.Down)            // ���� ������ ���� (�����������)
            {
                if ((track.speed - 1) < 1)              // ���� ��������� �������� �������� �����       
                {
                    track.speed = 1;                    // �� �������� �� ��������� 1 ������ �� 1 ���������
                    track.turn = 5;                     // ����������� ������� ����� �����������  �� ��� 5 ������ 
                    toolStripStatusLabel3.Text = "  speed: " + track.speed * 20 + " km/h";      // ���������� ���������� ��� �������� � StatusStrip
                }
                else
                {
                    track.speed--;                                                          // �� �������� ���������� �� �������
                    track.turn--;                                                           // ��� �������� �������� ���� �������� ��������
                    toolStripStatusLabel3.Text = "  speed: " + track.speed * 20 + " km/h";  // ���������� ���������� ��� �������� � StatusStrip
                }

            }
        }

        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)     // ����� - ���������� ������� ������ � ����� �� ���� �������� �����
        {
            var keys = new[] { Keys.Left, Keys.Right, Keys.Up, Keys.Down };
            if (keys.Contains(e.KeyData))
                e.IsInputKey = true;
        }

        private void timer2_Tick(object sender, EventArgs e)                            // �������� ��䳿 ������� - ��������� ���� �� ���� ���
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