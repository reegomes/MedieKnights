using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HManager : MonoBehaviour {

	int player1lifes = 2;
	int player2lifes = 2;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (player1lifes <= 0){
			Debug.Log("Colisão Player 1");
			Time.timeScale = 0f;
			// Puxar janela ou painel
		}
		if (player2lifes <= 0){
			Debug.Log("Colisão Player 2");
			Time.timeScale = 0f;
			// Puxar janela ou painel
		}
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.CompareTag("Player")){
			player1lifes--;
			Debug.Log("Vida 1 = " + player1lifes);
			Destroy(this.gameObject);
		}
		if(other.gameObject.CompareTag("Player1")){
			player2lifes--;
			Debug.Log("Vida 2 = " + player2lifes);
			Destroy(this.gameObject);
		}
	}
}
