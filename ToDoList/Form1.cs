using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddTask();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex == -1)
            {
                MessageBox.Show("Pilih tugas yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstTasks.Items.RemoveAt(lstTasks.SelectedIndex);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (lstTasks.Items.Count == 0)
            {
                MessageBox.Show("Tidak ada tugas untuk dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus semua tugas?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lstTasks.Items.Clear();
            }
        }

        

        private void txtTask_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddTask();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void AddTask()
        {
            string task = txtTask.Text.Trim();

            if (string.IsNullOrEmpty(task))
            {
                MessageBox.Show("Tugas tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTask.Focus();
                return;
            }

            lstTasks.Items.Add(task);
            txtTask.Clear();
            txtTask.Focus();
        }
    }
}
