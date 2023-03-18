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

namespace SIDB_HW2
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlDataAdapter DataAdapter1, DataAdapter2, DataAdapter3;
        DataSet DataSet1, DataSet2, DataSet3;

     

        BindingSource BindingSource1, BindingSource2, BindingSource3;

        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection("Data Source=KOMNIS;Initial Catalog=Katalogos;Integrated Security=True");
            connection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataAdapter1 = new SqlDataAdapter("select * from FRIEND", connection);
            DataSet1 = new DataSet();
            DataAdapter1.Fill(DataSet1);
            BindingSource1 = new BindingSource();
            BindingSource1.DataSource = DataSet1.Tables[0].DefaultView;
            bindingNavigator1.BindingSource = BindingSource1;
            dataGridView1.DataSource = BindingSource1;

            DataAdapter2 = new SqlDataAdapter("select * from FRIEND where CITY='ΣΕΡΡΕΣ'", connection);
            DataSet2 = new DataSet();
            DataAdapter2.Fill(DataSet2);
            BindingSource2 = new BindingSource();
            BindingSource2.DataSource = DataSet2.Tables[0].DefaultView;
            bindingNavigator2.BindingSource = BindingSource2;
            dataGridView2.DataSource = BindingSource2;

            DataAdapter3 = new SqlDataAdapter("select SURNAME, NAME, MOBILE from FRIEND where MOBILE LIKE '69%'", connection);
            DataSet3 = new DataSet();
            DataAdapter3.Fill(DataSet3);
            BindingSource3 = new BindingSource();
            BindingSource3.DataSource = DataSet3.Tables[0].DefaultView;
            bindingNavigator3.BindingSource = BindingSource3;
            dataGridView3.DataSource = BindingSource3;



        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
