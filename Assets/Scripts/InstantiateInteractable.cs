using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateInteractable : MonoBehaviour
{
    [SerializeField] List<GameObject> interactables = new List<GameObject>();
    [SerializeField] GameObject interactableParent;

    private void Start()
    {
        NewInteractable();
    }

    private void NewInteractable()
    {
        if (GameStatesManager.instance.currentState == GameStatesManager.states.instructions ||
            GameStatesManager.instance.currentState == GameStatesManager.states.play)
        {
            System.Random _random = new System.Random();
            int index = _random.Next(0, interactables.Count);
            Instantiate(interactables[index], interactableParent.transform);
        }
    }

    #region Suscription
    private void OnEnable()
    {
        LimitArea.onTrigger += NewInteractable;
    }
    private void OnDisable()
    {
        LimitArea.onTrigger -= NewInteractable;
    }
    #endregion
}
