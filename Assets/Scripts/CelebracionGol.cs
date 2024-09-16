using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebracionGol : MonoBehaviour
{
    public float TiempoDeVida = 4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TiempoDeVida -= Time.deltaTime;
        if(TiempoDeVida <= 0){
            Destroy(this.gameObject);
        }

        //this.transform.localScale = new Vector3(this.transform.localScale.x * 1.5f, this.transform.localScale.y * 1.5f, this.transform.localScale.z * 1.5f);
        
    }
}
