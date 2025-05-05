using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 2f;
    public float raycastDistance = 0.1f;

    private int direction = 1;

    [SerializeField]
    private LayerMask layer;

    public Animator animator;

    public bool isFly;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("IsFly", isFly);
    }

    void Update()
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocityY);

        if (!IsGroundAhead())
        {
            Flip();
        }
    }

    bool IsGroundAhead()
    {
        Vector2 rayOrigin = transform.position + Vector3.right * direction * 0.6f;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, raycastDistance, layer);
        Debug.DrawRay(rayOrigin, Vector2.down * raycastDistance, Color.red);
        return hit.collider != null;
    }

    void Flip()
    {
        direction *= -1;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
