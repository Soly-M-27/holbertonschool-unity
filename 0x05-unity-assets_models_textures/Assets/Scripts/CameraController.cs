using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Public field for Player Object
    public GameObject player;

    //Camera Offset Original Position
    private Vector3 offset = new Vector3(0f, 2.5f, -6.25f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OutOfRange();
    }

    void LateUpdate()
    {
        Rotate();

        // Offset the camera behind the player by adding to the player's position
        transform.position = Vector3.Lerp(transform.position, (player.transform.position + offset), .25f);
        // Keep camera behind player
        transform.LookAt(player.transform.position);
    }

    void Rotate()
    {
        // Camera will rotate on X axis with mouse movement
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 4f, Vector3.up) * offset;
    }

    void OutOfRange()
    {
        if (transform.position.y <= -25)
        {
            player.transform.position = new Vector3(0f, 75f, 0f);
        }
    }
}
