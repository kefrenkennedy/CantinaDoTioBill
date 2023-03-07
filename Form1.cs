using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CantinaDoTioBill
{
    public partial class Form1 : Form
    {
        private PostgreSQL db = new PostgreSQL(); // instancia a classe PostgreSQL

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código para executar quando o formulário é carregado
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Obter o endereço de e-mail e a senha digitados pelo usuário
            string email = txtEmail.Text;
            string password_hash = txtPassword.Text;

            // Abrir a conexão com o banco de dados PostgreSQL
            NpgsqlConnection connection = new NpgsqlConnection(db.connectionString);
            connection.Open();

            // Definir a consulta SQL para selecionar registros com base no endereço de e-mail e senha
            string sql = "SELECT COUNT(*) FROM users WHERE email = @email AND password_hash = @password";

            // Criar um objeto NpgsqlCommand com a consulta SQL e os parâmetros
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password_hash", password_hash);

            // Executar a consulta e obter o número de registros correspondentes
            int count = Convert.ToInt32(command.ExecuteScalar());

            // Fechar a conexão com o banco de dados PostgreSQL
            connection.Close();

            // Verificar se há um registro correspondente na tabela de usuários
            if (count > 0)
            {
                MessageBox.Show("Login successful!");
                // Permitir que o usuário acesse a próxima página do aplicativo
            }
            else
            {
                MessageBox.Show("Endereço de e-mail ou senha incorretos. Tente novamente.");
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
