using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BInaryTableDemo
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		List<PersonModel> dataList;

		private void Form1_Load(object sender, EventArgs e)
		{
			var sampleDataJsonString = System.IO.File.ReadAllText("sample-data.json");
			dataList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<PersonModel>>(sampleDataJsonString);
			dataGridView1.DataSource = dataList;
			txtLog.AppendText("sample file loaded successfully" + Environment.NewLine);
		}

		private DataTable createDataTable()
		{
			var dataTable = new DataTable();
			dataTable.Columns.Add("ID", typeof(int));
			dataTable.Columns.Add("Name", typeof(string));
			dataTable.Columns.Add("Age", typeof(int));

			foreach (var i in dataList)
			{
				var dr = dataTable.NewRow();
				dr[0] = i.ID;
				dr[1] = i.Name;
				dr[2] = i.Age;
				dataTable.Rows.Add(dr);
			}
			return dataTable;
		}

		private void btnSimple_Click(object sender, EventArgs e)
		{
			var frmBrowse = new SaveFileDialog();
			frmBrowse.Filter = "Binary files (.bin)|*.bin";
			if (frmBrowse.ShowDialog() == DialogResult.OK)
			{
				var dataTable = createDataTable();
				MostafaTech.BinaryTable.WriteToFile(dataTable, frmBrowse.FileName);
				txtLog.AppendText("simple file saved successfully" + Environment.NewLine);
			}
		}

		private void btnCompressed_Click(object sender, EventArgs e)
		{
			var frmBrowse = new SaveFileDialog();
			frmBrowse.Filter = "Binary files (.bin)|*.bin";
			if (frmBrowse.ShowDialog() == DialogResult.OK)
			{
				var dataTable = createDataTable();
				MostafaTech.BinaryTable.WriteToFile(dataTable, frmBrowse.FileName, true);
				txtLog.AppendText("compressed file saved successfully" + Environment.NewLine);
			}
		}

		private void btnReadSimple_Click(object sender, EventArgs e)
		{
			var frmBrowse = new OpenFileDialog();
			frmBrowse.Filter = "Binary files (.bin)|*.bin";
			if (frmBrowse.ShowDialog() == DialogResult.OK)
			{
				var dataTable = MostafaTech.BinaryTable.ReadFromFile(frmBrowse.FileName);
				dataGridView1.DataSource = dataTable;
				txtLog.AppendText("simple file loaded successfully" + Environment.NewLine);
			}
		}

		private void btnReadCompressed_Click(object sender, EventArgs e)
		{
			var frmBrowse = new OpenFileDialog();
			frmBrowse.Filter = "Binary files (.bin)|*.bin";
			if (frmBrowse.ShowDialog() == DialogResult.OK)
			{
				var dataTable = MostafaTech.BinaryTable.ReadFromFile(frmBrowse.FileName, true);
				dataGridView1.DataSource = dataTable;
				txtLog.AppendText("compressed file loaded successfully" + Environment.NewLine);
			}
		}
	}
}
