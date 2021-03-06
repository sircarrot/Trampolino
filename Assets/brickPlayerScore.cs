﻿using UnityEngine;
using System.Collections;

public class brickPlayerScore : MonoBehaviour
{

    public int playerid;

    public brickScoreScript player1;
    public brickScoreScript player2;

    public bool pong = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (pong)
        {
            //Edge Screen
            if (col.gameObject.tag == "Edge")
            {
                switch (col.gameObject.GetComponent<brickEdgeScript>().edgeid)
                {
                    case 1:
                        player2.score++;
                        player2.onChangeValue();
                        break;
                    case 2:
                        player1.score++;
                        player1.onChangeValue();
                        break;
                }
            }
        }
        else
        {
            //Brick
            if (col.gameObject.tag == "Brick")
            {
                col.gameObject.GetComponent<brickBrickScript>().life--;
                if (col.gameObject.GetComponent<brickBrickScript>().life == 0)
                {
                    switch (playerid)
                    {
                        case 1:
                            player1.score += col.gameObject.GetComponent<brickBrickScript>().score;
                            player1.onChangeValue();
                            break;
                        case 2:
                            player2.score += col.gameObject.GetComponent<brickBrickScript>().score;
                            player2.onChangeValue();
                            break;
                    }
                    StartCoroutine(DestroyBrick(col.gameObject));
                }
            }

            //Edge Screen
            if (col.gameObject.tag == "Edge")
            {
                if (col.gameObject.GetComponent<brickEdgeScript>().edgeid == playerid)
                {
                    /*
                    switch (playerid)
                    {
                        case 1:
                            player1.score--;
                            player1.onChangeValue();
                            break;
                        case 2:
                            player2.score--;
                            player2.onChangeValue();
                            break;
                    }
                    */
                }
                else
                {
                    switch (playerid)
                    {
                        case 1:
                            player2.score--;
                            player2.onChangeValue();
                            break;
                        case 2:
                            player1.score--;
                            player1.onChangeValue();
                            break;
                    }
                }
            }
        }
    }
    IEnumerator DestroyBrick(GameObject Brick)
    {
        yield return new WaitForSeconds(0.05f);
        Destroy(Brick);
    }
}
