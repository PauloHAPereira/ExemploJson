
using UnityEngine;
using UnityEngine.UI;

public class Gerenciador : MonoBehaviour {
    public Text texto;
    public Button btnLista, btnCadastrar, btnEditar, btnRemover;
    public JsonSerializador serializador = new JsonSerializador();
    // Use this for initialization
    void Start() {
        //se não foe encontrado o arquivo Json, então crie um novo
        if (serializador.verificarExistenciaArquivo()==false) {
            serializador.preencherJsonSimples();
        }
    }

    // Update is called once per frame
    void Update() {

    }

    //chama a tela de cadastro de um novo player
    public void criar() {
        GerenciadorDeTelas.mudarTela(1);
    }

    //lista na tela todo o conteudo do Json
    public void listar() {
        ListaPontosJogador listaJogadorL = new ListaPontosJogador();
        listaJogadorL = serializador.Retrieve();
        string pontuacao = "";
        foreach (PontosJogador jogadorE in listaJogadorL.listaPontuacao) {
            pontuacao += "Nome: " + jogadorE.nomePlayer + " Pontos: " + jogadorE.pontosPlayer + "\n";
        }
        texto.text = pontuacao;
    }

    //chama a tela de edição
    public void editar() {
        GerenciadorDeTelas.mudarTela(3);
    }

    //chama a tela de deletar
    public void deletar()
    {
        GerenciadorDeTelas.mudarTela(2);
    }
}
