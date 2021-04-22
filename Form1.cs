using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpcEncoderTester
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            DataGridViewButtonColumn dgvButton = new DataGridViewButtonColumn();
            dgvEncoder.Columns.Add(dgvButton);
            SubscreveEventosDataGridView();
        }

        private void SubscreveEventosDataGridView() 
        {
            //MessageBox.Show("Subscrevi aos eventos");
            dgvEncoder.CellContentClick += dgvEncoder_CellContentClick;
        }

        private void dgvEncoder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                MessageBox.Show("Botão do GridView Clicado");
            }
        }

        private void CancelaSubscricaoEventosDataGridView() 
        {
            dgvEncoder.CellContentClick -= dgvEncoder_CellContentClick;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            CancelaSubscricaoEventosDataGridView();
        }
    }
}
