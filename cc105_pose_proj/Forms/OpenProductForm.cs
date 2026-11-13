using cc105_pose_proj.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cc105_pose_proj
{
    public partial class OpenProductForm : Form
    {
        Product? product;
        public OpenProductForm(Product? product)
        {
            this.product = product ?? null;
            InitializeComponent();
            ResizeComponents();
        }

        private void OpenProductForm_Load(object sender, EventArgs e)
        {
            
            if (product != null) 
                label1.Text = product.Name;
        }

        private void ResizeComponents()
        {
            Screen mainScreen = Screen.PrimaryScreen!;
            int screenWidth = mainScreen.Bounds.Width;
            int screenHeight = mainScreen.Bounds.Height;
            this.Width = screenWidth / 2;
            this.Height = (int)(screenHeight * 0.9);
        }

        private void OpenProductForm_Resize(object sender, EventArgs e)
        {
            
        }
    }
}
