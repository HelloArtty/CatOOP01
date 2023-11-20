using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{

    [SerializeField] protected GameObject interactSymbol;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                interactSymbol.SetActive(true);
            }
        }
        
    }

    protected override void OnTriggerStay2D(Collider2D collision){
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                interactSymbol.SetActive(true);
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        if(collision != null)
        {
            if (collision.CompareTag("Player"))
            {
                interactSymbol.SetActive(false);
            }
        }
    }
}
