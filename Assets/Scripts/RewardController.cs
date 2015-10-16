using UnityEngine;
using System.Collections;

public class RewardController : MonoBehaviour {

    public GameObject pReward1;
    public GameObject pReward2;
    public GameObject pReward3;
    public int rewardNumber;
    public Transform rewardTransform;
    private bool rewarded = false;
    private GameObject rewardObject;


	// Use this for initialization
	void Start () {    
        switch(rewardNumber)
        {
            case 1:
                rewardObject = pReward1;
                break;
            case 2:
                rewardObject = pReward2;
                break;
            case 3:
                rewardObject = pReward3;
                break;
            default:
                rewardObject = null;
                break;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Player" && !rewarded)
        {
            Reward();    
        }
    }

    void Reward()
    {
        Instantiate(rewardObject, new Vector3(rewardTransform.position.x, rewardTransform.position.y, rewardTransform.position.z), Quaternion.identity);
        rewarded = true;
        GetComponent<Animator>().SetBool("rewarded", true);
    }
}
