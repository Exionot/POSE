using cc105_pose_proj.Data;
using cc105_pose_proj.Models;
using cc105_pose_proj.Util;
using MySql.Data.MySqlClient;
using System.Data;

namespace cc105_pose_proj
{
    public partial class Form1 : Form
    {
        private readonly IRepository<Business> _businessRepo = new BusinessRepository();
        private readonly IRepository<Product> _productRepo = new ProductRepository(); 
        public static string imgPath;
        public Form1()
        {
            InitializeComponent();
            //new Form2().Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(RESOURCE_DIR);
            foreach (Business b in _businessRepo.GetAll())
            {
                comboBox1.Items.Add(b);
            }
            loadTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //User.login(textBox1.Text, textBox2.Text, out User? user);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Product> list = _productRepo.GetAll();
            flowLayoutPanel1.Controls.Clear();
            int maxSize = 100;
            foreach (Product p in list)
            {
                Button button = new Button();
                button.Text = p.Name;
                button.Size = new Size(maxSize + 20, maxSize + 20);
                button.AutoSize = false;

                Image image = Image.FromFile(AppPaths.ResourceDir + p.Image);

                double ratio = Math.Min((double)maxSize / image.Width, (double)maxSize / image.Height);

                int height = (int)(image.Height * ratio);
                int width = (int)(image.Width * ratio);

                button.Image = new Bitmap(image, new Size(width, height));
                image.Dispose();

                button.ImageAlign = ContentAlignment.MiddleCenter;
                button.TextImageRelation = TextImageRelation.ImageAboveText;
                flowLayoutPanel1.Controls.Add(button);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = textBox4.Text;
            string quantityString = textBox3.Text;
            string priceString = textBox5.Text;
            Business? selectedBusiness = (Business?)comboBox1.SelectedItem;

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Name cannot be empty");
                return;
            }
            if (string.IsNullOrEmpty(quantityString))
            {
                MessageBox.Show("Quantity cannot be empty");
                return;
            }
            if (string.IsNullOrEmpty(priceString))
            {
                MessageBox.Show("Price cannot be empty");
                return;
            }
            if (selectedBusiness == null)
            {
                MessageBox.Show("Business cannot be empty");
                return;
            }

            if (!int.TryParse(quantityString, out int quantity))
            {
                MessageBox.Show("Quantity must be a number");
                return;
            }

            if (!decimal.TryParse(priceString, out decimal price))
            {
                MessageBox.Show("Quantity must be a number");
                return;
            }

            if (string.IsNullOrEmpty(imgPath))
            {
                imgPath = "Default.png";
            }

            var product = new Product
            {
                Name = name,
                Quantity = quantity,
                Price = price,
                Business = selectedBusiness!,
                Image = imgPath
            };
            if (_productRepo.Add(product))
            {
                MessageBox.Show("Product added successfully");
            }
            else
            {
                MessageBox.Show("Product insertion failed");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = DbConnector.GetConnection())
            {
                try
                {
                    conn.Open();
                    string q = "insert into users(username, password) values(@username, @password)";
                    using (MySqlCommand cmd = new MySqlCommand(q, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@password", PasswordUtils.hashPassword(textBox2.Text));

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("User Added");
                        }
                        else
                        {
                            MessageBox.Show("Failed");
                        }

                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(selectImage());
            imgPath = selectImage();
            Image img = Image.FromFile(imgPath);
            if (img != null)
            {
                pictureBox1.Image = img;
            }
        }

        private String selectImage()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Select an Image";
                dialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    return dialog.FileName;
                }
            }
            return "";
        }

        private void loadTable()
        {
            using var conn = DbConnector.GetConnection();
            conn.Open();

            string q = @"select * from business";
            using var cmd = new MySqlCommand(q, conn);
            MySqlDataAdapter a = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            a.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
