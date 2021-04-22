namespace EpcEncoderTester
{
    partial class frmMain
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvEncoder = new System.Windows.Forms.DataGridView();
            this.TipoEncoder = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Filter = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GS1Prefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeqRFID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EPC_Gerado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EPC_GS1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncoder)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(50, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(174, 20);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "EPC Encoder Helper";
            // 
            // dgvEncoder
            // 
            this.dgvEncoder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEncoder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoEncoder,
            this.Filter,
            this.GS1Prefix,
            this.Item,
            this.SeqRFID,
            this.EPC_Gerado,
            this.EPC_GS1});
            this.dgvEncoder.Location = new System.Drawing.Point(59, 115);
            this.dgvEncoder.Name = "dgvEncoder";
            this.dgvEncoder.Size = new System.Drawing.Size(800, 226);
            this.dgvEncoder.TabIndex = 1;
            // 
            // TipoEncoder
            // 
            this.TipoEncoder.HeaderText = "Tipo Encoder";
            this.TipoEncoder.Items.AddRange(new object[] {
            "SSCC96",
            "SGLN96",
            "SGLN195",
            "GRAI96",
            "GRAI170",
            "SGTIN96",
            "SGTIN198"});
            this.TipoEncoder.Name = "TipoEncoder";
            this.TipoEncoder.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TipoEncoder.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Filter
            // 
            this.Filter.HeaderText = "Filtro";
            this.Filter.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.Filter.Name = "Filter";
            // 
            // GS1Prefix
            // 
            this.GS1Prefix.HeaderText = "Prefixo GTIN13";
            this.GS1Prefix.Name = "GS1Prefix";
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // SeqRFID
            // 
            this.SeqRFID.HeaderText = "SeqRFID";
            this.SeqRFID.Name = "SeqRFID";
            // 
            // EPC_Gerado
            // 
            this.EPC_Gerado.HeaderText = "EPC Gerado";
            this.EPC_Gerado.Name = "EPC_Gerado";
            this.EPC_Gerado.ReadOnly = true;
            // 
            // EPC_GS1
            // 
            this.EPC_GS1.HeaderText = "EPC GS1";
            this.EPC_GS1.Name = "EPC_GS1";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 413);
            this.Controls.Add(this.dgvEncoder);
            this.Controls.Add(this.lblTitle);
            this.Name = "frmMain";
            this.Text = "EPC Encoder - Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncoder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvEncoder;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipoEncoder;
        private System.Windows.Forms.DataGridViewComboBoxColumn Filter;
        private System.Windows.Forms.DataGridViewTextBoxColumn GS1Prefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeqRFID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EPC_Gerado;
        private System.Windows.Forms.DataGridViewTextBoxColumn EPC_GS1;
    }
}

