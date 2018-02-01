using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpcoesDropDown {

    private ListaPontosJogador listaJ = new ListaPontosJogador();
    private JsonSerializador serializador = new JsonSerializador();
    private Dropdown dpdPlayes;

    //popula/atualiza a lista contendo os players cadastrados
    public  Dropdown popularDropDown(Dropdown dropdown)
    {
        this.dpdPlayes = dropdown;
        dpdPlayes.ClearOptions();
        listaJ = serializador.Retrieve();
        //se a lista estiver vazia significa que não há nenhum player cadastrado
        if (listaJ == null)
        {
            //retorna um dpPlayers nulo
            dpdPlayes = null;
            return dpdPlayes;
        }
        else
        {
            List<string> nomes = new List<string>();
            foreach (PontosJogador dados in listaJ.listaPontuacao)
            {
                nomes.Add(dados.nomePlayer);
                //Debug.Log("entrei: " + dados.nomePlayer);
            }
            dpdPlayes.AddOptions(nomes);
            return dpdPlayes;
        }
        
    }

    public string selecionarItemDpd(Dropdown dropdown) {
        string quem="";
        quem = dpdPlayes.options[dpdPlayes.value].text;
        return quem;
    }
}
