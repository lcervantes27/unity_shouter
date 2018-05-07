using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BalaScript : MonoBehaviour {
    GameControllerScript ControllScript;
    Text ptsText;
    // Use this for initialization
    void Start () {
        ControllScript = GameObject.Find("SceneController").GetComponent<GameControllerScript>();
        ptsText = GameObject.Find("Puntos").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.gameObject.tag);
        if (collision.collider.gameObject.tag == "entorno")
        {
            Destroy(this.gameObject);
        }
        if (collision.collider.gameObject.tag == "enemigo")
        {
            Destroy(this.gameObject);
            Destroy(collision.collider.gameObject);           
            ControllScript.puntos = ControllScript.puntos + ControllScript.puntosIncrementos;
            ptsText.text = ControllScript.puntos.ToString();
        }
    }
}
