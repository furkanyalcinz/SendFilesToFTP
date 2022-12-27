using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileTransfer
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }
       
        private void SelectFilesButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect= true;

            DialogResult dialogResult = openFileDialog1.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                foreach (var file in openFileDialog1.FileNames)
                {
                    checkedListBox1.Items.Add(file);
                }
            }
        }
    }
}
