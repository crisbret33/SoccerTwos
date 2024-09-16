using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoccerBallController : MonoBehaviour
{
    public GameObject area;
    public GameObject menuFinPartida;
    [HideInInspector]
    public SoccerEnvController envController;
    public string purpleGoalTag; //will be used to check if collided with purple goal
    public string blueGoalTag; //will be used to check if collided with blue goal
    public TextMeshProUGUI puntuacionTextAzul;
    public TextMeshProUGUI puntuacionTextLila;

    public TextMeshProUGUI puntuacionFinalAzul;
    public TextMeshProUGUI puntuacionFinalVerde;
    public GameObject GolAzul;
    public GameObject GolVerde;
    public GameObject jugador;
    public GameObject jugador2;


    private int puntuacionAzul;
    private int puntuacionLila;

    void Start()
    {
        envController = area.GetComponent<SoccerEnvController>();
        puntuacionAzul = 0;
        puntuacionLila = 0;
    }

    void OnCollisionEnter(Collision col)
    {
        if(!menuFinPartida.activeSelf){
            if (col.gameObject.CompareTag(purpleGoalTag)) //ball touched purple goal
            {
                puntuacionAzul++;
                puntuacionTextAzul.text = puntuacionAzul.ToString();
                puntuacionFinalAzul.text = "Equipo azul: " + puntuacionAzul.ToString();
                envController.GoalTouched(Team.Blue);
                Destroy(GameObject.Find(GolAzul.name + "(Clone)"));
                Destroy(GameObject.Find(GolVerde.name + "(Clone)"));
                Instantiate(GolAzul);

                var randomPosX = Random.Range(-5f, 5f);
                var newStartPos = new Vector3(randomPosX, 0f, 0f);
                jugador.transform.position = new Vector3(3.19f, 0.5f, 1.2f) + newStartPos;
                randomPosX = Random.Range(-5f, 5f);
                newStartPos = new Vector3(randomPosX, 0f, 0f);
                jugador2.transform.position = new Vector3(3.19f, 0.5f, -1.2f) + newStartPos;
            }
            if (col.gameObject.CompareTag(blueGoalTag)) //ball touched blue goal
            {
                puntuacionLila++;
                puntuacionTextLila.text = puntuacionLila.ToString();
                puntuacionFinalVerde.text = "Equipo verde: " + puntuacionLila.ToString();
                envController.GoalTouched(Team.Purple);
                Destroy(GameObject.Find(GolAzul.name + "(Clone)"));
                Destroy(GameObject.Find(GolVerde.name + "(Clone)"));
                Instantiate(GolVerde);

                var randomPosX = Random.Range(-5f, 5f);
                var newStartPos = new Vector3(randomPosX, 0f, 0f);
                jugador.transform.position = new Vector3(3.19f, 0.5f, 1.2f) + newStartPos;
                randomPosX = Random.Range(-5f, 5f);
                newStartPos = new Vector3(randomPosX, 0f, 0f);
                jugador2.transform.position = new Vector3(3.19f, 0.5f, -1.2f) + newStartPos;
            }
        }
        
    }
}
