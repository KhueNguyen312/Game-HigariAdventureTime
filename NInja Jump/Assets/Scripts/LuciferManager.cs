using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuciferManager : MonoBehaviour
{
    [SerializeField]
    Transform magicCircle;
    [SerializeField]
    Transform hook;
    GameObject luciferObj;
    Rigidbody2D luciferRigidbody;
    public float luciferSpeed;
    Animator LuciferAnim;
    bool rightPlace;
    // Use this for initialization
    void Start ()
    {
        luciferObj = GameObject.FindGameObjectWithTag("Lucifer");
        luciferRigidbody = luciferObj.GetComponent<Rigidbody2D>();
        luciferRigidbody.velocity = new Vector2(0, -luciferSpeed);
        LuciferAnim = luciferObj.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        Time.timeScale = 2;
        if (gameObject.transform.position.y <= 1f && !rightPlace)
        {
            LuciferAnim.SetBool("IsCasting",true);
            luciferRigidbody.velocity = new Vector2(0, 0);
            GameObject.Instantiate(magicCircle, gameObject.transform.position, Quaternion.identity);
            GameObject.Instantiate(hook, gameObject.transform.position, Quaternion.identity);
            rightPlace = true;
        }
	}
}
