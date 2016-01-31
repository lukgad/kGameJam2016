using UnityEngine;
using System.Collections;

public class EnemyRemoverControl : MonoBehaviour {

    // Use this for initialization
    public bool isValidForScore = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(!GetComponent<Renderer>().IsVisibleFrom(Camera.main))
        {
            if(isValidForScore)
            {
                GameplayControl.Instance.GetComponent<ComboController>().IncrementCounter();
            }
            Destroy(gameObject);
        }
	}

    void OnDestroy()
    {
        if(isValidForScore)
        {
            SpecialEffectsHelper.Instance.ExplodeBarrel(transform.position);
        }
    }
}
