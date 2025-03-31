using System;
using System.Windows.Forms;

namespace SuperMarket
{
    public partial class DisplayForm : Form // Tema #6
    {
        private ListBox lstDisplayData;  // ListBox to display the data

        public DisplayForm()
        {
            InitializeComponent();
            DisplayData();  // Call to display data when the form is initialized
        }

        // Method to display the data in the ListBox
        private void DisplayData()
        {
            lstDisplayData.Items.Clear();  // Clear previous data

            // Display Manager data
            lstDisplayData.Items.Add("--- Manageri ---");
            Program.manager.ForEach(m => lstDisplayData.Items.Add(m.ToString()));

            // Display Casier data
            lstDisplayData.Items.Add("\n\n--- Casieri ---");
            Program.casier.ForEach(c => lstDisplayData.Items.Add(c.ToString()));

            // Display Client data
            lstDisplayData.Items.Add("\n\n--- Clienti ---");
            Program.client.ForEach(cl => lstDisplayData.Items.Add(cl.ToString()));

            // Display Raion data
            lstDisplayData.Items.Add("\n\n--- Raioane ---");
            Program.raion.ForEach(r => lstDisplayData.Items.Add(r.ToString()));

            // Display Produs data
            lstDisplayData.Items.Add("\n\n--- Produse ---");
            Program.produs.ForEach(p => lstDisplayData.Items.Add(p.ToString()));
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
