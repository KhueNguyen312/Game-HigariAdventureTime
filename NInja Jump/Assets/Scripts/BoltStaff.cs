using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltStaff : MonoBehaviour
{
    Rigidbody2D boltStaffRigidBody;
    [SerializeField]
    float speed;
    [SerializeField]
    Transform shootingPosition;
    [SerializeField]
    Transform sword;
	// Use this for initialization
	void Start ()
    {
        boltStaffRigidBody = gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine(Disapper());

    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        
		if(gameObject.transform.position.x < Camera.main.ViewportToWorldPoint(new Vector2(0,0)).x - 2f || gameObject.transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x +2f)
        {
            Destroy(gameObject);
        }
	}

    IEnumerator Disapper()
    {
        if (!GameObject.FindGameObjectWithTag("GameObj").GetComponent<GameController>().inverse)
            boltStaffRigidBody.velocity = new Vector2(speed / 2.5f, 0);
        else
        {
            speed = -speed;
            boltStaffRigidBody.velocity = new Vector2(speed / 2.5f, 0);
        }
        yield return new WaitForSeconds(0.5f);
        if (speed > 0)
        {
            Instantiate(sword, shootingPosition.transform.position, Quaternion.Euler(0, 0, 215));
        }
        else
            Instantiate(sword, shootingPosition.transform.position, Quaternion.Euler(0, 0, 145));
        boltStaffRigidBody.velocity = new Vector2(-speed / 2.5f, -5);
            
    }
}
