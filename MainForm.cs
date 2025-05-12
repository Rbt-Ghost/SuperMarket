using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class MainForm : Form // Tema #6
    {
        private Button btnLoadData;
        private Button btnInsertData;
        private Button btnSearchData;
        private Button btnDisplayData;
        private Label lblTitle;

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
            this.lblTitle = new Label();

            // Common button style
            Font buttonFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            Color buttonColor = Color.FromArgb(52, 152, 219); 
            Size buttonSize = new Size(240, 45);

            // Title Label
            this.lblTitle.Text = "SuperMarket Menu";
            this.lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Height = 60;
            this.lblTitle.ForeColor = Color.FromArgb(44, 62, 80);

            // btnLoadData
            this.btnLoadData.Text = "🔄 Load Data";
            this.btnLoadData.Size = buttonSize;
            this.btnLoadData.Font = buttonFont;
            this.btnLoadData.BackColor = buttonColor;
            this.btnLoadData.ForeColor = Color.White;
            this.btnLoadData.FlatStyle = FlatStyle.Flat;
            this.btnLoadData.Location = new Point(30, 80);
            this.btnLoadData.Click += new EventHandler(this.btnLoadData_Click);

            // btnInsertData
            this.btnInsertData.Text = "➕ Insert Data";
            this.btnInsertData.Size = buttonSize;
            this.btnInsertData.Font = buttonFont;
            this.btnInsertData.BackColor = buttonColor;
            this.btnInsertData.ForeColor = Color.White;
            this.btnInsertData.FlatStyle = FlatStyle.Flat;
            this.btnInsertData.Location = new Point(30, 135);
            this.btnInsertData.Click += new EventHandler(this.btnInsertData_Click);

            // btnSearchData
            this.btnSearchData.Text = "🔍 Search Data";
            this.btnSearchData.Size = buttonSize;
            this.btnSearchData.Font = buttonFont;
            this.btnSearchData.BackColor = buttonColor;
            this.btnSearchData.ForeColor = Color.White;
            this.btnSearchData.FlatStyle = FlatStyle.Flat;
            this.btnSearchData.Location = new Point(30, 190);
            this.btnSearchData.Click += new EventHandler(this.btnSearchData_Click);

            // btnDisplayData
            this.btnDisplayData.Text = "📋 Display Data";
            this.btnDisplayData.Size = buttonSize;
            this.btnDisplayData.Font = buttonFont;
            this.btnDisplayData.BackColor = buttonColor;
            this.btnDisplayData.ForeColor = Color.White;
            this.btnDisplayData.FlatStyle = FlatStyle.Flat;
            this.btnDisplayData.Location = new Point(30, 245);
            this.btnDisplayData.Click += new EventHandler(this.btnDisplayData_Click);

            // MainForm
            this.Text = "SuperMarket Application";
            this.BackColor = Color.White;
            this.ClientSize = new Size(300, 330);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Add controls
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnLoadData);
            this.Controls.Add(this.btnInsertData);
            this.Controls.Add(this.btnSearchData);
            this.Controls.Add(this.btnDisplayData);
        }
    }
}
