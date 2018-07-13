using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class MapDestroyer : MonoBehaviour {

	public Tilemap tilemap;
	public Tile wallTile, wallTile2, wallTile3, wallTile4, wallTile5, wallTile6;
    public Tile destructibleTile;
	public GameObject explosionPrefab;

	public void Explode (Vector2 worldPos)
	{
		Vector3Int originCell = tilemap.WorldToCell(worldPos);
		ExplodeCell(originCell);
	    if(ExplodeCell(originCell + new Vector3Int(1,0,0))){
			ExplodeCell(originCell + new Vector3Int(2,0,0));
		}
		if(ExplodeCell(originCell + new Vector3Int(-1,0,0))){
			ExplodeCell(originCell + new Vector3Int(-2,0,0));
		}
		if(ExplodeCell(originCell + new Vector3Int(0,1,0))){
			ExplodeCell(originCell + new Vector3Int(0,2,0));
		}
		
		if(ExplodeCell(originCell + new Vector3Int(0,-1,0))){
			ExplodeCell(originCell + new Vector3Int(0,-2,0));
		}		
	}

	bool ExplodeCell (Vector3Int cell){
		Tile tile = tilemap.GetTile<Tile>(cell);
		if(tile == wallTile || tile == wallTile2 || tile == wallTile3 || tile == wallTile4 || tile == wallTile5 || tile == wallTile6)
        {
			return false;
		}
		if(tile == destructibleTile){
			tilemap.SetTile(cell, null);
			
		}

		Vector3 pos = tilemap.GetCellCenterWorld(cell);
		Instantiate(explosionPrefab, pos, Quaternion.identity);
		return true;
	}
}
