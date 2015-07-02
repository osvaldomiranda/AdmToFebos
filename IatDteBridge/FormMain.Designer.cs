namespace IatDteBridge
{
    partial class FormMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.archivosMaestrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.datosEmpresaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button12 = new System.Windows.Forms.Button();
            this.button14 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button16 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            this.button18 = new System.Windows.Forms.Button();
            this.button19 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(710, 167);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(22, 167);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Envio a Febos";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosMaestrosToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(172, 26);
            // 
            // archivosMaestrosToolStripMenuItem
            // 
            this.archivosMaestrosToolStripMenuItem.Name = "archivosMaestrosToolStripMenuItem";
            this.archivosMaestrosToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.archivosMaestrosToolStripMenuItem.Text = "Archivos Maestros";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.datosEmpresaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(940, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // datosEmpresaToolStripMenuItem
            // 
            this.datosEmpresaToolStripMenuItem.Name = "datosEmpresaToolStripMenuItem";
            this.datosEmpresaToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.datosEmpresaToolStripMenuItem.Text = "Administración";
            this.datosEmpresaToolStripMenuItem.Click += new System.EventHandler(this.datosEmpresaToolStripMenuItem_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(22, 107);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(107, 23);
            this.button3.TabIndex = 16;
            this.button3.Text = "IatProcess";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(716, 197);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(168, 23);
            this.button9.TabIndex = 20;
            this.button9.Text = "PDF Denuevo";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Visible = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(710, 119);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(174, 20);
            this.textBox1.TabIndex = 21;
            this.textBox1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(713, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Json";
            this.label1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(714, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Xml";
            this.label3.Visible = false;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(888, 118);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(35, 23);
            this.button10.TabIndex = 24;
            this.button10.Text = "json";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(888, 166);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(37, 23);
            this.button11.TabIndex = 25;
            this.button11.Text = "xml";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(716, 227);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(168, 23);
            this.button12.TabIndex = 26;
            this.button12.Text = "PDF Masivo";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Visible = false;
            this.button12.Click += new System.EventHandler(this.button12_Click_1);
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(803, 358);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(112, 22);
            this.button14.TabIndex = 28;
            this.button14.Text = "Salir";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(21, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "IatProcess Detenido";
            this.label4.Click += new System.EventHandler(this.label4_Click_1);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.Chartreuse;
            this.progressBar1.Location = new System.Drawing.Point(22, 75);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(172, 12);
            this.progressBar1.TabIndex = 31;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(716, 315);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(134, 23);
            this.button16.TabIndex = 34;
            this.button16.Text = "Carga Pdfs Al Core";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(778, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "VERSIÓN: 20150620-1200";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(482, 164);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(168, 23);
            this.button17.TabIndex = 36;
            this.button17.Text = "Ver Log";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Visible = false;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button18
            // 
            this.button18.Location = new System.Drawing.Point(482, 197);
            this.button18.Name = "button18";
            this.button18.Size = new System.Drawing.Size(168, 23);
            this.button18.TabIndex = 37;
            this.button18.Text = "Ver tabla reenvios";
            this.button18.UseVisualStyleBackColor = true;
            this.button18.Visible = false;
            this.button18.Click += new System.EventHandler(this.button18_Click);
            // 
            // button19
            // 
            this.button19.Location = new System.Drawing.Point(482, 275);
            this.button19.Name = "button19";
            this.button19.Size = new System.Drawing.Size(168, 23);
            this.button19.TabIndex = 38;
            this.button19.Text = "Proceso Reenvio";
            this.button19.UseVisualStyleBackColor = true;
            this.button19.Visible = false;
            this.button19.Click += new System.EventHandler(this.button19_Click);
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(22, 136);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(107, 23);
            this.button13.TabIndex = 39;
            this.button13.Text = "Stop IatProcess";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click_1);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 402);
            this.ControlBox = false;
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button19);
            this.Controls.Add(this.button18);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button16);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdmToFebos";
            this.Load += new System.EventHandler(this.FormMain_Load_1);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosMaestrosToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem datosEmpresaToolStripMenuItem;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button14;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button16;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button18;
        private System.Windows.Forms.Button button19;
        private System.Windows.Forms.Button button13;

    }
}

