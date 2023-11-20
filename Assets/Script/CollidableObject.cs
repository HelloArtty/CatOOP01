using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter Collided with " + collision.gameObject.name);
    }

    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Stay Collide with " + collision.gameObject.name);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Enter Collided with " + collision.gameObject.name);
    }

}
