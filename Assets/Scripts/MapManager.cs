using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour {

	public Tilemap gameTileMap;
	public Tile bushTile;
    public Tile wall;
    public GameObject graminha;


	private List<Vector3> mapPositions = new List<Vector3>();

	// Use this for initialization
	void Start () {
        PositionsMapping();
        InitialPositions();
        BlockCreate();
        

    }
	
	// Update is called once per frame
	void Update () {
      
	}

	void PositionsMapping(){
		for(int x = -8; x < 7 ; x++){
			for(int y = -4; y < 5; y++){
				mapPositions.Add(new Vector3(x,y));
			}
		}
	}

	void BlockCreate(){
        int blocks = ((int)mapPositions.Count / 3) * 2 ; 

		for(int i = 0; i< blocks;i++){
            Vector3Int cells = gameTileMap.WorldToCell(RandomPositionsSet());
            Tile tile = gameTileMap.GetTile<Tile>(cells);
            if (tile != wall)
            {
                gameTileMap.SetTile(cells, bushTile);
                //Instantiate(graminha, cells, Quaternion.identity);
            }
            
		}
	} 

    Vector3 RandomPositionsSet()
    {
        int tempNumero = Random.Range(0,mapPositions.Count);
        Vector3 tempPosition = mapPositions[tempNumero];
        mapPositions.RemoveAt(tempNumero);

        return tempPosition;
    }

    void InitialPositions()
    {
        mapPositions.Remove(new Vector3Int(-8,-4,0));
        mapPositions.Remove(new Vector3Int(-8, 4, 0));
        mapPositions.Remove(new Vector3Int(6, -4, 0));
        mapPositions.Remove(new Vector3Int(6, 4, 0));


    }
}
