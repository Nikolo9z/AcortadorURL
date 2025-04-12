using AcortadorURL.Modelo.InsertURL;
using Npgsql;

namespace AcortadorURL.Data
{
    public class InsertURL
    {
        private readonly string _connectionString;

        // Constructor que obtiene la cadena de conexión desde la configuración
        public InsertURL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ResponseInsertURL InsertarURL(RequestInsertURL url)
        {
            ResponseInsertURL response = new ResponseInsertURL();

            // Abrir conexión con PostgreSQL
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                // Llamar a la función almacenada
                using (NpgsqlCommand command = new NpgsqlCommand("SELECT insert_url(@OriginalUrl)", connection))
                {
                    // Agregar el parámetro de entrada
                    command.Parameters.AddWithValue("@OriginalUrl", url.URL);

                    // Ejecutar y leer el resultado
                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        response.ShortURL = result.ToString();
                    }
                    else
                    {
                        throw new Exception("No se pudo generar la URL corta.");
                    }
                }
            }

            return response;
        }
    }
}
