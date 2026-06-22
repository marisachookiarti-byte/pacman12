using DefaultNamespace;
using UnityEngine;

public class level1 : MonoBehaviour
{
    public GameController one;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        one.scene = 1;
        one.maxCoin = 10;
    }
}
