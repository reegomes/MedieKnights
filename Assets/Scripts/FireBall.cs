using UnityEngine;

public class FireBall : MonoBehaviour
{
    float countdown = 0.5f;

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2") || other.gameObject.CompareTag("Player3")){
            //Do nothing keke
        }
    }
}