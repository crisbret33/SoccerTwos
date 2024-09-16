using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Funcionesbotones : MonoBehaviour
{
    public int multijugador;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PulsaEmpezar() {
        SceneManager.LoadScene("Nivel 1");
    }

    public void PulsaNiveles() {   //Misma función repetida
        SceneManager.LoadScene("Niveles");
    }

    public void CambioEscena(string nombre) {
        SceneManager.LoadScene(nombre);
    }

    public void unJugador(string nombre){
        multijugador = 0;
        SceneManager.LoadScene(nombre);
    }

    public void dosJugadores(string nombre){
        multijugador = 1;
        SceneManager.LoadScene(nombre);
    }

    public void saveData(){
        PlayerPrefs.SetInt("multijugador",multijugador);
    }

    public void loadData(){
        multijugador = PlayerPrefs.GetInt("multijugador",0);
    }

    private void Awake(){
        loadData();
    }

    private void OnDestroy(){
        saveData();
    }


}
