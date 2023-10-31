using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
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
}
