namespace wellness.WinUI
{
    partial class mdiMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pregledKorisnikaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zaposleniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trenutnoPrisutniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vrsteUslugeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kategorijeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tretmaniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.članarinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjavaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisniciToolStripMenuItem,
            this.zaposleniciToolStripMenuItem,
            this.trenutnoPrisutniToolStripMenuItem,
            this.vrsteUslugeToolStripMenuItem,
            this.kategorijeToolStripMenuItem,
            this.tretmaniToolStripMenuItem,
            this.članarinaToolStripMenuItem,
            this.odjavaToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(822, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pregledKorisnikaToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.korisniciToolStripMenuItem.Text = "Korisnici";
            // 
            // pregledKorisnikaToolStripMenuItem
            // 
            this.pregledKorisnikaToolStripMenuItem.Name = "pregledKorisnikaToolStripMenuItem";
            this.pregledKorisnikaToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.pregledKorisnikaToolStripMenuItem.Text = "Pregled korisnika";
            // 
            // zaposleniciToolStripMenuItem
            // 
            this.zaposleniciToolStripMenuItem.Name = "zaposleniciToolStripMenuItem";
            this.zaposleniciToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.zaposleniciToolStripMenuItem.Text = "Zaposlenici";
            // 
            // trenutnoPrisutniToolStripMenuItem
            // 
            this.trenutnoPrisutniToolStripMenuItem.Name = "trenutnoPrisutniToolStripMenuItem";
            this.trenutnoPrisutniToolStripMenuItem.Size = new System.Drawing.Size(109, 20);
            this.trenutnoPrisutniToolStripMenuItem.Text = "Trenutno prisutni";
            // 
            // vrsteUslugeToolStripMenuItem
            // 
            this.vrsteUslugeToolStripMenuItem.Name = "vrsteUslugeToolStripMenuItem";
            this.vrsteUslugeToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.vrsteUslugeToolStripMenuItem.Text = "Vrste usluge";
            // 
            // kategorijeToolStripMenuItem
            // 
            this.kategorijeToolStripMenuItem.Name = "kategorijeToolStripMenuItem";
            this.kategorijeToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.kategorijeToolStripMenuItem.Text = "Kategorije";
            // 
            // tretmaniToolStripMenuItem
            // 
            this.tretmaniToolStripMenuItem.Name = "tretmaniToolStripMenuItem";
            this.tretmaniToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.tretmaniToolStripMenuItem.Text = "Tretmani";
            // 
            // članarinaToolStripMenuItem
            // 
            this.članarinaToolStripMenuItem.Name = "članarinaToolStripMenuItem";
            this.članarinaToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.članarinaToolStripMenuItem.Text = "Članarina";
            // 
            // odjavaToolStripMenuItem
            // 
            this.odjavaToolStripMenuItem.Name = "odjavaToolStripMenuItem";
            this.odjavaToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.odjavaToolStripMenuItem.Text = "Odjava";
            // 
            // mdiMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 523);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "mdiMainMenu";
            this.Text = "mdiMainMenu";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private ToolStripMenuItem korisniciToolStripMenuItem;
        private ToolStripMenuItem pregledKorisnikaToolStripMenuItem;
        private ToolStripMenuItem zaposleniciToolStripMenuItem;
        private ToolStripMenuItem trenutnoPrisutniToolStripMenuItem;
        private ToolStripMenuItem vrsteUslugeToolStripMenuItem;
        private ToolStripMenuItem kategorijeToolStripMenuItem;
        private ToolStripMenuItem tretmaniToolStripMenuItem;
        private ToolStripMenuItem članarinaToolStripMenuItem;
        private ToolStripMenuItem odjavaToolStripMenuItem;
    }
}



