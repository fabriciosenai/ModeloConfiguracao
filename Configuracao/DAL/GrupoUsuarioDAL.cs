using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class GrupoUsuarioDAL
    {
        public void inserir(GrupoUsuario _grupousuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO GrupoUsuario(NomeGrupo)      
                                  VALUES(@NomeGrupo )";

                cmd.Parameters.AddWithValue("@NomeGrupo", _grupousuario.NomeGrupo);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception("O correu um erro na tentativa de inserir uma descrissao. por favor verifique sua conexão", ex);
            }
            finally
            {
                cn.Close();
            }

        }



        public void Alterar(GrupoUsuario _grupousuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "update GrupoUsuario set NomeGrupo = @nomegrupo WHERE Id = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _grupousuario.IdGrupo);
                cmd.Parameters.AddWithValue("@nomegrupo", _grupousuario.NomeGrupo);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception("O correu um erro na tentativa de inserir um usuário. por favor verifique sua conexão", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public void Excluir(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = "DELETE FROM GrupoUsuario WHERE ID = @Id";
                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Id", _id);

                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw new Exception("O correu um erro na tentativa de exluir um usuário.por favor verifique sua conexão", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        public List<GrupoUsuario> BuscarPorTodos()
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<GrupoUsuario> grupousuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id, NomeGrupo FROM GrupoUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cn.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupousuario = new GrupoUsuario();
                        grupousuario.IdGrupo = Convert.ToInt32(rd["Id"]);
                        grupousuario.NomeGrupo = rd["NomeGrupo"].ToString();
                        grupousuarios.Add(grupousuario);
                    }
                }
                return grupousuarios;
            }
            catch (Exception ex)
            {
                throw new Exception("O correu um erro na tentetiva de buscar dos dados. Por favor verifique sua conexao", ex);
            }
            finally
            {
                cn.Close();
            }
        }
        public List<GrupoUsuario> BuscarPorNome(string _nomegrupo)
        {

            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<GrupoUsuario> grupousuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario = new GrupoUsuario();


            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,Nomegrupo";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@Nomegrupo", "%" + _nomegrupo + "%");
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        grupousuario.IdGrupo = Convert.ToInt32(rd["Id"]);
                        grupousuario.NomeGrupo = rd["nomegrupo "].ToString();
                        grupousuarios.Add(grupousuario);
                    }
                }

                return grupousuarios;
            }

            catch (Exception ex)
            {
                throw new Exception("O correu um erro na tentativa de inserir um usuário. por favor verifique sua conexão", ex);
            }
            finally
            {
                cn.Close();
            }

        }
        public List<GrupoUsuario> BuscarPorId(int _id)

        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<GrupoUsuario> grupousuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario = new GrupoUsuario();
            try
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = "SELECT Id,nomegrupo";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("Id", _id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())


                {
                    while (rd.Read())
                    {

                        grupousuario.IdGrupo = Convert.ToInt32(rd["Id"]);
                        grupousuario.NomeGrupo = rd["nomegrupo "].ToString();
                        grupousuarios.Add(grupousuario);
                    }
                }

                return grupousuarios;

            }
            catch (Exception ex)
            {
                throw new Exception("O correu um erro na tentativa de inserir um usuário. por favor verifique sua conexão", ex);
            }
            finally
            {
                cn.Close();
            }
        }

        internal List<GrupoUsuario> BuscarPorIdUsuario(int _id)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
            List<GrupoUsuario> grupousuarios = new List<GrupoUsuario>();
            GrupoUsuario grupousuario = new GrupoUsuario();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandText = @"SELECT GrupoUsuario.Id, GrupoUsuario.NomeGrupo FROM GrupoUsuario
                    INNER JOIN UsuarioGrupoUsuario ON GrupoUsuario.Id = UsuarioGrupoUsuario.IdGrupoUsuario
                    WHERE UsuarioGrupoUsuario.IdGrupoUsuario = @IdUsuario";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("@IdUsuario", _id);
                cn.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())


                {
                    while (rd.Read())
                    {

                        grupousuario.IdGrupo = Convert.ToInt32(rd["Id"]);
                        grupousuario.NomeGrupo = rd["nomegrupo "].ToString();
                        grupousuarios.Add(grupousuario);
                    }
                }

                return grupousuarios;

            }
            catch (Exception ex)
            {
                throw new Exception("O correu um erro na tentativa de inserir um usuário. por favor verifique sua conexão", ex);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
