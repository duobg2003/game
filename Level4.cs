using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxWMPLib;
using WMPLib;

namespace nguyenquocduong_2122110443
{
    public partial class Level4 : Form

    {
        private readonly WindowsMediaPlayer backgroundMusic = new WindowsMediaPlayer();
        //private AxWindowsMediaPlayer axWmp;
        PictureBox pbBasket = new PictureBox();
        PictureBox pbEgg = new PictureBox();
        PictureBox pbChicken = new PictureBox();
        PictureBox pbBom = new PictureBox(); // Quả bom
        Timer tmEgg = new Timer();
        Timer tmChicken = new Timer();
        Timer tmBom = new Timer(); // Timer cho bom
        int xBasket = 300;
        int yBasket = 285;
        int xDeltaBasket = 30;

        int xChicken = 300;
        int yChicken = 10;
        int xDeltaChicken = 5;

        int xEgg = 300;
        int yEgg = 10;
        int yDeltaEgg = 2;

        int xBom = 300;
        int yBom = 10;
        int yDeltaBom = 30; // Tốc độ rơi của bom

        int eggDropCount = 1; // Đếm số lần trứng rơi
        bool isEggBroken = false; // sự kiện trứng vỡ
        bool isGameOver = false;
        int score = 0;
        int second = 0;
        Label lblGameOver = new Label();


        public Level4()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Bật double buffering để giảm nhòe hình ảnh
            PlayBackgroundMusic();


        }
        private void PlayBackgroundMusic()
        {
            try
            {
                backgroundMusic.URL = "D:\\games con gà\\nguyenquocduong_212110443\\Sounds\\chicken_sound.mp3";
                backgroundMusic.settings.volume = 100;
                backgroundMusic.settings.setMode("loop", true);
                backgroundMusic.controls.play();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi phát nhạc: " + ex.Message);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            backgroundMusic.controls.stop();
            base.OnFormClosing(e);
        }

        private void Level4_Load(object sender, EventArgs e)
        {




            this.BackgroundImage = Image.FromFile("../../Images/ba1.jpg");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            // Timer cho bom
            tmBom.Interval = 10;
            tmBom.Tick += TmBom_Tick;
            tmBom.Start();
            //Thời Gian
            tmBom.Interval = 700; // Bom rơi mỗi giây
            tmBom.Tick += TmBom_Tick;
            tmBom.Start();
            // Cài đặt quả bom
            pbBom.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBom.Size = new Size(50, 50);
            pbBom.Location = new Point(xBom, yBom);
            pbBom.BackColor = Color.Transparent;
            pbBom.Visible = false;
            pbBom.Image = Image.FromFile("../../Images/bom.png");
            this.Controls.Add(pbBom);
            RoundPictureBox(pbBom); // Bo tròn viền cho bom
            //pbBom.Visible = false;

            //thời gian của trứng rơi
            tmEgg.Interval = 4;
            tmEgg.Tick += TmEgg_Tick;
            tmEgg.Start();
            //thời gian gà di chuyển
            tmChicken.Interval = 60;
            tmChicken.Tick += TmChicken_Tick;
            tmChicken.Start();
            //Thời Gian
            tmStopwatch.Interval = 800;
            tmStopwatch.Tick += TmStopwatch_Tick;
            tmStopwatch.Start();
            //sự kiện của giỏ trứng
            pbBasket.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBasket.Size = new Size(70, 70);
            pbBasket.Location = new Point(xBasket, yBasket);
            pbBasket.BackColor = Color.Transparent;
            this.Controls.Add(pbBasket);
            pbBasket.Image = Image.FromFile("../../Images/basket.png");
            this.Controls.Add(pbEgg);
            RoundPictureBox(pbEgg);
            //thuộc tính của trứng
            pbEgg.SizeMode = PictureBoxSizeMode.StretchImage;
            pbEgg.Size = new Size(50, 50);
            pbEgg.Location = new Point(xEgg, yEgg);
            pbEgg.BackColor = Color.Transparent;
            this.Controls.Add(pbEgg);
            pbEgg.Image = Image.FromFile("../../Images/trg2.png");
            //thuộc tính gà
            pbChicken.SizeMode = PictureBoxSizeMode.StretchImage;
            pbChicken.Size = new Size(100, 100);
            pbChicken.Location = new Point(xChicken, yChicken);
            pbChicken.BackColor = Color.Transparent;
            this.Controls.Add(pbChicken);
            pbChicken.Image = Image.FromFile("../../Images/ga2.png");

            pbEgg.SendToBack(); //đưa lbDiem xuống dưới
            pbChicken.BringToFront(); //đưa ảnh lên trên
            this.BackColor = Color.LightBlue;

            pbBasket.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            // Cài đặt Label cho chữ "Kết thúc"
            lblGameOver.Font = new Font("Arial", 24, FontStyle.Bold);
            lblGameOver.ForeColor = Color.Red;
            lblGameOver.Text = "GameOver";

            lblGameOver.Size = new Size(200, 50);
            lblGameOver.Location = new Point((this.ClientSize.Width - lblGameOver.Width) / 2, (this.ClientSize.Height - lblGameOver.Height) / 2);
            lblGameOver.Visible = false; // ban đầu ẩn label này
            this.Controls.Add(lblGameOver);
        }
        // Phương thức bo tròn viền cho PictureBox
        private void RoundPictureBox(PictureBox pictureBox)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height);
            pictureBox.Region = new Region(path);
        }
        private void TmStopwatch_Tick(object sender, EventArgs e)
        {
            second++;
            lblDisplay.Text = second.ToString();
            if (isEggBroken == true)
                tmStopwatch.Stop();
        }

        private void TmChicken_Tick(object sender, EventArgs e)
        {
            if (isEggBroken)
            {
                return;
            }
            xChicken += xDeltaChicken;

            if (xChicken > this.ClientSize.Width - pbChicken.Width || xChicken <= 0)
            {
                xDeltaChicken = -xDeltaChicken;
            }
            pbChicken.Location = new Point(xChicken, yChicken);

        }
        private void TmBom_Tick(object sender, EventArgs e)
        {
            if (isGameOver || isEggBroken) return;

            // Cho bom rơi nếu nó không trùng thời điểm với trứng
            yBom += yDeltaBom;
            if (yBom > this.ClientSize.Height - pbBom.Height)
            {
                // Nếu bom rơi xuống quá màn hình, đặt lại vị trí quả bom ngay dưới chân gà
                xBom = pbChicken.Location.X + (pbChicken.Width / 2) - (pbBom.Width / 2);
                yBom = pbChicken.Location.Y + pbChicken.Height; // Đặt yBom ngay dưới chân gà

                pbBom.Location = new Point(xBom, yBom);
                pbBom.Visible = true; // Hiển thị bom sau khi đã đặt vị trí
            }

            // Kiểm tra nếu bom chạm giỏ
            Rectangle bomIntersection = Rectangle.Intersect(pbBom.Bounds, pbBasket.Bounds);
            if (!bomIntersection.IsEmpty)
            {
                GameOver();
                return;
            }

            // Cập nhật vị trí bom
            pbBom.Location = new Point(xBom, yBom);
        }

        // Hàm đặt lại vị trí trứng
        private void ResetEggPosition()
        {
            yEgg = pbChicken.Location.Y + pbChicken.Height;
            xEgg = pbChicken.Location.X + (pbChicken.Width / 2) - (pbEgg.Width / 2);
            isEggBroken = false;
            pbEgg.Image = Image.FromFile("../../Images/trg2.png");
        }

        // Hàm đặt lại vị trí bom
        private void ResetBomPosition()
        {
            xBom = pbChicken.Location.X + (pbChicken.Width / 2) - (pbBom.Width / 2);
            yBom = pbChicken.Location.Y + pbChicken.Height;
            pbBom.Visible = true;
        }

        private void TmEgg_Tick(object sender, EventArgs e)
        {
            yEgg += yDeltaEgg;
            if (yEgg > this.ClientSize.Height - pbEgg.Height || yEgg <= 0)
            {
                pbEgg.Image = Image.FromFile("../../Images/broken_egg.png");
                isEggBroken = true;

                // Dừng mọi thứ và hiển thị chữ "Kết thúc"
                tmEgg.Stop();
                tmChicken.Stop();
                lblGameOver.Visible = true; // hiển thị chữ "Kết thúc"
                return;

            }
            Rectangle unionRect = Rectangle.Intersect(pbEgg.Bounds, pbBasket.Bounds);
            if (unionRect.IsEmpty == false)
            {
                score++;
                lbDiem.Text = "Điểm: " + score;

                if (score == 9)
                {
                    NextLevel();
                    return;
                }

                // Tăng tốc độ gà và trứng sau mỗi 4 điểm
                if (score % 6 == 0)
                {
                    xDeltaChicken += 1;  // Tăng tốc độ di chuyển của gà
                    yDeltaEgg += 1;      // Tăng tốc độ rơi của trứng
                }
                yEgg = pbChicken.Location.Y + pbChicken.Height;
                xEgg = pbChicken.Location.X + (pbChicken.Width / 2) - (pbEgg.Width / 2);

                isEggBroken = false;
                pbEgg.Image = Image.FromFile("../../Images/trg2.png");
            }
            pbEgg.Location = new Point(xEgg, yEgg);
        }
        private void GameOver()
        {
            // Kết thúc trò chơi
            isGameOver = true;
            tmEgg.Stop();
            tmChicken.Stop();
            tmBom.Stop();
            lblGameOver.Visible = true;

            backgroundMusic.controls.stop();

        }

        private void Level4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (xBasket < this.ClientSize.Width - pbBasket.Width)
                    xBasket += xDeltaBasket;
            }
            else if (e.KeyCode == Keys.Left)
            {
                if (xBasket > 0)
                    xBasket -= xDeltaBasket;
            }

            pbBasket.Location = new Point(xBasket, yBasket);
        }
        private void NextLevel()
        {
            // Dừng tất cả các timer
            tmEgg.Stop();
            tmChicken.Stop();
            tmStopwatch.Stop();

            // Thông báo người chơi đã qua màn
            MessageBox.Show("Chúc mừng bạn đã qua màn!", "Qua màn", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Tăng độ khó (tốc độ gà, tốc độ rơi trứng)
            xDeltaChicken += 2;
            yDeltaEgg += 2;

            // Reset lại vị trí trứng và gà
            yEgg = pbChicken.Location.Y + pbChicken.Height;
            xEgg = pbChicken.Location.X + (pbChicken.Width / 2) - (pbEgg.Width / 2);
            xChicken = 300;

            // Reset giỏ trứng và trứng
            xBasket = 300;
            yBasket = 285;
            pbBasket.Location = new Point(xBasket, yBasket);
            pbEgg.Location = new Point(xEgg, yEgg);

            // Bắt đầu lại các timer
            tmEgg.Start();
            tmChicken.Start();
            tmStopwatch.Start();
            // Chuyển sang màn chơi thứ hai
            Level5 level5 = new Level5();
            level5.Show(); // Hiện màn chơi mới
            this.Hide();   // Ẩn màn chơi hiện tại

            // Tăng số điểm cần để qua màn cho màn tiếp theo
            score = 0;
        }


    }
}

