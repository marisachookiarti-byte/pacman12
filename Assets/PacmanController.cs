using UnityEngine;
using UnityEngine.Events;

public class PacmanController : MonoBehaviour
{
    public float speedMul = 5f;
    public UnityEvent<Collision2D> eatCoinEvent;
    
    public void ReceiveInput(Vector2 input)
    {
        Debug.Log($"$[PacmanController] input received {input.ToString()}");
        transform.Translate(input.x * Time.deltaTime * speedMul, input.y * Time.deltaTime * speedMul, 0);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        eatCoinEvent.Invoke(collision);
    }
}
