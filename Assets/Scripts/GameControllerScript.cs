using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour {
    public GameObject enemigo;
    public int puntosIncrementos;
    public int puntos;
    public bool onGame = false;
    public float TiempoNuevoRival;
    public GameObject Player;
    public Text LabelTiempo;
    int TiempoJuego =0;
    public CanvasGroup[] Pantalla;
    public Text PtsTotales;
    public Text TiempoTotal;
    public Text PtsText;
	// Use this for initialization
	void Start () {
        InvokeRepeating("CrearEnemigo", 1.0f,TiempoNuevoRival);
        InvokeRepeating("Cronometro", 0.0f, 1.0f);
        NextPantalla(0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void CrearEnemigo() {
        if (onGame)
        {
            GameObject newEnemigo = Instantiate(enemigo, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
            GameObject Entorno = GameObject.Find("Entorno");
            newEnemigo.transform.parent = Entorno.transform;
            newEnemigo.transform.localPosition = new Vector3(Random.Range(-8.5f, 8.5f), 0.76f, 8.3f);
            newEnemigo.transform.localRotation = Quaternion.identity;
            newEnemigo.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }        
    }
    void Cronometro() {
        if (onGame)
        {
            TiempoJuego = TiempoJuego + 1;
            LabelTiempo.text = TiempoJuego + " Seg";
        }
    }
    public void DetenerJuego()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag("enemigo");
        for (int i = 0; i < enemigos.Length; i++) {
            Destroy(enemigos[i]);
        }
        Player.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        Player.transform.localPosition = new Vector3(0.0f, 1.29f,0.0f);
        onGame = false;
        PtsTotales.text = puntos.ToString();
        TiempoTotal.text = TiempoJuego + " Seg";
        NextPantalla(2);
        puntos = 0;
        TiempoJuego = 0;
        LabelTiempo.text = "0 Seg";
        PtsText.text = "0";
    }
    public void NextPantalla(int numPantalla)
    {
        for (int i = 0; i < Pantalla.Length; i++)
        {
            Pantalla[i].alpha = 0;
            Pantalla[i].blocksRaycasts = false;
        }
        Pantalla[numPantalla].alpha=1;
        Pantalla[numPantalla].blocksRaycasts = true;
    }
    public void EmpiezaJuego()
    {
        NextPantalla(1);
        onGame = true;
    }
}
