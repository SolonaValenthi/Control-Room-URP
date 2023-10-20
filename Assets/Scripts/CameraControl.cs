using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerObj;

    private float _yOffset;
    private float _rotateSpeed = 120.0f;

    // Start is called before the first frame update
    void Start()
    {
        _yOffset = transform.position.y - _playerObj.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
    }

    private void LateUpdate()
    {
        Vector3 offset = new Vector3(0, _yOffset, 0);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, _playerObj.transform.rotation.eulerAngles.y, 0);
        transform.position = _playerObj.transform.position + offset;
    }

    private void RotateCamera()
    {
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotation = new Vector3(-mouseY, 0, 0);
        transform.Rotate(rotation * _rotateSpeed * Time.deltaTime);
    }
}
