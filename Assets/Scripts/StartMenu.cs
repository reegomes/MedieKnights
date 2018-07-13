using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    Button btnMenu;
    [SerializeField]
    Button btnResume;
    [SerializeField]
    Button btnRestart;

    public GameObject panel;

    void Awake()
    {
        btnMenu.onClick.AddListener(ClickMenu);
        btnResume.onClick.AddListener(ClickResume);
        btnRestart.onClick.AddListener(ClickRestart);
    }
    public void ClickMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void ClickResume()
    {
        panel.SetActive(false);
    }
    public void ClickRestart()
    {
        SceneManager.LoadScene("TestScene");
    }
}