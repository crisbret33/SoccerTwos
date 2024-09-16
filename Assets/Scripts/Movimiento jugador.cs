using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientojugador : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    float m_LateralSpeed;
    float m_ForwardSpeed;
    public GameObject menuFinPartida;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSpeed = 15;
        m_LateralSpeed = 0.3f;
        m_ForwardSpeed = 1.3f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!menuFinPartida.activeSelf){

            float ver = 0;
            float hor = 0;

            if(Input.GetKey(KeyCode.LeftArrow)) ver = -1;
            else if(Input.GetKey(KeyCode.RightArrow)) ver = 1;
            if(Input.GetKey(KeyCode.UpArrow)) hor = 1;
            else if(Input.GetKey(KeyCode.DownArrow)) hor = -1;

            //float ver = Input.GetAxis("Horizontal");
            //float hor = Input.GetAxis("Vertical");
            
            if (hor != 0 || ver != 0){
                Vector3 direction = (transform.forward * (-ver) + transform.right * hor*0.3f).normalized;
                rb.velocity = direction * movementSpeed;
            }
            else if (hor == 0 || ver == 0){
                rb.velocity = Vector3.zero;
            }
        }
    }

    

    void OnCollisionEnter(Collision c)
    {
        var force = 2000f;
        
        if (c.gameObject.CompareTag("ball"))
        {
            var dir = c.contacts[0].point - transform.position;
            dir = dir.normalized;
            c.gameObject.GetComponent<Rigidbody>().AddForce(dir * force);
        }
    }
}
