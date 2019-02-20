using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [Header("Скорость перемещения")]
    public float speed = 10;
    [Header("Скорость скролла")]
    public float scrollSpeed = 5;

    public float maxX = 15;
    public float maxZ = 15;

    public float minX = 0;
    public float minZ = 0;

    public float minY = 4;
    public float maxY = 10;

    private Transform pos;

    private void Start()
    {
        pos = GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float scroll = Input.GetAxis("Mouse ScrollWheel") * scrollSpeed * Time.deltaTime;


        pos.position = new Vector3(Mathf.Clamp(pos.position.x, minX, maxX), Mathf.Clamp(pos.position.y, minY, maxY), Mathf.Clamp(pos.position.z, minZ, maxZ));

        pos.Translate(new Vector3(horizontal, -scroll, vertical));

    }
}
