using System.Collections.Generic;
using MySqlConnector;

namespace Trabalho._2.Models
{
    public class UsuarioBancodeDados
    {
        private const string dadosconexao = "Database=projcadastros; Data Source=localhost; User Id=root";

        public void Insert(Usuario novoUsuario)
        {
            MySqlConnection conexao = new MySqlConnection(dadosconexao);
            conexao.Open();
            string Sql = "INSERT INTO pessoa (nome, login ,senha, tipo, data ) values (@nome, @login ,@senha, @tipo, @data) ";
            MySqlCommand comando = new MySqlCommand(Sql, conexao);

            comando.Parameters.AddWithValue("@nome", novoUsuario.nome);
            comando.Parameters.AddWithValue("@login", novoUsuario.login);
            comando.Parameters.AddWithValue("@senha", novoUsuario.senha);
            comando.Parameters.AddWithValue("@tipo", novoUsuario.tipo);
            comando.Parameters.AddWithValue("@data", novoUsuario.data);
            comando.ExecuteNonQuery();
            conexao.Close();

        } 
        public Usuario Querycadastro(Usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(dadosconexao);
            conexao.Open();
            string sql = "SELECT * FROM pessoa WHERE login = @login AND senha = @senha";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@login", u.login);
            comandoQuery.Parameters.AddWithValue("@senha", u.senha);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Usuario usr = null;
            if (reader.Read())
            {
                usr = new Usuario();
                usr.id = reader.GetInt32("id");
                 if(!reader.IsDBNull(reader.GetOrdinal("nome")))
            usr.nome = reader.GetString("nome");

                if (!reader.IsDBNull(reader.GetOrdinal("login")))
                    usr.login = reader.GetString("login");

                if (!reader.IsDBNull(reader.GetOrdinal("senha")))
                    usr.senha = reader.GetString("senha");
            }

            conexao.Close();
            return usr;
        } 

        public List<Usuario> Query()
        {
            MySqlConnection conexao = new MySqlConnection(dadosconexao);
            conexao.Open();
            string sql = "SELECT * FROM pessoa ORDER BY nome";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Usuario> lista = new List<Usuario>();
            while (reader.Read())
            {
                Usuario usr = new Usuario();
                usr.id = reader.GetInt32("id");

                if (!reader.IsDBNull(reader.GetOrdinal("nome")))
                    usr.nome = reader.GetString("nome");

                if (!reader.IsDBNull(reader.GetOrdinal("login")))
                    usr.login = reader.GetString("login");
                if (!reader.IsDBNull(reader.GetOrdinal("senha")))
                    usr.senha = reader.GetString("senha");
                lista.Add(usr);
            }
             
            
            conexao.Close();
            return lista;
        }

        public Usuario QueryLogin(Usuario u)
        {
            MySqlConnection conexao = new MySqlConnection(dadosconexao);
            conexao.Open();
            string sql = "SELECT * FROM pessoa WHERE login = @login AND senha = @senha";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@login", u.login);
            comandoQuery.Parameters.AddWithValue("@senha", u.senha);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Usuario usr = null;
            if (reader.Read())
            {
                usr = new Usuario();
                usr.id = reader.GetInt32("id");
                 if(!reader.IsDBNull(reader.GetOrdinal("nome")))
            usr.nome = reader.GetString("nome");

                if (!reader.IsDBNull(reader.GetOrdinal("login")))
                    usr.login = reader.GetString("login");

                if (!reader.IsDBNull(reader.GetOrdinal("senha")))
                    usr.senha = reader.GetString("senha");
            }

            conexao.Close();
            return usr;
        } 
   
      
           public  void atualizar( Usuario  user )
        {
            MySqlConnection Conexao = new MySqlConnection(dadosconexao);
            Conexao.Open();
            string  Query  =  " UPDATE pessoa SET login = @login, senha = @senha WHERE id = @id " ;
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@login", user.login);
            Comando.Parameters.AddWithValue ( "@senha" , user.senha );
            Comando.Parameters.AddWithValue("@id", user.id);
            Comando . ExecuteNonQuery ();
            Conexao.Close();            
        }
        
             public  void  Excluir( int  id )
        {
            MySqlConnection Conexao = new MySqlConnection(dadosconexao);
            Conexao.Open();
            string Query = "DELETE FROM pessoa WHERE id=@id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@id", id);
            Comando . ExecuteNonQuery ();
            Conexao.Close();  
        }
          public  Usuario  buscar ( int  id )
        {
            MySqlConnection Conexao = new MySqlConnection(dadosconexao);
            Conexao.Open();
            string Query = "SELECT * FROM pessoa WHERE id=@id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@id", id);
            MySqlDataReader Reader = Comando.ExecuteReader();

            Usuario  encontrar =  new  Usuario ();

            if(Reader.Read())
            {
                encontrar.id = Reader.GetInt32("id");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("nome")))
                    encontrar .nome = Reader.GetString("nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("login")))                    
                    encontrar .login = Reader.GetString("login");
                if(!Reader.IsDBNull(Reader.GetOrdinal("senha")))                    
                   encontrar .senha= Reader.GetString( "senha" );
            }
            Conexao.Close();
            return encontrar ;            
        }
       
    }
}