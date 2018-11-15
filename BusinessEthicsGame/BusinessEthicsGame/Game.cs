﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessEthicsGame
{
    
    public partial class Game : Form
    {
        public NPC[] npcs;

        public Game()
        {
            InitializeComponent();

            this.Load += Game_Load;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            timer1.Tick += Timer1_Tick;
            timer1.Start();
            Random rand = new Random();
            npcs = Enumerable.Range(0, 5).Select(n =>
                new NPC(rand, ClientRectangle.Width, ClientRectangle.Height)).ToArray();
            foreach (var n in npcs)
                Controls.Add(n.image);
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            foreach(var n in npcs)
            {
                n.update();
            }
        }
    }

    public class NPC
    {
        private int width, height;
        private int timeSinceMoved;
        private Random random;
        public PictureBox image;

        public NPC(Random rand, int w, int h)
        {
            this.random = rand;
            this.width = w;
            this.height = h;
            this.image = new PictureBox();
            this.image.Image = Properties.Resources.White_square;
            this.image.Location = new Point(random.Next(w-50), random.Next(h-50));
            this.image.Size = new Size(50, 50);
            this.timeSinceMoved = random.Next(2000, 6000);
        }

        public void update()
        {
            timeSinceMoved -= 100;
            if (timeSinceMoved <= 0)
            {
                makeMove();
                timeSinceMoved = random.Next(2000, 6000);
            }
        }

        public void makeMove()
        {
            int i = random.Next(4);
            switch(i)
            {
                case 0: // Up
                    image.Top -= 10;
                    break;
                case 1: //Down
                    image.Top += 10;
                    break;
                case 2: // Left
                    image.Left -= 10;
                    break;
                case 3: // Right
                    image.Left += 10;
                    break;
            }
        }

    }
}