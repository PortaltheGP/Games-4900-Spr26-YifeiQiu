using UnityEngine;

using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputActionReference moveAction; // 指向 Move
    [SerializeField] private InputActionReference keyAction;//Attack
    [SerializeField] private float speed = 5f;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        if (moveAction != null) moveAction.action.Enable();
        if (keyAction != null) keyAction.action.Enable();
    }

    private void OnDisable()
    {
        if (moveAction != null) moveAction.action.Disable();
        if (keyAction != null) keyAction.action.Disable();
    }

    private void Update()
    {
        // ===== 移动 =====
        if (moveAction != null)
        {
            Vector2 input = moveAction.action.ReadValue<Vector2>(); // (x=AD, y=WS)

            Vector3 move =
                transform.forward * input.y +
                transform.right   * input.x;

            if (move.sqrMagnitude > 1f) move.Normalize();

            controller.Move(move * (speed * Time.deltaTime));
        }

        // ===== 检测特定按键 =====
        if (keyAction != null && keyAction.action.WasPressedThisFrame())
        {
            Debug.Log("Attack!!");
        }
    }
}