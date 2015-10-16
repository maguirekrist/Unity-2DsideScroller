using UnityEngine;
using System.Collections;

public class BigUpEffect : MonoBehaviour {

    public bool moveRight;
    public float moveSpeed;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(moveRight)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player")
        {
            other.GetComponent<Animator>().SetBool("isBig", true);
            other.GetComponent<CircleCollider2D>().radius = 0.15f;
            other.GetComponent<BoxCollider2D>().size = new Vector2(0.18f, 0.31f);
            other.GetComponent<BoxCollider2D>().offset = new Vector2(0f, 0.01f);
            other.GetComponent<PlayerController>().isBig = true;
            Destroy(gameObject);
        }
    }
}
