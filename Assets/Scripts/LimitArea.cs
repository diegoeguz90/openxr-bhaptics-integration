using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitArea : MonoBehaviour
{
    public delegate void OnTrigger();
    public static event OnTrigger onTrigger;

    public delegate void OnReachGoal();
    public static event OnReachGoal onReachGoal;

    private void OnTriggerEnter(Collider other)
    {
        if (GameStatesManager.instance.currentState == GameStatesManager.states.play)
        {
            ScoreManager.instance.Goal--;
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
        }

        if (ScoreManager.instance.Goal == 0)
        {
            GameStatesManager.instance.currentState = GameStatesManager.states.results;
            onReachGoal();
        }

        onTrigger();

        Destroy(other.gameObject);
    }
}
