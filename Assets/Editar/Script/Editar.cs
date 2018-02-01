using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Editar : MonoBehaviour {
    public Button btnEditar, btnVoltar;
    public InputField novoNome, novaPontuacao;
    public Dropdown dpdPlayes;
    public Text status;
    private OpcoesDropDown opDropDown = new OpcoesDropDown();
    private JsonSerializador serializador = new JsonSerializador();
    private ListaPontosJogador listaE = new ListaPontosJogador();
    void Start()
    {
        //assim que começar, atualizar o dropdown e preencher o campo
        opDropDown.popularDropDown(dpdPlayes);
        preencherInpField();
    }

    public void editar() {
        string quem = "";                                       //quem vai ser editado
        PontosJogador novosDados = new PontosJogador();         //para coletar os novos dados
        quem =opDropDown.selecionarItemDpd(dpdPlayes);
        //se os campos estiverem vazios, então monstra mensagem de erro
        if (novoNome.text.Equals("") || novaPontuacao.text.Equals("")) {
            status.text = "Novo nome e/ou nova pontuação estão em branco!";
        }
        else {
            //edita o item selecionado
            novosDados.nomePlayer = novoNome.text;
            novosDados.pontosPlayer = int.Parse(novaPontuacao.text);
            serializador.Update(novosDados, quem);                  //realiza o update no nome selecionado
            opDropDown.popularDropDown(dpdPlayes);                  //atualiza o combobox
            status.text = quem + " alterado para " + novoNome.text;
        }


    }

    //tratamento do botão voltar
    public void voltar() {
        GerenciadorDeTelas.mudarTela(0);
    }

    //preenche os campos nome e pontuação com os dados do item selecionado
    //tratamento da seleceção de itens do dropDown
    public void preencherInpField() {
        listaE = serializador.Retrieve();                           //recupera a lista de jogadores salvas no Json
        string quem = opDropDown.selecionarItemDpd(dpdPlayes);      //quem esta selecionado no dropDown
        foreach (PontosJogador dados in listaE.listaPontuacao) {    //for para atualizar os campos e mostrar os dados antigos
            if (dados.nomePlayer.Equals(quem)) {
                novoNome.text = dados.nomePlayer;
                novaPontuacao.text = dados.pontosPlayer.ToString();
                break;
            }
        }
    }
}
