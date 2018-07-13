using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MagicSkill : MonoBehaviour {

    public GameObject Skill0, Skill1, Skill2, Skill3;
	string inputname;
    //float fireRate;
    //Animator animatorPlayer;

    void Start() {
        //animatorPlayer = GetComponent<Animator>();
    }
	void Update () {
        // Detecta a ultima direção registrada
		DetectPressedKey();
        // Fim

        // Teste
        //float nextFire = Time.time + fireRate;
        //Debug.Log("Teste"+ nextFire);
        // Fim do Teste

        // Golpe duas casas
        /*if(Input.GetKeyDown(KeyCode.Joystick1Button1)){
			Wind();
		}
        // Golpe no Local
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
           Hit();
        }
        // Bola de fogo 5 Casas
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            FireBall();
        }
        // Fim bola de fogo

        // Parede de Gelo
        if ((Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space)))
        {
            IceWall();
        }*/
        // Fim Parede de Gelo
    }
    public void DetectPressedKey()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            inputname = "Left";
            Debug.Log(inputname);
        }
        else if (Input.GetAxis("Horizontal") > 0)
        {
            inputname = "Right";
            Debug.Log(inputname);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            inputname = "Down";
            Debug.Log(inputname);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            inputname = "Up";
            Debug.Log(inputname);
        }
    }
    public void Wind(){
        if (inputname == "Up"){
            Instantiate(Skill0, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Down"){
            Instantiate(Skill0, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Right"){
            Instantiate(Skill0, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Left"){
            Instantiate(Skill0, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
    }
    public void Hit(){
        if (inputname == "Up"){
            Instantiate(Skill1, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Down"){
            Instantiate(Skill1, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Right"){
            Instantiate(Skill1, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Left"){
            Instantiate(Skill1, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
    }
    public void FireBall(){
        if (inputname == "Up"){
            Instantiate(Skill2, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Down"){
            Instantiate(Skill2, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Right"){
            Instantiate(Skill2, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Left"){
            Instantiate(Skill2, new Vector2(transform.localPosition.x, transform.localPosition.y), Quaternion.identity);
        }
    }
    public void IceWall(){
        if (inputname == "Up"){
            Instantiate(Skill3, new Vector2(transform.localPosition.x, transform.localPosition.y+2), Quaternion.identity);
        }
        if (inputname == "Down"){
            Instantiate(Skill3, new Vector2(transform.localPosition.x, transform.localPosition.y-2), Quaternion.identity);
        }
        if (inputname == "Right"){
            Instantiate(Skill3, new Vector2(transform.localPosition.x+2, transform.localPosition.y), Quaternion.identity);
        }
        if (inputname == "Left"){
            Instantiate(Skill3, new Vector2(transform.localPosition.x-2, transform.localPosition.y), Quaternion.identity);
        }
    }
}