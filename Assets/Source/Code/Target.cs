using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private int slot = 0;
    private string color;
    public string cl;

    private void Start()
    {
        cl = GetComponent<SpriteRenderer>().sprite.name;
        cl = cl.Replace('x', 'c');
    }

    public bool isTrueColor(string spr)
    {
        if (slot == 0)
        {
            if (!GameManager.Instance.listColorUsed.Exists(l=>l == spr))
                return true;
            return false;
        }
        return spr == color;
    }
    public void SetSpr(Sprite spr)
    {
        color = spr.name;
        if (!GameManager.Instance.listColorUsed.Exists(l=>l == spr.name))
        {
            GameManager.Instance.listColorUsed.Add(spr.name);
        }

        if (slot < transform.childCount)
        {
            transform.GetChild(slot).GetComponent<SpriteRenderer>().sprite = spr;
            transform.GetChild(slot).gameObject.SetActive(true);
            slot++;
        }
    }
}
