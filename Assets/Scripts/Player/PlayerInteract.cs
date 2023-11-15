using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] 
    private float distance = 1f;
    [SerializeField]
    private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //the text will be empty when we dont hit the ray with the obj
        playerUI.UpdateText(string.Empty);

        //creates a ry from origin towars the forward direction from centre of cam of infinte distance
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        //to store collision info
        RaycastHit hitInfo;                      
        if(Physics.Raycast(ray, out hitInfo, distance, mask))                                       //raycasting through centre of screen
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMsg);
                if(inputManager.interact.triggered)                                                 //works same like input.getkeydown works
                {
                    interactable.BaseInteract();
                }
            }
        }

    }
}
