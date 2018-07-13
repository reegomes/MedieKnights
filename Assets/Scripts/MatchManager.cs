using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MatchManager : MonoBehaviour {

    public GameObject p1win, p2win;
    public PlayerOne oneRef;
    public PlayerTwo twoRef;
    float timeToResetScene = 5f;
	AudioSource BGM;
	// Update is called once per frame
    private void Start() {
        BGM = GetComponent<AudioSource>();
    }
	void Update () {
        if (oneRef.life <= 0f)
        {
            BGM.Stop();
            p2win.SetActive(true);
            GameObject.Find("Wizard").GetComponent<PlayerOne>().enabled = false;
            GameObject.Find("Knight").GetComponent<PlayerTwo>().enabled = false;
            timeToResetScene -= Time.deltaTime;
        }

        if (twoRef.life <= 0f)
        {
            BGM.Stop();
            p1win.SetActive(true);
            GameObject.Find("Wizard").GetComponent<PlayerOne>().enabled = false;
            GameObject.Find("Knight").GetComponent<PlayerTwo>().enabled = false;
            timeToResetScene -= Time.deltaTime;
        }
        if (timeToResetScene <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
