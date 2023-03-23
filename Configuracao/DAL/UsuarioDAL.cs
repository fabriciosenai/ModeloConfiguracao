
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace DAL
{
    public class UsuarioDAL
    {
        public void Inserir(Usuario _usuario)
        {
            SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

            try
            {
                SqlCommand cmd = cn.CreateCommand();
                cmd.CommandText = @"INSERT INTO Usuario(Nome, NomeUsuario, Email, CPF, Ativo, Senha)
                                   VALUES(@Nome, @NomeUsuario, @Email, @CPF, @Ativo, @Senha)";

                cmd.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();


            }
            catch (Exception ex) { 
            throw new Exception("Implementar este método.",ex);
            }
        }

            public void Alterar(Usuario _usuario)
            {
                SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

                try
                {
                    SqlCommand cmd = cn.CreateCommand();
                    cmd.CommandText = "update Usuario set Nome = @nome,NomeUsuario = @NomeUsuario,Email = @Email,Cpf =@Cpf,Senha = @Senha,Ativo = @Ativo WHERE id = @ID";
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Id", _usuario.Id);
                    cmd.Parameters.AddWithValue("@Nome", _usuario.Nome);
                    cmd.Parameters.AddWithValue("@NomeUsuario", _usuario.NomeUsuario);
                    cmd.Parameters.AddWithValue("@Email", _usuario.Email);
                    cmd.Parameters.AddWithValue("@CPF", _usuario.CPF);
                    cmd.Parameters.AddWithValue("@Senha", _usuario.Senha);
                    cmd.Parameters.AddWithValue("@Ativo", _usuario.Ativo);
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();


                }
                catch (Exception ex)
                {
                    throw new Exception("ocorreu um erro na tentativa de alterar um usuário. por favor verifique sua conexão", ex);
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
                    cmd.CommandText = "DELETE FROM Usuario WHERE Id = @Id";
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Id", _id);

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("ocorreu um erro na tentativa de exluir um usuário.por favor verifique sua conexão", ex);
                }
                finally
                {
                    cn.Close();
                }

            }
            public List<Usuario> BuscarPorTodos()
            {
                SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
                List<Usuario> usuarios = new List<Usuario>();
                Usuario usuario;
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT Id, Nome, NomeUsuario, Email,CPF,Ativo,Senha FROM Usuario";
                    cmd.CommandType = System.Data.CommandType.Text;

                    cn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(rd["Id"]);
                            usuario.Nome = rd["Nome"].ToString();
                            usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                            usuario.Email = rd["Email"].ToString();
                            usuario.CPF = rd["Cpf"].ToString();
                            usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                            usuario.Senha = rd["Senha"].ToString();
                            usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);

                            usuarios.Add(usuario);
                        }
                    }
                    return usuarios;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro na tentetiva de buscar dos dados. Por favor verifique sua conexao", ex);
                }
                finally
                {
                    cn.Close();
                }
            }
            public List<Usuario> BuscarPorCPF(string _cpf)
            {
                SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
                List<Usuario> usuarios = new List<Usuario>();
                Usuario usuario = new Usuario();

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT Id,Nome,NomeUsuario,Email,CPF,Ativo,Senha FROM Usuario WHere CPF = @cpf";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@CPF", "%" + _cpf + "%");
                    cn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(rd["Id"]);
                            usuario.Nome = rd["Nome"].ToString();
                            usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                            usuario.Email = rd["Email"].ToString();
                            usuario.CPF = rd["Cpf"].ToString();
                            usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                            usuario.Senha = rd["Senha"].ToString();
                            usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);

                            usuarios.Add(usuario);

                        }
                    }

                    return usuarios;
                }

                catch (Exception ex)
                {
                    throw new Exception("ocorreu um erro na tentativa de inserir um usuário. por favor verifique sua conexão", ex);
                }
                finally
                {
                    cn.Close();
                }
            }

            public List<Usuario> BuscarPorNome(string _nome)
            {
                throw new NotImplementedException("Apagar essa linha e implementar o método: BuscarPorNome na UsuarioDAL");
            }



            public List<Usuario> BuscarPorNomeUsuario(string _nomeUsuario)
            {
                SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
                List<Usuario> usuarios = new List<Usuario>();
                Usuario usuario = new Usuario();


                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT Id,Nome,NomeUsuario,Email,CPF,Ativo FROM Usuario WHERE NomeUsuario LIKE = @nomeusuario";
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@nomeusuario", "%" + _nomeUsuario + "%");
                    cn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(rd["Id"]);
                            usuario.Nome = rd["Nome"].ToString();
                            usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                            usuario.Email = rd["Email"].ToString();
                            usuario.CPF = rd["Cpf"].ToString();
                            usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                            usuario.Senha = rd["Senha"].ToString();
                            usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);

                            usuarios.Add(usuario);

                        }
                    }

                    return usuarios;
                }

                catch (Exception ex)
                {
                    throw new Exception("ocorreu um erro na tentativa de inserir um usuário. por favor verifique sua conexão", ex);
                }
                finally
                {
                    cn.Close();
                }
            }
            public List<Usuario> BuscarPorId(int _id)
            {
                List<Usuario> usuarios = new List<Usuario>();
                Usuario usuario = new Usuario();
                SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = "SELECT Id,Nome,NomeUsuario,Email,CPF,Ativo, Senha FROM Usuario WHERE Id = @Id";
                    cmd.CommandType = System.Data.CommandType.Text;

                    cmd.Parameters.AddWithValue("@Id", _id);

                    cn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            usuario = new Usuario();
                            usuario.Id = Convert.ToInt32(rd["Id"]);
                            usuario.Nome = rd["Nome"].ToString();
                            usuario.NomeUsuario = rd["NomeUsuario"].ToString();
                            usuario.Email = rd["Email"].ToString();
                            usuario.CPF = rd["Cpf"].ToString();
                            usuario.Ativo = Convert.ToBoolean(rd["Ativo"]);
                            usuario.Senha = rd["Senha"].ToString();
                            usuario.GrupoUsuarios = new GrupoUsuarioDAL().BuscarPorIdUsuario(usuario.Id);

                            usuarios.Add(usuario);

                        }
                    }

                    return usuarios;
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

            public bool ValidarPermissao(int _idUsuario, int _idPermissao)
            {
                SqlConnection cn = new SqlConnection(Conexao.StringDeConexao);
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandText = @"SELECT 1 FROM PermissaoGrupoUsuario
                 INNER JOIN UsuarioGrupoUsuario ON PermissaGrupoUsuario.IdGrupoUsuario = UsuarioGrupoUsuario.IdGrupoUsuario
                 WHERE UsuarioGrupoUsuario.IdUsuario = @IdUsuario AND PermissaGrupoUsuario.IdPermissao = @IdPermissao";


                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@IdUsuario", _idUsuario);
                    cmd.Parameters.AddWithValue("@Idpermissao", _idPermissao);

                    cn.Open();
                    using (SqlDataReader rd = cmd.ExecuteReader())
                    {
                        if (rd.Read())
                            return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro na tentetiva jde buscar dos dados. Por favor verifique sua conexao", ex);
                }
                finally
                {
                    cn.Close();
                }
            }
        }
    
    }










