using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateHeart : MonoBehaviour {

    Rigidbody2D hUnit;
    [SerializeField]
    PolygonCollider2D[] colliders;
    int currentColliderIndex = 0;
    [SerializeField]
    float speed;
    // Use this for initialization
    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
    void Start ()
    {
        hUnit = gameObject.GetComponent<Rigidbody2D>();
        hUnit.velocity = new Vector2(0, -speed);
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
