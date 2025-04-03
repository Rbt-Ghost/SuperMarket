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

            // ComboBox for selection
            this.cmbInsertType.Items.AddRange(new object[] { "Manager", "Casier", "Client", "Raion", "Produs" });
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

            // Form Properties
            this.ClientSize = new System.Drawing.Size(500, 450);
            this.Controls.Add(this.cmbInsertType);
            this.Controls.Add(this.pnlInputs);
            this.Controls.Add(this.btnInsert);
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

            inputFields["Client"] = new List<Control>
            {
                CreateLabel("Name"), CreateTextBox("txtName"),
                CreateLabel("Age"), CreateTextBox("txtAge"),
                CreateLabel("ID"), CreateTextBox("txtID"),
                CreateLabel("ListaCumparaturi"), CreateTextBox("txtListaCumparaturi"),
                CreateLabel("PretTotal"), CreateTextBox("txtPretTotal"),
                CreateLabel("PuncteFidelitate"), CreateTextBox("txtPuncteFidelitate")
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
                }
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string selectedType = cmbInsertType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedType))
            {
                MessageBox.Show("Please select a category first!");
                return;
            }
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
                    int.Parse(GetTextBoxValue("txtNrcasa")),
                    double.Parse(GetTextBoxValue("txtSalary"))
                );
                Program.casier.Add(newCasier);
                File.AppendAllText(Program.fCasier, newCasier.ToString() + Environment.NewLine);
            }
            else if (selectedType == "Client")
            {
                Client newClient = new Client(
                    GetTextBoxValue("txtName"),
                    int.Parse(GetTextBoxValue("txtAge")),
                    int.Parse(GetTextBoxValue("txtID")),
                    GetTextBoxValue("txtListaCumparaturi"),
                    double.Parse(GetTextBoxValue("txtPretTotal")),
                    int.Parse(GetTextBoxValue("txtPuncteFidelitate"))
                );
                Program.client.Add(newClient);
                File.AppendAllText(Program.fClient, newClient.ToString() + Environment.NewLine);
            }
            else if (selectedType == "Raion")
            {
                RaionType selectedRaionType = (RaionType)Enum.Parse(typeof(RaionType), GetComboBoxValue("cmbRaion"));
                int nrRaion = (int)selectedRaionType; // Auto-generate number based on enum

                Raion newRaion = new Raion(nrRaion, selectedRaionType);

                Program.raion.Add(newRaion);
                File.AppendAllText(Program.fRaion, newRaion.ToString() + Environment.NewLine);
            }
            else if (selectedType == "Produs")
            {
                int nrRaion = Program.raion.Count + 1; // Auto-generate Raion Number

                Produs newProdus = new Produs(
                    nrRaion,
                    (RaionType)Enum.Parse(typeof(RaionType), GetComboBoxValue("cmbRaion")),
                    GetTextBoxValue("txtName"),
                    double.Parse(GetTextBoxValue("txtPrice")),
                    int.Parse(GetTextBoxValue("txtQuantity"))
                );
                Program.produs.Add(newProdus);
                File.AppendAllText(Program.fProdus, newProdus.ToString() + Environment.NewLine);
            }

            MessageBox.Show("Data Inserted Successfully!");
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
