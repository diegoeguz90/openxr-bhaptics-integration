using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Score UI")]
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text testTxt;

    public void ChangeTestTxt()
    {
        testTxt.text = "Funciono!!!";
    }

    private void Start()
    {

        scoreTxt.text = "Ordena: " + ScoreManager.instance.Goal.ToString() + "\n" +
                        "-------------" + "\n" +
                        "Aciertos: " + "0" + "\n" +
                        "Fallos: " + "0";
    }
    private void UpdateScoreTxt()
    {

        scoreTxt.text = "Ordena: " + ScoreManager.instance.Goal.ToString() + "\n" + 
                        "-------------" + "\n" +
                        "Aciertos: " + ScoreManager.instance.Success.ToString() + "\n" +
                        "Fallos: " + ScoreManager.instance.Failures.ToString();
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
