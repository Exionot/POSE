namespace cc105_pose_proj.UserControls
{
    public partial class EditStock : UserControl
    {
        private readonly int _stock;

        public EditStock(int stock = 0)
        {
            _stock = stock;
            InitializeComponent();
        }

        private void EditStock_Load(object sender, EventArgs e)
        {
            stockField.Text = _stock.ToString();
            buttonPanel.Left = (this.ClientSize.Width - buttonPanel.Width) / 2;
        }
    }
}
