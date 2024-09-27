using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;  // changes the value of movement at x axis 
    [SerializeField] private float JumpingPower; // changes the value of movement at y axis 
    private bool grounded;       // a bool parameter 
    private Rigidbody2D body;    // we made this variable to basically fetch the rigidbody2d component
    private Animator anim;       // we made this variable to basically fetch the animator component


    // Respawn Point
    private Vector3 respawnPoint; // going to record the position of the player ( whereever it starts )
    public GameObject fallDetector;


    // Audio 
    [SerializeField] private AudioSource jumpsoundEffect;

    private void Awake()         // whenever we will run the game then this functions will always be called
    {
        // Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }
    private void Start()
    {
        respawnPoint = transform.position;
    }
    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");        // bascially it will change movement on x axis
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y); 

        // flip player when moving left-right
        if(horizontalInput > 0.01f)
        {
            transform.localScale = new Vector3(2, 2, 1);
        }
        else if ( horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-2 , 2 , 1);
        }

        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }

        // Set animator parameters
        anim.SetBool("isWalking", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

        // fall detector -->
        fallDetector.transform.position = new Vector2(transform.position.x , fallDetector.transform.position.y);  // changing position of fall detector.Here, x is the position of the player (meaning it will move along with player position)  object and y is its current position
    }

    private void Jump()
    {
        jumpsoundEffect.Play();
        body.velocity = new Vector2(body.velocity.x, JumpingPower);
        anim.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    // coin manager
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FallDetector")
        {
            transform.position = respawnPoint;
        }
        else if (collision.gameObject.tag == "CheckPoint")
        {
            respawnPoint = transform.position;
        }
        else if(collision.gameObject.tag == "Water")
        {
            transform.position = respawnPoint;
        }
    }   
}


