using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class InputManager : MonoBehaviour
{

    public PlayerControls playerControls;
    private PlayerMotor p_motor;
    private PlayerLook p_look;
    private WeaponSway weaponSway;
    private GunController gunController;
    private WeaponSwitch weaponSwitch;
    private GameManager gameManager;

    public InputAction move;
    public InputAction jump;
    public InputAction look;
    public InputAction interact;
    public InputAction fire;
    public InputAction switching;
    public InputAction pausing;

    private Vector3 movement = Vector3.zero;
    private Vector3 pov = Vector3.zero;
    private Vector3 w_look = Vector3.zero;

    Coroutine FireCoroutine;

    private void Awake()
    {
        playerControls = new PlayerControls();
        gunController = FindAnyObjectByType<GunController>();
        p_motor = GetComponent<PlayerMotor>();            //getting the playermototr script here for movemnt
        p_look = GetComponent<PlayerLook>();
        weaponSway = FindAnyObjectByType<WeaponSway>();
        weaponSwitch = FindAnyObjectByType<WeaponSwitch>();
        gameManager = FindAnyObjectByType<GameManager>();

        move = playerControls.Player.Move;
        jump = playerControls.Player.Jump;
        look = playerControls.Player.Look;
        interact = playerControls.Player.Interact;
        fire = playerControls.Player.Fire;
        switching = playerControls.Player.WeaponSwitch;
        pausing = playerControls.Player.Pause;

        jump.started += ctx => p_motor.PJump();         //subscribed to jump event
        fire.started += ctx => gunController.StartFiring();      //subscribed  to  startfiring
        fire.canceled += ctx => gunController.StopFirirng();          //subscribed  to  stopfiring
                                                                      //subscribed to switching
        switching.performed += ctx => weaponSwitch.SwitchingWeapon();
        pausing.performed += ctx => gameManager.TogglePauseGame();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }

    private void FixedUpdate()
    {
        //player movement
        movement = move.ReadValue<Vector2>();
        p_motor.PMoving(movement);
        p_motor.PForce(movement);
        //movement of cam
        pov = look.ReadValue<Vector2>();
        p_look.PLook(pov);
        //movement of guncam
        w_look = look.ReadValue<Vector2>();
        weaponSway.GunSway(w_look);
    }
}
