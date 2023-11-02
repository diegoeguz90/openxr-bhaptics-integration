using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class GameStatesManager : MonoBehaviour
{
    public static GameStatesManager instance;

    bool onPlayState = false;

    public enum states
    {
        instructions,
        play,
        results
    }

    public states currentState {  get; set; }

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
    private void Start()
    {
        currentState = states.instructions;
    }

    private void ChangeState()
    {
        if(currentState == states.instructions) 
        {
            onPlayState = true;
            currentState = states.play;
        }
        else if(onPlayState && 
            currentState == states.play && 
            ScoreManager.instance.Goal == 0)
        {
            currentState = states.results;
        }
    }

    #region Suscription
    private void OnEnable()
    {
        XRInteractableHerancy.onPickInteractable += ChangeState;
        LimitArea.onReachGoal += ChangeState;
    }
    private void OnDisable()
    {
        XRInteractableHerancy.onPickInteractable -= ChangeState;
        LimitArea.onReachGoal -= ChangeState;
    }
    #endregion
}
