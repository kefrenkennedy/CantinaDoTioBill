using Npgsql;
using System.Data;

public class PostgreSQL
{
    public string connectionString;


    public PostgreSQL()
    {
        connectionString = "Host=localhost;Username=postgres;Password=1234;Database=cantina_do_tio_bill";
    }

    public DataTable Query(string sql)
    {
        DataTable dt = new DataTable();

        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                da.Fill(dt);
            }
        }

        return dt;
    }

    public void Execute(string sql)
    {
        using (NpgsqlConnection conn = new NpgsqlConnection(connectionString))
        {
            conn.Open();

            using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
