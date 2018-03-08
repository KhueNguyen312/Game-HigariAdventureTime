using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {
    [SerializeField]
    Transform darkFlame;
    [SerializeField]
    Transform deadAnim;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag != "Ninja" && target.gameObject.tag != "Lucifer" && target.gameObject.tag != "Heart" && target.gameObject.tag != "Ground")
        {
            GameObject.Instantiate(darkFlame, target.gameObject.transform.position, Quaternion.identity);
            GameObject.Instantiate(deadAnim, target.gameObject.transform.position, Quaternion.identity);
            Destroy(target.gameObject);
        }
    }
}
