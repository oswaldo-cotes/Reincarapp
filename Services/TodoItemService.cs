  
   
    using Microsoft.EntityFrameworkCore;
    using MySql.Data.MySqlClient;
    using Newtonsoft.Json;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    using Reincarapp.Data;
    using Reincarapp.Models.MyModels;
    using Reincarapp.Models.reincardb;
    using System.Data;
    using System.Linq.Dynamic.Core;
    using System.Text.RegularExpressions;

namespace Reincarapp
{
    public class TodoItemService
    {
        private readonly IConfiguration configuration;
        private readonly reincardbContext db;
        private readonly string connectionString;
        
        public Usuario usuario { get; set; }
        public string ErrorDefUsuario { private set; get; } = "OK";

        public TodoItemService(IConfiguration configuration, reincardbContext db)
        {
            this.configuration = configuration;
            this.db = db;
            this.connectionString = configuration["ConnectionStrings:reincardbConnection"];
        }

        public async Task<Usuario> SetUsuario(string email)
        {
            try
            {
                var local_usr = await db.Usuario.Include(x => x.UsuarioRol).Include(x => x.UsuarioCliente).ThenInclude(x => x.Cliente).Where(x => x.Correo_Electronico == email).FirstOrDefaultAsync();

                if (local_usr != null)
                {
                    
                }
                else
                {
                    ErrorDefUsuario = "Usuario no ha sido relacionado usando el correo electronico";
                }

                return local_usr;
            }
            catch(Exception ex)
            {
                return null;
            }
        }


        /// <summary>
        /// Generic method to execute stored procedures that return JSON data and deserialize to specified type
        /// </summary>
        /// <typeparam name="T">The type to deserialize the JSON response to</typeparam>
        /// <param name="storedProcedureName">Name of the stored procedure to execute</param>
        /// <param name="parameters">Parameters to pass to the stored procedure</param>
        /// <returns>Task containing a list of the specified type T</returns>
        public async Task<List<T>> SpGet<T>(string storedProcedureName, object[] parameters)
        {
            List<T> result = new List<T>();
            try
            {
              

                Message msg = DataAccessMySql.execSpPcRetJson(storedProcedureName, parameters, connectionString);
                if (msg.IsSuccess && !string.IsNullOrEmpty(msg.Data))
                {
                    result = JsonConvert.DeserializeObject<List<T>>(msg.Data);
                }
            }
            catch (Exception ex)
            {
                await AddExc(0, $"TodoItemService.SpGet<{typeof(T).Name}>", $"{ex.Message} | SP: {storedProcedureName} | {ex.StackTrace}");
            }
            return result;
        }

        public async Task<DataTable> GetDataSPDt(string spName, object[] parametros)
        {
            var dt = new DataTable();
            try
            {

                dt = await DataAccessMySql.execSpPcRetTbl2(spName, parametros, connectionString);

            }
            catch (Exception ex)
            {

            }
            return dt;
        }


        public Task<List<Valores>> SpGetGestionesCons(object[] _params)
        {
            List<Valores> lstRet = new List<Valores>();
            try
            {
                                Message msg = DataAccessMySql.execSpPcRetJson("SpGetGestionesCons", _params, connectionString);
                if (msg.IsSuccess && msg.Data != "")
                {
                    lstRet = JsonConvert.DeserializeObject<List<Valores>>(msg.Data);
                }
            }
            catch (Exception ex)
            {

            }
            return Task.FromResult(lstRet);
        }

        public Task<List<ValoresN>> SpGetTareasCons(object[] _params)
        {
            List<ValoresN> lstRet = new List<ValoresN>();
            try
            {
                Message msg = DataAccessMySql.execSpPcRetJson("SpGetTareasCons", _params, connectionString);
                if (msg.IsSuccess && msg.Data != "")
                {
                    lstRet = JsonConvert.DeserializeObject<List<ValoresN>>(msg.Data);
                }
            }
            catch (Exception ex)
            {

            }
            return Task.FromResult(lstRet);
        }

        public Task<List<RepartoDet>> GetRepartoGenDet(object pv_id_usuario, object pv_subreparto, object pv_id_cliente)
        {
            List<RepartoDet> lstRet = new List<RepartoDet>();

            var lc_id_usuario = pv_id_usuario == DBNull.Value ? pv_id_usuario : pv_id_usuario.ToString() == "todos" ? DBNull.Value : pv_id_usuario;
            var lc_subreparto = pv_subreparto == DBNull.Value ? pv_subreparto : pv_subreparto.ToString() == "todos" ? DBNull.Value : pv_subreparto;

            try
            {
                Message msg = DataAccessMySql.execSpPcRetJson("SP_GET_REPARTO_GEN_DET", new object[] { lc_id_usuario, lc_subreparto, pv_id_cliente }, connectionString);
                if (msg.IsSuccess && msg.Data != "")
                {
                    lstRet = JsonConvert.DeserializeObject<List<RepartoDet>>(msg.Data);
                }
            }
            catch (Exception ex)
            {

            }
            return Task.FromResult(lstRet);
        }

        public Task<List<Reparto>> GetRepartoGen(object pv_id_usuario, object pv_id_cliente)
        {
            List<Reparto> lstRet = new List<Reparto>();

            var lc_id_usuario = pv_id_usuario == DBNull.Value ? pv_id_usuario : pv_id_usuario.ToString() == "todos" ? DBNull.Value : pv_id_usuario;

            try
            {
                Message msg = DataAccessMySql.execSpPcRetJson("SP_GET_REPARTO_GEN", new object[] { lc_id_usuario, pv_id_cliente }, connectionString);
                if (msg.IsSuccess && msg.Data != "")
                {
                    lstRet = JsonConvert.DeserializeObject<List<Reparto>>(msg.Data);
                }
            }
            catch (Exception ex)
            {

            }
            return Task.FromResult(lstRet);
        }

        public async Task AddExc(long idUsuario, string proc, string texto)
        {
            try
            {
                using (reincardbContext db = new reincardbContext())
                {
                    await db.Logapp.AddAsync(new Logapp() { IdUsuario = idUsuario, Proc = proc, Texto = texto, FechaCreacion = DateTime.Now });
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<string> InsertarLineaGen(Cliente idCliente, MySqlCommand cmd, DataRow dato, Base _base)
        {
            string res = "OK";

            try
            {
                var dict = dato.Table.Columns
                     .Cast<DataColumn>()
                     .ToDictionary(c => c.ColumnName, c => dato[c] == null ? "" : dato[c].ToString().Trim());

                cmd.Parameters["@pv_id_cliente"].Value = idCliente.Id_Cliente;

                if (_base.Basecampo.Count() == 0)
                {
                    throw new Exception("No se han configurado campos");
                }

                foreach (var campo in _base.Basecampo)
                {
                    cmd.Parameters[campo.Campoclave.NombreInterno].Value = dato[campo.Nombre] == null ? "" : dato[campo.Nombre].ToString();
                }

                if (cmd.Parameters["@pv_valor"].Value == null)
                {
                    cmd.Parameters["@pv_valor"].Value = 0;
                }

                if (cmd.Parameters["@pv_nombre"].Value == null)
                {
                    cmd.Parameters["@pv_nombre"].Value = "";
                }

                cmd.Parameters["@pv_dato"].Value = JsonConvert.SerializeObject(dict);

                await cmd.ExecuteNonQueryAsync();

                if (cmd.Parameters["@pv_mensaje"].Value.ToString() != "OK")
                {
                    res = "Excepcion Controlada " + cmd.Parameters["@pv_mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
                await AddExc(0, "TodoItemService.InsertarLinea", ex.Message + " " + ex.StackTrace);
            }

            return res;
        }

        public async Task<string> InsertarLinea(Cliente idCliente, MySqlCommand cmd, DataRow dr, DataColumnCollection dcC, string idTipoCargue)
        {
            List<object> _params = new List<Object>();
            List<long> clientes_directos = new List<long>() { 1, 20, 23 };
            List<long> clientes_coomultrasan = new List<long>() { 7, 58, 59 };
            List<string> pa = new List<string>();
            string res = "OK";

            try
            {
                // Validacion de notacion cientifica
                foreach (DataColumn c in dcC)
                {
                    if ((dr[c.ColumnName] ?? "").ToString().Length <= 20 && (dr[c.ColumnName] ?? "").ToString().ToUpper().Contains("E+"))
                    {
                        throw new Exception("Campo " + c.ColumnName + ": " + (dr[c.ColumnName] ?? "").ToString() + " contiene un valor en notacion cientifica");
                    }
                }

                // Validacion de documento de persona
                string doc = "";

                Dictionary<long, string> campos = new Dictionary<long, string>()
                {
                    {50,"cedula"},
                    {6,"documento"},
                    {10,"documento"}
                };

                if (campos.ContainsKey(idCliente.Id_Cliente) && idTipoCargue == "1")
                {
                    if (campos.ContainsKey(idCliente.Id_Cliente))
                    {
                        doc = dr[campos[idCliente.Id_Cliente]].ToString();
                    }

                    if (string.IsNullOrEmpty(doc))
                    {
                        throw new Exception("numero de cedula de la persona esta vacio ");
                    }
                    else
                    {
                        if (isAlphaNumeric(doc))
                        {
                            throw new Exception("numero de cedula de la persona esta en un formato no valido debe contener solo letras y numeros " + doc);
                        }
                    }
                }

                if (idTipoCargue == "1")
                {
                    if (clientes_directos.Contains(idCliente.Id_Cliente) || idCliente.id_tipo_cliente == 2)
                    {
                        foreach (DataColumn dc in dcC)
                        {
                            dc.ColumnName = dc.ColumnName.Replace("Ñ", "N");
                            _params.Add(dr[dc.ColumnName]);
                        }

                        if (idCliente.id_tipo_cliente == 2 || idCliente.Id_Cliente == 23)
                        {
                            _params.Add(idCliente.Id_Cliente);
                        }

                        if (clientes_directos.Contains(idCliente.Id_Cliente))
                        {
                            _params.Add("ASIG_" + DateTime.Now.Month.ToString().PadLeft(1));
                        }

                        int i = 0;
                        foreach (MySqlParameter param in cmd.Parameters)
                        {
                            if (param.Direction == ParameterDirection.InputOutput)
                            {
                                param.Direction = ParameterDirection.Output;
                            }
                            else if (param.Direction == ParameterDirection.Input)
                            {
                                param.Value = _params[i].ToString();
                                i++;
                            }
                        }
                    }
                    else
                    {
                        List<string> columnNames = new List<string>();
                        foreach (DataColumn dc in dcC)
                        {
                            dc.ColumnName = dc.ColumnName.Trim().Replace(" ", "_").ToLower();
                            columnNames.Add(dc.ColumnName.Trim().Replace(" ", "_").ToLower());
                        }

                        int j = 0;
                        foreach (MySqlParameter param in cmd.Parameters)
                        {
                            string paso = "0";
                            string cName = "";
                            if (param.Direction == ParameterDirection.Input)
                            {
                                if (clientes_coomultrasan.Contains(idCliente.Id_Cliente))
                                    cName = param.ParameterName.ToLower().Replace("@", "");
                                else
                                    cName = param.ParameterName.ToLower().Replace("@pv_", "");


                                var existsCol = columnNames.Where(x => x.Trim().ToLower() == cName.Trim().ToLower());

                                if (existsCol.Count() > 0)
                                {
                                    if (dr[cName] == null)
                                    {
                                        _params.Add(DBNull.Value);
                                        param.Value = DBNull.Value;
                                        paso = "1";
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(dr[cName].ToString()))
                                        {
                                            _params.Add(DBNull.Value);
                                            param.Value = DBNull.Value;
                                            paso = "2";
                                        }
                                        else
                                        {
                                            if (param.DbType == DbType.DateTime)
                                            {
                                                try
                                                {
                                                    _params.Add(DateTime.Parse(dr[cName].ToString().Trim()));
                                                    param.Value = DateTime.Parse(dr[cName].ToString().Trim());
                                                    paso = "3";
                                                }
                                                catch (Exception ex)
                                                {
                                                    _params.Add(DBNull.Value);
                                                    param.Value = DBNull.Value;
                                                    paso = "4";
                                                }
                                            }
                                            else
                                            {
                                                var valor = dr[cName].ToString().Trim();

                                                if (param.DbType == DbType.Single
                                                    || param.DbType == DbType.Decimal
                                                    || param.DbType == DbType.Double
                                                    )
                                                {
                                                    valor = valor.Replace("$", "").Replace(".", "").Replace(",", "");
                                                }


                                                _params.Add(valor);
                                                param.Value = valor;
                                                paso = "5";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    _params.Add(DBNull.Value);
                                    param.Value = DBNull.Value;
                                    paso = "6";
                                }
                                j++;
                            }
                            else if (param.Direction == ParameterDirection.InputOutput)
                            {
                                param.Direction = ParameterDirection.Output;
                            }


                            pa.Add(param.ParameterName + " - " + param.Value);
                        }
                    }
                }
                else if (idTipoCargue == "2")
                {

                    _params.Add(idCliente.Id_Cliente);

                    foreach (DataColumn dc in dcC)
                    {
                        _params.Add(dr[dc.ColumnName]);
                    }


                    if (_params[7] == null || string.IsNullOrEmpty(_params[7].ToString()))
                        _params[7] = DBNull.Value;

                    if (_params[6] == null || string.IsNullOrEmpty(_params[6].ToString()))
                        _params[6] = DBNull.Value;

                    if (_params[4] == null || string.IsNullOrEmpty(_params[4].ToString()))
                        _params[4] = 0;

                    int i = 0;
                    foreach (MySqlParameter param in cmd.Parameters)
                    {
                        if (param.Direction == ParameterDirection.InputOutput)
                        {
                            param.Direction = ParameterDirection.Output;
                        }
                        else if (param.Direction == ParameterDirection.Input)
                        {
                            param.Value = _params[i].ToString();
                            i++;
                        }
                    }
                }
                else if (idTipoCargue == "3")
                {

                    foreach (DataColumn dc in dcC)
                    {
                        _params.Add(dr[dc.ColumnName]);
                    }


                    int i = 0;
                    foreach (MySqlParameter param in cmd.Parameters)
                    {
                        if (param.Direction == ParameterDirection.InputOutput)
                        {
                            param.Direction = ParameterDirection.Output;
                        }
                        else if (param.Direction == ParameterDirection.Input)
                        {
                            param.Value = _params[i].ToString();
                            i++;
                        }
                    }
                }

                await cmd.ExecuteNonQueryAsync();

                if (cmd.Parameters["@pv_mensaje"].Value.ToString() != "OK")
                {
                    res = "Excepcion Controlada " + cmd.Parameters["@pv_mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
                await AddExc(0, "TodoItemService.InsertarLinea", ex.Message + " " + ex.StackTrace);
            }

            return res;
        }

        public async Task<Dictionary<string,DataTable>> ExcelToDataTable(string sheetName, bool isFirstRowColumn,Stream fs,string filename)
        {
            ISheet sheet = null;
            DataTable data = new DataTable();
            int startRow = 0;
            IWorkbook workbook = null;
            string ret = "OK";
            try
            {
                fs.Position = 0;

                if (filename.Contains("xlsx")) // 2007
                {
                    workbook = new XSSFWorkbook(fs);
                }
                else if (filename.Contains("xls")) // 2003
                {
                    workbook = new HSSFWorkbook(fs);
                }

                if (sheetName != null)
                {
                    sheet = workbook.GetSheet(sheetName);
                    if (sheet == null) 
                    {
                        sheet = workbook.GetSheetAt(0);
                    }
                }
                else
                {
                    sheet = workbook.GetSheetAt(0);
                }

                if (sheet != null)
                {
                    IRow firstRow = sheet.GetRow(0);
                    int cellCount = firstRow.LastCellNum; 

                    if (isFirstRowColumn)
                    {
                        for (int i = firstRow.FirstCellNum; i < cellCount; ++i)
                        {
                            ICell cell = firstRow.GetCell(i);
                            if (cell != null)
                            {
                                string cellValue = cell.StringCellValue;
                                if (cellValue != null)
                                {
                                    DataColumn column;
                                    if (data.Columns.Contains(cellValue)){
                                        column = new DataColumn(cellValue + "_" + i);
                                    }
                                    else
                                    {
                                        column = new DataColumn(cellValue);
                                    }

                                    data.Columns.Add(column);
                                }
                            }
                        }
                        startRow = sheet.FirstRowNum + 1;
                    }
                    else
                    {
                        startRow = sheet.FirstRowNum;
                    }

                    int rowCount = sheet.LastRowNum;
                    for (int i = startRow; i <= rowCount; ++i)
                    {
                        IRow row = sheet.GetRow(i);
                        if (row == null) continue; 

                        DataRow dataRow = data.NewRow();
                        for (int j = row.FirstCellNum; j < cellCount; ++j)
                        {
                            if (row.GetCell(j) != null) 
                                dataRow[j] = row.GetCell(j).ToString();
                        }
                        data.Rows.Add(dataRow);
                    }
                }
            }
            catch (Exception ex)
            {
                ret = ex.Message;
            }

            return new Dictionary<string, DataTable>() { { ret, data } };
        }

        public Task<MemoryStream> WriteExcelWithNPOI(String extension, DataTable dt)
        {
            // dll refered NPOI.dll and NPOI.OOXML  
            IWorkbook workbook;

            try
            {

                if (extension == "xlsx")
                {
                    workbook = new XSSFWorkbook();
                }
                else if (extension == "xls")
                {
                    workbook = new HSSFWorkbook();
                }
                else
                {
                    throw new Exception("This format is not supported");
                }

                ISheet sheet1 = workbook.CreateSheet("Sheet 1");

                //make a header row  
                IRow row1 = sheet1.CreateRow(0);

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ICell cell = row1.CreateCell(j);
                    String columnName = dt.Columns[j].ToString();
                    cell.SetCellValue(columnName);
                }

                //loops through data  
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IRow row = sheet1.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        String columnName = dt.Columns[j].ToString();
                        cell.SetCellValue(dt.Rows[i][columnName].ToString().Length > 32767 ? dt.Rows[i][columnName].ToString().Substring(0,32767) : dt.Rows[i][columnName].ToString());
                    }
                }

                MemoryStream exportData = new MemoryStream();
                workbook.Write(exportData,true);
                return Task.FromResult(exportData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
        }

        public async Task<MySqlCommand> GetParameters(string spName)
        {

            MySqlCommand cmd;

            try
            {
                MySqlConnection conn = new MySqlConnection(connectionString);
                await conn.OpenAsync();
                cmd = new MySqlCommand(spName, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlCommandBuilder.DeriveParameters(cmd);
            }
            catch (Exception ex)
            {
                cmd = new MySqlCommand();
            }

            return cmd;
        }

        public static Boolean isAlphaNumeric(string strToCheck)
        {
            Regex rg = new Regex(@"^[a-zA-Z][a-zA-Z0-9]*$");
            return rg.IsMatch(strToCheck);
        }

        public static DataTable createDt(Object[] columns)
        {
            DataTable dt = new DataTable();
            foreach (String col in columns)
            {
                dt.Columns.Add(col.Split(',')[0], System.Type.GetType("System." + col.Split(',')[1]));
            }
            return dt;
        }

        public static void addRowDt(ref DataTable dt, Object[] data)
        {
            DataRow newRow = dt.NewRow();
            int i = 0;
            foreach (object col in data)
            {
                newRow[i] = col;
                newRow[i].GetType();
                i += 1;
            }
            dt.Rows.Add(newRow);
        }
    }
}
