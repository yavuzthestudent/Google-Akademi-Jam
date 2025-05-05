using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour, IActivator
{

    [SerializeField]
    private List<GameObject> character;

    private int activePlayer = 0;

    public static GameManager Instance;
    public GameObject ActivePlayer => character[activePlayer];
    public Rigidbody2D ActivePlayerRb => character[activePlayer].GetComponent<Rigidbody2D>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        Disable();
        Enable();
    }

    void Update()
    {
        Activator();
    }

    private void Activator()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            activePlayer++;
            if (activePlayer == character.Count)
            {
                activePlayer = 0;
            }
            Disable();
            Enable();
        }
    }

    public void Enable()
    {
        foreach (var activator in character[activePlayer].GetComponents<IActivator>())
        {
            activator.Enable();
        }
        ActivePlayerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void Disable()
    {
        foreach (var item in character)
        {
            foreach (var activator in item.GetComponents<IActivator>())
            {
                activator.Disable();
            }
            
            Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezePositionX|RigidbodyConstraints2D.FreezeRotation;
        }
    }
}
