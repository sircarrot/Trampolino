﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLine : MonoBehaviour {

    public Vector3 target;
    public Vector3 target2;
    public GameObject prefab;
    public bool clicked;
    public GameObject instantiated;
    public double newScale;
    public double initialScale;
    public double newRotate;
    private double opp;
    private double adj;
    private double hypo;
    private float power;

    public int nodrawn = 0;
    public int allowedmax = 3;

    public bool AddpoweredUp;
    public float Addpowertime;

    public bool shielded;
    public GameObject Shield;

    public List<GameObject> lineList = new List<GameObject>();
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(AddpoweredUp == true)
        {
            if(Addpowertime > 0)
            {
                Addpowertime = Addpowertime - 1 * Time.deltaTime;
            }
            else
            {
                allowedmax = 3;
                AddpoweredUp = false;
            }
        }
        if (shielded == true)
        {
            Shield.SetActive(true);
        }
        if(shielded == false)
        {
            Shield.SetActive(false);
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            if (nodrawn < allowedmax)
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
                clicked = true;
                instantiated = (GameObject)Instantiate(prefab, target, Quaternion.identity);
                initialScale = instantiated.transform.localScale.x;
                instantiated.name = "Trampoline " + nodrawn;
                power = 0;
            }
            else
            {
                
                Destroy(first);
                //Debug.Log("Destroy: " + first.name);
                lineList.Remove(first);
                //Debug.Log("First = : " + second.name);
                first = second;
                //Debug.Log("Second = : " + third.name);
                second = third;
                third = fourth;
                /*
                Debug.Log("Destroy: " + lineList[0].name);
                lineList.Remove(lineList[0]);
                Destroy(lineList[0]);
                //lineList.TrimExcess();
                */
                nodrawn--;
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
                clicked = true;
                instantiated = (GameObject)Instantiate(prefab, target, Quaternion.identity);
                initialScale = instantiated.transform.localScale.x;
                instantiated.name = "Trampoline " + nodrawn;
                power = 0;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            //target2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //target2.z = transform.position.z;
            clicked = false;
            instantiated.GetComponent<Collider2D>().enabled = true;
            instantiated.GetComponent<TrampolineScript>().bounceForce = power;
            //Debug.Log(power);
            lineList.Add(instantiated);
                
            switch (nodrawn)
            {
                case 0:
                    first = instantiated;
                    //Debug.Log("Case: " + instantiated.name);
                    break;
                case 1:
                    second = instantiated;
                    Debug.Log("Case: " + instantiated.name);
                    break;
                case 2:
                    third = instantiated;
                    //Debug.Log("Case: "+instantiated.name);
                    break;
                case 3:
                    fourth = instantiated;
                    //Debug.Log("Case: " + instantiated.name);
                    break;
            }
            nodrawn++;
        }
        
        if (clicked == true)
        {
            opp = target.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            adj = target.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x;

            hypo = Mathf.Sqrt(Mathf.Pow((float)opp, 2) + Mathf.Pow((float)adj, 2));
            //Debug.Log(Mathf.Abs(target.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x));


            if (adj >= 0)
            {
                newScale = initialScale + -1 * (hypo) * 0.4;
            }
            else
            {
                newScale = initialScale + (hypo) * 0.4;
            }
            instantiated.transform.localScale = new Vector3((float)newScale, instantiated.transform.localScale.y, instantiated.transform.localScale.z);
            if (newScale < 1)
            {
                power = 10;
            }
            else if (newScale < 2)
            {
                power = 8;
            }
            else if (newScale < 3)
            {
                power = 6;
            }
            else
            {
                power = 5;
            }
            if (opp != 0 && adj !=0)
            {
                newRotate = Mathf.Rad2Deg * Mathf.Atan((float)(opp / adj));
            }

            instantiated.transform.eulerAngles = new Vector3(0, 0, (float)newRotate);


            //Debug.Log(Mathf.Rad2Deg * Mathf.Atan((float)(opp/adj)));
            //Debug.Log((float)newScale);
        }
    }
}
