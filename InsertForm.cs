using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class InsertForm : Form // Tema #6
    {
        private ComboBox cmbInsertType;
        private Panel pnlInputs;
        private Button btnInsert;
        private Label lblError;
        private Dictionary<string, List<Control>> inputFields;

        public InsertForm()
        {
            InitializeComponent();
            CreateDynamicInputs();
        }

        private void InitializeComponent()
        {
            this.cmbInsertType = new ComboBox();
            this.pnlInputs = new Panel();
            this.btnInsert = new Button();
            this.lblError = new Label { ForeColor = System.Drawing.Color.Red, AutoSize = true };

            // ComboBox for selection
            this.cmbInsertType.Items.AddRange(new object[] { "Manager", "Casier", "Raion", "Produs" });
            this.cmbInsertType.SelectedIndexChanged += new EventHandler(cmbInsertType_SelectedIndexChanged);
            this.cmbInsertType.Location = new System.Drawing.Point(30, 20);
            this.cmbInsertType.Size = new System.Drawing.Size(200, 30);

            // Input Panel
            this.pnlInputs.Location = new System.Drawing.Point(30, 60);
            this.pnlInputs.Size = new System.Drawing.Size(300, 300);

            // Insert Button
            this.btnInsert.Text = "Insert Data";
            this.btnInsert.Location = new System.Drawing.Point(30, 400);
            this.btnInsert.Size = new System.Drawing.Size(200, 40);
            this.btnInsert.Click += new EventHandler(btnInsert_Click);

            // Error Label
            this.lblError.Location = new System.Drawing.Point(30, 450);

            // Form Properties
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.cmbInsertType);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.lblError);
            this.Text = "Insert Data";
        }

        private void CreateDynamicInputs()
        {
            inputFields = new Dictionary<string, List<Control>>();

            inputFields["Manager"] = new List<Control>
            {
                CreateLabel("Name"), CreateTextBox("txtName"),
                CreateLabel("Age"), CreateTextBox("txtAge"),
                CreateLabel("ID"), CreateTextBox("txtID"),
                CreateLabel("Departament"), CreateComboBox("cmbDepartament", Enum.GetNames(typeof(DepartamentType))),
                CreateLabel("Salary"), CreateTextBox("txtSalary")
            };

            inputFields["Casier"] = new List<Control>
            {
                CreateLabel("Name"), CreateTextBox("txtName"),
                CreateLabel("Age"), CreateTextBox("txtAge"),
                CreateLabel("ID"), CreateTextBox("txtID"),
                CreateLabel("NrCasa"), CreateTextBox("txtNrCasa"),
                CreateLabel("Salary"), CreateTextBox("txtSalary")
            };

            inputFields["Raion"] = new List<Control>
            {
                CreateLabel("Raion Type"), CreateComboBox("cmbRaion", Enum.GetNames(typeof(RaionType)))
            };

            inputFields["Produs"] = new List<Control>
            {
                CreateLabel("Raion Type"), CreateComboBox("cmbRaion", Enum.GetNames(typeof(RaionType))),
                CreateLabel("Name"), CreateTextBox("txtName"),
                CreateLabel("Price"), CreateTextBox("txtPrice"),
                CreateLabel("Quantity"), CreateTextBox("txtQuantity")
            };
        }

        private Label CreateLabel(string text)
        {
            return new Label { Text = text, AutoSize = true };
        }

        private TextBox CreateTextBox(string name)
        {
            return new TextBox { Name = name, Width = 200 };
        }

        private ComboBox CreateComboBox(string name, string[] items)
        {
            ComboBox comboBox = new ComboBox { Name = name, Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            comboBox.Items.AddRange(items);
            comboBox.SelectedIndex = -1;
            return comboBox;
        }

        private CheckBox CreateCheckBox(string name)
        {
            return new CheckBox { Name = name, Width = 20, Checked = false, Enabled = false }; // Disable the checkbox
        }

        private void cmbInsertType_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlInputs.Controls.Clear();
            string selectedType = cmbInsertType.SelectedItem?.ToString();
            if (selectedType != null && inputFields.ContainsKey(selectedType))
            {
                int y = 10;
                foreach (var control in inputFields[selectedType])
                {
                    control.Location = new System.Drawing.Point(10, y);
                    pnlInputs.Controls.Add(control);
                    y += 30;

                    if (control is TextBox textBox)
                    {
                        // Place the checkbox a little higher
                        var checkBox = CreateCheckBox(textBox.Name + "Check");
                        checkBox.Location = new System.Drawing.Point(220, y - 30); // Adjust the position to make it higher
                        pnlInputs.Controls.Add(checkBox);
                    }

                    if (control is ComboBox comboBox)
                    {
                        // Create checkbox for ComboBox (Enum type)
                        var checkBox = CreateCheckBox(comboBox.Name + "Check");
                        checkBox.Location = new System.Drawing.Point(220, y - 30); // Adjust position for ComboBox checkboxes
                        pnlInputs.Controls.Add(checkBox);
                    }
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            bool allValid = true;

            string selectedType = cmbInsertType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedType))
            {
                lblError.Text = "Please select a category first!";
                return;
            }

            foreach (var control in pnlInputs.Controls)
            {
                if (control is TextBox textBox)
                {
                    var checkBox = pnlInputs.Controls[textBox.Name + "Check"] as CheckBox;
                    if (checkBox != null)
                    {
                        bool isValid = ValidateInput(textBox);
                        checkBox.Checked = isValid;

                        if (!isValid)
                        {
                            allValid = false;
                        }
                    }
                }

                if (control is ComboBox comboBox)
                {
                    var checkBox = pnlInputs.Controls[comboBox.Name + "Check"] as CheckBox;
                    if (checkBox != null)
                    {
                        bool isValid = ValidateComboBox(comboBox);
                        checkBox.Checked = isValid;

                        if (!isValid)
                        {
                            allValid = false;
                        }
                    }
                }
            }

            if (!allValid)
            {
                lblError.Text = "Error: Incorrect format!";
                return;
            }

            // If everything is valid, insert data
            InsertData(selectedType);
            MessageBox.Show("Data Inserted Successfully!");
        }

        private bool ValidateInput(TextBox textBox)
        {
            if (textBox.Name == "txtAge" || textBox.Name == "txtID" || textBox.Name == "txtSalary" || textBox.Name == "txtNrcasa" || textBox.Name == "txtPrice" || textBox.Name == "txtQuantity")
            {
                return int.TryParse(textBox.Text, out _) || double.TryParse(textBox.Text, out _);
            }
            return !string.IsNullOrEmpty(textBox.Text);
        }

        private bool ValidateComboBox(ComboBox comboBox)
        {
            return comboBox.SelectedIndex != -1; // Ensure a valid selection is made
        }

        private void InsertData(string selectedType)
        {
            if (selectedType == "Manager")
            {
                Manager newManager = new Manager(
                    GetTextBoxValue("txtName"),
                    int.Parse(GetTextBoxValue("txtAge")),
                    int.Parse(GetTextBoxValue("txtID")),
                    (DepartamentType)Enum.Parse(typeof(DepartamentType), GetComboBoxValue("cmbDepartament")),
                    double.Parse(GetTextBoxValue("txtSalary"))
                );
                Program.manager.Add(newManager);
                File.AppendAllText(Program.fManager, newManager.ToString() + Environment.NewLine);
            }
            else if (selectedType == "Casier")
            {
                Casier newCasier = new Casier(
                    GetTextBoxValue("txtName"),
                    int.Parse(GetTextBoxValue("txtAge")),
                    int.Parse(GetTextBoxValue("txtID")),
                    int.Parse(GetTextBoxValue("txtNrCasa")),
                    double.Parse(GetTextBoxValue("txtSalary"))
                );
                Program.casier.Add(newCasier);
                File.AppendAllText(Program.fCasier, newCasier.ToString() + Environment.NewLine);
            }
            else if (selectedType == "Raion")
            {
                RaionType rt = (RaionType)Enum.Parse(typeof(RaionType), GetComboBoxValue("cmbRaion"));
                Raion r = new Raion(rt);
                MessageBox.Show($"Raion: {r.ToString()}");
                Program.raion.Add(r);
                File.AppendAllText(Program.fRaion, r.ToString() + Environment.NewLine);
            }
            else if (selectedType == "Produs")
            {
                RaionType rt = (RaionType)Enum.Parse(typeof(RaionType), GetComboBoxValue("cmbRaion"));
                Produs p = new Produs(
                    rt,
                    GetTextBoxValue("txtName"),
                    double.Parse(GetTextBoxValue("txtPrice")),
                    int.Parse(GetTextBoxValue("txtQuantity"))
                );
                MessageBox.Show($"Produs: {p.ToString()}");
                Program.produs.Add(p);
                File.AppendAllText(Program.fProdus, p.ToString() + Environment.NewLine);
            }
        }

        private string GetTextBoxValue(string name)
        {
            return pnlInputs.Controls[name] is TextBox textBox ? textBox.Text : "";
        }

        private string GetComboBoxValue(string name)
        {
            return pnlInputs.Controls[name] is ComboBox comboBox ? comboBox.SelectedItem?.ToString() : "";
        }
    }
}
