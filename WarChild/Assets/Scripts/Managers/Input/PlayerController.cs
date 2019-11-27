using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movSpeed;
    private float sensitivity;
    private Camera camera;
    private Player player;
    private float pitch;
    private float maxPitch;
    private float yaw;

    private void Start()
    {
        maxPitch = 30f;
        player = GetComponent<Player>();
        movSpeed = GetComponent<Player>().GetStats().GetMovSpeed();
        sensitivity = 1f;
        camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        pitch = 0.0f;
        yaw = 0.0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal") * movSpeed, 0f, Input.GetAxis("Vertical") * movSpeed);
        transform.Translate(velocity);

        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= (sensitivity / 2) * Input.GetAxis("Mouse Y");
        if (pitch > maxPitch)
            pitch = maxPitch;
        else if (pitch < -maxPitch)
            pitch = -maxPitch;


        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
        camera.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        if (Input.GetButton("Fire3"))
        {
            player.PullTrigger();
        }
    }
}
