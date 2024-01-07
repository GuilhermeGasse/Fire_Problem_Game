using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObj : MonoBehaviour
{
    public string[] Tags;
    public GameObject objgrabbing;
    [Space(20)]
    public float distancemax;
    public bool grabbing;
    public GameObject local;
    public LayerMask layo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (grabbing == true)
        {   //soltando
            if (Input.GetKeyDown(KeyCode.E))
            {
                grabbing = false;
                objgrabbing.transform.parent = null;
                objgrabbing.GetComponent<Rigidbody>().isKinematic = false;
                objgrabbing = null;
                return;
            }
        }
        if (grabbing == false)
        {
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(transform.position, transform.forward, out hit, distancemax, layo, QueryTriggerInteraction.Ignore))
            {
                Debug.DrawLine(transform.position, hit.point, Color.green);

                for (int x = 0; x < Tags.Length; x++)
                {
                    if (hit.transform.gameObject.tag == Tags[x])
                    {
                        if (Input.GetKeyDown(KeyCode.E))
                        {
                            grabbing = true;

                            objgrabbing = hit.transform.gameObject;
                            if (objgrabbing.GetComponent<Rigidbody>())
                            {
                                objgrabbing.GetComponent<Rigidbody>().isKinematic = true;
                                objgrabbing.transform.position = local.transform.position;
                                objgrabbing.transform.rotation = local.transform.rotation;
                                objgrabbing.transform.parent = local.transform;
                            }
                            return;
                        }
                    }
                }
            }
        }
    }
}
