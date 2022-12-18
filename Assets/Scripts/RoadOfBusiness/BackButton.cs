using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{

    void Start()
    {
        GetComponent<UIEventHandler>().PointerClick += Back2MainScene;
    }

    private void Back2MainScene(PointerEventData eventData)
    {
        // SceneManager.LoadScene("MainScene");
        EventHandler.CallAfterSceneLoadeEvent("MainScene");
    }
}
