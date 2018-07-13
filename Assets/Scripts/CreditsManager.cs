using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditsManager : MonoBehaviour {

    [SerializeField]
    Button btnBack;

    // Use this for initialization

    private void Update()
    {
        if (Input.GetAxis("BButton") != 0)
        {
            ClickBack();
        }
    }
    void Awake () {
        btnBack.onClick.AddListener(ClickBack);
    }
	
    void ClickBack()
    {
        SceneManager.LoadScene(0);
    }
}
