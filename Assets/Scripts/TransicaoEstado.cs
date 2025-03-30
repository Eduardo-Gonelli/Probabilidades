using UnityEngine;
using System.Linq;
using TMPro;

public class TransicaoEstado : MonoBehaviour
{
    public TextMeshProUGUI txtRandom;
    public TextMeshProUGUI txtCurrentState;
    public TextMeshProUGUI txtNumberOfStates;
    // Cria uma lista de estados poss�veis
    enum Estado { Atacar, Fugir, SeEsconder, Patrulhar }
    // Cria uma vari�vel para armazenar o estado atual
    Estado estadoAtual = Estado.Patrulhar;
    // Cria uma tabela de estados
    int[] tabela = new int[100];
    void Start()
    {
        // Preenche a tabela de estados
        for (int i = 0; i < 100; i++)
        {
            if (i < 50) { tabela[i] = (int)Estado.Atacar; }
            else if (i < 70) { tabela[i] = (int)Estado.Fugir; }
            else if (i < 80) { tabela[i] = (int)Estado.SeEsconder; }
            else { tabela[i] = (int)Estado.Patrulhar; }
        }
        // Faz um shuffle no array para que os estados sejam aleatorizados
        tabela = ShuffleArray(tabela);
        // tabela = KnuthShuffle(tabela);

        PrintCurrentState();
        PrintNumberOfStates();
        PrintAllStates();
    }

    // Exemplo de m�todo para embaralhar um array usando System.Linq, por Thomas Steffen
    // Fonte: https://thomassteffen.medium.com/super-simple-array-shuffle-with-linq-167b317ba035
    int[] ShuffleArray(int[] array)
    {
        System.Random random = new System.Random();
        return array.OrderBy(x => random.Next()).ToArray();
    }

    // Algoritmo Knuth Shuffle para aleatoriza��o de arrays (alternativa ao ShuffleArray com System.Linq)
    // Fonte: https://en.wikipedia.org/wiki/Fisher-Yates_shuffle
    int[] KnuthShuffle(int[] array)
    {
        for (int t = 0; t < array.Length; t++)
        {
            int tmp = array[t];
            int r = Random.Range(t, array.Length);
            array[t] = array[r];
            array[r] = tmp;
        }
        return array;
    }

    void PrintCurrentState()
    {
        // Faz um sorteio de 0 a 99 para definir o estado atual
        int novoEstado = Random.Range(0, 100);
        // Atualiza o estado atual
        estadoAtual = (Estado)tabela[novoEstado];
        txtCurrentState.text = "Estado Atual: " + estadoAtual;
    }

    // M�todo para imprimir o n�mero de estados
    void PrintNumberOfStates()
    {
        int counterState0 = 0;
        int counterState1 = 0;
        int counterState2 = 0;
        int counterState3 = 0;

        // Aqui fazemos um cast do nome do Estado para um int para comparar com i
        // Se o valor de i for igual ao valor do Estado, incrementamos o respectivo contador
        foreach (int i in tabela)
        {
            if (i == (int)Estado.Atacar) counterState0++;
            if (i == (int)Estado.Fugir) counterState1++;
            if (i == (int)Estado.SeEsconder) counterState2++;
            if (i == (int)Estado.Patrulhar) counterState3++;
        }
        txtNumberOfStates.text = 
            "Total de Estados:\n"+
            "Atacar: " + counterState0 + "\n" +
            "Fugir: " + counterState1 + "\n" +
            "Se Esconder: " + counterState2 + "\n" +
            "Patrulhar: " + counterState3
            ;
    }

    // M�todo para imprimir todos os estados
    void PrintAllStates()
    {
        txtRandom.text = "Estados Embaralhados:\n";
        foreach (int i in tabela)
        {
            // Estado � um enum e quando faz um cast do int para Estado, ele retorna o nome do estado
            txtRandom.text += (Estado)i + ", ";
        }
        // Remove a v�rgula e o espa�o do �ltimo estado
        txtRandom.text = txtRandom.text.Substring(0, txtRandom.text.Length - 2);
        // Adiciona o ponto final no �ltimo estado
        txtRandom.text += ".";
    }
}
