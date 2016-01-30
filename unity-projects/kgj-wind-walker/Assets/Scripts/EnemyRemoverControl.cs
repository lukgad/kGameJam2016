using UnityEngine;
using System.Collections;

public class EnemyRemoverControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(!GetComponent<Renderer>().IsVisibleFrom(Camera.main))
        {
            Destroy(gameObject);
        }
	}
}
