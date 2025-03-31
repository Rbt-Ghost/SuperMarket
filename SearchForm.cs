using System;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class SearchForm : Form // Tema #6
    {
        private ComboBox cmbSearchType;
        private TextBox txtSearch;
        private Button btnSearch;
        private ListBox lstResults;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selection = cmbSearchType.SelectedItem?.ToString();
            string searchTerm = txtSearch.Text;
            lstResults.Items.Clear();

            if (string.IsNullOrEmpty(selection) || string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Please select a category and enter a search term.");
                return;
            }

            switch (selection)
            {
                case "Manager":
                    Program.manager.ForEach(m => { if (m.CautareManager(searchTerm)) lstResults.Items.Add(m.ToString()); });
                    break;
                case "Casier":
                    Program.casier.ForEach(c => { if (c.CautareCasier(searchTerm)) lstResults.Items.Add(c.ToString()); });
                    break;
                case "Client":
                    Program.client.ForEach(cl => { if (cl.CautareClient(searchTerm)) lstResults.Items.Add(cl.ToString()); });
                    break;
                case "Raion":
                    Program.raion.ForEach(r => { if (r.ToString().Contains(searchTerm)) lstResults.Items.Add(r.ToString()); });
                    break;
                case "Produs":
                    Program.produs.ForEach(p => { if (p.ToString().Contains(searchTerm)) lstResults.Items.Add(p.ToString()); });
                    break;
            }
        }

        private void InitializeComponent()
        {
            this.cmbSearchType = new ComboBox();
            this.txtSearch = new TextBox();
            this.btnSearch = new Button();
            this.lstResults = new ListBox();

            // cmbSearchType
            this.cmbSearchType.Items.AddRange(new object[] { "Manager", "Casier", "Client", "Raion", "Produs" });
            this.cmbSearchType.Location = new System.Drawing.Point(30, 30);
            this.cmbSearchType.Size = new System.Drawing.Size(200, 30);

            // txtSearch
            this.txtSearch.Location = new System.Drawing.Point(30, 70);
            this.txtSearch.Size = new System.Drawing.Size(200, 30);

            // btnSearch
            this.btnSearch.Location = new System.Drawing.Point(30, 110);
            this.btnSearch.Size = new System.Drawing.Size(200, 40);
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);

            // lstResults
            this.lstResults.Location = new System.Drawing.Point(30, 160);
            this.lstResults.Size = new System.Drawing.Size(400, 200);

            // SearchForm
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.cmbSearchType);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lstResults);
            this.Text = "Search Data";
        }
    }
}
