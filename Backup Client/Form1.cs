using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Backup_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button_full_Click(object sender, EventArgs e)
        {

            Backup_Full.CopyDirectory(@"C:\ToBackup", @"C:\BackUp Folder");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Backup_Diff.CopyDirectory(@"C:\ToBackup", @"C:\BackUp Folder", 7);
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
