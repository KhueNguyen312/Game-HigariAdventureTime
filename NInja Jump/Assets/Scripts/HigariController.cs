using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HigariController : MonoBehaviour
{
    public bool isAlive;
    Animator ninjaAnimator;
    Rigidbody2D ninjaObj;
    [SerializeField]
    float speed;
    [SerializeField]
    float maxX;
    [SerializeField]
    float minX;
    bool isLeft;
    [SerializeField]
    GameObject groundRight;
    [SerializeField]
    GameObject groundLeft;
    [SerializeField]
    Transform smoke;
    [SerializeField]
    Transform darkFlame;
    [SerializeField]
    Transform deadEffect;
    [SerializeField]
    Transform pinkExplosion;
    [SerializeField]
    Transform explosion;
    [SerializeField]
    Transform FireSkill;
    [SerializeField]
    Transform lightning;
    [SerializeField]
    Transform blackDragon;
    [SerializeField]
    Transform magicCircle;
    [SerializeField]
    Transform magicBeam;
    [SerializeField]
    Transform lucifer;
    public int numsOfHeart;
    public int numsOfDragon;
    public int requirementLucifer;
    public int countDragon;
    public float yPos;
    public float dragonTimeDuration = 20f;
    public float luciferTimeDuration = 20f;
    
    // Use this for initialization
    void Start()
    {
        yPos = gameObject.transform.position.y;
        numsOfHeart = 5;
        numsOfDragon = 0;
        countDragon = 0;
        requirementLucifer = 0;
        isLeft = true;
        ninjaObj = gameObject.GetComponent<Rigidbody2D>();
        isAlive = true;
        maxX = groundRight.transform.position.x;
        minX = groundLeft.transform.position.x;
        ninjaAnimator = gameObject.GetComponent<Animator>();
        if (isAlive)
        {
            ninjaAnimator.SetBool("isRunning", true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //transform to a dragon: Dragon Ultimate Skill will be called if Higari collects enough 6 dragons
        if (numsOfDragon > 5)
        {
            StartCoroutine(TransformDragon());
        }
        if(requirementLucifer == 3)
        {
            StartCoroutine(LuciferSummoning());
        }
        if (isAlive)
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                if (Input.touchCount > 0)
                {
                    if (Input.GetTouch(0).phase == TouchPhase.Began)
                    {
                        checkTouch(Input.GetTouch(0).position);
                    }
                }
            }

            /* Check if the user is touching the button on the Editor, change OSXEditor value if you are on Windows */

            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    checkTouch(Input.mousePosition);
                }
            }
            if ((gameObject.transform.position.x >= maxX - 1.25f || gameObject.transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y) && isLeft)
            {
                ninjaObj.transform.rotation = Quaternion.Euler(0, 180, 270);
                ninjaObj.velocity = new Vector2(0, 0);
                gameObject.transform.position = new Vector2(maxX - 1.25f, yPos);
                isLeft = false;
                ninjaAnimator.SetInteger("Attacking", 0);
            }
            else if ((gameObject.transform.position.x <= minX + 1.25f || gameObject.transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y)&& !isLeft)
            {
                ninjaObj.transform.rotation = Quaternion.Euler(0, 0, 270);
                ninjaObj.velocity = new Vector2(0, 0);
                gameObject.transform.position = new Vector2(minX + 1.25f, yPos);
                isLeft = true;
                ninjaAnimator.SetInteger("Attacking", 0);
            }
        }
        CheckUnitAlive();
        if (gameObject.transform.position.y < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y - 10f)
        {
            Destroy(gameObject);
        }
    }
    void checkTouch(Vector3 pos)
    {
        Vector3 wp = Camera.main.ScreenToWorldPoint(pos);
        Vector2 touchPos = new Vector2(wp.x, wp.y);
        Collider2D hit = Physics2D.OverlapPoint(touchPos);
        if (hit)
        {
            if (hit.transform.gameObject.tag == "Dragon")
            {
                numsOfDragon++;
                countDragon++;
                GameObject.Instantiate(explosion, new Vector2(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y), Quaternion.Euler(0, 0, 0));
                if (Random.Range(0, 2) == 0)
                    GameObject.Instantiate(FireSkill, new Vector2(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y + 1.3f), Quaternion.Euler(0, 0, 0));
                else
                    GameObject.Instantiate(lightning, new Vector2(hit.transform.gameObject.transform.position.x, hit.transform.gameObject.transform.position.y + 1.3f), Quaternion.Euler(0, 0, 0));
                Destroy(hit.transform.gameObject);
            }
            else
            {
                Jump();
            }

        }
        else
        {
            Jump();
        }
    }
    void Jump()
    {
        // if player touches button pause. it will not jump
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if (isLeft && isAlive)
            {
                ninjaObj.velocity = new Vector2(speed, 0);
                ninjaObj.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else if (isAlive)
            {
                ninjaObj.velocity = new Vector2(-speed, 0);
                ninjaObj.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            ninjaAnimator.SetInteger("Attacking", 1);
        }
    }
    #region Collision handling

    void OnTriggerEnter2D(Collider2D target)
    {
        if (isAlive)
        {
            if (target.gameObject.tag != "GalickGun" && target.gameObject.tag != "BigBangAttack" && target.gameObject.tag != "Heart" && target.gameObject.tag != "GrimReaper")
                numsOfHeart--;
            else if (target.gameObject.tag == "Heart")
            {
                GameObject.Instantiate(pinkExplosion, new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y), Quaternion.identity);
                if (numsOfHeart < 5)
                    numsOfHeart++;
                Destroy(target.gameObject);
            }
            else if (target.gameObject.tag == "GrimReaper")
            {
                Instantiate(darkFlame, new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y),Quaternion.identity);
                Instantiate(deadEffect, new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y), Quaternion.identity);
                if(requirementLucifer < 3)
                    requirementLucifer++;
            }
            else
            {
                if (numsOfHeart > 1)
                    numsOfHeart -= 2;
                else if (numsOfHeart == 1)
                    numsOfHeart--;
            }
            if (target.gameObject.tag != "Heart"&&target.gameObject.tag != "GrimReaper")
            {
                StartCoroutine(TheCollision());
            }
            if (target.gameObject.tag != "Fire" && target.gameObject.tag != "Ground" && target.gameObject.tag != "GalickGun" && target.gameObject.tag != "Heart")
            {
                GameObject.Instantiate(smoke, new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y), Quaternion.identity);
                Destroy(target.gameObject);
            }
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "GrimReaper")
        {
            if (numsOfHeart > 2)
                numsOfHeart -= 3;
            else if (numsOfHeart == 2)
                numsOfHeart -= 2;
            else if (numsOfHeart == 1)
                numsOfHeart--;
            GameObject.Instantiate(explosion, new Vector2(target.gameObject.transform.position.x, target.gameObject.transform.position.y), Quaternion.identity);
        }
    }
    IEnumerator TheCollision()
    {
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 1;
    }
    #endregion
    IEnumerator TransformDragon()
    {
        GameObject[] effectSkill;
        GameObject ninjaS;
        ninjaS = GameObject.FindGameObjectWithTag("Ninja");
        ninjaS.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<PolygonCollider2D>().enabled = false;
        numsOfDragon = 0;
        Time.timeScale = 2;
        GameObject.Instantiate(smoke, new Vector2(0, Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y + 1.5f), Quaternion.identity);
        GameObject.Instantiate(blackDragon, new Vector2(0, Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y + 1.5f), Quaternion.identity);
        GameObject.Instantiate(magicCircle, new Vector2(0, Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y + 3f), Quaternion.identity);
        GameObject.Instantiate(magicBeam, new Vector2(0, Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).y + 4.5f), Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(dragonTimeDuration);
        gameObject.GetComponent<PolygonCollider2D>().enabled = true;
        ninjaS.GetComponent<SpriteRenderer>().enabled = true;
        effectSkill = GameObject.FindGameObjectsWithTag("BlackDragon");
        foreach (GameObject BlackDragon in effectSkill)
        {
            Destroy(BlackDragon);
        }
        Time.timeScale = 1;
    }
    IEnumerator LuciferSummoning()
    {
        GameObject [] effectSkill;
        GameObject.Instantiate(lucifer, new Vector2(0, Camera.main.ViewportToWorldPoint(new Vector2(1, 1)).y + 1.5f), Quaternion.identity);
        requirementLucifer = 0;
        yield return new WaitForSeconds(luciferTimeDuration);
        Time.timeScale = 1;
        effectSkill = GameObject.FindGameObjectsWithTag("Lucifer");
        foreach (GameObject Lucifer in effectSkill)
        {
            Destroy(Lucifer);
        }
        
    }
    void CheckUnitAlive()
    {
        if (numsOfHeart <= 0)
        {
            isAlive = false;
            ninjaAnimator.SetBool("isRunning", false);
            ninjaAnimator.enabled = false;
            // when Unit dies
            if (isLeft)
                ninjaObj.velocity = new Vector2(3, -speed);
            else
                ninjaObj.velocity = new Vector2(-3, -speed);
        }
    }

}
