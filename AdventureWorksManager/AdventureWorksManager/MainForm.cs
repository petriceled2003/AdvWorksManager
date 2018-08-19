using AdventureWorksManager.Production.Forms;
using System;
using System.Windows.Forms;

namespace AdventureWorksManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var productsListForm = new ProductsListForm();
            productsListForm.MdiParent = this;
            productsListForm.Show();
        }
    }
}
