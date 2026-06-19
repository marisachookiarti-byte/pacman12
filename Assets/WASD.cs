using UnityEngine;
using UnityEngine.InputSystem;

public class WASD : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float hiz = 2500;
    private int dx = 0;
    private int dy = 1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            dx = 1;
            dy = 0;
        }
        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            dx = -1;
            dy = 0;
        }
        if (Keyboard.current.wKey.wasPressedThisFrame)
        {
            dx = 0;
            dy = 1;
        }
        if (Keyboard.current.sKey.wasPressedThisFrame)
        {
            dx = 0;
            dy = -1;
        }
        transform.Translate(dx * Time.deltaTime, dy * Time.deltaTime, 0);
    }
}
