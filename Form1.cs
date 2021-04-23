using SoEpcConverter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpcEncoderTester
{
    public partial class frmMain : Form
    {
        SoEncode MyEncoder;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (!instanciarSoEncode())
            {
                Application.Exit();
                return;
            }

            //dgvResizeColumns(dgvEncoder);
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvButton.Name = "execButton";
            dgvButton.HeaderText = "";
            dgvButton.Text = "Encode";
            dgvButton.UseColumnTextForButtonValue = true;
            dgvButton.Width = 150;
            dgvButton.FlatStyle = FlatStyle.Standard;
            dgvEncoder.Columns.Add(dgvButton);

            // add 7 rows to the grid
            for (int i = 0; i < 8; i++)
            {
                dgvEncoder.Rows.Add(
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null,
                    null
                    );
            }

            //dgvEncoder.AutoResizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEncoder.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEncoder.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvEncoder.Columns[8].Width = 162;

            SubscreveEventosDataGridView();
            lblEncoderSintaxeContent.Text = "";
        }

        private void SubscreveEventosDataGridView() 
        {
            //MessageBox.Show("Subscrevi aos eventos");
            dgvEncoder.CellContentClick += dgvEncoder_CellContentClick;
        }

        private bool instanciarSoEncode()
        {
            bool bReturn = true;
            try
            {
                MyEncoder = new SoEncode();
            }
            catch (Exception e)
            {
                bReturn = false;
                MessageBox.Show($"Erro ao instanciar Solink Encoder. Exceção: {e.Message}","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error); ;
            }

            return bReturn;
        }

        private void dgvEncoder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            string myHexEpc = null;

            //if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            //{
            //    MessageBox.Show("Botão do GridView Clicado");
            //}

            //string sextension = string.IsNullOrEmpty(senderGrid.Rows[e.RowIndex].Cells[3].Value?.ToString()) ? "0" : senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();

            //senderGrid.Rows[e.RowIndex].Cells[0].Value
            string encoderType;
            int filter;
            string gs1CompanyPrefix;
            long extension;
            int locationReference;
            int assetType;
            int item;
            long serial;

            if (senderGrid.Rows[e.RowIndex].Cells[0].Value == null)
                encoderType = string.Empty;
            else
                encoderType = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (senderGrid.Rows[e.RowIndex].Cells[1].Value == null)
                filter = -1;
            else
                filter = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[1].Value);

            if (senderGrid.Rows[e.RowIndex].Cells[2].Value == null)
                gs1CompanyPrefix = string.Empty;
            else
                gs1CompanyPrefix = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString();

            if (senderGrid.Rows[e.RowIndex].Cells[3].Value == null)
                extension = -1;
            else
                extension = Convert.ToInt64(senderGrid.Rows[e.RowIndex].Cells[3].Value);

            if (senderGrid.Rows[e.RowIndex].Cells[4].Value == null)
                locationReference = -1;
            else
                locationReference = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[4].Value);

            if (senderGrid.Rows[e.RowIndex].Cells[5].Value == null)
                assetType = -1;
            else
                assetType = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[5].Value);

            if (senderGrid.Rows[e.RowIndex].Cells[6].Value == null)
                item = -1;
            else
                item = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[6].Value);

            if (senderGrid.Rows[e.RowIndex].Cells[7].Value == null)
                serial = -1;
            else
                serial = Convert.ToInt64(senderGrid.Rows[e.RowIndex].Cells[7].Value);


            Debug.WriteLine($"encoderType: {encoderType}");
            Debug.WriteLine($"filter: {filter}");
            Debug.WriteLine($"gs1CompanyPrefix: {gs1CompanyPrefix}");
            Debug.WriteLine($"extension: {extension}");
            Debug.WriteLine($"locationReference: {locationReference}");
            Debug.WriteLine($"assetType: {assetType}");
            Debug.WriteLine($"item: {item}");
            Debug.WriteLine($"serial: {serial}");

            //MessageBox.Show($"{encoderType}");

            switch (encoderType)
            {
                case "SSCC96":
                    // "SSCC96(int Filter, string GS1CompanyPrefix, Int64 Extension)";

                    // consistência

                    if (filter == -1)
                    {
                        MessageBox.Show($"filter faltando!","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                    if (gs1CompanyPrefix == string.Empty)
                    {
                        MessageBox.Show($"gs1CompanyPrefix faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (extension == -1)
                    {
                        MessageBox.Show($"extension faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //MessageBox.Show($"Todos parâmetros preenchidos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    try
                    {
                        myHexEpc = MyEncoder.SSCC96(filter, gs1CompanyPrefix, extension).HexEpc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao chamar MyEncoder.SSCC96.\n{ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;

                case "SGLN96":

                    //"SGLN96(int Filter, string GS1CompanyPrefix, int LocationReference, Int64 Extension)";

                    // consistência
                    if (filter == -1)
                    {
                        MessageBox.Show($"filter faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (gs1CompanyPrefix == string.Empty)
                    {
                        MessageBox.Show($"gs1CompanyPrefix faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (locationReference == -1)
                    {
                        MessageBox.Show($"locationReference faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (extension == -1)
                    {
                        MessageBox.Show($"extension faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //MessageBox.Show($"Todos parâmetros preenchidos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    try
                    {
                        myHexEpc = MyEncoder.SGLN96(filter, gs1CompanyPrefix, locationReference, extension).HexEpc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao chamar MyEncoder.SGLN96.\n{ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;
                case "SGLN195":

                    // "SGLN195(int Filter, string GS1CompanyPrefix, int LocationReference, string Extension)";

                    // consistência
                    if (filter == -1)
                    {
                        MessageBox.Show($"filter faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (gs1CompanyPrefix == string.Empty)
                    {
                        MessageBox.Show($"gs1CompanyPrefix faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (locationReference == -1)
                    {
                        MessageBox.Show($"locationReference faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (extension == -1)
                    {
                        MessageBox.Show($"extension faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //MessageBox.Show($"Todos parâmetros preenchidos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    try
                    {
                        myHexEpc = MyEncoder.SGLN195(filter, gs1CompanyPrefix, locationReference, extension.ToString()).HexEpc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao chamar MyEncoder.SGLN195.\n{ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;

                case "GRAI96":
                    //"GRAI96(int Filter, string GS1CompanyPrefix, int AssetType, Int64 Serial)";

                    // consistência
                    if (filter == -1)
                    {
                        MessageBox.Show($"filter faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (gs1CompanyPrefix == string.Empty)
                    {
                        MessageBox.Show($"gs1CompanyPrefix faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (assetType == -1)
                    {
                        MessageBox.Show($"assetType faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (serial == -1)
                    {
                        MessageBox.Show($"serial faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //MessageBox.Show($"Todos parâmetros preenchidos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    try
                    {
                        myHexEpc = MyEncoder.GRAI96(filter, gs1CompanyPrefix, assetType, serial).HexEpc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao chamar MyEncoder.GRAI96.\n{ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;

                case "GRAI170":
                    // "GRAI170(int Filter, string GS1CompanyPrefix, int AssetType, string Serial)";

                    // consistência
                    if (filter == -1)
                    {
                        MessageBox.Show($"filter faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (gs1CompanyPrefix == string.Empty)
                    {
                        MessageBox.Show($"gs1CompanyPrefix faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (assetType == -1)
                    {
                        MessageBox.Show($"assetType faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (serial == -1)
                    {
                        MessageBox.Show($"serial faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }


                    //MessageBox.Show($"Todos parâmetros preenchidos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    try
                    {
                        myHexEpc = MyEncoder.GRAI170(filter, gs1CompanyPrefix, assetType, serial.ToString()).HexEpc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao chamar MyEncoder.GRAI170.\n{ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;

                case "SGTIN96":
                    // "SGTIN96(int Filter, string GS1CompanyPrefix, int Item, Int64 Serial)";

                    // consistência
                    if (filter == -1)
                    {
                        MessageBox.Show($"filter faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (gs1CompanyPrefix == string.Empty)
                    {
                        MessageBox.Show($"gs1CompanyPrefix faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (item == -1)
                    {
                        MessageBox.Show($"item faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (serial == -1)
                    {
                        MessageBox.Show($"serial faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //MessageBox.Show($"Todos parâmetros preenchidos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    try
                    {
                        myHexEpc = MyEncoder.SGTIN96(filter, gs1CompanyPrefix, item, serial).HexEpc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao chamar MyEncoder.SGTIN96.\n{ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    break;

                case "SGTIN198":
                    // "SGTIN198(int Filter, string GS1CompanyPrefix, int Item, string Serial)";

                    // consistência
                    if (filter == -1)
                    {
                        MessageBox.Show($"filter faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (gs1CompanyPrefix == string.Empty)
                    {
                        MessageBox.Show($"gs1CompanyPrefix faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (item == -1)
                    {
                        MessageBox.Show($"item faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (serial == -1)
                    {
                        MessageBox.Show($"serial faltando!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //MessageBox.Show($"Todos parâmetros preenchidos!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    try
                    {
                        myHexEpc = MyEncoder.SGTIN198(filter, gs1CompanyPrefix, item, serial.ToString()).HexEpc;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao chamar MyEncoder.SGTIN198.\n{ex.Message} ", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    break;

                case "":
                case "[Selecione]":
                    MessageBox.Show($"Escolha um tipo de Encoder! (SGTIN96, SGTIN198, ...)", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            senderGrid.Rows[e.RowIndex].Cells[8].Value = myHexEpc;

        }

        private void CancelaSubscricaoEventosDataGridView() 
        {
            dgvEncoder.CellContentClick -= dgvEncoder_CellContentClick;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelaSubscricaoEventosDataGridView();
        }



        //private void dgvEncoder_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    ComboBox cb = e.Control as ComboBox;
        //    if (cb != null)
        //    {
        //        cb.SelectedIndexChanged += new EventHandler(selectionchange);
        //        //here SelectedIndexChanged event is used
        //    }
        //}

        //void selectionchange(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ComboBox cb = (ComboBox)sender;
        //        if (cb.Text == "SGTIN96")
        //        {
        //            MessageBox.Show($"cb.Text");
        //            //dgvEncoder.CurrentRow.Cells[1].Value = "Hello";
        //            //if datagridviewcombobox text is yes then set the first column value to 'Hello'
        //        }
        //        else if (cb.Text == "no")
        //        {
        //            //dgvEncoder.CurrentRow.Cells[1].Value = string.Empty;
        //            //else set the first column  value to empty
        //        }
        //    }
        //    catch { }
        //}

        private void dgvResizeColumns(DataGridView grd) 
        {
            grd.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grd.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
            for (int i = 0; i <= grd.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = grd.Columns[i].Width;

                // Remove AutoSizing:
                grd.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                grd.Columns[i].Width = colw;
            }
        }

        private void dgvEncoder_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            ((DataGridViewButtonCell)dgvEncoder.CurrentRow.Cells[10]).Value = "Encode";
        }

    }

    public class myDataGridView : DataGridView
    {
        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewComboBoxEditingControl control = e.Control as DataGridViewComboBoxEditingControl;
            if (control != null)
            {

                control.SelectedIndexChanged += new EventHandler(selectionchange);
            }
            base.OnEditingControlShowing(e);
        }

        void selectionchange(object sender, EventArgs e)
        {
            try
            {
                //Acessa o label do form
                Label lblEncoderSintaxeContent = Application.OpenForms["frmMain"].Controls["lblEncoderSintaxeContent"] as Label;
                DataGridView dgv = Application.OpenForms["frmMain"].Controls["dgvEncoder"] as DataGridView;

                ComboBox cb = (ComboBox)sender;

                switch (cb.Text)
                {
                    case "SSCC96":
                        //MessageBox.Show(${cb.Text});
                        lblEncoderSintaxeContent.Text = "SSCC96(int Filter, string GS1CompanyPrefix, Int64 Extension)";
                        break;
                    case "SGLN96":
                        //MessageBox.Show(${cb.Text});
                        lblEncoderSintaxeContent.Text = "SGLN96(int Filter, string GS1CompanyPrefix, int LocationReference, Int64 Extension)";
                        break;
                    case "SGLN195":
                        //MessageBox.Show(${cb.Text});
                        lblEncoderSintaxeContent.Text = "SGLN195(int Filter, string GS1CompanyPrefix, int LocationReference, string Extension)";
                        break;
                    case "GRAI96":
                        //MessageBox.Show(${cb.Text});
                        lblEncoderSintaxeContent.Text = "GRAI96(int Filter, string GS1CompanyPrefix, int AssetType, Int64 Serial)";
                        break;
                    case "GRAI170":
                        //MessageBox.Show(${cb.Text});
                        lblEncoderSintaxeContent.Text = "GRAI170(int Filter, string GS1CompanyPrefix, int AssetType, string Serial)";
                        break;
                    case "SGTIN96":
                        //MessageBox.Show(${cb.Text});
                        lblEncoderSintaxeContent.Text = "SGTIN96(int Filter, string GS1CompanyPrefix, int Item, Int64 Serial)";
                        break;
                    case "SGTIN198":
                        //MessageBox.Show(${cb.Text});
                        lblEncoderSintaxeContent.Text = "SGTIN198(int Filter, string GS1CompanyPrefix, int Item, string Serial)";
                        break;
                    case "[Selecione]":
                        lblEncoderSintaxeContent.Text = string.Empty;
                        DataGridViewCellCollection cellsCol = dgv.CurrentRow.Cells;
                        foreach (DataGridViewCell cel in cellsCol) 
                        {
                            if (cel.ColumnIndex > 0 && cel.ColumnIndex < 9)
                            {
                                cel.Value = null;
                            }
                        }
                        break;
                }

                //if (cb.Text == "SGTIN96")
                //{
                //    MessageBox.Show($"cb.Text");
                //    //dgvEncoder.CurrentRow.Cells[1].Value = "Hello";
                //    //if datagridviewcombobox text is yes then set the first column value to 'Hello'
                //}
                //else if (cb.Text == "no")
                //{
                //    //dgvEncoder.CurrentRow.Cells[1].Value = string.Empty;
                //    //else set the first column  value to empty
                //}
            }
            catch { }
        }
    }
}
