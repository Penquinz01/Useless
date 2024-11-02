using System.Collections;
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
    private bool _canMove = true;
    [SerializeField] Transform _endPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        transform.position = _startingPosition.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_canMove)rb.linearVelocity = dir;
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Trap"))
        {
            GameManager.Instance.Trap();
            StartCoroutine(Restart());
            
        }
        if (collision.CompareTag("Login"))
        {
            GameManager.Instance.LastScene();
        }
    }
    IEnumerator Restart()
    {   
        _canMove = false;
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(3);
        transform.position = _startingPosition.position;
        _canMove = true;
    }
    public void T(InputAction.CallbackContext cxt)
    {
        if (cxt.performed)
        {
            transform.position = _endPoint.position;
        } 
    }
}
