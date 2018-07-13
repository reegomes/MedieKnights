using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Panel : MonoBehaviour {

    public GameObject Pause;
    bool Pause2;
    Text txtScore;
    [SerializeField]
    Button btnResume;
    [SerializeField]
    Button btnMenu;
    void Update()
    {
        if (Input.GetAxisRaw("Start") == 1)
        {
            Pause2 = true;
            if(Pause2 == true)
            {
                PauseGame();
                Debug.Log(Pause2);
                Time.timeScale = 0f;
            }
        }

        float scores = Time.time;
		int intScores = Mathf.RoundToInt(scores);
		string timing = intScores.ToString();		
		txtScore.text = ("Time: " + timing);
    }
    void PauseGame()
    {
        Pause.SetActive(true);
        GameObject varWizard = GameObject.FindWithTag("Player");
        varWizard.GetComponent<PlayerOne>().enabled = false;
        GameObject varKnight = GameObject.FindWithTag("Player1");
        varKnight.GetComponent<PlayerTwo>().enabled = false;
    }
    public void ClickMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void ClickResume()
    {
        Time.timeScale = 1f;
        Pause.SetActive(false);
        GameObject varWizard = GameObject.FindWithTag("Player");
        varWizard.GetComponent<PlayerOne>().enabled = true;
        GameObject varKnight = GameObject.FindWithTag("Player1");
        varKnight.GetComponent<PlayerTwo>().enabled = true;
    }
	void Start () {
	txtScore = GetComponentInChildren<Text>();
	}

    void Awake()
    {
        btnResume.onClick.AddListener(ClickResume);
        btnMenu.onClick.AddListener(ClickMenu);
    }
}
