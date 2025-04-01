using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace лаба_4
{
    public partial class Form1 : Form
    {
        private List<Beverage> beverages = new List<Beverage>();
        private PictureBox drinkDisplay = new PictureBox();

        public Form1()
        {
            InitializeComponent();
            InitializeDrinkDisplay();
            ShowInfo();
        }

        private void InitializeDrinkDisplay()
        {
            
            drinkDisplay.Size = new Size(150, 150);
            drinkDisplay.Location = new Point(
                (this.ClientSize.Width - 150) / 2, 
                130); 
            drinkDisplay.SizeMode = PictureBoxSizeMode.Zoom;
            drinkDisplay.BorderStyle = BorderStyle.FixedSingle;
            drinkDisplay.BackColor = Color.White;
            drinkDisplay.Visible = false;
            this.Controls.Add(drinkDisplay);
        }

        private void ShowInfo()
        {
            int juiceCount = 0, sodaCount = 0, alcoholCount = 0;

            foreach (var beverage in beverages)
            {
                if (beverage is Juice) juiceCount++;
                else if (beverage is Soda) sodaCount++;
                else if (beverage is Alcohol) alcoholCount++;
            }

            txtInfo.Text = $"Сок: {juiceCount}\nГазировка: {sodaCount}\nАлкоголь: {alcoholCount}";
        }

        private void btnRefill_Click(object sender, EventArgs e)
        {
            beverages.Clear();
            var rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                switch (rnd.Next(3))
                {
                    case 0: beverages.Add(Juice.Generate()); break;
                    case 1: beverages.Add(Soda.Generate()); break;
                    case 2: beverages.Add(Alcohol.Generate()); break;
                }
            }

            drinkDisplay.Visible = false;
            ShowInfo();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            if (beverages.Count == 0)
            {
                txtOut.Text = "Автомат пуст!";
                drinkDisplay.Visible = false;
                return;
            }

            var beverage = beverages[0];
            beverages.RemoveAt(0);

            txtOut.Text = beverage.GetInfo();
            UpdateDrinkImage(beverage);
            ShowInfo();
        }

        private void UpdateDrinkImage(Beverage beverage)
        {
            string imageName = beverage switch
            {
                Juice j => $"juice_{j.Fruit.ToString().ToLower()}.png",
                Soda s => $"soda_{s.Type.ToString().ToLower()}.png",
                Alcohol a => $"alcohol_{a.Type.ToString().ToLower()}.png",
                _ => "default.png"
            };

            string imagePath = Path.Combine(Application.StartupPath, imageName);

            if (File.Exists(imagePath))
            {
                drinkDisplay.Image = Image.FromFile(imagePath);
            }
            else
            {
                
                var bmp = new Bitmap(150, 150);
                using (var g = Graphics.FromImage(bmp))
                {
                    string text = beverage switch
                    {
                        Juice j => $"Сок {j.Fruit}",
                        Soda s => $"{s.Type}",
                        Alcohol a => $"{a.Type}",
                        _ => "Напиток"
                    };

                    g.Clear(beverage is Juice ? Color.Orange :
                           beverage is Soda ? Color.LightBlue :
                           Color.LightPink);
                    g.DrawString(text, new Font("Arial", 14), Brushes.Black,
                               new Rectangle(0, 0, 150, 150),
                               new StringFormat
                               {
                                   Alignment = StringAlignment.Center,
                                   LineAlignment = StringAlignment.Center
                               });
                }
                drinkDisplay.Image = bmp;
            }

            drinkDisplay.Visible = true;
        }
    }
}