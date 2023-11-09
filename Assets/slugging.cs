using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slugging : MonoBehaviour
{
    public Transform[] pos;
    int dest;
    SpriteRenderer spr;

    // Start is called before the first frame update
    void Start()
    {
        dest = 0; 
        spr=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Vector2.Distance(transform.position, pos[dest].position) < 0.001f)
        {

            dest=(dest+1) % pos.Length;
            spr.flipX = !spr.flipX;

        } 
      else
        {
            transform.position = Vector2.MoveTowards(transform.position, pos[dest].position, Time.deltaTime);
        }
    }
}
