namespace IatDteBridge
{
    partial class Administracion
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.empresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datosEmisorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setPruebaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesaPaqueteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libroVentasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libroComprasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.libroGuiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empresaToolStripMenuItem,
            this.setPruebaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1139, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // empresaToolStripMenuItem
            // 
            this.empresaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosEmisorToolStripMenuItem});
            this.empresaToolStripMenuItem.Name = "empresaToolStripMenuItem";
            this.empresaToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.empresaToolStripMenuItem.Text = "Empresa";
            this.empresaToolStripMenuItem.Click += new System.EventHandler(this.empresaToolStripMenuItem_Click);
            // 
            // datosEmisorToolStripMenuItem
            // 
            this.datosEmisorToolStripMenuItem.Name = "datosEmisorToolStripMenuItem";
            this.datosEmisorToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.datosEmisorToolStripMenuItem.Text = "Datos Emisor";
            this.datosEmisorToolStripMenuItem.Click += new System.EventHandler(this.datosEmisorToolStripMenuItem_Click);
            // 
            // setPruebaToolStripMenuItem
            // 
            this.setPruebaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.procesaPaqueteToolStripMenuItem,
            this.libroVentasToolStripMenuItem,
            this.libroComprasToolStripMenuItem,
            this.libroGuiasToolStripMenuItem});
            this.setPruebaToolStripMenuItem.Name = "setPruebaToolStripMenuItem";
            this.setPruebaToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.setPruebaToolStripMenuItem.Text = "Set Prueba";
            this.setPruebaToolStripMenuItem.Visible = false;
            // 
            // procesaPaqueteToolStripMenuItem
            // 
            this.procesaPaqueteToolStripMenuItem.Name = "procesaPaqueteToolStripMenuItem";
            this.procesaPaqueteToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.procesaPaqueteToolStripMenuItem.Text = "Procesa Paquete xml";
            this.procesaPaqueteToolStripMenuItem.Click += new System.EventHandler(this.procesaPaqueteToolStripMenuItem_Click);
            // 
            // libroVentasToolStripMenuItem
            // 
            this.libroVentasToolStripMenuItem.Name = "libroVentasToolStripMenuItem";
            this.libroVentasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.libroVentasToolStripMenuItem.Text = "Libro Ventas";
            this.libroVentasToolStripMenuItem.Click += new System.EventHandler(this.libroVentasToolStripMenuItem_Click);
            // 
            // libroComprasToolStripMenuItem
            // 
            this.libroComprasToolStripMenuItem.Name = "libroComprasToolStripMenuItem";
            this.libroComprasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.libroComprasToolStripMenuItem.Text = "Libro Compras";
            this.libroComprasToolStripMenuItem.Click += new System.EventHandler(this.libroComprasToolStripMenuItem_Click);
            // 
            // libroGuiasToolStripMenuItem
            // 
            this.libroGuiasToolStripMenuItem.Name = "libroGuiasToolStripMenuItem";
            this.libroGuiasToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.libroGuiasToolStripMenuItem.Text = "Libro Guias";
            this.libroGuiasToolStripMenuItem.Click += new System.EventHandler(this.libroGuiasToolStripMenuItem_Click);
            // 
            // Administracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 417);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Administracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administracion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Administracion_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem empresaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datosEmisorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setPruebaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesaPaqueteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem libroVentasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem libroComprasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem libroGuiasToolStripMenuItem;
    }
}