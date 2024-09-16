using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuFinPartida : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reiniciar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MenuInicial(string nombre){
        SceneManager.LoadScene(nombre);
    }

    public void Salir(){
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
