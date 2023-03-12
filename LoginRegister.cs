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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace CantinaDoTioBill
{
    public partial class LoginRegister : Form
    {
        private PostgreSQL db = new PostgreSQL(); // instancia a classe PostgreSQL

        public LoginRegister()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Código para executar quando o formulário é carregado
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                MessageBox.Show("Email Inválido.");
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Obter o endereço de e-mail e a senha digitados pelo usuário
            string email = txtEmailLogin.Text;
            string password = txtPasswordLogin.Text;

            // Abrir a conexão com o banco de dados PostgreSQL
            NpgsqlConnection connection = new NpgsqlConnection(db.connectionString);
            connection.Open();

            // Definir a consulta SQL para selecionar registros com base no endereço de e-mail e senha
            string sql = "SELECT COUNT(*) FROM users WHERE email = @email AND password = @password";

            // Criar um objeto NpgsqlCommand com a consulta SQL e os parâmetros
            NpgsqlCommand command = new NpgsqlCommand(sql, connection);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@password", password);

            // Executar a consulta e obter o número de registros correspondentes
            int count = Convert.ToInt32(command.ExecuteScalar());

            // Fechar a conexão com o banco de dados PostgreSQL
            connection.Close();

            // Verificar se há um registro correspondente na tabela de usuários
            if (count > 0)
            {
                MessageBox.Show("Login efetuado!");
                // Permitir que o usuário acesse a próxima página do aplicativo
 
                Welcome pagina = new Welcome(email);

                // Exiba a nova página e feche a tela de login
                pagina.Show();
                Hide();

            }
            else
            {
                MessageBox.Show("Endereço de e-mail ou senha incorretos. Tente novamente.");
            }

            txtEmailLogin.Clear();
            txtPasswordLogin.Clear();
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            // código do evento aqui
        }


        private void label5_Click(object sender, EventArgs e)
        {
            // código do evento aqui
        }

        private void btnRegister_Click_1(object sender, EventArgs e)
        {

            if (txtComplement.Text == null || txtStreetNumber.Text == null || txtStreet.Text == null || txtNeighborhood.Text == null || txtState.Text == null || txtCity.Text == null || txtUserType.Text == null || txtNameRegister.Text == null || txtEmailRegister.Text == null || txtPasswordRegister.Text == null)
            {
                MessageBox.Show("É necessário preencher todos os dados.");
            }

            if (txtUserType.Text != "manager" && txtUserType.Text != "customer")
            {
                MessageBox.Show("Type deve ser ou 'manager' ou 'customer'");
            }

            if(txtState.Text != "Ceará" && txtState.Text != "CE")
            {
                MessageBox.Show("No momento estamos disponíveis apenas no Ceará (CE).");
            }

            if (txtCity.Text != "Sobral")
            {
                MessageBox.Show("No momento estamos disponíveis apenas em Sobral.");
            }

            if (txtNeighborhood.Text != "Alto da Brasília" &&
                txtNeighborhood.Text != "Alto do Cristo" &&
                txtNeighborhood.Text != "Antônio Carlos Belchior" &&
                txtNeighborhood.Text != "Betânia" &&
                txtNeighborhood.Text != "Campo dos Velhos (Parque Alvorada)" &&
                txtNeighborhood.Text != "Centro" &&
                txtNeighborhood.Text != "Cidade Dr. José Euclides Ferreira Gomes (Terrenos Novos)" &&
                txtNeighborhood.Text != "Cidade Pedro Mendes Carneiro (Cohab III)" &&
                txtNeighborhood.Text != "Cohab I" &&
                txtNeighborhood.Text != "Cohab II" &&
                txtNeighborhood.Text != "Coração de Jesus" &&
                txtNeighborhood.Text != "Distrito Industrial" &&
                txtNeighborhood.Text != "Dom José (Alto Novo)" &&
                txtNeighborhood.Text != "Dom Expedito (Feitosa)" &&
                txtNeighborhood.Text != "Domingos Olímpio" &&
                txtNeighborhood.Text != "Expectativa" &&
                txtNeighborhood.Text != "Jatobá" &&
                txtNeighborhood.Text != "Jerônimo de Medeiros Prado" &&
                txtNeighborhood.Text != "Jocely Dantas de Andrade Torres" &&
                txtNeighborhood.Text != "Junco" &&
                txtNeighborhood.Text != "Juvêncio de Andrade" &&
                txtNeighborhood.Text != "Novo Recanto" &&
                txtNeighborhood.Text != "Padre Ibiapina" &&
                txtNeighborhood.Text != "Padre Palhano" &&
                txtNeighborhood.Text != "Nova Caiçara" &&
                txtNeighborhood.Text != "Cidade Gerardo Cristino de Menezes" &&
                txtNeighborhood.Text != "Parque Silvana" &&
                txtNeighborhood.Text != "Pedrinhas" &&
                txtNeighborhood.Text != "Edmundo Monte Coelho" &&
                txtNeighborhood.Text != "Nossa Senhora de Fátima" &&
                txtNeighborhood.Text != "Juazeiro" &&
                txtNeighborhood.Text != "Renato Parente" &&
                txtNeighborhood.Text != "Sinhá Sabóia" &&
                txtNeighborhood.Text != "Várzea Grande" &&
                txtNeighborhood.Text != "Vila União" &&
                txtNeighborhood.Text != "Sumaré")
            {
                MessageBox.Show("Estamos funcionando apenas em Sobral, por favor escolha um bairro da região: \"Alto da Brasília\", \"Alto do Cristo\", \"Antônio Carlos Belchior\", \"Betânia\", \"Campo dos Velhos (Parque Alvorada)\", \"Centro\", \"Cidade Dr. José Euclides Ferreira Gomes (Terrenos Novos)\", \"Cidade Pedro Mendes Carneiro (Cohab III)\", \"Cohab I\", \"Cohab II\", \"Coração de Jesus\", \"Distrito Industrial\", \"Dom José (Alto Novo)\", \"Dom Expedito (Feitosa)\", \"Domingos Olímpio\", \"Expectativa\", \"Jatobá\", \"Jerônimo de Medeiros Prado\", \"Jocely Dantas de Andrade Torres\", \"Junco\", \"Juvêncio de Andrade\", \"Novo Recanto\", \"Padre Ibiapina\", \"Padre Palhano\", \"Nova Caiçara\", \"Cidade Gerardo Cristino de Menezes\", \"Parque Silvana\", \"Pedrinhas\", \"Edmundo Monte Coelho\", \"Nossa Senhora de Fátima\", \"Juazeiro\", \"Renato Parente\", \"Sinhá Sabóia\", \"Várzea Grande\", \"Vila União\", \"Sumaré\"");
            }

            // Obter o nome, e-mail, senha e tipo de usuário digitados pelo usuário
            string name = txtNameRegister.Text;
            string email = txtEmailRegister.Text;
            string password = txtPasswordRegister.Text;
            string type = txtUserType.Text;
            string state = txtState.Text;
            string city = txtCity.Text;
            string neighborhood = txtNeighborhood.Text;
            string street = txtStreet.Text;
            string street_number = txtStreetNumber.Text;
            string complement = txtComplement.Text;


            // Verificar se já existe um usuário "manager" cadastrado
            if (type.Equals("manager"))
            {
                // Abrir a conexão com o banco de dados PostgreSQL
                using (NpgsqlConnection connection = new NpgsqlConnection(db.connectionString))
                {
                    try
                    {
                        connection.Open();

                        string sql = "SELECT COUNT(*) FROM users WHERE type = 'manager'";

                        // Criar um objeto NpgsqlCommand com a consulta SQL
                        using (NpgsqlCommand command = new NpgsqlCommand(sql, connection))
                        {
                            // Executar a consulta e obter o número de registros correspondentes
                            int count = Convert.ToInt32(command.ExecuteScalar());

                            if (count > 0)
                            {
                                MessageBox.Show("Já existe um usuário 'manager' cadastrado no sistema.");
                                return;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao verificar se já existe um usuário 'manager' cadastrado: {ex.Message}");
                        return;
                    }
                }
            }

            // Validar entrada do usuário
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, preencha todos os campos obrigatórios.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Por favor, insira um endereço de email válido.");
                return;
            }

            // Abrir a conexão com o banco de dados PostgreSQL
            using (NpgsqlConnection connection = new NpgsqlConnection(db.connectionString))
            {
                try
                {
                    connection.Open();
                    
                    // Definir a consulta SQL para inserir um novo usuário
                    string insertSql = "INSERT INTO users (name, email, password, type) VALUES (@name, @email, @password, @type)";
                    
                    // Criar um objeto NpgsqlCommand com a consulta SQL e os parâmetros
                    using (NpgsqlCommand command = new NpgsqlCommand(insertSql, connection))
                    {
                        
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@password", password);
                        command.Parameters.AddWithValue("@type", type);

                        // Executar a consulta
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Usuário cadastrado com sucesso!");
                        }
                        else
                        {
                            MessageBox.Show("Erro ao cadastrar usuário. Tente novamente.");
                        }
                    }

                    string insertSqlAddress = "INSERT INTO addresses (customer_id, state, city, neighborhood, street, street_number, complement) VALUES (@customer_id, @state, @city, @neighborhood, @street, @street_number, @complement)";

                    string sqlGetLastCustomerId = "SELECT id FROM users ORDER BY created_at DESC LIMIT 1";

                    NpgsqlCommand cmdGetLastUserId = new NpgsqlCommand(sqlGetLastCustomerId, connection);

                    Guid customer_id = (Guid)cmdGetLastUserId.ExecuteScalar();

                    using (NpgsqlCommand command = new NpgsqlCommand(insertSqlAddress, connection))
                    {
                        command.Parameters.AddWithValue("@customer_id", customer_id);
                        command.Parameters.AddWithValue("@state", state);
                        command.Parameters.AddWithValue("@city", city);
                        command.Parameters.AddWithValue("@neighborhood", neighborhood);
                        command.Parameters.AddWithValue("@street", street);
                        command.Parameters.AddWithValue("@street_number", street_number);
                        command.Parameters.AddWithValue("@complement", complement);

                        // Executar a consulta
                        int rowsAffected = command.ExecuteNonQuery();
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar usuário: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }



            // Limpar os campos do formulário
            txtNameRegister.Clear();
            txtEmailRegister.Clear();
            txtPasswordRegister.Clear();
            txtUserType.Clear();
            txtState.Clear();
            txtCity.Clear();
            txtNeighborhood.Clear();
            txtStreet.Clear();
            txtStreetNumber.Clear();
            txtComplement.Clear();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }
    }
}
