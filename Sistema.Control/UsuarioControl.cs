using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Sistema.Control
{
    public class UsuarioControl
    {
        public int Inserir(UsuarioEnt objTabela)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "INSERT INTO usuarios ([nome],[usuario],[senha]) VALUES (@nome, @usuario, @senha)";
                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = objTabela.Nome;
                cn.Parameters.Add("usuario", SqlDbType.VarChar).Value = objTabela.Usuario;
                cn.Parameters.Add("senha", SqlDbType.VarChar).Value = objTabela.Senha;

                cn.Connection = con;

                int qtd = cn.ExecuteNonQuery();
                Console.Write(qtd);
                return qtd;
            }   
        }

        public List<UsuarioEnt> Lista()
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Properties.Settings.Default.banco;
                SqlCommand cn = new SqlCommand();
                cn.CommandType = CommandType.Text;
                con.Open();
                cn.CommandText = "SELECT * FROM usuarios ORDER BY nome ASC";

                cn.Connection = con;

                SqlDataReader dr;
                List<UsuarioEnt> Lista = new List<UsuarioEnt>();

                dr = cn.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        UsuarioEnt dado = new UsuarioEnt();
                        dado.Id = Convert.ToInt32(dr["id"]);
                        dado.Nome = Convert.ToString(dr["nome"]);
                        dado.Usuario = Convert.ToString(dr["usuario"]);
                        dado.Senha = Convert.ToString(dr["senha"]);

                        Lista.Add(dado);
                    }
                }
                return Lista;
            }
        }
    }
}
