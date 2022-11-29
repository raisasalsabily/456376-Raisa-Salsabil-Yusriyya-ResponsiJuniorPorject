using Npgsql;
using System.Data;

namespace ResponsiJP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=2022;Username=raisasalsabil;Password=Raisa10112001baru;Database=resp_raisa";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(connstring);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"select * form insert_func(:_nama, :_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_nama", tbNama.Text);
                cmd.Parameters.AddWithValue("_id_dep", tbDep.Text);
                if((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Berhasil Memasukkan Data!");
                    conn.Close();
                    btnLoad.PerformClick();
                    tbNama.Text = tbDep.Text = null;
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " FAIL!");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                dgvData.DataSource = null;
                sql = "select * from select_func()";
                cmd = new NpgsqlCommand(sql, conn);
                dt = new DataTable();
                NpgsqlDataReader rd = cmd.ExecuteReader();
                dt.Load(rd);
                dgvData.DataSource = dt;
                conn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message + " FAIL!");
            }
        }
    }
}