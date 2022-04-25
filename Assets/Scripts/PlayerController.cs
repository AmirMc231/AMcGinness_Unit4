using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rbPlayer;
    public float speed = 10.0f;
    Renderer render;
    GameObject focalPoint;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        render = GetComponent<Renderer>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float magnitude = forwardInput * speed * Time.deltaTime;
        rbPlayer.AddForce(transform.forward * forwardInput * speed * Time.deltaTime, ForceMode.Impulse);

        if(forwardInput > 0)
        {
            render.material.color = new Color(1.0f - forwardInput, 1.0f, 1.0f - forwardInput);
        }
        else
        {
            render.material.color = new Color(1.0f + forwardInput, 1.0f, 1.0f + forwardInput);
        }
    }
}
