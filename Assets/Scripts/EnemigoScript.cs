using UnityEngine;
using System.Collections;

public class EnemigoScript : MonoBehaviour {
    GameControllerScript ControllScript;
    // Use this for initialization
    void Start () {
        ControllScript = GameObject.Find("SceneController").GetComponent<GameControllerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        GameObject targ = GameObject.Find("Player");
        transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, .08f);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "player")
        {
            ControllScript.DetenerJuego();
        }
    }
}
