using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

    public int totalPoints;
    public int redPoints;
    public int greenPoints;
    public int bluePoints;

    public Image currentHealthBar;
    public Text greenText;
    public Text blueText;
    public Text redText;
    public Text scoreTime;
    public Text totalScore;
    public float limitTime;

    private float hitpoint = 150;
    private float maxHitPoint = 150;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateTime();
        greenText.text = "x" + greenPoints;
        redText.text = "x" + redPoints;
        blueText.text = "x" + bluePoints;
        totalScore.text = "Puntos Totales: " + totalPoints;
        CheckScore();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("enemy")){
            //Debug.Log("YOU DIE");
            float ratio = hitpoint / maxHitPoint;
            currentHealthBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
            hitpoint -= 10;
            if(hitpoint <= 0){
                SceneManager.LoadScene("Lose");
            }
            //SceneManager.LoadScene("Lose");
        }
    }

    void UpdateTime(){
        limitTime -= Time.deltaTime;
        string segundos = limitTime.ToString("f0");
        scoreTime.text = "Tiempo: " + segundos;
        if (limitTime <= 0)
        {
            SceneManager.LoadScene("Lose");
        }
    }

    void CheckScore()
    {
        if (greenPoints >= 50 && redPoints >= 30 && bluePoints >= 10)
        {
            Debug.Log("Juego terminado");
            Debug.Log("Puntaje Final: " + totalPoints);
            SceneManager.LoadScene(2);
        }
        if (totalPoints > 1000){
            SceneManager.LoadScene(2);
        }
    }
}
