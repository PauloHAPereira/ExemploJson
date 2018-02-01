using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Deletar : MonoBehaviour {

    public Button btnDeletar, btnVoltar;
    public Dropdown dpdListaPlayers;
    public Text status;
    private OpcoesDropDown dropDown = new OpcoesDropDown();
    private JsonSerializador serializador = new JsonSerializador();
    // Use this for initialization
	void Start () {
        //pupula o dropDown assim que a tela é chamada
        dpdListaPlayers = dropDown.popularDropDown(dpdListaPlayers);
	}

    //tratamento do botão de deletar
    public void deletar() {
       string quem;
        //obtem os nome selecionado
        quem = dropDown.selecionarItemDpd(dpdListaPlayers);
        //se vazio, então nenhum item foi selecionado
        if (quem.Equals(""))
        {
            status.text = "Nenhum item selecionado";
        }
        else
        {
            //deleta o titem selecionado
            serializador.delete(quem);
            status.text = "Player deletado com sucesso!";
        }
        //atualiza o dropDown
        dpdListaPlayers = dropDown.popularDropDown(dpdListaPlayers);
    }
    //tratamento do botão voltar
    public void voltar() {
        GerenciadorDeTelas.mudarTela(0);
    }

}
