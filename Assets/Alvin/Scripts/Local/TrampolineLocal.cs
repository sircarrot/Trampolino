using UnityEngine;
using System.Collections;

public class TrampolineLocal : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("boing");

        if (col.gameObject.tag == "Puck")
        {
            StartCoroutine(destroySelf());
            
        }
    }
    IEnumerator destroySelf()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}