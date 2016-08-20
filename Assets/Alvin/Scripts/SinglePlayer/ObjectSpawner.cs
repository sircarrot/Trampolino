using UnityEngine;
using System.Collections;

public class ObjectSpawner : MonoBehaviour
{
    private Vector3 stageDimensions;
    public GameObject mainCamera;
    public bool initialized;
    public bool spawnedCourse;
    public int spawnType; //0 course 1-2 random
    public float randomHeight; //Height that will be spent doing random spawning
    public GameObject[] Courses;
    public GameObject[] items;
    public int courseType;
    public int itemType;
    public Vector3 spawnPos;
    public float initialspawnCourse;
    public float initialRandomHeight;
    public float lastspawnRandom;
    private int noOfTimes;

    // Use this for initialization
    void Start ()
    {
        stageDimensions = mainCamera.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(mainCamera.transform.position.y > 5)
        {
            if (initialized == false)
            {
                //spawnType = Random.Range(0, 2);
                spawnType = 0;
                if (spawnType == 0)
                {
                    courseType = Random.Range(0, Courses.Length);
                    initialized = true;
                }
                else
                {
                    randomHeight = Random.Range(10, 30);
                    lastspawnRandom = mainCamera.transform.position.y + stageDimensions.y;
                    initialRandomHeight = mainCamera.transform.position.y + stageDimensions.y;
                    initialized = true;
                }
            }
            else
            {
                if (spawnType == 0)
                {
                    if(spawnedCourse == false)
                    {
                        spawnPos = new Vector3(0, mainCamera.transform.position.y+ stageDimensions.y+2, -0.1f);
                        spawnedCourse = true;
                        Instantiate(Courses[courseType], spawnPos , Quaternion.identity);
                        initialspawnCourse = mainCamera.transform.position.y + stageDimensions.y;
                    }
                    else
                    {
                        if(mainCamera.transform.position.y- stageDimensions.y > initialspawnCourse + stageDimensions.y*2)
                        {
                            initialized = false;
                            spawnedCourse = false;
                        }
                    }
                }
                else
                {
                    if(mainCamera.transform.position.y < initialRandomHeight + randomHeight)
                    {
                        if (mainCamera.transform.position.y + stageDimensions.y > lastspawnRandom)
                        {
                            noOfTimes = Random.Range(0, 4);
                            for (int i = 0; i<noOfTimes; i++)
                            {
                                spawnPos = new Vector3(Random.Range(-6, 6), mainCamera.transform.position.y + stageDimensions.y, -0.1f);
                                itemType = Random.Range(0, items.Length);
                                Instantiate(items[itemType], spawnPos, Quaternion.identity);
                            }
                            noOfTimes = Random.Range(0, 4);
                            for (int i = 0; i < noOfTimes; i++)
                            {
                                spawnPos = new Vector3(Random.Range(-6, 6), mainCamera.transform.position.y + stageDimensions.y + 1, -0.1f);
                                itemType = Random.Range(0, items.Length);
                                Instantiate(items[itemType], spawnPos, Quaternion.identity);
                            }
                            noOfTimes = Random.Range(0, 4);
                            for (int i = 0; i < noOfTimes; i++)
                            {
                                spawnPos = new Vector3(Random.Range(-6, 6), mainCamera.transform.position.y + stageDimensions.y + 2, -0.1f);
                                itemType = Random.Range(0, items.Length);
                                Instantiate(items[itemType], spawnPos, Quaternion.identity);
                            }
                            lastspawnRandom = mainCamera.transform.position.y + stageDimensions.y + 4;
                        }
                    }
                    else
                    {
                        initialized = false;
                    }
                }
            }
        }
	}
}
