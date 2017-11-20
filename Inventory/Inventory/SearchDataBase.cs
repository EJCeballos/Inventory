using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Refresh();
            dataGridView1.ClearSelection();
        }

        private void SearchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ModelID dataset = new ModelID();
                ModelIDTableAdapters.MainStockTableAdapter mainstockTableAdapter = new ModelIDTableAdapters.MainStockTableAdapter();
                DataTable dt = new DataTable();
                mainstockTableAdapter.FillMainStockMaterialInfo(this.modelID.MainStock);
                dt = mainStockTableAdapter.GetDataMainStockMaterialInfo();

                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("SerialNumber like '%{0}%'", SearchBox.Text);
                dataGridView1.DataSource = dv;
                dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoResizeColumn(1);
                dataGridView1.Refresh();
            }
        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {
            ModelID dataset = new ModelID();
            ModelIDTableAdapters.MainStockTableAdapter mainstockTableAdapter = new ModelIDTableAdapters.MainStockTableAdapter();
            DataTable dt = new DataTable();
            mainstockTableAdapter.FillMainStockMaterialInfo(this.modelID.MainStock);
            dt = mainStockTableAdapter.GetDataMainStockMaterialInfo();

            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("SerialNumber like '%{0}%'", SearchBox.Text);
            dataGridView1.DataSource = dv;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Refresh();

        }


        private void SearchModel_TextChanged(object sender, EventArgs e)
        {
            ModelID dataset = new ModelID();
            ModelIDTableAdapters.MainStockTableAdapter mainstockTableAdapter = new ModelIDTableAdapters.MainStockTableAdapter();
            DataTable dt = new DataTable();
            mainstockTableAdapter.FillMainStockMaterialInfo(this.modelID.MainStock);
            dt = mainStockTableAdapter.GetDataMainStockMaterialInfo();

            DataView dv = dt.DefaultView;
            dv.RowFilter = string.Format("MaterialName like '%{0}%'", SearchModel.Text);
            dataGridView1.DataSource = dv;
            dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoResizeColumn(1);
            dataGridView1.Refresh();
        }

    }
}
