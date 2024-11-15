﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool autoMove = true;
    public GameObject player = null;
    public float speed = 0.75f;
    public float acceleration = 0.05f;
    public Vector3 offset = new Vector3(5, 7, -4);

    Vector3 depth = Vector3.zero;
    Vector3 pos = Vector3.zero;

    void Update()
    {

        if (!Manager.instance.CanPlay()) return;

        if (autoMove)
        {
            speed += acceleration * Time.deltaTime;
            depth = this.gameObject.transform.position += new Vector3(0, 0, speed * Time.deltaTime);
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            gameObject.transform.position = new Vector3(pos.x, offset.y, depth.z);
        }
        else
        {
            pos = Vector3.Lerp(gameObject.transform.position, player.transform.position + offset, Time.deltaTime);
            gameObject.transform.position = new Vector3(pos.x, offset.y, pos.z);
        }
    }
}
