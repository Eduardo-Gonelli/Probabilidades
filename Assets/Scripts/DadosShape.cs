using UnityEngine;

public class DadosShape : MonoBehaviour
{
    public GameObject[] sides;

    public void GetSide(int side)
    {
        foreach (GameObject go in sides)
        {
            go.SetActive(false);
        }
        sides[side].SetActive(true);
    }
}
