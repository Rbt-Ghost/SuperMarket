using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class InsertForm : Form
    {
        private Panel pnlInputs;
        private Button btnInsert;
        private Button btnClear;
        private Label lblError;
        private GroupBox grpInsertType;
        private RadioButton rdoManager;
        private RadioButton rdoCasier;
        private RadioButton rdoRaion;
        private RadioButton rdoProdus;
        private Dictionary<string, List<Control>> inputFields;

        public InsertForm()
        {
            InitializeComponent();
            CreateDynamicInputs();
        }

        private void InitializeComponent()
        {
            this.pnlInputs = new Panel();
            this.btnInsert = new Button();
            this.btnClear = new Button();
            this.lblError = new Label { ForeColor = Color.Red, AutoSize = true };
            this.grpInsertType = new GroupBox();
            this.rdoManager = new RadioButton();
            this.rdoCasier = new RadioButton();
            this.rdoRaion = new RadioButton();
            this.rdoProdus = new RadioButton();

            // RadioButton Group
            this.grpInsertType.Text = "Select Type";
            this.grpInsertType.Location = new Point(30, 20);
            this.grpInsertType.Size = new Size(440, 60);

            this.rdoManager.Text = "Manager";
            this.rdoManager.Location = new Point(10, 25);
            this.rdoManager.AutoSize = true;
            this.rdoManager.CheckedChanged += new EventHandler(Radio_CheckedChanged);

            this.rdoCasier.Text = "Casier";
            this.rdoCasier.Location = new Point(110, 25);
            this.rdoCasier.AutoSize = true;
            this.rdoCasier.CheckedChanged += new EventHandler(Radio_CheckedChanged);

            this.rdoRaion.Text = "Raion";
            this.rdoRaion.Location = new Point(210, 25);
            this.rdoRaion.AutoSize = true;
            this.rdoRaion.CheckedChanged += new EventHandler(Radio_CheckedChanged);

            this.rdoProdus.Text = "Produs";
            this.rdoProdus.Location = new Point(310, 25);
            this.rdoProdus.AutoSize = true;
            this.rdoProdus.CheckedChanged += new EventHandler(Radio_CheckedChanged);

            this.grpInsertType.Controls.AddRange(new Control[]
            {
                rdoManager, rdoCasier, rdoRaion, rdoProdus
            });

            // Input Panel
            this.pnlInputs.Location = new Point(30, 90);
            this.pnlInputs.Size = new Size(400, 300);
            this.pnlInputs.AutoScroll = true;

            // Insert Button (Styled)
            this.btnInsert.Text = "Insert Data";
            this.btnInsert.Location = new Point(30, 400);
            this.btnInsert.Size = new Size(120, 40);
            this.btnInsert.BackColor = Color.FromArgb(33, 150, 243);
            this.btnInsert.ForeColor = Color.White;
            this.btnInsert.Font = new Font("Arial", 10, FontStyle.Bold);
            this.btnInsert.FlatStyle = FlatStyle.Flat;
            this.btnInsert.FlatAppearance.BorderSize = 0;
            this.btnInsert.Click += new EventHandler(btnInsert_Click);

            // Clear Button (Styled)
            this.btnClear.Text = "Clear All";
            this.btnClear.Location = new Point(160, 400);
            this.btnClear.Size = new Size(120, 40);
            this.btnClear.BackColor = Color.FromArgb(233, 30, 99);
            this.btnClear.ForeColor = Color.White;
            this.btnClear.Font = new Font("Arial", 10, FontStyle.Bold);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Click += new EventHandler(btnClear_Click);

            // Error Label
            this.lblError.Location = new Point(30, 450);
            this.lblError.Font = new Font("Arial", 10, FontStyle.Italic);

            // Form Properties
            this.ClientSize = new Size(500, 500);
            this.Controls.Add(this.grpInsertType);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblError);
            this.Text = "Insert Data";
            this.BackColor = Color.White;
        }

        private void CreateDynamicInputs()
        {
            inputFields = new Dictionary<string, List<Control>>();

            inputFields["Manager"] = new List<Control>
            {
                CreateLabel("Name"), CreateTextBox("txtName", "Enter name..."),
                CreateLabel("Age"), CreateTextBox("txtAge", "Enter age..."),
                CreateLabel("ID"), CreateTextBox("txtID", "Enter ID..."),
                CreateLabel("Departament"), CreateComboBox("cmbDepartament", Enum.GetNames(typeof(DepartamentType))),
                CreateLabel("Salary"), CreateTextBox("txtSalary", "Enter salary...")
            };

            inputFields["Casier"] = new List<Control>
            {
                CreateLabel("Name"), CreateTextBox("txtName", "Enter name..."),
                CreateLabel("Age"), CreateTextBox("txtAge", "Enter age..."),
                CreateLabel("ID"), CreateTextBox("txtID", "Enter ID..."),
                CreateLabel("NrCasa"), CreateTextBox("txtNrCasa", "Enter casa number..."),
                CreateLabel("Salary"), CreateTextBox("txtSalary", "Enter salary...")
            };

            inputFields["Raion"] = new List<Control>
            {
                CreateLabel("Raion Type"), CreateComboBox("cmbRaion", Enum.GetNames(typeof(RaionType)))
            };

            inputFields["Produs"] = new List<Control>
            {
                CreateLabel("Raion Type"), CreateComboBox("cmbRaion", Enum.GetNames(typeof(RaionType))),
                CreateLabel("Name"), CreateTextBox("txtName", "Enter name..."),
                CreateLabel("Price"), CreateTextBox("txtPrice", "Enter price..."),
                CreateLabel("Quantity"), CreateTextBox("txtQuantity", "Enter quantity...")
            };
        }

        private Label CreateLabel(string text)
        {
            return new Label { Text = text, AutoSize = true, Font = new Font("Arial", 10, FontStyle.Bold), ForeColor = Color.FromArgb(63, 81, 181) };
        }

        private TextBox CreateTextBox(string name, string placeholder)
        {
            var tb = new TextBox
            {
                Name = name,
                Width = 200,
                ForeColor = Color.Gray,
                Text = placeholder,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Arial", 10)
            };

            tb.GotFocus += (s, e) =>
            {
                if (tb.Text == placeholder)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };

            tb.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = placeholder;
                    tb.ForeColor = Color.Gray;
                }
            };

            tb.Margin = new Padding(5);
            tb.BackColor = Color.FromArgb(240, 240, 240);
            tb.BorderStyle = BorderStyle.Fixed3D;

            return tb;
        }

        private ComboBox CreateComboBox(string name, string[] items)
        {
            ComboBox comboBox = new ComboBox
            {
                Name = name,
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Arial", 10)
            };
            comboBox.Items.AddRange(items);
            comboBox.SelectedIndex = -1;
            comboBox.BackColor = Color.FromArgb(240, 240, 240);

            return comboBox;
        }

        private CheckBox CreateCheckBox(string name)
        {
            return new CheckBox { Name = name, Width = 20, Checked = false, Enabled = false };
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            pnlInputs.Controls.Clear();
            string selectedType = (sender as RadioButton)?.Text;
            if (selectedType != null && inputFields.ContainsKey(selectedType))
            {
                int y = 10;
                foreach (var control in inputFields[selectedType])
                {
                    control.Location = new Point(10, y);
                    pnlInputs.Controls.Add(control);
                    y += 30;

                    if (control is TextBox textBox)
                    {
                        var checkBox = CreateCheckBox(textBox.Name + "Check");
                        checkBox.Location = new Point(220, y - 30);
                        pnlInputs.Controls.Add(checkBox);
                    }

                    if (control is ComboBox comboBox)
                    {
                        var checkBox = CreateCheckBox(comboBox.Name + "Check");
                        checkBox.Location = new Point(220, y - 30);
                        pnlInputs.Controls.Add(checkBox);
                    }
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            bool allValid = true;
            string selectedType = GetSelectedType();

            if (string.IsNullOrEmpty(selectedType))
            {
                lblError.Text = "Please select a category first!";
                return;
            }

            foreach (Control control in pnlInputs.Controls)
            {
                if (control is TextBox textBox)
                {
                    // Reset style first
                    textBox.BackColor = Color.FromArgb(240, 240, 240);

                    var checkBox = pnlInputs.Controls[textBox.Name + "Check"] as CheckBox;
                    if (checkBox != null)
                    {
                        bool isValid = ValidateInput(textBox);
                        checkBox.Checked = isValid;

                        // Set background to red if invalid
                        textBox.BackColor = isValid ? Color.FromArgb(240, 240, 240) : Color.MistyRose;

                        if (!isValid)
                            allValid = false;
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    // Reset style first
                    comboBox.BackColor = Color.FromArgb(240, 240, 240);

                    var checkBox = pnlInputs.Controls[comboBox.Name + "Check"] as CheckBox;
                    if (checkBox != null)
                    {
                        bool isValid = ValidateComboBox(comboBox);
                        checkBox.Checked = isValid;

                        comboBox.BackColor = isValid ? Color.FromArgb(240, 240, 240) : Color.MistyRose;

                        if (!isValid)
                            allValid = false;
                    }
                }
            }

            if (!allValid)
            {
                lblError.Text = "Error: Incorrect format!";
                return;
            }

            InsertData(selectedType);
            MessageBox.Show("Data Inserted Successfully!");
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach (Control control in pnlInputs.Controls)
            {
                if (control is TextBox tb)
                {
                    tb.Text = ""; 
                    tb.ForeColor = Color.Gray; 
                                               
                    if (tb.Name == "txtName") tb.Text = "Enter name...";
                    else if (tb.Name == "txtAge") tb.Text = "Enter age...";
                    else if (tb.Name == "txtID") tb.Text = "Enter ID...";
                    else if (tb.Name == "txtSalary") tb.Text = "Enter salary...";
                    else if (tb.Name == "txtNrCasa") tb.Text = "Enter casa number...";
                    else if (tb.Name == "txtPrice") tb.Text = "Enter price...";
                    else if (tb.Name == "txtQuantity") tb.Text = "Enter quantity...";
                }
                else if (control is ComboBox cb)
                {
                    cb.SelectedIndex = -1; 
                    cb.BackColor = Color.White; 
                }
                else if (control is CheckBox cbx)
                {
                    cbx.Checked = false; 
                }
            }

            lblError.Text = string.Empty; 
        }

        private string GetSelectedType()
        {
            if (rdoManager.Checked) return "Manager";
            if (rdoCasier.Checked) return "Casier";
            if (rdoRaion.Checked) return "Raion";
            if (rdoProdus.Checked) return "Produs";
            return null;
        }

        private bool ValidateInput(TextBox textBox)
        {
            string value = textBox.Text.Trim();

            if (textBox.Name == "txtName")
            {
                if (value.Length < 3 || value == "Enter name...")
                    return false;
            }
            else if (textBox.Name == "txtAge")
            {
                if (!int.TryParse(value, out int age) || age < 16 || age > 120)
                    return false;
            }
            else if (textBox.Name == "txtID")
            {
                if (!int.TryParse(value, out int id) || id < 100000 || id > 999999)
                    return false;
            }
            else if (textBox.Name == "txtSalary" || textBox.Name == "txtPrice")
            {
                if (!decimal.TryParse(value, out decimal result) || result <= 1999)
                    return false;
            }
            else if (textBox.Name == "txtNrCasa")
            {
                if (!int.TryParse(value, out int nr) || nr < 1)
                    return false;
            }
            else if (textBox.Name == "txtQuantity")
            {
                if (!int.TryParse(value, out int qty) || qty < 1)
                    return false;
            }

            return true;
        }


        private bool ValidateComboBox(ComboBox comboBox)
        {
            return comboBox.SelectedIndex != -1;
        }

        private void InsertData(string selectedType)
        {
            string filePath = GetFilePath(selectedType);

            List<string> dataToInsert = inputFields[selectedType]
                .Where(c => c is TextBox tb && tb.ForeColor == Color.Black || c is ComboBox cb && cb.SelectedIndex != -1)
                .Select(c =>
                {
                    if (c is TextBox textBox)
                        return textBox.Text;
                    if (c is ComboBox comboBox)
                        return comboBox.SelectedItem?.ToString();
                    return string.Empty;
                }).ToList();

            string data = string.Join(", ", dataToInsert);
            File.AppendAllText(filePath, data + Environment.NewLine);

            MessageBox.Show("Data inserted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string GetFilePath(string type)
        {
            return Path.Combine(Directory.GetCurrentDirectory(), $"{type}.txt");
        }
    }
}
