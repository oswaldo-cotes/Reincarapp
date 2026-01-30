using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;  
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reincarapp.Models.MyModels;

namespace Reincarapp
{
    public class DataAccessMySql
    {
        private string _strConn;
        public MySqlConnection _conn = new MySqlConnection();
        private MySqlCommand _Comm = new MySqlCommand();
        private MySqlDataAdapter _DataAdapder = new MySqlDataAdapter();

        public object Data { get; private set; }



        public DataAccessMySql(string strCn)
        {
            //Produccion
            this._strConn = strCn;
            //-------------
            //Pruebas
            //Me._strConn = "Data Source=10.10.100.43;database=PR_PREFACTURA;user=issadm;password=issadm123"
            //-------------
        }
        public void Open()
        {
            if (this._strConn.Length == 0)
            {
                throw new System.Exception("Unable to establish connection to database.");
                return;
            }
            try
            {
                this._conn.ConnectionString = _strConn;
                if (this._conn.State == ConnectionState.Open)
                {
                    this._conn.Close();
                }
                this._conn.Open();
            }
            catch (MySqlException ex)
            {
                throw new System.Exception(ex.Message);
            }
        }
        public void Close()
        {
            try
            {
                if (_conn.State == ConnectionState.Open)
                {
                    _conn.Close();
                }
            }
            catch (MySqlException ex)
            {
            }
        }


        public async Task<DataTable> q2Dt(string strSQL)
        {
            try
            {

                this._Comm = new MySqlCommand(strSQL, this._conn);
                this._Comm.CommandTimeout = 0;
                DataTable myDataTable = new DataTable();
                this._DataAdapder = new MySqlDataAdapter(this._Comm);
                this._Comm.CommandType = CommandType.Text;
                this._Comm.CommandTimeout = 86400;
                await this._DataAdapder.FillAsync(myDataTable);
                return myDataTable;
            }
            catch (MySqlException ex)
            {
                throw new System.Exception(ex.Message);
                return null;
            }
            finally
            {
                //Me._Comm = Nothing
            }
        }



        public void execSp(string spName, object[] inValues, ref MySqlCommand cmd)
        {
            try
            {
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 0; i <= cmd.Parameters.Count - 1; i++)
                {
                    if (cmd.Parameters[i].Direction == ParameterDirection.InputOutput)
                    {
                        cmd.Parameters[i].Direction = ParameterDirection.Output;
                    }
                    else if (cmd.Parameters[i].Direction == ParameterDirection.Input)
                    {
                        cmd.Parameters[i].Value = inValues[i - 1];
                    }
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            }
        }
        public MySqlCommand execSp(string spName, object[] inValues, MySqlTransaction Tr)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                cmd.Transaction = Tr;
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 0; i <= cmd.Parameters.Count - 1; i++)
                {
                    if (cmd.Parameters[i].Direction == ParameterDirection.InputOutput)
                    {
                        cmd.Parameters[i].Direction = ParameterDirection.Output;
                    }
                    else if (cmd.Parameters[i].Direction == ParameterDirection.Input)
                    {
                        cmd.Parameters[i].Value = inValues[i - 1];
                    }
                }
                cmd.ExecuteNonQuery();
                return cmd;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public MySqlCommand execSp(string spName, object[] inValues)
        {
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 0; i <= cmd.Parameters.Count - 1; i++)
                {
                    if (cmd.Parameters[i].Direction == ParameterDirection.InputOutput)
                    {
                        cmd.Parameters[i].Direction = ParameterDirection.Output;
                    }
                    else if (cmd.Parameters[i].Direction == ParameterDirection.Input)
                    {
                        cmd.Parameters[i].Value = inValues[i - 1];
                    }
                }
                cmd.ExecuteNonQuery();
                return cmd;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public MySqlCommand execSpPc(string spName, object[] paramsC)
        {
            MySqlCommand cmd = new MySqlCommand(spName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            try
            {
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 0; i <= cmd.Parameters.Count - 1; i++)
                {
                    if (cmd.Parameters[i].Direction == ParameterDirection.Input)
                    {
                        cmd.Parameters[i].Value = paramsC[i];
                    }
                }
                cmd.ExecuteNonQuery();
                return cmd;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public MySqlCommand execSpPc(string spName, object[] paramsC, ref string Msg)
        {
            MySqlCommand cmd = new MySqlCommand(spName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 120;
            try
            {
                MySqlCommandBuilder.DeriveParameters(cmd);

                int i = 0;
                foreach (MySqlParameter param in cmd.Parameters)
                    if (param.Direction == ParameterDirection.InputOutput)
                    {
                        param.Direction = ParameterDirection.Output;
                    }
                    else if (param.Direction == ParameterDirection.Input)
                    {
                        param.Value = paramsC[i];
                        i++;
                    }

                cmd.ExecuteNonQuery();
                return cmd;
            }
            catch (Exception ex)
            {
                Msg = ex.Message;
                return null;
            }
        }
        public MySqlCommand execSpPcNet(string spName, object[] paramsC)
        {
            MySqlCommand cmd = new MySqlCommand(spName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 0; i <= cmd.Parameters.Count - 1; i++)
                {
                    if (cmd.Parameters[i].Direction == ParameterDirection.Input)
                    {
                        cmd.Parameters[i].Value = paramsC[i];
                    }
                }
                cmd.ExecuteNonQuery();
                return cmd;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public DataTable execSpPcRetTbl(string spName, object[] paramsC)
        {
            MySqlCommand cmd = new MySqlCommand(spName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 86400;
            DataTable dt = new DataTable();
            try
            {
                MySqlCommandBuilder.DeriveParameters(cmd);

                int i = 0;
                foreach (MySqlParameter param in cmd.Parameters)
                    if (param.Direction == ParameterDirection.InputOutput)
                    {
                        param.Direction = ParameterDirection.Output;
                    }
                    else if (param.Direction == ParameterDirection.Input)
                    {
                        param.Value = paramsC[i];
                        i++;
                    }



                //for (int i = 0; i <= cmd.Parameters.Count - 1; i++)
                //{

                //    if (cmd.Parameters[i].Direction == ParameterDirection.InputOutput)
                //    {
                //        cmd.Parameters[i].Direction = ParameterDirection.Output;
                //    }
                //    else if (cmd.Parameters[i].Direction == ParameterDirection.Input)
                //    {
                //        cmd.Parameters[i].Value = paramsC[i];
                //    }



                //}

                dt.Load(cmd.ExecuteReader());
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static async Task<DataTable> execSpPcRetTbl2(string spName, object[] paramsC, string strConn)
        {
            MySqlConnection lcConn = new MySqlConnection(strConn);
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();
            try
            {
                lcConn.Open();
                cmd.Connection = lcConn;
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 300;
                MySqlCommandBuilder.DeriveParameters(cmd);
                int i = 0;
                foreach (MySqlParameter param in cmd.Parameters)
                {
                    if (param.Direction == ParameterDirection.InputOutput)
                    {
                        param.Direction = ParameterDirection.Output;
                    }
                    else if (param.Direction == ParameterDirection.Input)
                    {
                        param.Value = paramsC[i];
                        i++;
                    }
                }
                dt.Load(await cmd.ExecuteReaderAsync());
            }
            catch (Exception ex)
            {

            }
            finally
            {
                lcConn.Close();
            }
            return dt;
        }


        public async static Task<DataTable> execSpPcRetTbl3(string spName, object[] paramsC, string strConn)
        {
            MySqlConnection lcConn = new MySqlConnection(strConn);
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();
            try
            {
                lcConn.Open();
                cmd.Connection = lcConn;
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlCommandBuilder.DeriveParameters(cmd);
                int i = 0;
                foreach (MySqlParameter param in cmd.Parameters)
                {
                    if (param.Direction == ParameterDirection.InputOutput)
                    {
                        param.Direction = ParameterDirection.Output;
                    }
                    else if (param.Direction == ParameterDirection.Input)
                    {
                        param.Value = paramsC[i];
                        i++;
                    }
                }
                dt.Load(cmd.ExecuteReader());
            }
            catch (Exception ex)
            {

            }
            finally
            {
                lcConn.Close();
            }
            return dt;
        }

        public static Message execSpPcRetJson(string spName, object[] paramsC, string strConn)
        {
            MySqlConnection lcConn = new MySqlConnection(strConn);
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();
            Message msg = new Message();
            try
            {
                lcConn.Open();
                cmd.Connection = lcConn;
                cmd.CommandText = spName;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 86400;
                MySqlCommandBuilder.DeriveParameters(cmd);
                int i = 0;
                foreach (MySqlParameter param in cmd.Parameters)
                {

                    if (param.Direction == ParameterDirection.InputOutput)
                    {
                        param.Direction = ParameterDirection.Output;
                    }
                    else if (param.Direction == ParameterDirection.Input)
                    {
                        param.Value = paramsC[i];
                        i++;
                    }

                }
                dt.Load(cmd.ExecuteReader());
                if (dt.Rows.Count > 0)
                {
                     msg.IsSuccess = true;
                     msg.ReturnMessage = "OK";
                     msg.Data = JsonConvert.SerializeObject(dt);
                }
                else
                {
                    msg.IsSuccess = false;
                    msg.ReturnMessage = "Sin registros";
                    msg.Data = "";
                }
            }
            catch (Exception ex)
            {
                msg.IsSuccess = false;
                msg.ReturnMessage = ex.Message;
                msg.Data = "";
            }
            finally
            {
                lcConn.Close();
            }
            return msg;
        }


        public DataSet execSpPcRetDs(string spName, object[] paramsC)
        {
            MySqlCommand cmd = new MySqlCommand(spName, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 86400;
            DataSet ds = new DataSet();
            try
            {
                MySqlCommandBuilder.DeriveParameters(cmd);
                for (int i = 0; i <= cmd.Parameters.Count - 1; i++)
                {
                    if (cmd.Parameters[i].Direction == ParameterDirection.InputOutput)
                    {
                        cmd.Parameters[i].Direction = ParameterDirection.Output;
                    }
                    else if (cmd.Parameters[i].Direction == ParameterDirection.Input)
                    {
                        cmd.Parameters[i].Value = paramsC[i];
                    }
                }
                this._DataAdapder = new MySqlDataAdapter(cmd);
                this._DataAdapder.Fill(ds, "myDt");
                return ds;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public DataTable execSpPcRetTbl(string spName, object[] paramsC, ref MySqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                cmd.CommandTimeout = 86400;
                MySqlCommandBuilder.DeriveParameters(cmd);

                for (int i = 0; i <= cmd.Parameters.Count - 1; i++)
                {
                    //If cmd.Parameters[i].SqlDbType = SqlDbType.Structured Then
                    //    Dim typeName As String = cmd.Parameters[i].TypeName
                    //    typeName = typeName.Substring(typeName.IndexOf(".") + 1)
                    //    If typeName.Contains(".") Then
                    //        cmd.Parameters[i].TypeName = typeName
                    //    End If
                    //End If


                    if (cmd.Parameters[i].Direction == ParameterDirection.InputOutput)
                    {
                        cmd.Parameters[i].Direction = ParameterDirection.Output;
                    }
                    else if (cmd.Parameters[i].Direction == ParameterDirection.Input)
                    {
                        cmd.Parameters[i].Value = paramsC[i];
                    }



                }

                dt.Load(cmd.ExecuteReader());
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public MySqlCommand execSpPcWithTbl(string spName, object[] paramsC)
        {
            MySqlCommand cmd = new MySqlCommand();
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = _conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = spName;
                cmd.CommandTimeout = 86400;
                MySqlCommandBuilder.DeriveParameters(cmd);

                for (int i = 0; i <= cmd.Parameters.Count - 1; i++)
                {
                    //If cmd.Parameters[i].SqlDbType = SqlDbType.Structured Then
                    //    Dim typeName As String = cmd.Parameters[i].TypeName
                    //    typeName = typeName.Substring(typeName.IndexOf(".") + 1)
                    //    If typeName.Contains(".") Then
                    //        cmd.Parameters[i].TypeName = typeName
                    //    End If
                    //End If


                    if (cmd.Parameters[i].Direction == ParameterDirection.InputOutput)
                    {
                        cmd.Parameters[i].Direction = ParameterDirection.Output;
                    }
                    else if (cmd.Parameters[i].Direction == ParameterDirection.Input)
                    {
                        cmd.Parameters[i].Value = paramsC[i - 1];
                    }



                }

                cmd.ExecuteNonQuery();
                return cmd;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + "Error Ejecutando Insercion En Bd Referencia");
            }
        }



    }
}

