using System;
using System.Collections.Generic;
using MySqlConnector;

namespace Trabalho._2.Models
{
    public class ViagemBanco
    {

        private const string dados = "Database=projcadastros; Data Source=localhost; User Id=root";

        public void Insert(Viagem novacompra, int IDusuario)
        {
            MySqlConnection conexao = new MySqlConnection(dados);
            conexao.Open();
            string Query = "INSERT INTO objeto (nomePacote,origemPacote ,destinoPacote, atrativosPacote, saidaPacote, retornoPacote,IDusuario ) VALUES (@nomePacote,@origemPacote ,@destinoPacote, @atrativosPacote, @saidaPacote, @retornoPacote,@IDusuario) ";
            MySqlCommand comando = new MySqlCommand(Query, conexao);


            comando.Parameters.AddWithValue("@nomePacote", novacompra.nomePacote);
            comando.Parameters.AddWithValue("@origemPacote", novacompra.origemPacote);
            comando.Parameters.AddWithValue("@destinoPacote", novacompra.destinoPacote);
            comando.Parameters.AddWithValue("@atrativosPacote", novacompra.atrativosPacote);
            comando.Parameters.AddWithValue("@saidaPacote", novacompra.saidaPacote);
            comando.Parameters.AddWithValue("@retornoPacote", novacompra.retornoPacote);
            novacompra.IDusuario = IDusuario;
            comando.Parameters.AddWithValue("@IDusuario", IDusuario);

            comando.ExecuteNonQuery();
            conexao.Close();

        }
        public Viagem Querycompra(Viagem usar)
        {
            MySqlConnection conexao = new MySqlConnection(dados);
            conexao.Open();
            string sql = "SELECT * FROM objeto WHERE nomePacote = @nomePacote";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@nomePacote", usar.nomePacote);
            comandoQuery.Parameters.AddWithValue("@origem", usar.origemPacote);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Viagem usr = null;
            if (reader.Read())
            {
                usr = new Viagem();
                usr.IDProduto = reader.GetInt32("IDProduto");
                if (!reader.IsDBNull(reader.GetOrdinal("nomePacote")))
                    usr.nomePacote = reader.GetString("nomePacote");

                if (!reader.IsDBNull(reader.GetOrdinal("origemPacote")))
                    usr.origemPacote = reader.GetString("origemPacote");
            }

            conexao.Close();
            return usr;
        }




        public List<Viagem> Query()
        {
            MySqlConnection conexao = new MySqlConnection(dados);
            conexao.Open();
            string sql = "SELECT * FROM objeto ORDER BY IDusuario ";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Viagem> lista = new List<Viagem>();
            while (reader.Read())
            {
                Viagem turisticos = new Viagem();
                turisticos.IDProduto = reader.GetInt32("IDProduto");

                if (!reader.IsDBNull(reader.GetOrdinal("IDusuario")))
                    turisticos.IDusuario = reader.GetInt32("IDusuario");


                if (!reader.IsDBNull(reader.GetOrdinal("nomePacote")))
                    turisticos.nomePacote = reader.GetString("nomePacote");

                if (!reader.IsDBNull(reader.GetOrdinal("origemPacote")))
                    turisticos.origemPacote = reader.GetString("origemPacote");


                if (!reader.IsDBNull(reader.GetOrdinal("destinoPacote")))
                    turisticos.destinoPacote = reader.GetString("destinoPacote");

                if (!reader.IsDBNull(reader.GetOrdinal("atrativosPacote")))
                    turisticos.atrativosPacote = reader.GetString("atrativosPacote");
            /*
                if(!reader.IsDBNull(reader.GetOrdinal("saidaPacote")))
                    turisticos.saidaPacote = reader.GetDateTime("saidaPacote");

                 if (!reader.IsDBNull(reader.GetOrdinal("retornoPacote")))
                    turisticos.retornoPacote = reader.GetDateTime("retornoPacote");
                 */   
                lista.Add(turisticos);
            }
            conexao.Close();
            return lista;
        }
        
           public  void atualizar( Viagem  user )
        {
            MySqlConnection Conexao = new MySqlConnection(dados);
            Conexao.Open();
            string  Query  =  " UPDATE objeto SET nomePacote = @nomePacote WHERE IDProduto = @IDProduto " ;
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@nomePacote", user.nomePacote);
            Comando.Parameters.AddWithValue("@IDProduto", user.IDProduto);
            Comando . ExecuteNonQuery ();
            Conexao.Close();            
        }
        
             public  void  Excluir( int  id )
        {
            MySqlConnection Conexao = new MySqlConnection(dados);
            Conexao.Open();
            string Query = "DELETE FROM objeto WHERE IDProduto=@IDProduto";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@IDProduto", id);
            Comando . ExecuteNonQuery ();
            Conexao.Close();  
        }
          public  Viagem  buscar ( int  id )
        {
            MySqlConnection Conexao = new MySqlConnection(dados);
            Conexao.Open();
            string Query = "SELECT * FROM objeto WHERE IDProduto=@IDProduto";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@IDProduto", id);
            MySqlDataReader Reader = Comando.ExecuteReader();

            Viagem  encontra =  new Viagem ();

            if(Reader.Read())
            {
                encontra.IDProduto = Reader.GetInt32("IDProduto");
                
                if(!Reader.IsDBNull(Reader.GetOrdinal("nomePacote")))
                    encontra.nomePacote = Reader.GetString("nomePacote");
                if(!Reader.IsDBNull(Reader.GetOrdinal("origemPacote")))                    
                    encontra .origemPacote = Reader.GetString("origemPacote");
          
            }
            Conexao.Close();
            return encontra;            
        }
       
    }
}