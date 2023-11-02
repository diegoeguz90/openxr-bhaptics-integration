using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
using System;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.CloudSave;
using System.Threading.Tasks;
using UnityEngine.Events;
using UnityEngine.Analytics;

public class CloudSaveManager : MonoBehaviour
{
    // Singleton
    private static CloudSaveManager _instance;
    public static CloudSaveManager Instance => _instance;

    struct saveData
    {
        public int success;
        public int failed;
    }

    private void Awake()
    {
        // Just a basic singleton
        if (_instance is null)
        {
            _instance = this;
            return;
        }

        Destroy(this);
    }

    // Start is called before the first frame update
    async void Start()
    {
        // Initialize unity services
        await UnityServices.InitializeAsync();

        // Setup events listeners
        SetupEvents();

        // Unity Login
        await SignInAnonymouslyAsync();
    }

    void SetupEvents()
    {
        AuthenticationService.Instance.SignedIn += () => {
            // Shows how to get a playerID
            Debug.Log($"PlayerID: {AuthenticationService.Instance.PlayerId}");

            // Shows how to get an access token
            Debug.Log($"Access Token: {AuthenticationService.Instance.AccessToken}");
        };

        AuthenticationService.Instance.SignInFailed += (err) => {
            Debug.LogError(err);
        };

        AuthenticationService.Instance.SignedOut += () => {
            Debug.Log("Player signed out.");
        };
    }

    async Task SignInAnonymouslyAsync()
    {
        try
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
            Debug.Log("Sign in anonymously succeeded!");
            UIManager.instance.DebugMessage("Sign in anonymously succeeded!");
        }
        catch (Exception ex)
        {
            // Notify the player with the proper error message
            Debug.LogException(ex);
            UIManager.instance.DebugMessage($"{ex.Message}");
        }
    }

    public async void SaveDataCloud()
    {
        saveData performance = new saveData();

        performance.success = ScoreManager.instance.Success;
        performance.failed = ScoreManager.instance.Failures;

        var data = new Dictionary<string, object> { { "performance", performance } }; 
        await CloudSaveService.Instance.Data.Player.SaveAsync(data);

        UIManager.instance.DebugMessage("save to cloud");
    }
}
