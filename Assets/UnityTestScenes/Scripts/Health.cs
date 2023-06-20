using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health: MonoBehaviour
{
    public float maxHP = 100;
    public float stepSize = 4f;
    public float minDistance = 7f;
    public float currentHP;
    public float speedRate;

    public void Start()
    {
        currentHP = maxHP;
        speedRate = 1;
    }

    public bool reduceHealth(float distance)
    {
        if (distance >= minDistance)
        {
            //Debug.Log(distance);
            currentHP -= distance * stepSize;
        }

        if (currentHP < maxHP / 2)
        {
            speedRate = 0.5f;
        }

        if (currentHP <= 0)
        {
            currentHP = 0;
            SceneManager.LoadScene("GameOver");
        }

        return true;
    }

    public bool shot(float damage)
    {
        currentHP -= damage;
        if (currentHP < maxHP / 2)
        {
            speedRate = 0.5f;
        }

        if (currentHP <= 0)
        {
            currentHP = 0;
            SceneManager.LoadScene("GameOver");
            
            
        }

        return true;
    }
}
