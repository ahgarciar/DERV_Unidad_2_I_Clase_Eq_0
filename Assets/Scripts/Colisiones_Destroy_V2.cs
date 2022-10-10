using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Colisiones_Destroy_V2 : MonoBehaviour
{
    [SerializeField]
    GameObject ref_handler_spawns; //inspector
    Manager_Spawns control_manager_spawns; //getcomponent


    [SerializeField]
    TextMeshProUGUI texto_tiempo; //se vincula desde inspecto

    [SerializeField]
    int con_objetos_comidos;

    [SerializeField]
    int tot_objetos_a_comer  = 10;

    [SerializeField]
    GameObject referencia_to_HanlerUI; //se vincula desde inspector
    control_UI_Game_V2 componente_control_UI; //se obtiene atraves de getcomponent

    // Start is called before the first frame update
    void Start()
    {
        con_objetos_comidos = 0;

        componente_control_UI = referencia_to_HanlerUI.GetComponent<control_UI_Game_V2>();

        //agregado para la version 2
        control_manager_spawns = ref_handler_spawns.GetComponent<Manager_Spawns>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        string name = collision.gameObject.name;
        string tag = collision.gameObject.tag;

        //si el objeto con el que se colisiona es un enemigo, entonces
        if (tag.Equals("Enemigo_TAG")) {

            GameObject obj_a_destruir;
            obj_a_destruir = GameObject.Find(name);

            if (obj_a_destruir != null) {
                //destruye el objeto 5 segundos despues de colisionar con el 
                //Destroy(obj_a_destruir, 5);

                Destroy(obj_a_destruir); //destruye inmediatamente
                Debug.Log("Moriras!! :D!");
                con_objetos_comidos++;

                if (con_objetos_comidos == tot_objetos_a_comer) {
                    //se acaba el juego
                    string tiempo = texto_tiempo.text;
                    PlayerPrefs.SetString("Score", tiempo);

                    componente_control_UI.cambiarEscena(2);
                }

                control_manager_spawns.crearEnemigo();

            }
            
        }

    }


}
