using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buynew
{
    public partial class S2 : Form
    {
        public S2()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv)|*.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);
                string readAllText = File.ReadAllText(openFileDialog.FileName);

                for (int i = 0; i < readAllLine.Length; i++)
                {
                    string classs2RAW = readAllLine[i];
                    string[] classs2Splited = classs2RAW.Split(',');
                    ClassS2 classS2 = new ClassS2(classs2Splited[0], classs2Splited[1], classs2Splited[2], classs2Splited[3]);
                    addDataToGridView(classs2Splited[0], classs2Splited[1], classs2Splited[2], classs2Splited[3]);
                }
            }
        }
        void addDataToGridView(string name, string mail, string number, string location)
        {
            this.dataGridView1.Rows.Add(new string[] { name, mail, number, location });
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Visible = false;
            Form2 form2 = new Form2();
            form2.Visible = true;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filepath = string.Empty;
            if (dataGridView1.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "CSV(*.csv)|*.csv";
                bool fileError = false;
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (!fileError)
                    {
                        try
                        {
                            int columnCount = dataGridView1.Columns.Count;
                            string columnNames = "";
                            string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                            for (int i = 0; i < columnCount; i++)
                            {
                                columnNames += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                            }
                            outputCSV[0] += columnNames;
                            for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < columnCount; j++)
                                {
                                    outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                                }
                            }
                            File.WriteAllLines(sfd.FileName, outputCSV, Encoding.UTF8);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error :" + ex.Message);
                        }
                    }
                }
            }
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("คุณได้สั่งซื้อบัตรของ ศิลปินคนที่2 เเล้ว");
            int n = dataGridView1.Rows.Add();
            dataGridView1.Rows[n].Cells[0].Value = textBoxName.Text;
            dataGridView1.Rows[n].Cells[1].Value = textBoxMail.Text;
            dataGridView1.Rows[n].Cells[2].Value = textBoxNumber.Text;
            dataGridView1.Rows[n].Cells[3].Value = textBoxLocation.Text;
            textBoxName.Text = "";
            textBoxMail.Text = "";
            textBoxNumber.Text = "";
            textBoxLocation.Text = "";
        }
    }
}
