using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PAP
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=EPBEPB-HIF0VA08;Initial Catalog=OficinaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public Form1()
        {
            InitializeComponent();
            CarregarClientes();
        }

        // Método para carregar os dados dos clientes na DataGridView
        private void CarregarClientes()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Clientes", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewClientes.DataSource = dt;
            }
        }

        // Método para adicionar um novo cliente
        private void AdicionarCliente(string nome, string telefone)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Clientes (Nome, Telefone) VALUES (@Nome, @Telefone)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Telefone", telefone);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Método para adicionar um veículo
        private void AdicionarVeiculo(int clienteID, string marca, string modelo, int ano)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Veiculos (ClienteID, Marca, Modelo, Ano) VALUES (@ClienteID, @Marca, @Modelo, @Ano)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ClienteID", clienteID);
                cmd.Parameters.AddWithValue("@Marca", marca);
                cmd.Parameters.AddWithValue("@Modelo", modelo);
                cmd.Parameters.AddWithValue("@Ano", ano);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
