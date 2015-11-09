using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float MoveSpeed;
    public float JumpHeight;

    // Player physics
    public PhysicsMaterial2D playerMaterial;

    //Ground Checking
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded; // Not accessable in editor or by other classes!
    private bool facingRight = true;

    public bool isBig = false;

    // Top Checking
    public Transform topCheck;
    public float topCheckRadius;
    public LayerMask whatIsPlatform;
    private bool isTopChecking;


    //Animator
    private Animator anim; // Allows us to use the animator in code

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}

    void FixedUpdate() // Occures as set ammount of times every single second; Good for physics stuff!
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if(grounded)
        {
            anim.SetBool("grounded", true);
            playerMaterial.friction = 1;
        } else
        {
            anim.SetBool("grounded", false);
            playerMaterial.friction = 0;
        }

        isTopChecking = Physics2D.OverlapCircle(topCheck.position, topCheckRadius, whatIsPlatform);
        

    }
	
	// Update is called once per frame
	void Update () {
        //Controlls
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
            }
        }

        //Left Right Movement
        if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            facingRight = false;
            anim.SetBool("moving", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            facingRight = true;
            anim.SetBool("moving", true);
        } else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
            anim.SetBool("moving", false);
        }

        if(!facingRight)
        {
            GetComponent<Transform>().localRotation = Quaternion.Euler(0, 180, 0);
        } else if(facingRight)
        {
            GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
        }
        
	}
}
