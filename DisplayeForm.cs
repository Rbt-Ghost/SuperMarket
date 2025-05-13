using System;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class DisplayForm : Form // Tema #5
    {
        private ListBox lstDisplayData;
        private CheckBox chkManager;
        private CheckBox chkCasier;
        private CheckBox chkRaion;
        private CheckBox chkProdus;
        private Button btnRefresh;

        public DisplayForm()
        {
            InitializeComponent();
            DisplayData();
        }

        private void InitializeComponent()
        {
            this.Icon = new System.Drawing.Icon("Assets/DisplayData.ico");

            this.lstDisplayData = new ListBox();
            this.chkManager = new CheckBox();
            this.chkCasier = new CheckBox();
            this.chkRaion = new CheckBox();
            this.chkProdus = new CheckBox();
            this.btnRefresh = new Button();

            // 
            // lstDisplayData
            // 
            this.lstDisplayData.Location = new System.Drawing.Point(30, 130);
            this.lstDisplayData.Size = new System.Drawing.Size(520, 320);
            this.lstDisplayData.Font = new System.Drawing.Font("Arial", 10);
            this.lstDisplayData.BorderStyle = BorderStyle.FixedSingle;
            this.lstDisplayData.BackColor = System.Drawing.Color.LavenderBlush;

            // 
            // chkManager
            // 
            this.chkManager.Text = "Manager";
            this.chkManager.Location = new System.Drawing.Point(30, 20);
            this.chkManager.AutoSize = true;
            this.chkManager.Checked = true;
            this.chkManager.Font = new System.Drawing.Font("Arial", 10);

            // 
            // chkCasier
            // 
            this.chkCasier.Text = "Casier";
            this.chkCasier.Location = new System.Drawing.Point(130, 20);
            this.chkCasier.AutoSize = true;
            this.chkCasier.Checked = true;
            this.chkCasier.Font = new System.Drawing.Font("Arial", 10);

            // 
            // chkRaion
            // 
            this.chkRaion.Text = "Raion";
            this.chkRaion.Location = new System.Drawing.Point(230, 20);
            this.chkRaion.AutoSize = true;
            this.chkRaion.Checked = true;
            this.chkRaion.Font = new System.Drawing.Font("Arial", 10);

            // 
            // chkProdus
            // 
            this.chkProdus.Text = "Produs";
            this.chkProdus.Location = new System.Drawing.Point(330, 20);
            this.chkProdus.AutoSize = true;
            this.chkProdus.Checked = true;
            this.chkProdus.Font = new System.Drawing.Font("Arial", 10);

            // 
            // btnRefresh
            // 
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(430, 20);
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            this.btnRefresh.BackColor = System.Drawing.Color.SkyBlue;
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // 
            // DisplayForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.lstDisplayData);
            this.Controls.Add(this.chkManager);
            this.Controls.Add(this.chkCasier);
            this.Controls.Add(this.chkRaion);
            this.Controls.Add(this.chkProdus);
            this.Controls.Add(this.btnRefresh);
            this.Text = "Display Data";
            this.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Program.LoadData(); // Load data from files
            DisplayData(); // Then display it in the list
        }

        // Displays selected data categories
        private void DisplayData()
        {
            lstDisplayData.Items.Clear();

            if (chkManager.Checked)
            {
                lstDisplayData.Items.Add("--- Manageri ---");
                Program.manager.ForEach(m => lstDisplayData.Items.Add(m.DisplayManagerInfo()));
                lstDisplayData.Items.Add("");
            }

            if (chkCasier.Checked)
            {
                lstDisplayData.Items.Add("--- Casieri ---");
                Program.casier.ForEach(c => lstDisplayData.Items.Add(c.DisplayCasierInfo()));
                lstDisplayData.Items.Add(""); 
            }

            if (chkRaion.Checked)
            {
                lstDisplayData.Items.Add("--- Raioane ---");
                Program.raion.ForEach(r => lstDisplayData.Items.Add(r.DisplayRaionInfo()));
                lstDisplayData.Items.Add("");
            }

            if (chkProdus.Checked)
            {
                lstDisplayData.Items.Add("--- Produse ---");
                Program.produs.ForEach(p => lstDisplayData.Items.Add(p.DisplayProdusInfo()));
            }
        }
    }
}
