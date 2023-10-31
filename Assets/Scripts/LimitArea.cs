using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitArea : MonoBehaviour
{
    public delegate void OnTrigger();
    public static event OnTrigger onTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(this.tag))
        {
            // success
            ScoreManager.instance.Success++;
        }
        else
        { 
            // fail
            ScoreManager.instance.Failures++;
        }
        onTrigger();
        Destroy(other.gameObject);
    }
}
