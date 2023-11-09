using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class interaction : MonoBehaviour

{
    public static int score;
    public Text scoretxt;
    AudioSource source;
    public AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        source = GetComponent<AudioSource>();


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "item")
        {
            score++;
            scoretxt.text = "" + score;
            source.PlayOneShot(clips[2]);

            //Debug.Log(collision.name);

            //Debug.Log(score);

            Destroy(collision.gameObject);
        }
        if (collision.tag == "ennemy")
        {
            score--;
            scoretxt.text = "" + score;
            source.PlayOneShot(clips[1]);
            //Debug.Log(collision.name);

            //Debug.Log(score);

            Destroy(collision.gameObject);
        }

    }
    // Update is called once per frame
    //void Update()
    //{

    //}

}
