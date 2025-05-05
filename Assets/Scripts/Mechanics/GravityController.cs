using UnityEngine;

public class GravityController : MonoBehaviour, IActivator
{
    private Rigidbody2D rb;
    private bool isGravity;
    [SerializeField] private float gravitySpeed = 5f;
    public AbilityCooldown gravityCd;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb == null)
        {
            Debug.Log("rb");
        }
    }

    void Update()
    {
        gravityCd.UpdateCooldown();
        if (Input.GetKeyDown(KeyCode.F) && gravityCd.IsReady)
        {
            SoundManager.PlaySound(SoundType.Gravity);
            ReverseGravity();

        }
    }
    public void ReverseGravity()
    {
        isGravity = !isGravity;
        rb.gravityScale *= -1;

        float forceDirection = isGravity ? 1 : -1;
        rb.AddForce(new Vector2(0, forceDirection * gravitySpeed), ForceMode2D.Impulse);
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
        gravityCd.StartCooldown();
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
       enabled = false;
    }
}
