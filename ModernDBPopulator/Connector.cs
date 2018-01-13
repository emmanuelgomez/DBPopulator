using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ModernDBPopulator
{
    class Connector
    {
        private string _host;
        private string _port;
        private string _database;
        private string _user;
        private string _password;

        private const String Procedure = "Procedure";
        private const String SDT = "SDT";
        private const String DataProvider = "DataProvider";
        private const String Folders = "Folders";
        private const String Transaction = "Transaction";
        private const String WebPanel = "WebPanel";

        public Connector(string host, string port, string database, string user, string password )
        {
            _host = host;
            _port = port;
            _database = database;
            _user = user;
            _password = password;

        }
        private string GetConnectionString()
        {

            return string.Format("Data Source={0};Database={1};User ID={2};Password={3};MultipleActiveResultSets=true ;", _host, _database, _user, _password);
        }

        public bool ExisteGrupo(string grupoId)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.Parameters.Clear();

            //Get Procedures ID
            cmd.CommandText = "SELECT GrupoCodigo FROM dbo.Grupo WHERE GrupoCodigo='"+grupoId+"' ";
            //cmd.Parameters.AddWithValue("@parm", Procedure);
            //cmd.Parameters.AddWithValue("@parm1", "Objects");
            bool flag = false;
            using (SqlDataReader dataReader = cmd.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    flag = true;
                }
            }

            
            connection.Close();

            return flag;

        }

        public bool InsertarGrupo(Grupo grupo, int entidadId)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.Parameters.Clear();
            //var idAux ;
            //if ((grupo.GrupoSuperiorCodigo == null) || (grupo.GrupoSuperiorCodigo == ""))
            //{
            //     idAux = (object) DBNull.Value;
            //}
            //else
            //{
            //     idAux = GetGrupoId(grupo.GrupoSuperiorCodigo, cmd);
            //}
            var idAux = grupo.GrupoSuperiorCodigo == null || (grupo.GrupoSuperiorCodigo == "")
                ? (object)DBNull.Value
                : GetGrupoId(grupo.GrupoSuperiorCodigo, cmd);
            //Get Procedures ID
            cmd.CommandText = "INSERT INTO dbo.Grupo (GrupoNombre,EntidadId,GrupoCodigo,GrupoSuperiorId) VALUES (@GrupoNombre,@Entidad,@GrupoCodigo,@GrupoSuperior)  ";
            cmd.Parameters.AddWithValue("@GrupoNombre", grupo.GrupoNombre);
            cmd.Parameters.AddWithValue("@Entidad", entidadId);
            cmd.Parameters.AddWithValue("@GrupoCodigo", grupo.GrupoCodigo);
            cmd.Parameters.AddWithValue("@GrupoSuperior",idAux) ;

            int rows = -1;

            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
           


            connection.Close();

            if (rows > 0) return true;
            else return false;


        }

        private int GetGrupoId(string grupoCodigo, SqlCommand cmd)
        {
            try
            {
                cmd.CommandText = "SELECT GrupoId FROM dbo.Grupo WHERE GrupoCodigo='" + grupoCodigo + "' ";
                int ret= (int)cmd.ExecuteScalar();
                return ret;
            }
            catch (Exception e)
            {
                throw new Exception("No existe grupo con código "+grupoCodigo);

            }


           
        }

        public bool InsertarTrabajador(Trabajador trabajador, int entidadId)
        {
            SqlConnection connection = new SqlConnection(GetConnectionString());
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            var grupoId = GetGrupoId(trabajador.GrupoCodigo, cmd);
            //Get Procedures ID
            cmd.CommandText = "INSERT INTO dbo.Trabajador (TrabajadorNombre,TrabajadorApellidos,TrabajadorCodigo,TrabajadorIdentidad,TrabajadorLdap,SubEntidadId,GrupoId,TrabajadorFechaIniCont,TrabajadorUltimaMarca)" +
                " VALUES (@TrabajadorNombre,@TrabajadorApellidos,@TrabajadorCodigo,@TrabajadorIdentidad,@TrabajadorLdap,@SubEntidadId,@GrupoCodigo,@TrabajadorFechaIniCont,@TrabajadorUltimaMarca)  ";
            cmd.Parameters.AddWithValue("@TrabajadorNombre", trabajador.TrabajadorNombre);
            cmd.Parameters.AddWithValue("@TrabajadorApellidos", trabajador.TrabajadorApellidos);
            cmd.Parameters.AddWithValue("@TrabajadorCodigo", trabajador.TrabajadorCodigo);
            cmd.Parameters.AddWithValue("@TrabajadorIdentidad", trabajador.TrabajadorIdentidad);
            cmd.Parameters.AddWithValue("@TrabajadorLdap", trabajador.TrabajadorLdap ?? "");
            cmd.Parameters.AddWithValue("@SubEntidadId", entidadId);
            cmd.Parameters.AddWithValue("@GrupoCodigo", grupoId);
            cmd.Parameters.AddWithValue("@TrabajadorFechaIniCont", DateTime.Now);
            cmd.Parameters.AddWithValue("@TrabajadorUltimaMarca", SqlDateTime.MinValue);
            
            int rows = -1;

            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }



            connection.Close();

            if (rows > 0) return true;
            else return false;


        }

       
    }
}
