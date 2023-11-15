using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    private InputManager _inputManager;
    public Camera cam;
    public float xRotation = 0f;

    [SerializeField]
    [Range(0.1f, 20f)] float xSensi = 1f;
    [SerializeField]
    [Range(0.1f, 10f)] float ySensi = 1f;

    private void Awake()
    {
        _inputManager = GetComponent<InputManager>();   
    }

    private void LateUpdate()
    {

    }

    public void PLook(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y; 
        //calculating camera rotation for looking up and down
        xRotation -= (mouseY * Time.deltaTime) * ySensi;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);                          //clamp(for which, min , max)
        
        //moving cam
        //Quaternion camRotation = Quaternion.Euler(xRotation, 0f, 0);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //able to see left and right from players pov
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime) * xSensi);   
    }
}
