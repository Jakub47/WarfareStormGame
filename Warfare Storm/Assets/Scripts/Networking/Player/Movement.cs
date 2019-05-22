using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Pun;

public class Movement : MonoBehaviourPun
{
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Forward;
    public KeyCode Backward;

    [SerializeField]
    private float moveSpeed = 50;

    private Rigidbody body;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        //cam = gameObject.transform.GetChild(0).gameObject;
        if(photonView.IsMine)
        {
            cam.SetActive(true);
        }
        //else
        //{
        //    cam.SetActive(false);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            if (Input.GetKey(Left))
            {
                body.AddRelativeForce(Vector3.left * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            if (Input.GetKey(Right))
            {
                body.AddRelativeForce(Vector3.left * -moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            if (Input.GetKey(Forward))
            {
                body.AddRelativeForce(Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            if (Input.GetKey(Backward))
            {
                body.AddRelativeForce(Vector3.forward * -moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            gameObject.transform.Rotate(new Vector3(0, x, 0));
            cam.transform.Rotate(new Vector3(-y, 0, 0));
        }
    }
}
