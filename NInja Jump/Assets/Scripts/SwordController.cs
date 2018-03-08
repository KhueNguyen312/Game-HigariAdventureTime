using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    [SerializeField]
    float speed;
    [SerializeField]
    Transform shootingPosition;
    Vector3 targetPosition;
    Rigidbody2D swordRididbody;
	// Use this for initialization
	void Start ()
    {
        swordRididbody = gameObject.GetComponent<Rigidbody2D>();
        if (gameObject.transform.eulerAngles.z < 150)
            swordRididbody.velocity = new Vector2(-speed / 2.5f, -speed);
        else
            swordRididbody.velocity = new Vector2(speed / 2.5f, -speed);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(gameObject.transform.position.x < Camera.main.ViewportToWorldPoint(new Vector2(0,0)).x || gameObject.transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x)
        {
            Destroy(gameObject);
        }
	}
}
