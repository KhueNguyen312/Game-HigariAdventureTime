using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBalllManager : MonoBehaviour
{
    HigariController higari;
    Rigidbody2D darkBall;
    [SerializeField]
    Transform explosion;
    [SerializeField]
    float speed;
    float angle;
    Vector3 targetPositon;
	// Use this for initialization
	void Start ()
    {
        higari = GameObject.FindGameObjectWithTag("Ninja").GetComponent<HigariController>();
        targetPositon = higari.transform.position;

	}
	// Update is called once per frame
	void Update ()
    {
        if (transform.position != targetPositon)
            transform.position = Vector3.MoveTowards(transform.position, targetPositon, speed * Time.deltaTime);
        else
        {
            targetPositon *= 2; // keep current angle 
        }
        if(gameObject.transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y - 1f)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag != "GrimReaper")
        {
            GameObject.Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    void OnCollision2DEnter(Collision target)
    {
        if (target.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
