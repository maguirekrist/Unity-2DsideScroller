using UnityEngine;
using System.Collections;

public class GumbaController : MonoBehaviour {

    public bool startRight;
    public float moveSpeed;
    public float playerJumpBack;

    public Transform colliderCheck;
    public float colliderCheckRadius;
    public LayerMask whatIsCollider;
    public LayerMask whatIsPlayer;
    private bool touching;
    private bool movingRight;
    private bool contactPlayer;
    private GameObject player;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        touching = Physics2D.OverlapCircle(colliderCheck.position, colliderCheckRadius, whatIsCollider);
        contactPlayer = Physics2D.OverlapCircle(colliderCheck.position, colliderCheckRadius, whatIsPlayer);
        if(touching || contactPlayer)
        {
            movingRight = !movingRight;
            player = GameObject.FindGameObjectWithTag("Player");
            if(contactPlayer)
            {
                Destroy(player);
                Debug.Log("Destroy Player called!");
            }
        }
        else
        {
            if (movingRight)
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            else
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (movingRight)
        {
            GetComponent<Transform>().localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            GetComponent<Transform>().localRotation = Quaternion.Euler(0, 180, 0);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            other.GetComponent<Rigidbody2D>().velocity = new Vector2(other.GetComponent<Rigidbody2D>().velocity.x, playerJumpBack);
            Destroy(gameObject);
        }
    }
}
