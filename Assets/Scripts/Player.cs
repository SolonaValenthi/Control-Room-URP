using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 7.0f;
    private float _rotateSpeed = 120.0f;

    MeshRenderer _playerMesh;
    Rigidbody _playerRB;

    // Start is called before the first frame update
    void Start()
    {
        _playerMesh = gameObject.GetComponent<MeshRenderer>();
        _playerRB = gameObject.GetComponent<Rigidbody>();

        _playerMesh.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        RotatePlayer();
    }

    private void PlayerMovement()
    {
        float fbMovement = Input.GetAxis("Vertical"); // forward/backward movement
        float lrMovement = Input.GetAxis("Horizontal"); // left/right movement

        Vector3 direction = new Vector3(lrMovement, 0, fbMovement);

        if (Physics.Raycast(transform.position, transform.TransformDirection(direction), 0.6f))
        {
            return;
        }
        else
        {
            transform.Translate(direction * _speed * Time.deltaTime);
        }

    }

    private void RotatePlayer()
    {
        float mouseX = Input.GetAxis("Mouse X");

        Vector3 rotation = new Vector3(0, mouseX, 0);

        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime);
    }
}
