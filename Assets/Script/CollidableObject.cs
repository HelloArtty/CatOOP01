using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collision){}
    protected virtual void OnTriggerStay2D(Collider2D collision){}
    protected virtual void OnTriggerExit2D(Collider2D collision){}
}
