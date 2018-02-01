using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cadastrar : MonoBehaviour {

    public Button btnSalvar,btnVoltar;  //botão de salvar e voltar
    public Text status;                 //em caso de o usuario já estar cadastrado então ele retornara uma status de erro
    public InputField nome, pontuacao;  //campos de coleta 

    public void salvar() {

        ListaPontosJogador listaDeDadosJogadores = new ListaPontosJogador();    //Lista que recebera os dados do Json
        PontosJogador novoDadoJogador = new PontosJogador();                    //objeto que usaremos para salvar os novos dados
        JsonSerializador serializador = new JsonSerializador();                 //classe que contem o metodo de save e retriev
        bool playerExiste = false;                                              //flag para indicar se o player existe ou nao

        //Obtem os dados do Json
        listaDeDadosJogadores = serializador.Retrieve();                        

        //se algum campo estiver vazio então envie mensagem de erro
        if (nome.text.Equals("") || pontuacao.text.Equals("")){                
            status.text = "Nome ou pontuação estão em branco!";
        }
        else {
            //salva a nova entrada
            novoDadoJogador.nomePlayer = nome.text;                             
            novoDadoJogador.pontosPlayer = int.Parse(pontuacao.text);
            //se alista estiver vazia significa que não há nenhum player salvo no Json ou que o arquivo não foi criado
            if (listaDeDadosJogadores == null)                                  
            {
                //sava a nova entrada e exibe mensagem de sucesso
                listaDeDadosJogadores.listaPontuacao.Add(novoDadoJogador);     
                serializador.Create(listaDeDadosJogadores);                    
                status.text =  nome.text + " cadastrado com sucesso!";          
            }
            else
            {
                foreach (PontosJogador dados in listaDeDadosJogadores.listaPontuacao)   //varre a lista que obtemos do Json
                {
                    //se ja existir esse nome na lista então ele deve avisar o jogador
                    if (dados.nomePlayer.Equals(novoDadoJogador.nomePlayer))
                    {
                        playerExiste = true;
                        break;
                    }
                }
                //se o player existe então mostre uma mensagem de erro
                if (playerExiste)
                {
                    status.text = "Erro. Esse jogador já foi cadastrado entre com um novo ou vá no menu EDITAR para alterar os dados";
                }
                //se o player não existe então salve-o no Json
                else
                {
                    listaDeDadosJogadores.listaPontuacao.Add(novoDadoJogador);
                    serializador.Create(listaDeDadosJogadores);
                    status.text = nome.text + " cadastrado com sucesso";
                }
            }
        }

    }

    //tratamento do botão voltar
    public void voltar() {
        GerenciadorDeTelas.mudarTela(0);
    }
}
