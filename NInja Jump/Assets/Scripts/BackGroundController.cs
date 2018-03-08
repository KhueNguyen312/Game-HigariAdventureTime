using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour {
    [SerializeField]
    float speed;
    [SerializeField]
    GameObject CheckPosition;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(CheckPosition.transform.position.y > Camera.main.ViewportToWorldPoint(new Vector2(1,1)).y)
            gameObject.transform.Translate(new Vector3(0, -speed*Time.deltaTime, 0));
	}
}
