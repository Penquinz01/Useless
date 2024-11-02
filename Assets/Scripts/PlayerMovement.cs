using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed=5f;
    Vector2 dir;
    Animator anim;
    [SerializeField] Transform _startingPosition;
    [SerializeField] AudioManager audioManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = _startingPosition.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = dir;
        anim.SetFloat("SpeedX",rb.linearVelocity.x);
        anim.SetFloat("SpeedY",rb.linearVelocity.y);
        anim.SetFloat("Speed", (rb.linearVelocity == Vector2.zero) ? 0 : 1);
    }
    public void Move(InputAction.CallbackContext cxt)
    {
        dir =    cxt.ReadValue<Vector2>();
        if ((Mathf.Abs(dir.x) > 0) && (Mathf.Abs(dir.y) > 0))
        {
            dir = Vector2.zero;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Maze")){
            audioManager.Play(0);
        }
    }
}
