using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clonk
{
    public partial class Form1 : Form
    {
        private RadioButton RB_Lever1;
        private RadioButton RB_Lever2;
        private RadioButton RB_2Red;
        private RadioButton RB_2Blue;
        private RadioButton RB_2West;
        private RadioButton RB_2East;
        private Label outputLabel;
        private Label outputGroupBoxLabel;
        private GroupBox outputGroupBox;
        private Button copyButton; // Add a button for copying text

        public Form1()
        {
            InitializeComponent();
            InitializeControls();
            UpdateOutput(null, EventArgs.Empty);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void InitializeControls()
        {
            // Create labels for group boxes
            Label groupLeversLabel = new Label
            {
                Text = "Left/Right Most Levers",
                Location = new Point(20, 268),
                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Regular)
            };

            Label groupRedBlueLabel = new Label
            {
                Text = "Red/Blue Levers",
                Location = new Point(20, 8),
                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Regular)
            };

            Label groupWestEastLabel = new Label
            {
                Text = "East/West Levers",
                Location = new Point(20, 138),
                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Regular)
            };

            outputGroupBoxLabel = new Label
            {
                Text = "Lever Combination(s)",
                Location = new Point(20, 398),
                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Regular)
            };

            RB_Lever1 = new RadioButton
            {
                Text = "Left Most",
                Location = new Point(30, 24),
                Visible = true,
                AutoCheck = false
            };

            RB_Lever2 = new RadioButton
            {
                Text = "Right Most",
                Location = new Point(30, 57),
                Visible = true,
                AutoCheck = false
            };

            var groupLevers = new GroupBox
            {
                Location = new Point(20, 280),
                Size = new Size(200, 100),
                Visible = true
            };
            groupLevers.Controls.Add(RB_Lever1);
            groupLevers.Controls.Add(RB_Lever2);

            RB_Lever1.Click += new EventHandler(RadioButton_Click);
            RB_Lever2.Click += new EventHandler(RadioButton_Click);

            RB_2Red = new RadioButton
            {
                Text = "2+ Red",
                Location = new Point(30, 24),
                Visible = true,
                Checked = true
            };

            RB_2Blue = new RadioButton
            {
                Text = "2+ Blue",
                Location = new Point(30, 57),
                Visible = true
            };

            var groupRedBlue = new GroupBox
            {
                Location = new Point(20, 20),
                Size = new Size(200, 100),
                Visible = true
            };
            groupRedBlue.Controls.Add(RB_2Red);
            groupRedBlue.Controls.Add(RB_2Blue);

            RB_2West = new RadioButton
            {
                Text = "2+ West",
                Location = new Point(30, 24),
                Visible = true,
                Checked = true
            };

            RB_2East = new RadioButton
            {
                Text = "2+ East",
                Location = new Point(30, 57),
                Visible = true
            };

            var groupWestEast = new GroupBox
            {
                Location = new Point(20, 150),
                Size = new Size(200, 100),
                Visible = true
            };
            groupWestEast.Controls.Add(RB_2West);
            groupWestEast.Controls.Add(RB_2East);

            outputGroupBox = new GroupBox
            {
                Location = new Point(20, 410),
                Size = new Size(200, 60),
                Visible = true
            };

            outputLabel = new Label
            {
                Location = new Point(15, 24),
                AutoSize = true,
                Font = new Font("Arial", 11, FontStyle.Bold)
            };
            outputGroupBox.Controls.Add(outputLabel);

            // Move copyButton under the outputGroupBox
            copyButton = new Button
            {
                Text = "Copy",
                Location = new Point(82, 486), // Adjusted location to be under the outputGroupBox
                Size = new Size(75, 23)
            };
            copyButton.Click += new EventHandler(CopyButton_Click);

            Controls.Add(groupLeversLabel);
            Controls.Add(groupRedBlueLabel);
            Controls.Add(groupWestEastLabel);
            Controls.Add(outputGroupBoxLabel);
            Controls.Add(groupLevers);
            Controls.Add(groupRedBlue);
            Controls.Add(groupWestEast);
            Controls.Add(outputGroupBox);
            Controls.Add(copyButton); // Add the button to the form

            RB_Lever1.CheckedChanged += new EventHandler(UpdateOutput);
            RB_Lever2.CheckedChanged += new EventHandler(UpdateOutput);
            RB_2Red.CheckedChanged += new EventHandler(UpdateOutput);
            RB_2Blue.CheckedChanged += new EventHandler(UpdateOutput);
            RB_2West.CheckedChanged += new EventHandler(UpdateOutput);
            RB_2East.CheckedChanged += new EventHandler(UpdateOutput);
        }



        private void RadioButton_Click(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb != null)
            {
                rb.Checked = !rb.Checked;
            }
        }

        private void UpdateOutput(object sender, EventArgs e)
        {
            string output = "";

            if (!RB_Lever1.Checked && !RB_Lever2.Checked)
            {
                if (RB_2East.Checked && RB_2Red.Checked)
                {
                    output = "2,4,5";
                }
                else if (RB_2East.Checked && RB_2Blue.Checked)
                {
                    output = "3,4,5";
                }
                else if (RB_2West.Checked && RB_2Red.Checked)
                {
                    output = "2,3,4";
                }
                else if (RB_2West.Checked && RB_2Blue.Checked)
                {
                    output = "2,3,5";
                }
            }
            else if (RB_Lever1.Checked && RB_Lever2.Checked)
            {
                if (RB_2East.Checked && RB_2Red.Checked)
                {
                    output = "1,4,6";
                }
                else if (RB_2East.Checked && RB_2Blue.Checked)
                {
                    output = "1,5,6";
                }
                else if (RB_2West.Checked && RB_2Red.Checked)
                {
                    output = "1,2,6";
                }
                else if (RB_2West.Checked && RB_2Blue.Checked)
                {
                    output = "1,3,6";
                }
            }
            else if (RB_Lever1.Checked && !RB_Lever2.Checked)
            {
                if (RB_2East.Checked)
                {
                    output = "1,4,5";
                }
                else if (RB_2West.Checked && RB_2Red.Checked)
                {
                    output = "1,2,4";
                }
                else if (RB_2West.Checked && RB_2Blue.Checked)
                {
                    output = "1,2,3 / 1,2,5 / 1,3,4 / 1,3,5";
                }
            }
            else if (!RB_Lever1.Checked && RB_Lever2.Checked)
            {
                if (RB_2East.Checked && RB_2Red.Checked)
                {
                    output = "2,4,6 / 2,5,6 / 4,5,6 / 3,4,6";
                }
                else if (RB_2East.Checked && RB_2Blue.Checked)
                {
                    output = "3,5,6";
                }
                else if (RB_2West.Checked && RB_2Blue.Checked)
                {
                    output = "2,3,6";
                }
                else if (RB_2West.Checked && RB_2Red.Checked)
                {
                    output = "2,3,6";
                }
            }

            outputLabel.Text = output;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(outputLabel.Text);
        }
    }
}
