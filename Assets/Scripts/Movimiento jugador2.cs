using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimientojugador2 : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    float m_LateralSpeed;
    float m_ForwardSpeed;
    public GameObject menuFinPartida;
    public Vector3 initialPos;
    public float rotSign;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movementSpeed = 15;
        m_LateralSpeed = 0.3f;
        m_ForwardSpeed = 1.3f;
        initialPos = new Vector3(transform.position.x + 5f, .5f, transform.position.z);
        rotSign = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!menuFinPartida.activeSelf){

            float ver = 0;
            float hor = 0;

            if(Input.GetKey(KeyCode.A)) ver = -1;
            else if(Input.GetKey(KeyCode.D)) ver = 1;
            if(Input.GetKey(KeyCode.W)) hor = 1;
            else if(Input.GetKey(KeyCode.S)) hor = -1;
            
            if (hor != 0 || ver != 0){
                Vector3 direction = (transform.forward * (-ver) + transform.right * hor*0.3f).normalized;
                rb.velocity = direction * movementSpeed;
            }
            else{
                rb.velocity = Vector3.zero;
            }
        }
    }

    public void Initialize()
    {    
        initialPos = new Vector3(transform.position.x + 5f, .5f, transform.position.z);
        rotSign = -1f;
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
