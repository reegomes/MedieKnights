using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	Text txtScore;
	void Start () {
		txtScore = GetComponentInChildren<Text>();
	}

	void Update () {
		float scores = Time.time;
		int intScores = Mathf.RoundToInt(scores);
		string timing = intScores.ToString();		
		txtScore.text = ("Time: " + timing);
	}
}
