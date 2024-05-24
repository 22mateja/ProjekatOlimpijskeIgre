namespace OlimpijskeIgre
{
    partial class Ekipe1
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
            this.Cmb_Sport = new System.Windows.Forms.ComboBox();
            this.Cmb_Drzava = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Grid_Ekipa = new System.Windows.Forms.DataGridView();
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Ekipa)).BeginInit();
            this.SuspendLayout();
            // 
            // Cmb_Sport
            // 
            this.Cmb_Sport.FormattingEnabled = true;
            this.Cmb_Sport.Location = new System.Drawing.Point(125, 71);
            this.Cmb_Sport.Name = "Cmb_Sport";
            this.Cmb_Sport.Size = new System.Drawing.Size(121, 24);
            this.Cmb_Sport.TabIndex = 0;
            // 
            // Cmb_Drzava
            // 
            this.Cmb_Drzava.FormattingEnabled = true;
            this.Cmb_Drzava.Location = new System.Drawing.Point(125, 123);
            this.Cmb_Drzava.Name = "Cmb_Drzava";
            this.Cmb_Drzava.Size = new System.Drawing.Size(121, 24);
            this.Cmb_Drzava.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sport";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Drzava";
            // 
            // Grid_Ekipa
            // 
            this.Grid_Ekipa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Ekipa.Location = new System.Drawing.Point(80, 202);
            this.Grid_Ekipa.Name = "Grid_Ekipa";
            this.Grid_Ekipa.RowHeadersWidth = 51;
            this.Grid_Ekipa.RowTemplate.Height = 24;
            this.Grid_Ekipa.Size = new System.Drawing.Size(602, 150);
            this.Grid_Ekipa.TabIndex = 4;
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(410, 68);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 23);
            this.btn_insert.TabIndex = 5;
            this.btn_insert.Text = "dodaj";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(410, 109);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "izbaci";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // Ekipe1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.Grid_Ekipa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cmb_Drzava);
            this.Controls.Add(this.Cmb_Sport);
            this.Name = "Ekipe1";
            this.Text = "Ekipe";
            this.Load += new System.EventHandler(this.Ekipe1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Ekipa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Cmb_Sport;
        private System.Windows.Forms.ComboBox Cmb_Drzava;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView Grid_Ekipa;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Button btn_delete;
    }
}