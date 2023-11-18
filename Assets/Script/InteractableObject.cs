using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{

    [SerializeField] protected GameObject buttonPrefab;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                buttonPrefab.SetActive(true);
            }
        }
        
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                buttonPrefab.SetActive(false);
            }
        }
    }
}
