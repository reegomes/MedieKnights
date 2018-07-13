using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : MonoBehaviour
{
    public PlayerTwo twoRef;
    // andar
    Animator animatorPlayer;
    public float speed;
    public float strengh = 0;
    bool isWalk;
    Vector2 Stopping;

    //skills
    public GameObject skill1, skill2;
    string inputname;

    //Stats
    public GameObject lifebar;
    public float life = 0.295f;
    private bool button2isPressed;
    private bool button1isPressed;
    float cdrIceWall, cdrFire, cdRHit, cdR;
    // SFX
    AudioSource hit;
    // Use this for initialization
    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
        cdR = 1;
        hit = GetComponent<AudioSource>();
        cdRHit = 1;
    }

    // Update is called once per frame
    void Update()
    {
        print(life);
        
        DetectPressedKey();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        isWalk = false;
        if (horizontal > 0 || horizontal < 0)
        {
            transform.Translate(horizontal * Time.deltaTime * speed, 0, 0);
            isWalk = true;
            Stopping = new Vector2(horizontal, 0);
        }
        if (vertical > 0 || vertical < 0)
        {
            transform.Translate(0, vertical * Time.deltaTime * speed, 0);
            isWalk = true;
            Stopping = new Vector2(0, vertical);
        }
        animatorPlayer.SetFloat("y", vertical);
        animatorPlayer.SetFloat("x", horizontal);
        animatorPlayer.SetBool("Walk", isWalk);
        animatorPlayer.SetFloat("StopX", Stopping.x);
        animatorPlayer.SetFloat("StopY", Stopping.y);

        //skills

        if (Input.GetAxisRaw("BButton") != 0 && !button1isPressed && cdrIceWall >= 3.0f)
        {
            IceWall();
            button1isPressed = true;
            cdrIceWall = 0f;
        }
        else if (Input.GetAxisRaw("BButton") == 0)
        {
            button1isPressed = false;
        }

        if (Input.GetAxisRaw("XButton") != 0 && !button2isPressed && cdrFire >= 5.0f)
        {
            FireBall();
            button2isPressed = true;
            cdrFire = 0f;
            /* adicionar animação de cdr 
            animatorHud.SetBool("",isCdr); */
        }
        else if (Input.GetAxisRaw("XButton") == 0)
        {
            button2isPressed = false;
        }

        // CDR iceWall
        cdrIceWall += Time.deltaTime * cdR;
        Debug.Log("cdR icewall" + cdrIceWall);
        // CDR Fire
        cdrFire += Time.deltaTime * cdR;
        Debug.Log("cdR fire" + cdrFire);
        // CDR Hit
        cdRHit += Time.deltaTime;
        // Fim do CDR
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

    public void FireBall()
    {
        if (inputname == "Up")
        {
            for (int i = 1; i <= 5; i++)
            {
                Instantiate(skill2, new Vector2(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y + i)), Quaternion.identity);
            }
        }
        if (inputname == "Down")
        {
            for (int i = 1; i <= 5; i++)
            {
                Instantiate(skill2, new Vector2(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y - i)), Quaternion.identity);
            }
        }
        if (inputname == "Right")
        {
            for (int i = 1; i <= 5; i++)
            {
                Instantiate(skill2, new Vector2(Mathf.Round(transform.localPosition.x + i), Mathf.Round(transform.localPosition.y)), Quaternion.identity);
            }         
        }
        if (inputname == "Left")
        {
            for (int i = 1; i <= 5; i++)
            {
                Instantiate(skill2, new Vector2(Mathf.Round(transform.localPosition.x - i), Mathf.Round(transform.localPosition.y)), Quaternion.identity);
            }
        }
    }
    public void IceWall()
    {
        if (inputname == "Up")
        {
            Instantiate(skill1, new Vector2(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y + 2)), Quaternion.identity);
        }
        if (inputname == "Down")
        {
            Instantiate(skill1, new Vector2(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y - 2)), Quaternion.identity);
        }
        if (inputname == "Right")
        {
            Instantiate(skill1, new Vector2(Mathf.Round(transform.localPosition.x + 2), Mathf.Round(transform.localPosition.y)), Quaternion.identity);
        }
        if (inputname == "Left")
        {
            Instantiate(skill1, new Vector2(Mathf.Round(transform.localPosition.x - 2), Mathf.Round(transform.localPosition.y)), Quaternion.identity);
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass" && Input.GetAxis("AButton") != 0 && cdRHit >= 0.5f)
        {
            Destroy(collision.gameObject);
            hit.Play();
            cdRHit = 0f;
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Wind")
        {
            lifebar.transform.localScale -= new Vector3(0.029f + twoRef.strengh, 0, 0);
            life -= 0.029f + (twoRef.strengh);
        }
        if (col.gameObject.tag == "PowerUp0")
        {
            speed += 0.4f;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "PowerUp1")
        {
            strengh += 0.010f;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "PowerUp2")
        {
            cdR += 0.5f;
            Destroy(col.gameObject);
        }
    }
}
