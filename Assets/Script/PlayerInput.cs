using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private void PressSubmit()
    {
        GameEventManager.instance.submitPressEvent.SubmitPressed();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            PressSubmit();
        }
    }
}
