using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D _comprigidbody2D;
    private SpriteRenderer _compspriteRenderer;
    public float speedX;
    public float JumpingPower;
    public int maxJumps = 2;
    private int jumpsRemaining;
    public float raycastDistance = 1f;
     public BarraDeVida LifeController;
    private bool isCollidingEnemy = false;
    public Contador contador;

    public LayerMask collisionMask;
    public int Colore;

    private float Horizontal; 
    private void Awake()
    {
        _comprigidbody2D = GetComponent<Rigidbody2D>();
        _compspriteRenderer = GetComponent<SpriteRenderer>();
        jumpsRemaining = maxJumps; 
    }

    void Update()
    {

      
        Horizontal = Input.GetAxisRaw("Horizontal");
        _comprigidbody2D.velocity = new Vector2(Horizontal * speedX, _comprigidbody2D.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
      
            _comprigidbody2D.velocity = new Vector2(_comprigidbody2D.velocity.x, JumpingPower);
            jumpsRemaining = jumpsRemaining - 1;

  
            if (jumpsRemaining == 0)
            {
                _comprigidbody2D.velocity = new Vector2(_comprigidbody2D.velocity.x, JumpingPower);
            }
        }


        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, collisionMask);
        if (hit.collider != null)
        {
            jumpsRemaining = maxJumps;
        }

        if(Colore == 1)
        {
            _compspriteRenderer.color = Color.green;
        }
        else if(Colore == 2)
        {
            _compspriteRenderer.color = Color.red;
        }
        else if (Colore == 3)
        {
            _compspriteRenderer.color = Color.blue;
        }
        else if(Colore == 4)
        {
            _compspriteRenderer.color = Color.yellow;
        }
        else if(Colore == 5)
        {
            _compspriteRenderer.color = Color.cyan;
        }

        LifeController.Vidas();

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Portal")
        {
            contador.CambiarEscenaYouwin();
        }
        if (other.gameObject.tag == "Portal1")
        {
            contador.CambiarEscenaYouwin2();
        }
    }
    public void SetIsColEnemy(bool value)
    {
        isCollidingEnemy = value;
    }
    public bool GetIsCollidingWithEnemy()
    {
        return isCollidingEnemy;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * raycastDistance);
    }

    
}

