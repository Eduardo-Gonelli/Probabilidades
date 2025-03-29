using UnityEngine;

public class TransicaoEstado : MonoBehaviour
{
    // Cria uma lista de estados possíveis
    enum Estado { Atacar, Fugir, SeEsconder, Patrulhar }
    // Cria uma variável para armazenar o estado atual
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
        for (int i = 0; i < 100; i++)
        {
            int temp = tabela[i];
            int randomIndex = Random.Range(i, 99);
            tabela[i] = tabela[randomIndex];
            tabela[randomIndex] = temp;
        }

        // Faz um sorteio para definir o novo estado
        int novoEstado = Random.Range(0, 99);
        // Atualiza o estado atual
        estadoAtual = (Estado)tabela[novoEstado];
        Debug.Log("Estado Atual: " + estadoAtual);

        //PrintNumberOfStates();
        PrintAllStates();
    }

    // Método para imprimir o número de estados
    void PrintNumberOfStates()
    {
        int counterState0 = 0;
        int counterState1 = 0;
        int counterState2 = 0;
        int counterState3 = 0;

        foreach (int i in tabela)
        {
            if (i == (int)Estado.Atacar) counterState0++;
            if (i == (int)Estado.Fugir) counterState1++;
            if (i == (int)Estado.SeEsconder) counterState2++;
            if (i == (int)Estado.Patrulhar) counterState3++;
        }
        Debug.Log(
            "Número de estados:\n"+
            "Atacar: " + counterState0 + "\n" +
            "Fugir: " + counterState1 + "\n" +
            "Se Esconder: " + counterState2 + "\n" +
            "Patrulhar: " + counterState3
            );
    }

    // Método para imprimir todos os estados
    void PrintAllStates()
    {
        foreach (int i in tabela)
        {
            Debug.Log((Estado)i);
        }
    }
}
