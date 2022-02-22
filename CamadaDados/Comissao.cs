using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaDados
{
    public class Comissao
    {

        public static bool Gravar(int idEmpregado,
                                  byte idMensagem, decimal valor,
                                  out string erro)
        {
            erro = string.Empty;
            bool ok = true;

            try
            {
                SqlConnection sqlConnection = Database.OpenDatabase();

                SqlCommand sqlCommand = new SqlCommand("Gravar", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter sqlParameter = sqlCommand.Parameters.Add("IDEmpregado", System.Data.SqlDbType.Int);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = idEmpregado;

                sqlParameter = sqlCommand.Parameters.Add("IDMensagem", System.Data.SqlDbType.TinyInt);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = idMensagem;

                sqlParameter = sqlCommand.Parameters.Add("Valor", System.Data.SqlDbType.Decimal);
                sqlParameter.Direction = System.Data.ParameterDirection.Input;
                sqlParameter.Value = valor;

                sqlCommand.ExecuteNonQuery();

                sqlParameter = null;
                sqlCommand.Dispose();
                sqlConnection.Close();

            }
            catch (Exception ex)
            {
                erro = ex.Message;
                ok = false;
            }
            return ok;
        }
    }
}