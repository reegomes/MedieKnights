using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : MonoBehaviour {

    public PlayerOne oneRef;
    // andar
    Animator animatorPlayer;
    public float speed;
    public float strengh = 0;
    bool isWalk;
    Vector2 Stopping;
    public Rigidbody2D rb;

    //skills
    public GameObject[] skill1;
    string inputname;
    float dodgeInt;
    //Stats
    public GameObject lifebar;
    public float life = 0.295f;
    private bool buttonIsPressed;
    float cdrWind, cdrDash, cdRHit, cdR;
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
        DetectPressedKey();
        float horizontal = Input.GetAxisRaw("Horizontal2");
        float vertical = Input.GetAxisRaw("Vertical2");


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
        
        if (Input.GetAxisRaw("XButton2") != 0 && !buttonIsPressed)
        {
            buttonIsPressed = true;
            Wind();
            cdrWind = 0f;
        }
        else if (Input.GetAxisRaw("XButton2") == 0)
        {
            buttonIsPressed = false;
        }

        if (Input.GetAxis("BButton2") != 0)
        {
            Dodge();
            cdrDash = 0f;
        }
        // CDR Wind
        cdrWind += Time.deltaTime * cdR;
        // CDR Dash
        cdrDash += Time.deltaTime * cdR;
        // CDR Hit
        cdRHit += Time.deltaTime;
        // Fim CDR
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

    public void Dodge()
    {
        if (inputname == "Up")
        {
            rb.velocity += new Vector2(0, 100) * 10 * Time.deltaTime;
        }
        if (inputname == "Down")
        {
            rb.velocity += new Vector2(0, -100) * 10 * Time.deltaTime;
        }
        if (inputname == "Right")
        {
            rb.velocity += new Vector2(100, 0) * 10 * Time.deltaTime;
        }
        if (inputname == "Left")
        {
            rb.velocity += new Vector2(-100, 0) * 10 * Time.deltaTime;
        }
    }

    public void StopDodge()
    {
        rb.velocity += new Vector2(0, 0);
    }

    public void Wind()
    {
        if (inputname == "Up")
        {
            Instantiate(skill1[2], new Vector2(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y + 1)), Quaternion.identity);
        }
        if (inputname == "Down")
        {
            Instantiate(skill1[3], new Vector2(Mathf.Round(transform.localPosition.x), Mathf.Round(transform.localPosition.y - 1)), Quaternion.identity);
        }
        if (inputname == "Right")
        {
            Instantiate(skill1[0], new Vector2(Mathf.Round(transform.localPosition.x + 1), Mathf.Round(transform.localPosition.y)), Quaternion.identity);
        }
        if (inputname == "Left")
        {
            Instantiate(skill1[1], new Vector2(Mathf.Round(transform.localPosition.x - 1), Mathf.Round(transform.localPosition.y)), Quaternion.identity);
        }
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grass" && Input.GetAxis("AButton2") != 0)
        {
            Destroy(collision.gameObject);
            hit.Play();
            cdRHit = 0f;
        }
    }

 

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Fire")
        {
            print("acertou");
            lifebar.transform.localScale -= new Vector3(0.029f + oneRef.strengh, 0, 0);
            life -= 0.029f + oneRef.strengh;
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
        if (col.gameObject.CompareTag("PowerUp2"))
        {
            cdR += 0.5f;
            Destroy(col.gameObject);
        }
    }
}
