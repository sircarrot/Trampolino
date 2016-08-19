using UnityEngine;
using System.Collections;

public class TrampolineScript : MonoBehaviour {
    public float bounceForce = 10;
    public bool permanent;
    public DrawLine _gameMaster;
    void Start()
    {
        _gameMaster = GameObject.Find("_gameMaster").GetComponent<DrawLine>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("boing");
       
        if (col.gameObject.tag == "Player")
        {
            //col.rigidbody.AddForce(bounceForce * transform.up, ForceMode.VelocityChange);
            col.rigidbody.velocity = bounceForce * transform.up;
            if (permanent == false)
            {
                _gameMaster.lineList.Remove(this.gameObject);
                _gameMaster.lineList.TrimExcess();
                
                if(_gameMaster.first == this.gameObject)
                {
                    _gameMaster.first = _gameMaster.second;
                    _gameMaster.second = _gameMaster.third;
                }
                else if(_gameMaster.second == this.gameObject)
                {
                    _gameMaster.second = _gameMaster.third;
                }
                else if (_gameMaster.third == this.gameObject)
                {
                    _gameMaster.third = _gameMaster.fourth;
                }
                _gameMaster.nodrawn--;
                Destroy(this.gameObject);
            }

        }
    }
}