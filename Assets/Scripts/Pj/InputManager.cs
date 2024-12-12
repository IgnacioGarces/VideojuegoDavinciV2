using System;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    public static InputManager instance;
    private PlayerControllerInputs playerControllerInputs;
    public Action interactAction;
    public Action pause;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnEnable()
    {
        playerControllerInputs = new PlayerControllerInputs();
        playerControllerInputs?.Enable();
        playerControllerInputs.Player.Interact.performed += Shoot_performed;
        playerControllerInputs.Player.Pause.performed += Pause_performed;
    }
    private void OnDisable()
    {
        playerControllerInputs.Player.Interact.performed -= Shoot_performed;
        playerControllerInputs.Player.Pause.performed -= Pause_performed;
        playerControllerInputs?.Disable();
        playerControllerInputs = null;
    }
    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        interactAction?.Invoke();
    }
    public Vector2 GetMovementPj()
    {
        return playerControllerInputs.Player.Move.ReadValue<Vector2>();
    }
    private void Pause_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        pause?.Invoke();
    }
}
