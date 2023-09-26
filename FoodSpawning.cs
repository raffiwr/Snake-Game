using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawning : MonoBehaviour
{
    //Finding the food prefab
    public GameObject FoodPrefab;

    //Transforming the Borders
    public Transform wall_top;
    public Transform wall_bottom;
    public Transform wall_left;
    public Transform wall_right;

    //a void to spawn the food one by one
    void Spawn()
    {
        int x = (int)Random.Range(wall_left.position.x, wall_right.position.x);
        int y = (int)Random.Range(wall_top.position.y, wall_bottom.position.y);

        Instantiate(FoodPrefab, new Vector2(x, y), Quaternion.identity);
    }
    // to start spawning the food into the playfield
    void Start()
    {
        InvokeRepeating("Spawn", 3, 4);        
    }

}
