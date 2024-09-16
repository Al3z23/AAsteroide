using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector; 

    private bool Semaphore = true;


    public GameObject miniMeteorPrefab;
    
    public float maxMMTimeLife = 2f;

    private void SetFalse(){
        gameObject.SetActive(false);
    }

    void Start()
    {
        //Destroy(gameObject, maxLifeTime); //Sin object pooling
        Invoke("SetFalse",maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed  * targetVector * Time.deltaTime);
    }


    private void SemaphoreOn(){
        Semaphore = true;
    }

    private void OnCollisionEnter (Collision collision){
        if(collision.gameObject.CompareTag("Enemy") && Semaphore){
            Semaphore = false; //evita problema de condicion de carrera
            IncreaseScore();
            Destroy(collision.gameObject);
            //Destroy(gameObject); //destruir bala sin object pooling
            DivideMeteor();
            gameObject.SetActive(false);
            Invoke("SemaphoreOn", 0.6f); //evita problema de condicion de carrera
        }
        else if(collision.gameObject.CompareTag("Small Enemy")){
            IncreaseScore();
            Destroy(collision.gameObject);
            //Destroy(gameObject); //destruir bala sin object pooling
            gameObject.SetActive(false);
        }

    }

    private void DivideMeteor()
    {
        GameObject miniMeteor1 = Instantiate(miniMeteorPrefab, 
                transform.position + new Vector3(1f,-1f), Quaternion.identity);
                
        GameObject miniMeteor2 = Instantiate(miniMeteorPrefab, 
                transform.position + new Vector3(-1f,-1f), Quaternion.identity);

        Destroy(miniMeteor1, maxMMTimeLife);
        Destroy(miniMeteor2, maxMMTimeLife);
    }

    private void IncreaseScore(){
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Puntos: " + Player.SCORE;
    }
}
