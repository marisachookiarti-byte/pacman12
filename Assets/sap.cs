using UnityEngine;

public class sap : MonoBehaviour
{
    public GameObject coin;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i=0; i < 10; i++) {
            Instantiate(coin, new Vector3(Random.Range(-10, 10), Random.Range(-4, 4), 0), transform.rotation);
        }
    }
}
