using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float bounds = 3.3f;

    Rigidbody rb;
    Vector3 movement;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 startPos = rb.position;
        Vector3 moveDirection= startPos+movement*Time.deltaTime*moveSpeed;
        rb.MovePosition(moveDirection);
        rb.position = new Vector3( Mathf.Clamp(rb.position.x, -bounds, bounds), rb.position.y, rb.position.z);
    }

    public void Move( InputAction.CallbackContext cc)
    {
        movement = cc.ReadValue<Vector2>();
    }
}
