using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Score UI")]
    [SerializeField] TMP_Text scoreTxt;
    private void UpdateScoreTxt()
    {
        scoreTxt.text = "Puntaje\r\n\r\nAciertos: " + ScoreManager.instance.Success.ToString() 
            + "\r\nFallos: " + ScoreManager.instance.Failures.ToString();
    }

    #region Suscription
    private void OnEnable()
    {
        LimitArea.onTrigger += UpdateScoreTxt;
    }
    private void OnDisable()
    {
        LimitArea.onTrigger -= UpdateScoreTxt;
    }
    #endregion
}
