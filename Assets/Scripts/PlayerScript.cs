using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    //Objetos publicos
    public GameObject PlayerCamera;
    public float velocity;
    public GameObject Bala;
    // Use this for initialization
    GameControllerScript ControllScript;
    void Start () {
        ControllScript = GameObject.Find("SceneController").GetComponent<GameControllerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ControllScript.onGame) {
            //Rotación
            float speedX = Input.GetAxis("Mouse X");
            float speedY = Input.GetAxis("Mouse Y");
            PlayerCamera.transform.rotation = Quaternion.Euler(new Vector3((PlayerCamera.transform.eulerAngles.x - speedY), (PlayerCamera.transform.eulerAngles.y + (speedX * 2)), 0.0f));
            //Movimiento de camara
            if (Input.GetKey("w"))
            {
                this.GetComponent<Rigidbody>().velocity = PlayerCamera.transform.forward * velocity;
            }
            if (Input.GetKey("s"))
            {
                this.GetComponent<Rigidbody>().velocity = PlayerCamera.transform.forward * -velocity;
            }
            if (Input.GetKey("a"))
            {
                this.GetComponent<Rigidbody>().velocity = PlayerCamera.transform.right * -velocity;
            }
            if (Input.GetKey("d"))
            {
                this.GetComponent<Rigidbody>().velocity = PlayerCamera.transform.right * velocity;
            }
            if (!Input.anyKey)
            {
                this.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            }
            //DISPARO
            if (Input.GetMouseButtonDown(0))
            {
                GameObject newBala = Instantiate(Bala, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
                GameObject padreBala = GameObject.Find("Vala_Origen");
                newBala.transform.parent = padreBala.transform;
                newBala.transform.localPosition = new Vector3(0f, 0f, 0f);
                newBala.transform.localRotation = Quaternion.identity;
                newBala.transform.localScale = new Vector3(0.9898751f, 0.9898751f, 0.104868f);
                newBala.GetComponent<Rigidbody>().AddForce(transform.forward * 500.0f);
                newBala.transform.parent = null;
            }
        }
    }    
}
