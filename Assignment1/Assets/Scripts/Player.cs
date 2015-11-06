using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player : MonoBehaviour {

    private int health;
    private GameObject uiHP;

	// Use this for initialization
	void Start () {

        health = 10;
        uiHP = GameObject.Find("/Canvas/Text");
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision other) {
        //Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "bullet") {
            Destroy(other.gameObject);
            health--;
            uiHP.GetComponent<Text>().text = "HP: " + health;
        }
    }
}
