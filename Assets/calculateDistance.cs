using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class calculateDistance : MonoBehaviour
{
    [SerializeField] private GameObject landingPad;
    [SerializeField] private GameObject cam;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float aspectRatio = 16f/9f;
            float verticalAFOV = cam.GetComponent<Camera>().fieldOfView;
            float horizontalAFOV = 2 * Mathf.Rad2Deg* Mathf.Atan(aspectRatio * Mathf.Tan((verticalAFOV / 2)*Mathf.Deg2Rad));
            Vector3 screenPos = cam.GetComponent<Camera>().WorldToScreenPoint(landingPad.transform.position);
            float x = (screenPos.x/cam.GetComponent<Camera>().pixelWidth)-0.5f;
            float y = (screenPos.y / cam.GetComponent<Camera>().pixelHeight) - 0.5f;

            //Vector3 camvec = new Vector3(2*y*Mathf.Tan(verticalAFOV*Mathf.Deg2Rad/2), -2*x*Mathf.Tan(horizontalAFOV*Mathf.Deg2Rad/2), 1);
            //Vector3 worldvec = transform.TransformVector(camvec);
            //camvec.y *= -1;
            //worldvec.y *= -1;
            //worldvec = Vector3.Normalize(worldvec);
            float yaw = -transform.eulerAngles.z;
            float pitch = transform.eulerAngles.y;
            float roll = -transform.eulerAngles.x;
            float altitude = landingPad.transform.position.z - transform.position.z;
            float expectedX = landingPad.transform.position.x - transform.position.x;
            float expectedY = transform.position.y - landingPad.transform.position.y;
            Debug.Log("x: " + x);
            Debug.Log("y: " + y);
            Debug.Log("yaw: " + yaw);
            Debug.Log("pitch: " + pitch);
            Debug.Log("roll: " + roll);
            Debug.Log("altitude: " + altitude);
            Debug.Log("Expected X away: " + expectedX);
            Debug.Log("Expected Y away: " + expectedY);
            Debug.Log("Vertical AFOV degrees: " + verticalAFOV);
            Debug.Log("Horizontal AFOV degrees: " + horizontalAFOV);
            //Debug.Log("Vector in camera system: " + camvec);
            //Debug.Log("Vector in world system: " + worldvec);
        }
    }
}
