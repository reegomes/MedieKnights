using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTestSafado : MonoBehaviour
{

    public GameObject bush;
    public GameObject wall;

    private List<Vector3> mapPositions = new List<Vector3>();

    // Use this for initialization
    void Start()
    {
        PositionsMapping();
        InitialPositions();
        BlockCreate();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void PositionsMapping()
    {
        for (int x = 0; x < 17; x++)
        {
            for (int y = 0; y < 11; y++)
            {
                mapPositions.Add(new Vector3(x, y));
            }
        }
    }

    void BlockCreate()
    {
        for (int x = -1; x < 17 + 1; x++)
        {
            for (int y = -1; y < 11 + 1; y++)
            {

                if (x == -1 || x == 17 || y == -1 || y == 11)
                {
                    Instantiate(wall, new Vector2 (x,y), Quaternion.identity);
                }

                if (x % 2 != 0 && y%2 != 0)
                {
                    Instantiate(wall, new Vector2(x, y), Quaternion.identity);
                    mapPositions.Remove(new Vector2(x, y));
                }
            }
           
        }

        int blocks = ((int)mapPositions.Count / 3) * 2;

        for (int i = 0; i < blocks; i++)
        {
            Instantiate(bush, RandomPositionsSet(), Quaternion.identity);
        }
    }

    Vector3 RandomPositionsSet()
    {
        int tempNumero = Random.Range(0, mapPositions.Count);
        Vector3 tempPosition = mapPositions[tempNumero];
        mapPositions.RemoveAt(tempNumero);

        return tempPosition;
    }

    void InitialPositions()
    {
        mapPositions.Remove(new Vector2(0, 0));
        mapPositions.Remove(new Vector2(0, 10));
        mapPositions.Remove(new Vector2(16, 0));
        mapPositions.Remove(new Vector2(16, 10));
    }
}
