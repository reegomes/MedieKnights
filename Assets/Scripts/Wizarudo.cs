using UnityEngine;

public class Wizarudo : MonoBehaviour
{

    Animator animatorPlayer;
    public float speed;
    bool isWalk;
    Vector2 Stopping;
    void Start()
    {
        animatorPlayer = GetComponent<Animator>();
    }

    void Update()
    {
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
    }
}
