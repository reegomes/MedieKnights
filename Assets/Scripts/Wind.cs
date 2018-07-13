using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour {
    public Rigidbody2D rb;
    public int side;
    
    // Update is called once per frame
    void Update () {
        
        switch(side){
            case 1:                
                rb.velocity += new Vector2(10,0) * Time.deltaTime; 
                break;
            case 2:
                rb.velocity += new Vector2(-10, 0) * Time.deltaTime;
                break;
            case 3:
                rb.velocity += new Vector2(0, 10) * Time.deltaTime;
                break;
            case 4:
                rb.velocity += new Vector2(0, -10) * Time.deltaTime;
                break;
        }
	}

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ice")
        {
            Destroy(this.gameObject);
        }
    }
}
