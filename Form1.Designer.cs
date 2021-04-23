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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblEncoderSintaxe = new System.Windows.Forms.Label();
            this.lblEncoderSintaxeContent = new System.Windows.Forms.Label();
            this.dgvEncoder = new EpcEncoderTester.myDataGridView();
            this.TipoEncoder = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Filter = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.GS1CompanyPrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Extension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AssetType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Serial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EPC_Gerado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncoder)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(522, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(253, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "EPC Encoder Tester";
            // 
            // lblEncoderSintaxe
            // 
            this.lblEncoderSintaxe.AutoSize = true;
            this.lblEncoderSintaxe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncoderSintaxe.Location = new System.Drawing.Point(59, 365);
            this.lblEncoderSintaxe.Name = "lblEncoderSintaxe";
            this.lblEncoderSintaxe.Size = new System.Drawing.Size(74, 20);
            this.lblEncoderSintaxe.TabIndex = 2;
            this.lblEncoderSintaxe.Text = "Sintaxe:";
            // 
            // lblEncoderSintaxeContent
            // 
            this.lblEncoderSintaxeContent.AutoSize = true;
            this.lblEncoderSintaxeContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEncoderSintaxeContent.Location = new System.Drawing.Point(139, 367);
            this.lblEncoderSintaxeContent.Name = "lblEncoderSintaxeContent";
            this.lblEncoderSintaxeContent.Size = new System.Drawing.Size(36, 18);
            this.lblEncoderSintaxeContent.TabIndex = 2;
            this.lblEncoderSintaxeContent.Text = "Text";
            // 
            // dgvEncoder
            // 
            this.dgvEncoder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEncoder.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TipoEncoder,
            this.Filter,
            this.GS1CompanyPrefix,
            this.Extension,
            this.LocationReference,
            this.AssetType,
            this.Item,
            this.Serial,
            this.EPC_Gerado});
            this.dgvEncoder.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvEncoder.Location = new System.Drawing.Point(59, 115);
            this.dgvEncoder.Name = "dgvEncoder";
            this.dgvEncoder.Size = new System.Drawing.Size(1213, 227);
            this.dgvEncoder.TabIndex = 1;
            // 
            // TipoEncoder
            // 
            this.TipoEncoder.HeaderText = "Tipo Encoder";
            this.TipoEncoder.Items.AddRange(new object[] {
            "[Selecione]",
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
            this.Filter.HeaderText = "Filter";
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
            // GS1CompanyPrefix
            // 
            this.GS1CompanyPrefix.HeaderText = "GS1 Company Prefix";
            this.GS1CompanyPrefix.Name = "GS1CompanyPrefix";
            // 
            // Extension
            // 
            this.Extension.HeaderText = "Extension";
            this.Extension.Name = "Extension";
            // 
            // LocationReference
            // 
            this.LocationReference.HeaderText = "Location Reference";
            this.LocationReference.Name = "LocationReference";
            // 
            // AssetType
            // 
            this.AssetType.HeaderText = "AssetType";
            this.AssetType.Name = "AssetType";
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // Serial
            // 
            this.Serial.HeaderText = "Serial";
            this.Serial.Name = "Serial";
            // 
            // EPC_Gerado
            // 
            this.EPC_Gerado.HeaderText = "EPC Gerado";
            this.EPC_Gerado.Name = "EPC_Gerado";
            this.EPC_Gerado.ReadOnly = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1308, 428);
            this.Controls.Add(this.lblEncoderSintaxeContent);
            this.Controls.Add(this.lblEncoderSintaxe);
            this.Controls.Add(this.dgvEncoder);
            this.Controls.Add(this.lblTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1324, 467);
            this.MinimumSize = new System.Drawing.Size(1324, 467);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EPC Encoder - Tester";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEncoder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private myDataGridView dgvEncoder;
        private System.Windows.Forms.Label lblEncoderSintaxe;
        private System.Windows.Forms.Label lblEncoderSintaxeContent;
        private System.Windows.Forms.DataGridViewComboBoxColumn TipoEncoder;
        private System.Windows.Forms.DataGridViewComboBoxColumn Filter;
        private System.Windows.Forms.DataGridViewTextBoxColumn GS1CompanyPrefix;
        private System.Windows.Forms.DataGridViewTextBoxColumn Extension;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn AssetType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Serial;
        private System.Windows.Forms.DataGridViewTextBoxColumn EPC_Gerado;
    }
}

