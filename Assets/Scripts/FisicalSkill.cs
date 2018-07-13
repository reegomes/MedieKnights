using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FisicalSkill : MonoBehaviour
{
    public GameObject Skill0, Skill1, Skill2, Skill3;
    bool isDashing = false;
    [SerializeField]
    Vector3 dash;
    string inputname;
    void Update()
    {
        DetectPressedKey();

        if(Input.GetKeyDown(KeyCode.Joystick1Button1)){
			Dash();
		}
        if (Input.GetKeyDown(KeyCode.Joystick1Button3))
        {
           Hit();
        }
        if (Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            Crux();
        }
        if ((Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Space)))
        {
            NewSkill();
        }
    }

    private void Dash()
    {
        if (isDashing)
        {
            transform.position = Vector3.MoveTowards(transform.position, dash, 10f * Time.deltaTime);
            if (transform.position == dash)
            {
                isDashing = false;
            }
        }
    }

    public void DetectPressedKey()
    {
        if (Input.GetAxis("Horizontal2") < 0)
        {
            inputname = "Left";
            Debug.Log(inputname);
        }
        else if (Input.GetAxis("Horizontal2") > 0)
        {
            inputname = "Right";
            Debug.Log(inputname);
        }
        else if (Input.GetAxis("Vertical2") < 0)
        {
            inputname = "Down";
            Debug.Log(inputname);
        }
        else if (Input.GetAxis("Vertical2") > 0)
        {
            inputname = "Up";
            Debug.Log(inputname);
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
    public void Crux(){

    }
    public void NewSkill(){

    }
}