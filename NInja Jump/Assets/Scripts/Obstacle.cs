using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody2D tree1;
    float treeSpeed;
    Animator fireAnimator;
    GroundController groundController;
    GameObject ground;

    // Use this for initialization
    void Start ()
    {
        ground = GameObject.FindGameObjectWithTag("Ground");
        treeSpeed = ground.GetComponent<GroundController>().speed;
        tree1 = gameObject.GetComponent<Rigidbody2D>();
        tree1.velocity = new Vector2(0, -treeSpeed);
        if(gameObject.tag == "Fire")
        {
            fireAnimator = gameObject.GetComponent<Animator>();
            fireAnimator.SetBool("IsBurning", true);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

            if (gameObject.transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y - 1f)
            {
                Destroy(gameObject);
            }
	}
    
}
