using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace CantinaDoTioBill
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Criar uma conexão com o banco de dados
            var connectionString = "Host=localhost;Username=postgres;Password=1234;Database=cantina_do_tio_bill";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                // Abrir a conexão
                connection.Open();

                // Executar uma consulta
                var command = new NpgsqlCommand("SELECT * FROM users", connection);
                using (var reader = command.ExecuteReader())
                {
                    // Ler os resultados e adicionar ao ListBox
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader.GetString(3) + " " + reader.GetString(1) + " " + reader.GetString(2));
                    }
                }

                // Fechar a conexão
                connection.Close();
            }
        }
    }
}
