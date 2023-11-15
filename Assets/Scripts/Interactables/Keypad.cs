using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool isDoorOpen;            //best to not initaliz the value as we have isDoorOpen = !isDoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this func is used to design interactions
    protected override void Interact()
    {
        isDoorOpen = !isDoorOpen;
        door.GetComponent<Animator>().SetBool("isOpen", isDoorOpen);
        Debug.Log("interacted with" + gameObject.name);
    }
}
