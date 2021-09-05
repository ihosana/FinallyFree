/*
using System.Collections.Generic;
using MySqlConnector;

namespace Trabalho._2.Models
{
    public class CompraBanco
    {
        private const string dados = "Database=projcadastros; Data Source=localhost; User Id=root";

        public void Insert(Compra novacompra,int IDusuarios)
        {
            MySqlConnection conexao = new MySqlConnection(dados);
            conexao.Open();
            string sql = "INSERT INTO pacotes(nomePacote,IDusuario ,origem ,destino, atrativos, saida, retorno ) VALUES (@nomePacote, @IDusuario,@origem ,@destino, @atrativos, @saida, @retorno) ";
            MySqlCommand comando = new MySqlCommand(sql, conexao);

            comando.Parameters.AddWithValue("@nomePacote", novacompra.nomePacote);
              comando.Parameters.AddWithValue("@IDusuario",novacompra.IDusuarioPacote);
            comando.Parameters.AddWithValue("@origem", novacompra.origemPacote);
            comando.Parameters.AddWithValue("@destino", novacompra.destinoPacote);
            comando.Parameters.AddWithValue("@atrativos", novacompra.atrativosPacote);
            comando.Parameters.AddWithValue("@saida", novacompra.saidaPacote);
            comando.Parameters.AddWithValue("@retorno", novacompra.retornoPacote);
           
            comando.ExecuteNonQuery();
            conexao.Close();

        }
        
          public Compra Querycompra(Compra usar)
        {
        MySqlConnection conexao = new MySqlConnection(dados);
            conexao.Open();
            string sql = "SELECT * FROM pacote WHERE nomePacote = @nomePacote AND origem = @origem";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            comandoQuery.Parameters.AddWithValue("@nomePacote", usar.nomePacote);
            comandoQuery.Parameters.AddWithValue("@origem", usar.origemPacote);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            Compra usr = null;
            if (reader.Read())
            {
                usr = new Compra();
                usr.IDPacote = reader.GetInt32("IdPacote");
                if (!reader.IsDBNull(reader.GetOrdinal("nomePacote")))
                    usr.nomePacote = reader.GetString("nomePacote");

                if (!reader.IsDBNull(reader.GetOrdinal("origemPacote")))
                    usr.origemPacote = reader.GetString("origemPacote");
            }

            conexao.Close();
            return usr;
        }
      
       


        public List<Compra> listar()
        {
            MySqlConnection conexao = new MySqlConnection(dados);
            conexao.Open();
            string sql = "SELECT * FROM pacote ORDER BY IDusuario ";
            MySqlCommand comandoQuery = new MySqlCommand(sql, conexao);
            MySqlDataReader reader = comandoQuery.ExecuteReader();
            List<Compra> lista = new List<Compra>();
            while (reader.Read())
            {
                Compra turisticos = new Compra();
                turisticos.IDPacote = reader.GetInt32("IDPacote");
                   turisticos.IDusuarioPacote = reader.GetInt32("IDusuarioPacote");


                if (!reader.IsDBNull(reader.GetOrdinal("nomePacote")))
                   turisticos.nomePacote = reader.GetString("nomePacote");

                if (!reader.IsDBNull(reader.GetOrdinal("origemPacote")))
                    turisticos.origemPacote = reader.GetString("origemPacote");

                
                if (!reader.IsDBNull(reader.GetOrdinal("destinoPacote")))
                    turisticos.destinoPacote = reader.GetString("destinoPacote");
                
                
                if (!reader.IsDBNull(reader.GetOrdinal("atrativosPacote")))
                    turisticos.atrativosPacote= reader.GetString("atrativosPacote");

                if (!reader.IsDBNull(reader.GetOrdinal("saidaPacote")))
                    turisticos.saidaPacote = reader.GetDateTime("saidaPacote");
       
                
                if (!reader.IsDBNull(reader.GetOrdinal("retornoPacote")))
                    turisticos.retornoPacote= reader.GetDateTime("retornoPacote");
    

                lista.Add(turisticos);
            }
            conexao.Close();
            return lista;
        }
        
      


    }
}
*/
