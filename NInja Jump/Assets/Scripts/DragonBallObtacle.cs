using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonBallObtacle : MonoBehaviour
{
    Rigidbody2D unit;
    Animator unitAnim;
    float unitSpeed;
    Vector3 unitPos;
    [SerializeField]
    Transform skillEffect;
    [SerializeField]
    Transform BigBangAttack;
    [SerializeField]
    Transform fireBall;
    GameController gameObj;
	// Use this for initialization
	void Start ()
    {
        unitSpeed = 5;
        unit = gameObject.GetComponent<Rigidbody2D>();
        unitAnim = gameObject.GetComponent<Animator>();
        unit.velocity = new Vector2(0, -unitSpeed);
        StartCoroutine(CreateSkill());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameObject.transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y - 1f)
        {
            Destroy(gameObject);
        }
    }
    IEnumerator CreateSkill()
    {
        int Rand = Random.Range(0, 2);
        
        if (gameObject.tag == "Vegeta")
        {
            yield return new WaitForSeconds(0.2f);
            unitPos = gameObject.transform.position;
            if (Rand == 1)
            {
                unitAnim.SetInteger("UsingBigBangAttack", 1);
                if (!GameObject.FindGameObjectWithTag("GameObj").GetComponent<GameController>().inverse)
                    GameObject.Instantiate(skillEffect, unitPos - new Vector3(-0.5f, 1, 0), Quaternion.Euler(0, 0, 270));
                else
                    GameObject.Instantiate(skillEffect, unitPos - new Vector3(-0.2f, 1, 0), Quaternion.Euler(0, 0, 270));
            }
            else
            {
                unitAnim.SetInteger("UsingBigBangAttack", 2);
                GameObject.Instantiate(BigBangAttack, unitPos - new Vector3(0, 1.5f, 0), Quaternion.Euler(0, 0, 270));
            }
        }
        else if(gameObject.tag == "Itachi")
        {
            yield return new WaitForSeconds(0.5f);
            unitPos = gameObject.transform.position;
            if (!GameObject.FindGameObjectWithTag("GameObj").GetComponent<GameController>().inverse)
            {
                GameObject.Instantiate(fireBall, unitPos - new Vector3(0, 0.7f, 0), Quaternion.Euler(0, 0, 270));
            }
            else
            {
                GameObject.Instantiate(fireBall, unitPos - new Vector3(0, 0.7f, 0), Quaternion.Euler(180, 0, 90));
            }
        }

    }
}
