
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    //this scripts also use for LuciferSkill
    public Sprite[] heart;
    public Image heartUI;
    HigariController Ninja;

    void Start()
    {
        Ninja = GameObject.FindGameObjectWithTag("Ninja").GetComponent<HigariController>();
    } 
    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "HeartImage")
            heartUI.sprite = heart[Ninja.numsOfHeart];
        else
            heartUI.sprite = heart[Ninja.requirementLucifer];
    }
}
