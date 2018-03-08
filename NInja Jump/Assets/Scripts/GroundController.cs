using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundController : MonoBehaviour
{
    [SerializeField]
    public float speed;
    public float minY;
    Rigidbody2D ground;
    // Use this for initialization
    void Start()
    {
        minY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y;
        ground = gameObject.GetComponent<Rigidbody2D>();
        ground.velocity = new Vector2(0, -speed);
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < minY)
        {
            Destroy(gameObject);
            
        }
    }
}
