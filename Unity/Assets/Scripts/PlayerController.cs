using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction; // 指向 Move
    [SerializeField] private float speed = 5f;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        if (moveAction != null) moveAction.action.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null) moveAction.action.Disable();
    }

    private void Update()
    {
        if (moveAction == null) return;

        Vector2 input = moveAction.action.ReadValue<Vector2>(); // (x=AD, y=WS)

        // 让 WASD 按“角色自身朝向”移动：W=forward, S=back, A=left, D=right
        Vector3 move =
            transform.forward * input.y +
            transform.right   * input.x;

        // 防止斜向更快
        if (move.sqrMagnitude > 1f) move.Normalize();

        controller.Move(move * (speed * Time.deltaTime));
    }
}