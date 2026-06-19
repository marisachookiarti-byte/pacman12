using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class WASD : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float hiz = 2500;
    private int dx = 0;
    private int dy = 1;

    public KeyControl upKey;
    public KeyControl downKey;
    public KeyControl leftKey;
    public KeyControl rightKey;

    public UnityEvent<Vector2> movementEvent;
    
    void Start()
        {
        upKey = Keyboard.current.wKey;
        downKey = Keyboard.current.sKey;
        leftKey = Keyboard.current.aKey;
        rightKey = Keyboard.current.dKey;

    }

    // Update is called once per frame
    void Update()
    {
        if (rightKey.isPressed)
        {
            movementEvent.Invoke(new Vector2(1, 0));
        }
        if (leftKey.isPressed)
        {
            movementEvent.Invoke(new Vector2(-1, 0));
        }
        if (upKey.isPressed)
        {
            movementEvent.Invoke(new Vector2(0, 1));
        }
        if (downKey.isPressed)
        {
            movementEvent.Invoke(new Vector2(0, -1));
        }
    }
}
