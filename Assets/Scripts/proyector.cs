using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyector : MonoBehaviour
{
    public Material materialActivo, materialInactivo, materialyes;
    public Camera mainCamera;
    private Vector3 originalPosition;
    private float limitTime = 0;
    private float time;
    public GameObject proyector1;
    public int count = 0;
    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;
    public GameObject ob4;
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



            Debug.Log("DesInteraccion");
            this.GetComponent<Rigidbody>().useGravity = true;
            this.transform.localPosition = new Vector3(9.34f, 1.25f, 14.738f);
            originalPosition = this.transform.localPosition;
            count = count + 1;
            this.GetComponent<Renderer>().material = materialyes;
            this.GetComponent<Rigidbody>().useGravity = true;
            limitTime = 0;

        }

        if (count == 1 && ob1.GetComponent<Renderer>().material.name == "mug (Instance)"
            && ob2.GetComponent<Renderer>().material.name == "mug (Instance)"
            && ob3.GetComponent<Renderer>().material.name == "mug (Instance)"
            && ob4.GetComponent<Renderer>().material.name == "mug (Instance)")
        {

            proyector1.SetActive(true);
        }
    }

    public void activa(bool activado)
    {
        if (activado)
        {
            if (this.GetComponent<Renderer>().material.name != "mug (Instance)")
            {
                GetComponent<Renderer>().material = materialActivo;
                Debug.Log("Activado");
            }
        }
        else
        {
            if (this.GetComponent<Renderer>().material.name != "mug (Instance)")
            {
                GetComponent<Renderer>().material = materialInactivo;
                Debug.Log("Desactivado");
            }
        }

    }



    public void interaccion()
    {
        Debug.Log("Interaccion");
        //mainCamera = GetComponent<Camera>();

        originalPosition = this.transform.localPosition;

        Vector3 np = this.transform.position;
        if (np.x < 0)
            np = np + new Vector3(1, -1f, 0);
        else
            np = np + new Vector3(-1, 1f, 0);


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

    public void activeProyector()
    {
        Debug.Log("activeProyector");

        proyector1.GetComponent<Renderer>().material = materialActivo;
    }
}
