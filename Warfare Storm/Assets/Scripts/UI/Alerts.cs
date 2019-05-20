using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Alerts
{

   public IEnumerator  CreateNewAlert(string msg)
    {
        yield return SceneManager.LoadSceneAsync("Alerts", LoadSceneMode.Additive);
        GameObject.FindObjectOfType<AlertObjects>().AlertText.text = msg;        
    }


    //private void LateUpdate()
    //{
    //    if (GameObject.FindGameObjectWithTag("AlertMsg") != null)
    //    {
            
    //    }
        
    //}

    //IEnumerator UpdateText(string msg)
    //{
    //    yield return new WaitForSeconds(0.3f);
    //    GameObject.FindGameObjectWithTag("AlertMsg").GetComponent<AlertObjects>().AlertText.text = msg;
    //}
}
