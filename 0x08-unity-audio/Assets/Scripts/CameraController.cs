using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Public field for Player Object
    //public GameObject player;

    //Camera Offset Original Position
    //private Vector3 offset = new Vector3(0f, 2.5f, -6.25f);

    private const float yMIN = 0.0f;
    private const float yMAX = 50.0f;
    public Transform player;
    private Transform TransCam;
    public bool is_Inverted = false;
    private Camera OG_cam;
    private float dist = 6.3f;
    private float X = 0.0f;
    private float Y = 0.0f;
    private float X_mov = 150f;
    private float Y_mov = 100f;

    // Start is called before the first frame update
    void Start()
    {
        TransCam = transform;
        OG_cam = Camera.main;
        is_Inverted = (PlayerPrefs.GetInt("InvertedYToggle") == 1 ? true : false);   
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -dist);
        Quaternion rotation = Quaternion.Euler(Y, X, 0);
        TransCam.position = player.position + rotation * dir;
        TransCam.LookAt(player.position);

        /*Rotate();
        
        // Offset the camera behind the player by adding to the player's position
        transform.position = Vector3.Lerp(transform.position, (player.transform.position + offset), .25f);
        // Keep camera behind player
        transform.LookAt(player.transform.position);*/
    }

    void Rotate()
    {
        // Camera will rotate on X axis with mouse movement
        //offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * offset;
        X += Input.GetAxis("Mouse X") * X_mov * Time.deltaTime;
        Y += Input.GetAxis("Mouse Y") * (is_Inverted ? -1: 1) * Y_mov * Time.deltaTime;
        Y = Mathf.Clamp(Y, yMIN, yMAX);
    }
}
