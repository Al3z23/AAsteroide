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


    public GameObject miniMeteorPrefab;
    
    public float maxMMTimeLife = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed  * targetVector * Time.deltaTime);
    }

    private void OnCollisionEnter (Collision collision){
        if(collision.gameObject.CompareTag("Enemy")){
            //IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            DivideMeteor();
        }
        else if(collision.gameObject.CompareTag("Small Enemy")){
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
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
