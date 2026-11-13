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

namespace cc105_pose_proj
{
    public partial class Form2 : Form
    {
        SoundPlayer player;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Image = Image.FromFile(@"C:\Users\Matthew\Screenshots\Screenshot 2026-10-29 221711.png");
            player.Play();

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Image = Image.FromFile(@"C:\Users\Matthew\Screenshots\Screenshot 2026-10-29 221659.png");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer(@"C:\Users\Matthew\Downloads\Vine Boom sound effect meme.wav");
        }
    }
}
