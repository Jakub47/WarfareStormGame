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
    private Animator anim;
    public GameObject cam;
    //public GameObject Head;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //cam = gameObject.transform.GetChild(0).gameObject;
        if (photonView.IsMine)
        {
            cam.SetActive(true);
        }
        anim.SetFloat("Move", 0);
        //else
        //{
        //    cam.SetActive(false);
        //}
    }

    //private void LateUpdate()
    //{
    //    Head.transform.position = Vector3.zero;
    //}

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");

            if (Input.GetKey(Left))
            {
                anim.SetFloat("Move", .5f);
                body.AddRelativeForce(Vector3.left * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            else if (Input.GetKeyUp(Left))
            {
                anim.SetFloat("Move", 0);
            }
            if (Input.GetKey(Right))
            {
                anim.SetFloat("Move", .5f);
                body.AddRelativeForce(Vector3.left * -moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            else if (Input.GetKeyUp(Right))
            {
                anim.SetFloat("Move", 0);
            }
            if (Input.GetKey(Forward))
            {
                anim.SetFloat("Move", .5f);
                body.AddRelativeForce(Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            else if (Input.GetKeyUp(Forward))
            {
                anim.SetFloat("Move", 0);
            }
            if (Input.GetKey(Backward))
            {
                anim.SetFloat("Move", .5f);
                body.AddRelativeForce(Vector3.forward * -moveSpeed * Time.deltaTime, ForceMode.Impulse);
            }
            else if (Input.GetKeyUp(Backward))
            {
                anim.SetFloat("Move", 0);
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetFloat("Move", 1f);
                body.AddRelativeForce(Vector3.left * (moveSpeed + 30) * Time.deltaTime, ForceMode.Impulse);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetFloat("Move", 0f);
            }
            gameObject.transform.Rotate(new Vector3(0, x, 0));
            cam.transform.Rotate(new Vector3(-y, 0, 0));
        }
    }
}
