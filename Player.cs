using NUnit.Framework;
using UnityEngine;
using UnityEngine.AdaptivePerformance;

public class Player : MonoBehaviour
{   
    public float MoveForce = 10f;
    [SerializeField]
    private float JumpForce = 15f;
    
    private float movementx;
    private Rigidbody2D mybody;
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "walk";
    private bool isGrounded;
    private string GROUND_TAG = "Ground";
    private string Enemy_Tag = "Enemy";
    private bool jumpRequested = false;
     // Set these in Inspector for each player
    void Awake()
    {
        mybody= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playermovement();
        Playeranimation();

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        if (jumpRequested)
        {
        jumpRequested = false;
        isGrounded = false;
        mybody.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }

    }

    void playermovement()
    {
        movementx = Input.GetAxisRaw("Horizontal");
        
        transform.position += new Vector3(movementx , 0f, 0f ) * Time.deltaTime * MoveForce;
    }

    void Playeranimation()
    {
        if (movementx > 0)
        {
            anim.SetBool(WALK_ANIMATION , true);
            sr.flipX =false;
        }
        else if(movementx < 0)
        {
            anim.SetBool(WALK_ANIMATION , true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION , false);
        }
    }

    void Playerjump()
    {
        if (Input.GetButtonUp("Jump") && isGrounded)
        {
            isGrounded = false;
            mybody.AddForce(new Vector2(0f , JumpForce), ForceMode2D.Impulse);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
            Debug.Log("object has collided");
        }

        if (collision.gameObject.CompareTag(Enemy_Tag))
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Enemy_Tag))
            Destroy(gameObject);
        
    }


} //class
