//  Random movement script for Unity GameObjects
//  GameObjects with this script attached will constantly move at a random range of speed
//  and rotate at a random range of angles, and upon collision with walls or other GameObject tags,
//  the movement direction will change.

using UnityEngine;
using System.Collections;

public class RandomMovement : MonoBehaviour
{

    //public AudioClip AlienScream;
    public float minSpeed = 3;  // minimum range of speed to move
    public float maxSpeed = 6;  // maximum range of speed to move
    float speed;     // speed is a constantly changing value from the random range of minSpeed and maxSpeed 

    public string[] collisionTags;             //  What are the GO tags that will act as colliders that trigger a
                                               //  direction change? Tags like for walls, room objects, etc.
    public AudioClip collisionSound;

    float step = Mathf.PI / 60;
    float timeVar = 0;
    float rotationRange = 120;                  //  How far should the object rotate to find a new direction?
    float baseDirection = 0;

    Vector3 randomDirection;                // Random, constantly changing direction from a narrow range for natural motion


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("border"))
        {                   //  Tag it with a wall or other object
            baseDirection = baseDirection + Random.Range(150, 210);   // Switch to a new direction on collision
        }
        if (collision.gameObject.CompareTag("coin")) { 
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>(), true); 
        }
    }
    void Update()
    {
        randomDirection = new Vector3(0, Mathf.Sin(timeVar) * (rotationRange / 2) + baseDirection, 0); //   Moving at random angles 
        timeVar += step;
        speed = Random.Range(minSpeed, maxSpeed);              //      Change this range of numbers to change speed
        GetComponent<Rigidbody2D>().AddForce(transform.forward * speed);
        transform.Rotate(randomDirection * Time.deltaTime * 10.0f);
    }
}