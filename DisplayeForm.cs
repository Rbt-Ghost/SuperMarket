using System;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class DisplayForm : Form // Tema #5
    {
        private ListBox lstDisplayData; 

        public DisplayForm()
        {
            InitializeComponent();
            DisplayData(); 
        }

        // Method to display the data in the ListBox
        private void DisplayData()
        {
            lstDisplayData.Items.Clear();  // Clear previous data

            // Display Manager data
            lstDisplayData.Items.Add("--- Manageri ---");
            Program.manager.ForEach(m => lstDisplayData.Items.Add(m.DisplayManagerInfo()));

            // Display Casier data
            lstDisplayData.Items.Add("\n\n--- Casieri ---");
            Program.casier.ForEach(c => lstDisplayData.Items.Add(c.DisplayCasierInfo()));

            // Display Raion data
            lstDisplayData.Items.Add("\n\n--- Raioane ---");
            Program.raion.ForEach(r => lstDisplayData.Items.Add(r.DisplayRaionInfo()));

            // Display Produs data
            lstDisplayData.Items.Add("\n\n--- Produse ---");
            Program.produs.ForEach(p => lstDisplayData.Items.Add(p.DisplayProdusInfo()));
        }


        // UI components initialization
        private void InitializeComponent()
        {
            this.lstDisplayData = new System.Windows.Forms.ListBox();

            // 
            // lstDisplayData
            // 
            this.lstDisplayData.Location = new System.Drawing.Point(30, 30);
            this.lstDisplayData.Name = "lstDisplayData";
            this.lstDisplayData.Size = new System.Drawing.Size(500, 400);
            this.lstDisplayData.TabIndex = 0;

            // 
            // DisplayForm
            // 
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.lstDisplayData);
            this.Name = "DisplayForm";
            this.Text = "Display Data";
        }
    }
}
