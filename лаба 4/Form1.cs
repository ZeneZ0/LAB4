using System;
using System.Collections.Generic;
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
            drinkDisplay.Image = beverage.GetImage();
            drinkDisplay.Visible = true;
            ShowInfo();
        }
    }
}