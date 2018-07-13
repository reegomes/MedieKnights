using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    Button btnStart;
    [SerializeField]
    Button btnCredits;

    private void Update()
    {
        if (Input.GetAxis("Start") != 0)
        {
            ClickStart();
        }

        if (Input.GetAxis("XButton") != 0)
        {
            ClickCredits();
        }

    }

    void Awake()
    {
        // Usar em ultimo caso
        //btnStart = GameObject.Find("StartButton").GetComponent<Button>();
        //btnCredits = GameObject.Find("CreditButton").GetComponent<Button>();
        btnStart.onClick.AddListener(ClickStart);
        btnCredits.onClick.AddListener(ClickCredits);
    }
    public void ClickStart()
    {
        Debug.Log("Apertei o Start");
        SceneManager.LoadScene(1);
    }
    public void ClickCredits()
    {
        Debug.Log("Apertei o Creditos");
        SceneManager.LoadScene(2);
    }
}