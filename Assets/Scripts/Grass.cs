using UnityEngine;

public class Grass : MonoBehaviour {
	public GameObject[] drops;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fire")){
            Debug.Log("Fogo na Grama");
			//Destroy(this.gameObject);
			Drop();
		}
    }
    void Drop(){
		int dropRate = Random.Range(0, 10);
        if (dropRate >= 8)
        {
            int randItem = Random.Range(0, 4);
            Instantiate(drops[randItem], this.transform.position, Quaternion.identity);
        }
	}
}