using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Aleatoriedade : MonoBehaviour
{
    public TextMeshProUGUI txtFc;
    public TextMeshProUGUI txtRm;
    public TextMeshProUGUI txtRm3;
    public TextMeshProUGUI txtRm10;
    List<int> fc = new List<int>();
    List<int> rm = new List<int>();
    List<int> rm3 = new List<int>();
    List<int> rm10 = new List<int>();
    int n = 100;
    
    void Start()
    {
        // Alimenta as listas com valores aleatórios
        for (int i = 0; i < n; i++)
        {
            fc.Add(FlipCoin());
            rm.Add(RandomMedia());
            rm3.Add(RandomMedia(3));
            rm10.Add(RandomMedia(10));
        }
        PrintResult();
    }
    
    // Sorteia um valor aleatório entre 0 e 1
    int FlipCoin()
    {
        float random = Random.Range(0f, 1f);
        return random > 0.5 ? 1 : 0;
    }
    // Sorteia n vezes um valor aleatório entre 0 e 99 e retorna a média
    int RandomMedia(int loopCount = 1)
    {
        int sum = 0;
        for (int i = 0; i < loopCount; i++)
        {
            sum += Random.Range(0, 99);
        }
        return sum / loopCount;
    }

    void PrintResult()
    {
        // Média do FlipCoin
        string fcStr = "";
        int fcSum1 = 0;
        int fcSum2 = 0;
        foreach (int i in fc)
        {            
            if(i == 0) fcSum1++;
            else fcSum2++;
        }
        fcStr = $"Sorteios:\n0: {fcSum1}\n1: {fcSum2}";
        txtFc.text += "\n\n" + fcStr;
        // Random simples
        txtRm.text += $"\n\nMedia: {CalculateMedia(rm)}";
        txtRm.text += $"{CalculateChances(rm)}";
        // Média do RandomMedia 3
        txtRm3.text += $"\n\nMedia: {CalculateMedia(rm3)}";
        txtRm3.text += $"{CalculateChances(rm3)}";
        // Média do RandomMedia 10
        txtRm10.text += $"\n\nMedia: {CalculateMedia(rm10)}";
        txtRm10.text += $"{CalculateChances(rm10)}";
    }

    // Resultados do RandomMedia
    string CalculateChances(List<int> list)
    {
        string[] rmString = new string[10];
        string rmResult = "";
        int[] rmSum = new int[10];
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] < 10) rmSum[0]++;
            else if (list[i] >= 10 && list[i] < 20) rmSum[1]++;
            else if (list[i] >= 20 && list[i] < 30) rmSum[2]++;
            else if (list[i] >= 30 && list[i] < 40) rmSum[3]++;
            else if (list[i] >= 40 && list[i] < 50) rmSum[4]++;
            else if (list[i] >= 50 && list[i] < 60) rmSum[5]++;
            else if (list[i] >= 60 && list[i] < 70) rmSum[6]++;
            else if (list[i] >= 70 && list[i] < 80) rmSum[7]++;
            else if (list[i] >= 80 && list[i] < 90) rmSum[8]++;
            else rmSum[9]++;
        }
        for (int i = 0; i < 10; i++)
        {
            rmString[i] = "\n" + "< " + (i + 1).ToString() + "0: " + rmSum[i].ToString();
        }

        foreach (string s in rmString)
        {
            rmResult += s;
        }
        return rmResult;
    }

    // Calcula a média de uma lista de inteiros
    string CalculateMedia(List<int> list)
    {
        int sum = 0;
        foreach (int i in list)
        {
            sum += i;
        }
        return (sum / list.Count).ToString();
    }

    public void NewRandom()
    {
        fc.Clear();
        rm.Clear();
        rm3.Clear();
        rm10.Clear();
        txtFc.text = "Flip Coin";
        txtRm.text = "Random Simples";
        txtRm3.text = "Random Média 3";
        txtRm10.text = "Random Média 10";
        Start();
    }
}
