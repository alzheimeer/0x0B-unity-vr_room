using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    private Camera mainCamera;
    private RaycastHit rayHit;
    private RaycastHit hit = new RaycastHit();


    private Ray ray;

    private float MAX_RAY_DISTANCE = 500.0f;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        //var color = "green";
        ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

        if (Physics.Raycast(ray, out rayHit, MAX_RAY_DISTANCE))
        {
            Debug.DrawLine(ray.origin, rayHit.point, Color.green);
            Debug.Log("El Objeto Es: ->" + rayHit.transform.name);

            //color = rayHit.transform.GetComponent<MeshRenderer>().material.color;
            //Debug.DrawRay(transform.position, transform.forward * MAX_RAY_DISTANCE, Color.blue, 0.3f);
            //if (Physics.Raycast(transform.position, transform.forward, out hit, MAX_RAY_DISTANCE))
            //{
            //  hit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
            //
            //}

            if (rayHit.transform.name == "glass_panel_1_door")
            {
                //rayHit.transform.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            if (rayHit.transform.name == "GlassDoor")
            {
                Debug.Log("dd");

                // rayHit.transform.GetComponent<MeshRenderer>().material.color = Color.blue;

                //hit.transform.GetComponent<MeshRenderer>().material.color = Color.blue;
            }
            // else
            //rayHit.transform.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
            //Debug.DrawRay(transform.position, transform.forward * MAX_RAY_DISTANCE, Color.blue, 0.3f);
        }
    }


    // void Update()

    //    {

    //      ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //    if (Physics.Raycast(ray, out rayHit))
    //  {
    //    Transform objectHit = rayHit.transform;
    //}

    //}

}


