using Fight_arena.Controllers;
using Fight_arena.Entites;
using Fight_arena.Models;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fight_arena
{

    public partial class Form1 : Form
    {
        public Image dwarfSheet;
        public Image gladiatorSheet;
        public Entity player;
        public Form1()
        {
            InitializeComponent();
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            KeyUp += new KeyEventHandler(OnKeyUp);

            Init();
        }

        public void Init()
        {
            MapController.Init();

            Width = MapController.GetWidth();
            Height = MapController.GetHeight();
            dwarfSheet = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(),"Sprites\\Dwarf.png"));

            player = new Entity(Width/2, Height/2, Hero.idleFrames, Hero.runFrames, Hero.attackFrames, Hero.deathFrames, dwarfSheet);
            timer1.Start();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    player.dirY = 0;
                    break;
                case Keys.S:
                    player.dirY = 0;
                    break;
                case Keys.A:
                    player.dirX = 0;
                    break;
                case Keys.D:
                    player.dirX = 0;
                    break;
            }
            if (player.dirX == 0 && player.dirY == 0)
            {
                player.isMoving = false;
                if (player.flip == 1)
                    player.SetAnimationConfiguration(0);
                else player.SetAnimationConfiguration(5);
            }
            //player.dirX = 0;
            //player.dirY = 0;
            //player.isMoving = false;
            //player.SetAnimatConfiguration(0);
        }


        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.dirY = -1;
                    player.isMoving = true;
                    if (player.flip == 1)
                        player.SetAnimationConfiguration(1);
                    else player.SetAnimationConfiguration(6);
                    break;
                case Keys.S:
                    player.dirY = 1;
                    player.isMoving = true;
                    if (player.flip == 1)
                        player.SetAnimationConfiguration(1);
                    else player.SetAnimationConfiguration(6);
                    break;
                case Keys.A:
                    player.dirX = -1;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(6);
                    player.flip = -1;
                    break;
                case Keys.D:
                    player.dirX = 1;
                    player.isMoving = true;
                    player.SetAnimationConfiguration(1);
                    player.flip = 1;
                    break;
                case Keys.Space:
                    player.dirX = 0;
                    player.dirY = 0;
                    player.isMoving = false;
                    if (player.flip == 1)
                        player.SetAnimationConfiguration(2);
                    else player.SetAnimationConfiguration(7);
                    break;
            }

        }


        public void Update(object sendler, EventArgs e)
        {
            //PhysicsController.isCollide(player);
            if (!PhysicsController.isCollide(player, new Point(player.dirX, player.dirY)))
            {
                if (player.isMoving)
                    player.Move();
            }
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            MapController.DrawMap(g);
            player.PlayAnimation(g);
            
        }
    }
}
