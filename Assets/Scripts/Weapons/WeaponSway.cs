using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSway : MonoBehaviour
{
    public PlayerControls playerControls;
    [SerializeField]
    private float maxTurn = 8f;
    [SerializeField]
    private float rotateSpeed = 4f;

    /*
    private void Start()
    {
        playerControls = GetComponent<PlayerControls>();
        w_look = playerControls.Player.Look.ReadValue<Vector2>();
    }
    */
    public void GunSway(Vector2 input)
    {
        input = Vector2.ClampMagnitude(input, maxTurn);

        float mouseX = input.x;
        float mouseY = input.y;

        //claculate targetRotation
        Quaternion xRot = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion yRot = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRot = xRot * yRot;

        //rotate
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, rotateSpeed *Time.deltaTime);
    }
    /*
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }
    private void Update()
    {
        if (playerControls != null) 
        {
            ApplyRotation(GetRotation(w_look));
        }
    }

    public Quaternion GetRotation(Vector2 input)
    {
        input = Vector2.ClampMagnitude(input, maxTurn);
        float mouseX = input.x; 
        float mouseY = input.y;

        Quaternion rotX = Quaternion.AngleAxis(-mouseY, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(mouseX, Vector3.up);

        Quaternion targetRot = rotX * rotY;

        return targetRot;
    }

    //public Transform GetTransform() => transform;

    public void ApplyRotation(Quaternion targetRot)//, System.Func<Transform> getTransform)
    {
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRot, rotateSpeed * Time.deltaTime);
    }
    */


}
