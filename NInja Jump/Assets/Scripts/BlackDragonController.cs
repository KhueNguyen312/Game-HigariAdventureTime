using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackDragonController : MonoBehaviour
{
    bool isLeft;
    Rigidbody2D dragonBody;
    [SerializeField]
    float speed;
    float maxX;
    float minX;
    float yPos;
    [SerializeField]
    Transform explosion;
    [SerializeField]
    PolygonCollider2D[] colliders;
    int currentColliderIndex = 0;
    HigariController ninja;
    // Use this for initialization
    void Start ()
    {
        yPos = gameObject.transform.position.y;
        maxX = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).x;
        minX = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x;
        dragonBody = gameObject.GetComponent<Rigidbody2D>();
	}
    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
    void Jump()
    {
        if (isLeft)
        {
            dragonBody.velocity = new Vector2(speed, 0);
        }
        else
        {
            dragonBody.velocity = new Vector2(-speed, 0);
        }
    }
    // Update is called once per frame
    void Update ()
    {
        Time.timeScale = 2;
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
            if (gameObject.transform.position.x >= maxX - 1.11f && isLeft)
        {
            dragonBody.velocity = new Vector2(0, 0);
            gameObject.transform.position = new Vector2(maxX - 1.11f, yPos);
            isLeft = false;
        }
        else if (gameObject.transform.position.x <= minX + 1.11f && !isLeft)
        {
            dragonBody.velocity = new Vector2(0, 0);
            gameObject.transform.position = new Vector2(minX + 1.11f, yPos);
            isLeft = true;
        }
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag != "Ground"&& target.gameObject.tag != "BlackDragon" && target.gameObject.tag != "Ninja")
        {
            GameObject.Instantiate(explosion, new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y), Quaternion.identity);
            Destroy(target.gameObject);
        }
    }
}
