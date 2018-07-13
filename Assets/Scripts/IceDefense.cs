using UnityEngine;

public class IceDefense : MonoBehaviour {
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wind")
        {
            Destroy(col.gameObject);
        }
    }
}
