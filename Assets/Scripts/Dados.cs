using System.Linq;
using TMPro;
using UnityEngine;

public class Dados : MonoBehaviour
{
    public TextMeshProUGUI txtDados;
    int lados = 6;
    int[] dado1, dado2;
    public DadosShape dadosShape1, dadosShape2;
    int sorteio1, sorteio2, soma;    
    void Start()
    {
        CriarDados();
        RolarDados();        
    }

    void CriarDados()
    {
        dado1 = new int[lados];
        dado2 = new int[lados];
        for (int i = 0; i < lados; i++)
        {
            dado1[i] = i + 1;
            dado2[i] = i + 1;
        }
    }

    public void RolarDados()
    {
        // Aplicando maior randomicidade ao sorteio
        dado1 = ShuffleArray(dado1);
        dado2 = ShuffleArray(dado2);
        // Sorteia um valor aleatório entre 0 e 5
        sorteio1 = dado1[Random.Range(0, lados)];
        dadosShape1.GetSide(sorteio1 - 1);
        sorteio2 = dado2[Random.Range(0, lados)];
        dadosShape2.GetSide(sorteio2 - 1);
        soma = sorteio1 + sorteio2;
        PrintResult();
    }

    int[] ShuffleArray(int[] array)
    {
        System.Random random = new System.Random();
        return array.OrderBy(x => random.Next()).ToArray();
    }    

    void PrintResult()
    {
        int resultadosPossiveis_N = lados * lados;
        int probabilidade_n = 0;
        int evento = soma;
        float probabilidade = 0;
        float falha = 0;
        for (int i = 0; i < lados; i++)
        {
            for (int j = 0; j < lados; j++)
            {
                if (dado1[i] + dado2[j] == evento)
                {
                    probabilidade_n++;
                }
            }
        }
        probabilidade = (float)probabilidade_n / resultadosPossiveis_N;
        falha = 1 - probabilidade;

        txtDados.text = $"Rolar de Dados:\n" +
            $"Dado 1: {sorteio1}\n" +
            $"Dado 2: {sorteio2}\n" +
            $"Soma: {soma}\n" +
            $"Probabilidades de sair {soma} (n): {probabilidade_n}\n" +
            $"Todos os possíveis resultados (N): {resultadosPossiveis_N}\n" +
            $"Probabilidade do Evento (P): {probabilidade:P}" +
            $"\nFalha (1 - P): {falha:P}";
    }
}
