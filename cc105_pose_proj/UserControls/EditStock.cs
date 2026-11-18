using cc105_pose_proj.Forms;
using cc105_pose_proj.Models;

namespace cc105_pose_proj.UserControls
{
    public partial class EditStock : UserControl, IDialogControl
    {
        public event EventHandler<DialogResult>? RequestClose;
        private readonly int _currentStock;
        private bool IsAdjust;
        public int AdjustedQuantity { get; private set; }
        public MovementType SelectedType { get; private set; }

        public EditStock(int stock = 0)
        {
            _currentStock = stock;
            InitializeComponent();
        }

        private void EditStock_Load(object sender, EventArgs e)
        {
            buttonPanel.Left = (this.ClientSize.Width - buttonPanel.Width) / 2;
            movementReasonComboBox.DataSource = MovementReasonItem.All;
            movementReasonComboBox.SelectedIndex = -1;
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(quantityField.Text, out int quantity) || quantity <= 0)
                return;

            if (movementReasonComboBox.SelectedItem is not MovementReasonItem selected)
                return;

            SelectedType = selected.Type;
            AdjustedQuantity = quantity;

            RequestClose?.Invoke(this, DialogResult.OK);
        }

        private void stockField_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(quantityField.Text, out int quantity) || quantity <= 0)
                return;
        }

        private void movementReasonComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (movementReasonComboBox.SelectedItem is not MovementReasonItem selected)
                return;

            IsAdjust = selected.Type is MovementType.ADJUST_IN or MovementType.ADJUST_OUT;

            quantityLabel.Text = IsAdjust ? "Total Stock" : "Quantity";
            quantityField.Text = IsAdjust ? _currentStock.ToString() : "0";
        }
    }
}
