
using System.IO;
using UnityEngine;

public class JsonSerializador{

    //obtem o caminho para salvar o arquivo
    private string obtemCaminho() {
        string nomeDoArquivo = "Json.json";
        string caminhoApp = Application.persistentDataPath;
        string caminho = Path.Combine(caminhoApp, nomeDoArquivo);
        return (caminho);
    }

    //esta função sera chamada apenas uma vez, ela servira para criar o arquivo Json no sistema
    public void preencherJsonSimples() {

        ListaPontosJogador listaPontos = new ListaPontosJogador();
        PontosJogador pontosJogador = new PontosJogador();
        pontosJogador.nomePlayer = "Exemplo";
        pontosJogador.pontosPlayer = 10;
        listaPontos.listaPontuacao.Add(pontosJogador);
        this.Create(listaPontos);
        

    }
    //função para adcionar um novo player a lista
    public void Create(ListaPontosJogador listaPontos) {
        string json = JsonUtility.ToJson(listaPontos);          //transforma a lista de pontos do jogador em uma string Json  
        string caminho = this.obtemCaminho();
        File.WriteAllText(caminho, json);                       //salva o arquivo

    }
    //se retornar null então quer dizer que o arquivo não foi criado ainda
    public ListaPontosJogador Retrieve() {
        ListaPontosJogador listaPontos = null;
        string caminho = this.obtemCaminho();
        string json = File.ReadAllText(caminho);
         listaPontos = JsonUtility.FromJson<ListaPontosJogador>(json);
        return listaPontos;
    }

    //metodo para realizar Update no jogador selecionado
    public bool Update(PontosJogador jogador, string quem) {
        bool playerExiste = false;
        ListaPontosJogador listaPontos = new ListaPontosJogador();
        listaPontos = this.Retrieve();

        //varre a lista de players araz de quem será editado
        foreach (PontosJogador jogadorE in listaPontos.listaPontuacao) {
            if (jogadorE.nomePlayer.Equals(quem))
            {
                playerExiste = true;
                listaPontos.listaPontuacao.Remove(jogadorE);            //remove o dado antigo
                listaPontos.listaPontuacao.Add(jogador);                //adciona o novo dado
                break;
            }
        }
        if (playerExiste) {
            this.Create(listaPontos);
        }
        return playerExiste;
    }

    public bool delete(string quem) {
        bool playerExiste = false;
        ListaPontosJogador listaPontosL = new ListaPontosJogador();
        listaPontosL = this.Retrieve();
        //varre a lisa de players para tentar encontrar quem sera deletado
        foreach (PontosJogador jogadorE in listaPontosL.listaPontuacao) {
            if (jogadorE.nomePlayer.Equals(quem)) {
                playerExiste = true;
                listaPontosL.listaPontuacao.Remove(jogadorE);           //remove os dados do player da lista
                break;
            }
        }
        if (playerExiste) {
            this.Create(listaPontosL);                                  //salva a lista sem o player
        }
        return playerExiste;
    }

    public bool verificarExistenciaArquivo() {
        string caminho = this.obtemCaminho();
        return File.Exists(caminho);                               //se o arquivo não existir retorna false
    }
}
