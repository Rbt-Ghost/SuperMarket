using System;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class SearchForm : Form // Tema #7
    {
        private GroupBox grpSearchType;
        private RadioButton rdoManager;
        private RadioButton rdoCasier;
        private RadioButton rdoRaion;
        private RadioButton rdoProdus;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnDelete;
        private ListBox lstResults;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.grpSearchType = new GroupBox();
            this.rdoManager = new RadioButton();
            this.rdoCasier = new RadioButton();
            this.rdoRaion = new RadioButton();
            this.rdoProdus = new RadioButton();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.btnDelete = new Button();
            this.lstResults = new ListBox();

            // GroupBox
            this.grpSearchType.Text = "Select Type";
            this.grpSearchType.Location = new System.Drawing.Point(30, 20);
            this.grpSearchType.Size = new System.Drawing.Size(440, 60);
            this.grpSearchType.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);

            // RadioButtons
            this.rdoManager.Text = "Manager";
            this.rdoManager.Location = new System.Drawing.Point(10, 25);
            this.rdoManager.AutoSize = true;
            this.rdoManager.Font = new System.Drawing.Font("Arial", 9);

            this.rdoCasier.Text = "Casier";
            this.rdoCasier.Location = new System.Drawing.Point(110, 25);
            this.rdoCasier.AutoSize = true;
            this.rdoCasier.Font = new System.Drawing.Font("Arial", 9);

            this.rdoRaion.Text = "Raion";
            this.rdoRaion.Location = new System.Drawing.Point(210, 25);
            this.rdoRaion.AutoSize = true;
            this.rdoRaion.Font = new System.Drawing.Font("Arial", 9);

            this.rdoProdus.Text = "Produs";
            this.rdoProdus.Location = new System.Drawing.Point(310, 25);
            this.rdoProdus.AutoSize = true;
            this.rdoProdus.Font = new System.Drawing.Font("Arial", 9);

            this.grpSearchType.Controls.AddRange(new Control[]
            {
                rdoManager, rdoCasier, rdoRaion, rdoProdus
            });

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(30, 100);
            this.txtSearch.Size = new System.Drawing.Size(200, 30);
            this.txtSearch.Font = new System.Drawing.Font("Arial", 10);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(250, 95);
            this.btnSearch.Size = new System.Drawing.Size(100, 40);
            this.btnSearch.Text = "Search";
            this.btnSearch.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.btnSearch.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // btnDelete
            this.btnDelete.Location = new System.Drawing.Point(360, 95);
            this.btnDelete.Size = new System.Drawing.Size(100, 40);
            this.btnDelete.Text = "Delete";
            this.btnDelete.Font = new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold);
            this.btnDelete.BackColor = System.Drawing.Color.LightCoral;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // lstResults
            this.lstResults.Location = new System.Drawing.Point(30, 150);
            this.lstResults.Size = new System.Drawing.Size(440, 200);
            this.lstResults.Font = new System.Drawing.Font("Arial", 10);
            this.lstResults.BorderStyle = BorderStyle.FixedSingle;

            // SearchForm
            this.ClientSize = new System.Drawing.Size(500, 380);
            this.Controls.Add(this.grpSearchType);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lstResults);
            this.Text = "Search Data";
            this.BackColor = System.Drawing.Color.White;
        }

        private string GetSelectedType()
        {
            if (rdoManager.Checked) return "Manager";
            if (rdoCasier.Checked) return "Casier";
            if (rdoRaion.Checked) return "Raion";
            if (rdoProdus.Checked) return "Produs";
            return null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selection = GetSelectedType();
            string searchTerm = txtSearch.Text;
            lstResults.Items.Clear();

            if (string.IsNullOrEmpty(selection) || string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please select a category and enter a search term.");
                return;
            }

            bool resultsFound = false;

            switch (selection)
            {
                case "Manager":
                    Program.manager.ForEach(m =>
                    {
                        if (m.CautareManager(searchTerm))
                        {
                            lstResults.Items.Add(m.DisplayManagerInfo());
                            resultsFound = true;
                        }
                    });
                    break;

                case "Casier":
                    Program.casier.ForEach(c =>
                    {
                        if (c.CautareCasier(searchTerm))
                        {
                            lstResults.Items.Add(c.DisplayCasierInfo());
                            resultsFound = true;
                        }
                    });
                    break;

                case "Raion":
                    Program.raion.ForEach(r =>
                    {
                        if (r.CautareRaion(searchTerm))
                        {
                            lstResults.Items.Add(r.DisplayRaionInfo());
                            resultsFound = true;
                        }
                    });
                    break;

                case "Produs":
                    Program.produs.ForEach(p =>
                    {
                        if (p.CautareProdus(searchTerm))
                        {
                            lstResults.Items.Add(p.DisplayProdusInfo());
                            resultsFound = true;
                        }
                    });
                    break;
            }

            if (!resultsFound)
            {
                lstResults.Items.Add("Not Found");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
{
    if (lstResults.SelectedItem == null)
    {
        MessageBox.Show("Please select an item to delete.");
        return;
    }

    string selection = GetSelectedType();
    string selectedItem = lstResults.SelectedItem.ToString();

    DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
    if (result != DialogResult.Yes)
        return;

    bool itemDeleted = false;

    switch (selection)
    {
        case "Manager":
            for (int i = Program.manager.Count - 1; i >= 0; i--)
            {
                if (Program.manager[i].DisplayManagerInfo() == selectedItem)
                {
                    Program.manager.RemoveAt(i);
                    itemDeleted = true;
                    break;
                }
            }

            if (itemDeleted)
                System.IO.File.WriteAllLines("Manager.txt", Program.manager.ConvertAll(m => m.SaveToFile())); // Update file

            break;

        case "Casier":
            for (int i = Program.casier.Count - 1; i >= 0; i--)
            {
                if (Program.casier[i].DisplayCasierInfo() == selectedItem)
                {
                    Program.casier.RemoveAt(i);
                    itemDeleted = true;
                    break;
                }
            }

            if (itemDeleted)
                System.IO.File.WriteAllLines("Casier.txt", Program.casier.ConvertAll(c => c.SaveToFile()));

            break;

        case "Raion":
            for (int i = Program.raion.Count - 1; i >= 0; i--)
            {
                if (Program.raion[i].DisplayRaionInfo() == selectedItem)
                {
                    Program.raion.RemoveAt(i);
                    itemDeleted = true;
                    break;
                }
            }

            if (itemDeleted)
                System.IO.File.WriteAllLines("Raion.txt", Program.raion.ConvertAll(r => r.SaveToFile()));

            break;

        case "Produs":
            for (int i = Program.produs.Count - 1; i >= 0; i--)
            {
                if (Program.produs[i].DisplayProdusInfo() == selectedItem)
                {
                    Program.produs.RemoveAt(i);
                    itemDeleted = true;
                    break;
                }
            }

            if (itemDeleted)
                System.IO.File.WriteAllLines("Produs.txt", Program.produs.ConvertAll(p => p.SaveToFile()));

            break;
    }

    if (itemDeleted)
    {
        MessageBox.Show("Item deleted successfully.");
        lstResults.Items.Remove(selectedItem);
    }
    else
    {
        MessageBox.Show("Item could not be deleted.");
    }
}

    }
}
