using System;
using System.Collections;
using System.Collections.Generic;
using LitMotion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    [SerializeField] private CurtainUI curtainUI;

    private void Start()
    {
        curtainUI.Open();
    }

    public void StartGame()
    {
        curtainUI.Close();
        LMotion.Create(0, 1f, 1f).WithOnComplete(() =>
        {
            SceneManager.LoadScene("CutScene");
        }).RunWithoutBinding();
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
