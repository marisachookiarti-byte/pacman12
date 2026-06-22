using DefaultNamespace;
using UnityEngine;

public class level2 : MonoBehaviour
{
    public GameController two;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        two.scene = 0;
        two.maxCoin = 20;
    }
}
