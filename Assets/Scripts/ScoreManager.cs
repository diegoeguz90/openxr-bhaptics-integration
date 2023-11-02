using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    int goal;
    public int Goal
    {
        get 
        { 
            return goal; 
        } 
        set 
        {
            goal = value; 
        }
    }

    private int success;
    public int Success
    {
        get
        {
            return success;
        }
        set
        {
            success = value;
        }
    }
    private int failures;
    public int Failures
    {
        get
        {
            return failures;
        }
        set
        { 
            failures = value; 
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        System.Random _random = new System.Random();
        goal = _random.Next(1, 10);
    }
}
