using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrimReaper : MonoBehaviour
{
    HigariController higari;
    Rigidbody2D grimReaper;
    [SerializeField]
    float speed;
    [SerializeField]
    Transform darkBall;
    [SerializeField]
    PolygonCollider2D[] colliders;
    int currentColliderIndex = 0;
    [SerializeField]
    PolygonCollider2D[] weaponColliders;
    int currentColIndex = 0;
    bool isCreated;
    bool isFlying;
    public float distance;
    public float distanceToSlash;
    Animator grimReaperAnim;
    GameObject higariGameobj;
    // Use this for initialization
    void Start()
    {
        higariGameobj = GameObject.FindGameObjectWithTag("Ninja");
        grimReaperAnim = gameObject.GetComponent<Animator>();
        if(higariGameobj != null)
            higari = higariGameobj.GetComponent<HigariController>();
        grimReaper = gameObject.GetComponent<Rigidbody2D>();
        grimReaper.velocity = new Vector2(0, -speed);
    }
    public void SetColliderForSprite(int spriteNum)
    {
        colliders[currentColliderIndex].enabled = false;
        currentColliderIndex = spriteNum;
        colliders[currentColliderIndex].enabled = true;
    }
    public void SetColliderForWeapon(int spriteNums)
    {
        weaponColliders[currentColIndex].enabled = false;
        currentColIndex = spriteNums;
        weaponColliders[currentColIndex].enabled = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (higariGameobj != null)
        { 
            if (Vector2.Distance(gameObject.transform.position, higari.transform.position) < distance)
            {
                if (distance != distanceToSlash)
                {
                    distance = distanceToSlash;
                }
                distance = distanceToSlash;
                if (!isCreated)
                {
                    GameObject.Instantiate(darkBall, gameObject.transform.position, Quaternion.identity);
                    isCreated = true;
                    isFlying = true;
                }
                else
                {
                    grimReaperAnim.SetBool("IsNotUsingDarkBall", true);
                }
            }
            if (gameObject.transform.position.y >= Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y + 3f && isCreated)
            {
                if (!isFlying && gameObject.transform.position.y >= Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y)
                {
                    grimReaperAnim.SetBool("IsNotUsingDarkBall", true);
                    grimReaper.velocity = new Vector2(0, -speed);
                }
                else if (isFlying)
                {
                    grimReaper.velocity = new Vector2(0, speed);
                    isFlying = false;
                }
            }
        }
            if (gameObject.transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y - 1f)
            {
                Destroy(gameObject);
            }
        }
}
