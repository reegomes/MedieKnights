using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushDrop : MonoBehaviour {

    public GameObject[] powerUps;

    private void OnDestroy()
    {
        int dropRate = Random.Range(0, 10);
        if (dropRate > 6)
        {
            int randomItem = Random.Range(0, 3);
            Instantiate(powerUps[randomItem], this.transform.position, Quaternion.identity);
        }
    }

}
