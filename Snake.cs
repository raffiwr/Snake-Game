using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector2 dir = Vector2.left;
    List<Transform> tail = new List<Transform>();
    public GameObject TailPrefab;

    //Did the snake eat something?
    bool ate = false;

    void Start()
    {
        //To let the snake move
        InvokeRepeating("Move", 0.3f, 0.3f);
    }

    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);
        if(ate)
        {
            GameObject g =(GameObject)Instantiate(TailPrefab, v, Quaternion.identity);
            tail.Insert(0, g.transform);
            ate = false;
        }
        else if(tail.Count > 0)
        {
            tail.Last().position = v;
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //the controls to move the snake to another directions
        if(Input.GetKey(KeyCode.RightArrow))
        {
            dir = Vector2.right;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            dir = -Vector2.up;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            dir = -Vector2.right;
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            dir = Vector2.up;
        }

        //Did the snake eat something?
        bool ate = false;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.name.StartsWith("FoodPrefab"))
        {
            ate = true;
            Destroy(coll.gameObject);
        }
        else
        {
            print("Game Over");
        }
    }
}
