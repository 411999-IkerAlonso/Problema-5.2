using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Problema_5._2
{
    public class DAO
    {
        private string cadenaConexion = "Data Source=COSITAS;Initial Catalog = Trabajo5_1; Integrated Security = True; Encrypt=False; password=Fermin11";
        private SqlConnection conexion;
        private SqlCommand comando;
        public DAO()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public void Conectar()
        {
            conexion.Open();
            comando = new SqlCommand();
            comando.Connection = conexion;
            comando.CommandType = CommandType.Text;
        }

        public void Desconectar()
        {
            conexion.Close();
        }

        public DataTable CargarCombo(string tabla)
        {
            DataTable dt = new DataTable();
            Conectar();
            comando.CommandText = "SELECT * FROM " + tabla;
            dt.Load(comando.ExecuteReader());
            Desconectar();
            return dt;
        }

        public DataTable ConsultarBD(string consultaSQL)
        {
            DataTable dt = new DataTable();
            Conectar();
            comando.CommandText = consultaSQL;
            dt.Load(comando.ExecuteReader());
            Desconectar();
            return dt;
        }

        public int Actualizar(string consultaSQL)
        {
            Conectar();
            comando.CommandText = consultaSQL;
            int filasAfectadas = comando.ExecuteNonQuery();
            return filasAfectadas;
        }


    }
}
