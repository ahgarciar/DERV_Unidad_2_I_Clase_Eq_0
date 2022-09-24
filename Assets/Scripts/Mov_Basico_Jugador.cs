using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Basico_Jugador : MonoBehaviour
{
    [SerializeField]
    float velocidad  = 20;
   
    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            Debug.Log("W");
            transform.Translate(transform.forward * velocidad * Time.deltaTime);
            //transform.Translate(Vector3.forward * 20f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
            transform.Translate(transform.right * -1 * velocidad * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
            transform.Translate(transform.forward * -1f * velocidad * Time.deltaTime);
            //transform.Translate(Vector3.back * 20f * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            transform.Translate(transform.right * velocidad * Time.deltaTime);
        }
        

    }
}
