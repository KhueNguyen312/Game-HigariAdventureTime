using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    Rigidbody2D dragonRigidbody;
    [SerializeField]
    float speed;
    [SerializeField]
    PolygonCollider2D[] colliders;
    int currentColliderIndex = 0;
    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
    // Use this for initialization
    void Start ()
    {
        dragonRigidbody = gameObject.GetComponent<Rigidbody2D>();
        if(!GameObject.FindGameObjectWithTag("GameObj").GetComponent<GameController>().inverse)
            dragonRigidbody.velocity = new Vector2(speed/3.5f, -speed);
        else
            dragonRigidbody.velocity = new Vector2(-speed / 3.5f, -speed);

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.transform.position.x > Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x + 3f|| gameObject.transform.position.x < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x - 3f)
        {
            Destroy(gameObject);
        }
    }
}
