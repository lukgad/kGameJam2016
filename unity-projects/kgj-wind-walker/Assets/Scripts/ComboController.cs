using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboController : MonoBehaviour {

    public Text scoreText;
    private static readonly string TEXT_TEMPLATE = "COMBO x";
    private int comboCounter;


    // Use this for initialization
    void Start () {
        comboCounter = 0;

	}
	
	// Update is called once per frame
	void Update () {
	    if(comboCounter >= 5)
        {
            scoreText.text = TEXT_TEMPLATE + comboCounter;
        } else
        {
            scoreText.text = "";
        }
	}

    public void IncrementCounter()
    {
        comboCounter++;
    }

    public void ResetCounter()
    {
        comboCounter = 0;
    }
}
