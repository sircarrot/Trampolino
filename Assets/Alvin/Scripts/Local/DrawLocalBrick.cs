using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DrawLocalBrick : MonoBehaviour
{
    public GameObject player1;
    public Vector3 target1;

    public GameObject player2;
    public Vector3 target2;


    public int allowedmax = 2;

    public GameObject prefab;
    public GameObject prefab2;

    public GameObject instantiated1;
    public double initialScale1;
    public double newScale1;
    public double newRotate1;
    private double opp1;
    private double adj1;
    private double hypo1;
    public int nodrawn1 = 0;
    private float power1;
    private bool clicked;
    public GameObject instantiated2;
    public double initialScale2;
    public double newScale2;
    public double newRotate2;
    private double opp2;
    private double adj2;
    private double hypo2;
    public int nodrawn2 = 0;
    private float power2;

    public GameObject first1;

    public GameObject first2;

    public Vector3 stageDimensions;
    public GameObject mainCamera;

    void Start()
    {
        stageDimensions = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }
    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            Vector2 myPostion = player1.GetComponent<Rigidbody2D>().position;
            Vector2 myPostion2 = player2.GetComponent<Rigidbody2D>().position;
            TouchPhase phase = touch.phase;
            switch (phase)
            {
                case TouchPhase.Began:
                    
                    if (touchPos.y <= stageDimensions.y *-1 + 1)
                    {
                        if (nodrawn1 < allowedmax)
                        {
                            createTrampoline1(touch);
                        }
                        else
                        {
                            LoopDraw1();
                            createTrampoline1(touch);
                        }
                    }
                    if (touchPos.y >= stageDimensions.y - 1)
                    {

                        if (nodrawn2 < allowedmax)
                        {
                            createTrampoline2(touch);
                        }
                        else
                        {
                            LoopDraw2();
                            createTrampoline2(touch);
                        }
                    }
                    break;
                case TouchPhase.Moved:
                    
                    if ((touchPos.y > stageDimensions.y * -1 + 1) && !(touchPos.y > stageDimensions.y - 1))
                    {
                        if (clicked)
                        {
                            Debug.Log("Called1");
                            release1();
                        }
                    }
                    if ((touchPos.y < stageDimensions.y - 1) && !(touchPos.y < stageDimensions.y * -1 + 1))
                    {
                        if (clicked)
                        {
                            //Debug.Log("Called1");
                            release2();
                        }
                    }

                    if (touchPos.y <= stageDimensions.y * -1 + 1)
                    {
                        //Debug.Log("Atas");
                        drawing1(touch);
                    }
                    if (touchPos.y >= stageDimensions.y - 1)
                    {
                        //Debug.Log("Atas");
                        drawing2(touch);
                    }
                    break;
                case TouchPhase.Ended:
                    if (touchPos.y <= stageDimensions.y * -1 + 1)
                    {
                        Debug.Log("Bawah");
                        release1();
                    }
                    if (touchPos.y >= stageDimensions.y - 1)
                    {
                        
                        release2();
                    }
                    break;
            }

        }
    }

    public void LoopDraw1() //Destroy the first line and draw the second one if drawn is more than allowed for P1
    {
        Destroy(first1);
        
        nodrawn1--;

    }
    public void createTrampoline1(Touch touch)
    {
        target1 = Camera.main.ScreenToWorldPoint(touch.position);
        target1.z = transform.position.z;
        clicked = true;
        instantiated1 = (GameObject)Instantiate(prefab, target1, Quaternion.identity);
        initialScale1 = instantiated1.transform.localScale.x;
        instantiated1.name = "TrampolineP1 " + nodrawn1;
        //Debug.Log(instantiated1);
        power1 = 0;
    }
    public void release1()
    {
        instantiated1.GetComponent<Collider2D>().enabled = true;
        //instantiated1.GetComponent<TrampolineScript>().bounceForce = power1;
        clicked = false;
        first1 = instantiated1;
        
        nodrawn1++;
    }
    public void drawing1(Touch touch)
    {

        opp1 = target1.y - Camera.main.ScreenToWorldPoint(touch.position).y;
        adj1 = target1.x - Camera.main.ScreenToWorldPoint(touch.position).x;

        hypo1 = Mathf.Sqrt(Mathf.Pow((float)opp1, 2) + Mathf.Pow((float)adj1, 2));

        if (adj1 >= 0)
        {
            newScale1 = initialScale1 + -1 * (hypo1) * 0.4;
        }
        else
        {
            newScale1 = initialScale1 + (hypo1) * 0.4;
        }
        if (hypo1 < 2)
        {
            instantiated1.transform.localScale = new Vector3((float)newScale1, instantiated1.transform.localScale.y, instantiated1.transform.localScale.z);
        }

        if (newScale1 < 0.5)
        {
            power1 = 5;
        }
        else if (newScale1 < 1)
        {
            power1 = 4;
        }
        else if (newScale1 < 1.5)
        {
            power1 = 3;
        }
        else
        {
            power1 = 2;
        }
        if (opp1 != 0 && adj1 != 0)
        {
            newRotate1 = Mathf.Rad2Deg * Mathf.Atan((float)(opp1 / adj1));
        }

        instantiated1.transform.eulerAngles = new Vector3(0, 0, (float)newRotate1);

    }

    public void LoopDraw2() //Destroy the first line and draw the second one if drawn is more than allowed for P2
    {
        Destroy(first2);
        nodrawn1--;

    }
    public void createTrampoline2(Touch touch)
    {
        target2 = Camera.main.ScreenToWorldPoint(touch.position);
        target2.z = transform.position.z;
        clicked = true;
        instantiated2 = (GameObject)Instantiate(prefab2, target2, Quaternion.identity);
        initialScale2 = instantiated2.transform.localScale.x;
        instantiated2.name = "TrampolineP2 " + nodrawn2;
        power1 = 0;
    }
    public void release2()
    {

        instantiated2.GetComponent<Collider2D>().enabled = true;
        //instantiated2.GetComponent<TrampolineScript>().bounceForce = power2;
        //Debug.Log(power);
       
        clicked = false;
        first2 = instantiated2;
        
        nodrawn2++;
    }
    public void drawing2(Touch touch)
    {

        opp2 = target2.y - Camera.main.ScreenToWorldPoint(touch.position).y;
        adj2 = target2.x - Camera.main.ScreenToWorldPoint(touch.position).x;

        hypo2 = Mathf.Sqrt(Mathf.Pow((float)opp2, 2) + Mathf.Pow((float)adj2, 2));

        if (adj2 >= 0)
        {
            newScale2 = initialScale2 + -1 * (hypo2) * 0.4;
        }
        else
        {
            newScale2 = initialScale2 + (hypo2) * 0.4;
        }
        
        instantiated2.transform.localScale = new Vector3((float)newScale2, instantiated2.transform.localScale.y, instantiated2.transform.localScale.z);
        

        if (newScale2 < 1)
        {
            power2 = 10;
        }
        else if (newScale2 < 2)
        {
            power2 = 8;
        }
        else if (newScale2 < 3)
        {
            power2 = 6;
        }
        else
        {
            power2 = 5;
        }
        //Debug.Log(newRotate2);
        if (opp2 != 0 && adj2 != 0)
        {
            newRotate2 = Mathf.Rad2Deg * Mathf.Atan((float)(opp2 / adj2));
        }

        instantiated2.transform.eulerAngles = new Vector3(0, 0, (float)newRotate2);

    }
}
