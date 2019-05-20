using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayfabAuth : MonoBehaviour
{
    public InputField userName;
    public InputField password;
    public string LevelToLoad;


   public void Login()
    {
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest();
        request.Username = userName.text;
        request.Password = password.text;

        PlayFabClientAPI.LoginWithPlayFab(request, result => 
        {
            Alerts a = new Alerts();
            StartCoroutine(a.CreateNewAlert(userName.text + "You have logged in"));
            SceneManager.LoadScene(LevelToLoad);
        }, 
        error => 
        {
            Alerts a = new Alerts();
            StartCoroutine(a.CreateNewAlert(error.ErrorMessage));
        });
    }
}
