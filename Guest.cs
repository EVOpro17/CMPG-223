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

namespace Natuurpark1._2
{
    public partial class Guest : Form
    {
        public Guest()
        {
            InitializeComponent();
        }

        public SqlConnection conn;
        public SqlDataAdapter adap;
        public SqlCommand comm;
        public DataSet data;
        public SqlDataReader datar;
        string constr = @"Data Source=RYAN-PC;Initial Catalog=Park;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //hallo daar sien jy dit 
            //Ek weet nie hoekom joune nie wil werk nie 
            //Ryan Comment

        }

        private void Guest_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(constr);
            conn.Open();
            SqlCommand com;
            adap = new SqlDataAdapter();
            data = new DataSet();
            string sql = "Select * from Guests ";
            com = new SqlCommand(sql, conn);
            adap.SelectCommand = com;
            adap.Fill(data, "Lys");
            dataGridView1.DataSource = data;
            dataGridView1.DataMember = "Lys";
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //add new guest
            conn = new SqlConnection(constr);
            conn.Open();
            String query = "insert into Guests (Guest_Name,Guest_Surname,Guest_Email) VALUES (@Name,@LastName,@Email)";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@Name", NameTXT.Text);
            cmd.Parameters.AddWithValue("@LastName", VanTXT.Text);
            cmd.Parameters.AddWithValue("@Email", Emailtxt.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            //net ref
        }
    }
}
