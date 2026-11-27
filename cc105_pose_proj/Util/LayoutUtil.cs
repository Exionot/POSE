namespace cc105_pose_proj.Util
{
    public static class LayoutUtil
    {
        public static void FitTotalLabel(Label label)
        {
            if (label.Parent == null) return;

            int labelWidth = label.AutoSize ? label.PreferredWidth : label.Width;
            int labelHeight = label.AutoSize ? label.PreferredHeight : label.Height;

            if (label.Anchor.HasFlag(AnchorStyles.Right))
            {
                label.Left = label.Parent.ClientSize.Width - labelWidth - label.Margin.Right;
            }
            else if (label.Anchor.HasFlag(AnchorStyles.Left))
            {
                label.Left = label.Margin.Left;
            }

            label.Top = (label.Parent.ClientSize.Height - labelHeight) / 2;
        }

        public static void FitTotalLabel(IEnumerable<Label> labels)
        {
            foreach (var label in labels)
            {
                FitTotalLabel(label);
            }
        }

        public static void SetAutoFitEvents(Control container)
        {
            foreach (Panel rowPanel in container.Controls.OfType<Panel>())
            {
                foreach (Label label in rowPanel.Controls.OfType<Label>())
                {
                    label.TextChanged += (_, _) => FitTotalLabel(label);
                    label.SizeChanged += (_, _) => FitTotalLabel(label);
                }
            }
        }
    }
}
