using UnityEngine;
using System.Collections;

public class SpawnWall : MonoBehaviour {


    public Rigidbody wall;
    public float xspacing;
    public float yspacing;
    public bool offset = true;
    public int length;
    public int height;

    // Use this for initialization
    void Start() {

        Vector3 wallSize = wall.GetComponent<Renderer>().bounds.size;


        if (offset) {
            float offsetAmount;
            for (int x = 0; x < length; x++) {
                for (int y = 0; y < height; y++) {
                    offsetAmount = (y % 2 == 0) ? 0 : wallSize.x / 2;
                    Rigidbody instantiateWall = Instantiate(wall,
                        transform.position + new Vector3(x * (wallSize.x + xspacing) + offsetAmount, y * (wallSize.y + yspacing)),
                        transform.rotation) as Rigidbody;
                }
            }
            return;
        }
       
        for (int x = 0; x < length; x++) {
            for (int y = 0; y < height; y++) {
                Rigidbody instantiateWall = Instantiate(wall,
                    transform.position + new Vector3(x * wallSize.x + (x * xspacing), y * wallSize.y + (y * yspacing)),
                    transform.rotation) as Rigidbody;
            }
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
