using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //msg displayed when we try to interact with anything
    public string promptMsg;

    //this will be invoked from our player
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //this is a tempalte function to be overridden 
    }


}
