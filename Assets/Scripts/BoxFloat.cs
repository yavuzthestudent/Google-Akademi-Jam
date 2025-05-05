using DG.Tweening;
using UnityEngine;

public class BoxFloat : MonoBehaviour, IActivator
{
    private Rigidbody2D rb;
    public float floatForce = 10f;
    public float floatDuration = 2f; // Kuvvetin uygulanacaðý süre
    private float floatTimer = 0f;
    bool isFloating = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            SoundManager.PlaySound(SoundType.WaterBlink);
            rb.linearDamping = 5f; // Suda yavaþlama
            rb.angularDamping = 5f; // Dönüþ de yavaþlasýn
            floatTimer = floatDuration; // Süreyi baþlat
            isFloating = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Water"))
        {
            rb.linearDamping = 1f; // Sudan çýkýnca eski haline dön
            rb.angularDamping= 0.05f;
        }
    }
    private void Update()
    {
        if (isFloating)
        {
            if (floatTimer > 0 )
            {
                rb.AddForce(Vector2.up * floatForce);
                floatTimer -= Time.deltaTime; // Süreyi azalt
            }
            else
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Süre bitince yukarý hareketi durdur
            }
        }

    }

    public void Enable()
    {
        rb.gravityScale = 1;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
    }

    public void Disable()
    {
        
    }

    //private void OnTriggerStay2D(Collider2D other)
    //{
    //    if (other.CompareTag("Water"))
    //    {
    //        if (floatTimer > 0)
    //        {
    //            rb.AddForce(Vector2.up * floatForce);
    //            floatTimer -= Time.deltaTime; // Süreyi azalt
    //        }
    //        else
    //        {
    //            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Süre bitince yukarý hareketi durdur
    //        }
    //    }
    //}
}
