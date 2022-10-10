using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class control_UI_Game : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI txt_nombre;


    public void cambiarEscena(int index_escena) {


        Scene scene = SceneManager.GetActiveScene();

        if (scene.buildIndex == 0) //escena inicio
        {
            string nombre = txt_nombre.text;
            PlayerPrefs.SetString("nom_usuario", nombre);
        }        

        SceneManager.LoadScene(index_escena);
    }

    private void Start()
    {
        //siempre lee el nombre del usuario
        string n = PlayerPrefs.GetString("nom_usuario", "");
        if (!n.Equals("")) {
            Debug.Log("El nombre del usuario es: " + n);
        }


        //asigna el nombre del usuario al componente TMP
        Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex == 2) //escena final
        {
            string nombre = PlayerPrefs.GetString("nom_usuario", "");
            txt_nombre.text = nombre;
        }


    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) {
            Scene scene = SceneManager.GetActiveScene();
            if (scene.buildIndex == 1) //solo cambiara de escena
                //cuando la escena actual sea la del juego
            {
                cambiarEscena(2);
            }
        }
    }


}
