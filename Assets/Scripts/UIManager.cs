using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("Score UI")]
    [SerializeField] TMP_Text scoreTxt;
    [SerializeField] TMP_Text debugTxt;
    [SerializeField] Canvas retryCanvas;

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
        retryCanvas.enabled = false;
        scoreTxt.text = "Ordena: " + ScoreManager.instance.Goal.ToString() + "\n" +
                        "-------------" + "\n" +
                        "Aciertos: " + "0" + "\n" +
                        "Fallos: " + "0";
    }

    public void DebugMessage(String Message)
    {
        debugTxt.text = Message;
    }

    private void UpdateScoreTxt()
    {

        scoreTxt.text = "Ordena: " + ScoreManager.instance.Goal.ToString() + "\n" + 
                        "-------------" + "\n" +
                        "Aciertos: " + ScoreManager.instance.Success.ToString() + "\n" +
                        "Fallos: " + ScoreManager.instance.Failures.ToString();
    }

    private void ShowRetryCanvas()
    {
        retryCanvas.enabled = true;
        CloudSaveManager.Instance.SaveDataCloud();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    #region Suscription
    private void OnEnable()
    {
        LimitArea.onTrigger += UpdateScoreTxt;
        LimitArea.onReachGoal += ShowRetryCanvas;
    }

    private void OnDisable()
    {
        LimitArea.onTrigger -= UpdateScoreTxt;
        LimitArea.onReachGoal -= ShowRetryCanvas;
    }
    #endregion
}