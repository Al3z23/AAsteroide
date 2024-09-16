using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float thrustForce = 100f;
    public float rotationSpeed = 120f;

    public GameObject gun;
    public static int SCORE = 0;
    public static float xBorderLimit = 6f, yBorderLimit = 5f;

    private Rigidbody _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var newPos = transform.position;
        if(newPos.x > xBorderLimit){
            newPos.x = -xBorderLimit + 1;
        }
        else if(newPos.x < -xBorderLimit){
            newPos.x = xBorderLimit - 1;
        }
        else if(newPos.y > yBorderLimit){
            newPos.y = -yBorderLimit + 1;
        }
        else if(newPos.y < -yBorderLimit){
            newPos.y = yBorderLimit - 1;
        }
        transform.position = newPos;
        
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime * thrustForce;
        Vector3 thrustDirection = transform.right;
        _rigid.AddForce(thrustDirection * thrust);
        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);
        
        

        if(Input.GetKeyDown(KeyCode.Space)){
            //GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity); 
            //Sin object pooling
            GameObject bullet = BulletPool.Instance.RequestBullet();
            bullet.transform.position = gun.transform.position;
            Bullet balaScript = bullet.GetComponent<Bullet>();
            balaScript.targetVector = transform.right;
        }
    }

    private void OnCollisionEnter (Collision collision){
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Small Enemy"){
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    
    }
}
