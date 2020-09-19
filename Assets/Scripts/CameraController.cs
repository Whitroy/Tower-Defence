using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panOffset = 10f;
    public float ScrollSpeed = 10f;

    float Min_Y = 10f;
    float Max_Y = 120f;

    float Min_X = -60f;
    float Max_X = 40f;

    float Min_Z = -80f;
    float Max_Z = 30f;

    private bool _doMovement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            _doMovement = !_doMovement;

        if (!_doMovement)
            return;
        if(Input.GetKey(KeyCode.W) || Input.mousePosition.y>=Screen.height-panOffset)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= panOffset)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= panOffset)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - panOffset)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

        float MouseScroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;
        pos.y -= MouseScroll * ScrollSpeed * Time.deltaTime * 50;

        pos.y = Mathf.Clamp(pos.y,Min_Y, Max_Y);
        pos.x = Mathf.Clamp(pos.x, Min_X, Max_X);
        pos.z = Mathf.Clamp(pos.z, Min_Z, Max_Z);

        transform.position = pos;
    }
}
