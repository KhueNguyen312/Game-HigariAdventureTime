using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    Rigidbody2D skill;
    GameObject ninja;
    GameObject ground;
    [SerializeField]
    Transform explosion;
    [SerializeField]
    PolygonCollider2D[] colliders;
    int currentColliderIndex = 0;
    [SerializeField]
    float speed;
    // Use this for initialization
    void Start ()
    {
        ninja = GameObject.FindGameObjectWithTag("Ninja");
        skill = gameObject.GetComponent<Rigidbody2D>();
        skill.velocity = new Vector2(0, -speed);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y - 1f)
        {
            Destroy(gameObject);
        }
    }
    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if (gameObject.tag == "GalickGun" || gameObject.tag == "BigBangAttack" || gameObject.tag == "FireBall")
        {

            if (target.gameObject.tag != "Ninja" && target.gameObject.tag != "Ground" && target.gameObject.tag != "BlackDragon"&& target.gameObject.tag != "Lucifer")
            {
                GameObject.Instantiate(explosion, new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y), Quaternion.identity);
                Destroy(target.gameObject);
            }
            else if (target.gameObject.tag == "Ninja")
            {
                GameObject.Instantiate(explosion, new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y), Quaternion.identity);
               
            }
            else if(target.gameObject.tag == "BlackDragon" || target.gameObject.tag == "Lucifer")
            {
                GameObject.Instantiate(explosion, new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y), Quaternion.identity);
                GameObject.Instantiate(explosion, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
