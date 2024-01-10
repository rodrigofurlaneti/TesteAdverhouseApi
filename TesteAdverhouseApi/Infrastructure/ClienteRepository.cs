using System.Data;
using System.Data.SqlClient;
using System.Data;
using TesteAdverhouseApi.Model;

namespace TesteAdverhouseApi.Infrastructure
{
    public class ClienteRepository : BaseRepository
    {
        #region Methods 

        public IEnumerable<ClienteModel> GetAll()
        {
            try
            {
                List<ClienteModel> listClienteModel = new List<ClienteModel>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_Client_Adverhouse_GetAll", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ClienteModel ClienteModel = new ClienteModel();
                        ClienteModel.Id = Convert.ToInt32(rdr["Id"]);
                        ClienteModel.NomeCliente = Convert.ToString(rdr["NomeCliente"]);
                        ClienteModel.RazaoSocial = Convert.ToString(rdr["RazaoSocial"]);
                        ClienteModel.Cnpj = Convert.ToString(rdr["Cnpj"]);
                        ClienteModel.CodigoCnae = Convert.ToString(rdr["CodigoCnae"]);
                        ClienteModel.Endereco = Convert.ToString(rdr["Endereco"]);
                        listClienteModel.Add(ClienteModel);
                    }
                }
                return listClienteModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_Client_Adverhouse_GetAll síncrono " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<IEnumerable<ClienteModel>> GetAllAsync()
        {
            List<ClienteModel> listClienteModel = new List<ClienteModel>();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_BuyerGetAll", con))
                try
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        ClienteModel ClienteModel = new ClienteModel();
                        ClienteModel.NomeCliente = Convert.ToString(rdr["NomeCliente"]);
                        ClienteModel.RazaoSocial = Convert.ToString(rdr["RazaoSocial"]);
                        ClienteModel.Cnpj = Convert.ToString(rdr["Cnpj"]);
                        ClienteModel.CodigoCnae = Convert.ToString(rdr["CodigoCnae"]);
                        ClienteModel.Endereco = Convert.ToString(rdr["Endereco"]);
                        listClienteModel.Add(ClienteModel);
                    }
                    return listClienteModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_BuyerGetAll assíncrono " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }
        
        public ClienteModel GetById(int id)
        {
            try
            {
                ClienteModel ClienteModel = new ClienteModel();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("USP_Client_Adverhouse_GetById", con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        ClienteModel.Id = Convert.ToInt32(rdr["Id"]);
                        ClienteModel.NomeCliente = Convert.ToString(rdr["NomeCliente"]);
                        ClienteModel.RazaoSocial = Convert.ToString(rdr["RazaoSocial"]);
                        ClienteModel.Cnpj = Convert.ToString(rdr["Cnpj"]);
                        ClienteModel.CodigoCnae = Convert.ToString(rdr["CodigoCnae"]);
                        ClienteModel.Endereco = Convert.ToString(rdr["Endereco"]);
                    }
                }
                return ClienteModel;
            }
            catch (ArgumentNullException ex)
            {
                string mensagemErro = "Erro ao consumir a procedure USP_Client_Adverhouse_GetById, síncrono. " + ex.Message;
                throw new ArgumentNullException(mensagemErro);
            }

        }

        public async Task<ClienteModel> GetByIdAsync(int id)
        {
            ClienteModel ClienteModel = new ClienteModel();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("USP_Client_Adverhouse_GetById", con))
                try
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader rdr = await cmd.ExecuteReaderAsync();
                    while (rdr.Read())
                    {
                        ClienteModel.Id = Convert.ToInt32(rdr["Id"]);
                        ClienteModel.NomeCliente = Convert.ToString(rdr["NomeCliente"]);
                        ClienteModel.RazaoSocial = Convert.ToString(rdr["RazaoSocial"]);
                        ClienteModel.Cnpj = Convert.ToString(rdr["Cnpj"]);
                        ClienteModel.CodigoCnae = Convert.ToString(rdr["CodigoCnae"]);
                        ClienteModel.Endereco = Convert.ToString(rdr["Endereco"]);
                    }
                    return ClienteModel;
                }
                catch (ArgumentNullException ex)
                {
                    string mensagemErro = "Erro ao consumir a procedure USP_BuyerGetId, assíncrono. " + ex.Message;
                    throw new ArgumentNullException(mensagemErro);
                }
        }

        public void Insert(ClienteModel ClienteModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_Client_Adverhouse_Insert", con);
            cmd.Parameters.AddWithValue("@NomeCliente", ClienteModel.NomeCliente);
            cmd.Parameters.AddWithValue("@RazaoSocial", ClienteModel.RazaoSocial);
            cmd.Parameters.AddWithValue("@Cnpj", ClienteModel.Cnpj);
            cmd.Parameters.AddWithValue("@CodigoCnae", ClienteModel.CodigoCnae);
            cmd.Parameters.AddWithValue("@Endereco", ClienteModel.Endereco);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public async Task InsertAsync(ClienteModel ClienteModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BuyerInsert", con);
            cmd.Parameters.AddWithValue("@NomeCliente", ClienteModel.NomeCliente);
            cmd.Parameters.AddWithValue("@RazaoSocial", ClienteModel.RazaoSocial);
            cmd.Parameters.AddWithValue("@Cnpj", ClienteModel.Cnpj);
            cmd.Parameters.AddWithValue("@CodigoCnae", ClienteModel.CodigoCnae);
            cmd.Parameters.AddWithValue("@Endereco", ClienteModel.Endereco);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Delete(int buyerId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_Client_Adverhouse_Delete", con);
            cmd.Parameters.AddWithValue("@Id", buyerId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public async Task DeleteAsync(int buyerId)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_Client_Adverhouse_Delete", con);
            cmd.Parameters.AddWithValue("@Id", buyerId);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        public void Update(ClienteModel ClienteModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BuyerUpdate", con);
            cmd.Parameters.AddWithValue("@Id", ClienteModel.Id);
            cmd.Parameters.AddWithValue("@NomeCliente", ClienteModel.NomeCliente);
            cmd.Parameters.AddWithValue("@RazaoSocial", ClienteModel.RazaoSocial);
            cmd.Parameters.AddWithValue("@Cnpj", ClienteModel.Cnpj);
            cmd.Parameters.AddWithValue("@CodigoCnae", ClienteModel.CodigoCnae);
            cmd.Parameters.AddWithValue("@Endereco", ClienteModel.Endereco);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public async Task UpdateAsync(ClienteModel ClienteModel)
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("USP_BuyerUpdate", con);
            cmd.Parameters.AddWithValue("@Id", ClienteModel.Id);
            cmd.Parameters.AddWithValue("@NomeCliente", ClienteModel.NomeCliente);
            cmd.Parameters.AddWithValue("@RazaoSocial", ClienteModel.RazaoSocial);
            cmd.Parameters.AddWithValue("@Cnpj", ClienteModel.Cnpj);
            cmd.Parameters.AddWithValue("@CodigoCnae", ClienteModel.CodigoCnae);
            cmd.Parameters.AddWithValue("@Endereco", ClienteModel.Endereco);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }

        #endregion
    }
}