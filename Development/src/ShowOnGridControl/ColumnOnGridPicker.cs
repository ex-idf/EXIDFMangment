using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ShowOnGridControl
{
    public partial class ColumnOnGridPicker : UserControl
    {
        public DataGridView DGV { get; set; }
        public Dictionary<string, CheckBox> ColumnsToCheckBoxes { get; set; }

        public ColumnOnGridPicker() : this (null)
        {
            InitializeComponent();
        }

        public ColumnOnGridPicker(BindingSource bindingSource)
        {
            ColumnsToCheckBoxes = new Dictionary<string, CheckBox>();
        }
        
        public void Refresh()
        {
            if (DGV != null)
            {
                if (flpControlsLayout != null) // Wait for the FlowLayoutPanel initialization
                {
                    flpControlsLayout.Controls.Clear();
                }
                for (int i = 0;  i < DGV.Columns.Count; ++i)
                {
                    AddCheckBox(DGV.Columns[i].Name, DGV.Columns[i].Visible);
                }
            }
        }

        public void AddCheckBox(string columnName, bool isColumnVisible)
        {
            CheckBox newCheckbox = null;

            if (!(ColumnsToCheckBoxes.ContainsKey(columnName)))
            {
                newCheckbox = new CheckBox()
                                                        {
                                                            Visible = true,
                                                            Text = columnName,
                                                            Checked = isColumnVisible,
                                                            Margin = new Padding(0,0,0,0)
                                                        };
                newCheckbox.CheckedChanged += new EventHandler(newCheckbox_CheckedChanged);
                flpControlsLayout.Controls.Add(newCheckbox);
                flpControlsLayout.SetBounds(flpControlsLayout.Location.X, flpControlsLayout.Location.Y, 1,1);
                flpControlsLayout.AutoScroll = true;
            }
            else
            {
                return;
            }
        }

        void newCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox box = sender as CheckBox;
            if (box != null)
            {
                if (DGV.Columns.Contains(box.Text))
                {
                    DGV.Columns[box.Text].Visible = box.Checked;
                }
            }
        }
   
        public void SetLayoutSize(Size size)
        {
            flpControlsLayout.MaximumSize = size;
        }
    }
}
