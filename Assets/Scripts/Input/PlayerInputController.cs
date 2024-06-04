using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private GameInput _gameInput;
    private IMovable _iMovable;

    private void Awake()
    {
        _gameInput = new GameInput();
        _gameInput.Enable();

        _iMovable = GetComponent<IMovable>();
    }

    private void OnEnable()
    {
        _gameInput.Player.Jump.performed += onJump;
    }

    private void OnDisable()
    {
        _gameInput.Player.Jump.performed -= onJump;
    }

    private void Update()
    {
        ReadMoveVector();
    }

    private void ReadMoveVector()
    {
        var moveDirection = _gameInput.Player.Move.ReadValue<Vector2>().normalized;
        _iMovable.Move(moveDirection);
    }

    private void onJump(InputAction.CallbackContext context)
    {
        _iMovable.Jump();
    }
}
