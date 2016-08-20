using UnityEngine;
using System.Collections;

public class instantiateBricks : MonoBehaviour {

    public GameObject[] Bricks;

	// Use this for initialization
	void Start () {
        int randbrick = Random.Range(0, 9);

        Instantiate(Bricks[randbrick], new Vector3(0,0,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
