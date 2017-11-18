using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class SearchDataBase : Form
    {
        public SearchDataBase()
        {
            InitializeComponent();
        }

        private void SearchDataBase_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'modelID.MainStock' table. You can move, or remove it, as needed.
            this.mainStockTableAdapter.FillMainStockMaterialInfo(this.modelID.MainStock);
           
            // TODO: This line of code loads data into the 'modelID.MainStock' table. You can move, or remove it, as needed.
            this.mainStockTableAdapter.FillMainStockMaterialInfo(this.modelID.MainStock);
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
