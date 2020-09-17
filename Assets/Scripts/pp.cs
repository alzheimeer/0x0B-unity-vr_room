using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pp : MonoBehaviour
{
    public Material materialActivo, materialInactivo;
    public Camera mainCamera;
    private Vector3 originalPosition;
    private float limitTime = 0;
    private float time;
    public GameObject console;
    public GameObject Particle;
    public GameObject switchPuerta;
    void Start()
    {
        time = Mathf.Infinity;
        GetComponent<Renderer>().material = materialInactivo;

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Limit Time: " + limitTime);
        if (limitTime != 0)
            limitTime -= Time.deltaTime;
        if (limitTime < 0)
        {
            limitTime = 0;

            Debug.Log("DesInteraccion");
            this.GetComponent<Rigidbody>().useGravity = true;
            this.transform.localPosition = new Vector3(3.688f, 0.985f, 5.324f);
            originalPosition = this.transform.localPosition;
        }
    }

    public void activa(bool activado)
    {
        if (activado)
        {
            GetComponent<Renderer>().material = materialActivo;
            Debug.Log("Activado");
        }
        else
        {
            GetComponent<Renderer>().material = materialInactivo;
            Debug.Log("Desactivado");
        }

    }



    public void interaccion()
    {
        Debug.Log("Interaccion");
        //mainCamera = GetComponent<Camera>();

        originalPosition = this.transform.localPosition;

        Vector3 np = mainCamera.transform.position;
        if (np.x < 0)
            np = np + new Vector3(-0.5f, 0, -1f);
        else
            np = np + new Vector3(0.5f, 0, 1f);

        Debug.Log("La Posicion De La Camara Es" + np);
        this.GetComponent<Rigidbody>().useGravity = false;

        this.transform.localPosition = np;

        limitTime = 2f;

    }


    public void desinteraccion()
    {
        limitTime = 0;
        Debug.Log("DesInteraccion");
        this.GetComponent<Rigidbody>().useGravity = true;
        this.transform.localPosition = originalPosition;
    }

    public void activeConsole()
    {
        Debug.Log("activeConsole");
        switchPuerta.SetActive(true);
        Particle.SetActive(true);
        console.GetComponent<Renderer>().material = materialActivo;
    }
}
