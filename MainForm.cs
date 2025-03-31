using System;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class MainForm : Form // Tema #6
    {
        private Button btnLoadData;
        private Button btnInsertData;
        private Button btnSearchData;
        private Button btnDisplayData;

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            Program.LoadData();
        }

        private void btnInsertData_Click(object sender, EventArgs e)
        {
            InsertForm insertForm = new InsertForm();
            insertForm.Show();
        }

        private void btnSearchData_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void btnDisplayData_Click(object sender, EventArgs e)
        {
            DisplayForm displayForm = new DisplayForm();
            displayForm.Show();
        }

        private void InitializeComponent()
        {
            this.btnLoadData = new Button();
            this.btnInsertData = new Button();
            this.btnSearchData = new Button();
            this.btnDisplayData = new Button();

            // btnLoadData
            this.btnLoadData.Location = new System.Drawing.Point(30, 30);
            this.btnLoadData.Size = new System.Drawing.Size(200, 40);
            this.btnLoadData.Text = "Load Data";
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);

            // btnInsertData
            this.btnInsertData.Location = new System.Drawing.Point(30, 80);
            this.btnInsertData.Size = new System.Drawing.Size(200, 40);
            this.btnInsertData.Text = "Insert Data";
            this.btnInsertData.Click += new System.EventHandler(this.btnInsertData_Click);

            // btnSearchData
            this.btnSearchData.Location = new System.Drawing.Point(30, 130);
            this.btnSearchData.Size = new System.Drawing.Size(200, 40);
            this.btnSearchData.Text = "Search Data";
            this.btnSearchData.Click += new System.EventHandler(this.btnSearchData_Click);

            // btnDisplayData
            this.btnDisplayData.Location = new System.Drawing.Point(30, 180);
            this.btnDisplayData.Size = new System.Drawing.Size(200, 40);
            this.btnDisplayData.Text = "Display Data";
            this.btnDisplayData.Click += new System.EventHandler(this.btnDisplayData_Click);

            // MainForm
            this.ClientSize = new System.Drawing.Size(300, 250);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.btnInsertData);
            this.Controls.Add(this.btnSearchData);
            this.Controls.Add(this.btnDisplayData);
            this.Text = "SuperMarket Application";
        }
    }
}
