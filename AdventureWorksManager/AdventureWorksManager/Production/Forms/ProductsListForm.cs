using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureWorksManager.Production.Forms
{
    public partial class ProductsListForm : Form
    {
        public ProductsListForm()
        {
            InitializeComponent();
        }

        private void ProductsListForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<Product> dataSource = new List<Product>();

                using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["AdventureWorks2016CTP3ConnectionString"].ConnectionString))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand("select * from Production.Product", sqlConnection);
                    SqlDataReader dataReader = sqlCommand.ExecuteReader();

                    while (dataReader.Read())
                    {
                        dataSource.Add(new Product
                        {
                            ProductID = dataReader.GetInt32(0),
                            Name = dataReader.GetString(1),
                        });
                    }
                }

                dataGridView1.DataSource = dataSource;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
    }
}
