using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class MiniMeteor : MonoBehaviour
{

    public float speed = 5f;
    // Start is called before the first frame update
    private static int cont = 0;

    public UnityEngine.Vector3 targetVector;

    private UnityEngine.Vector3 calcularDir(){
        if(cont%2 == 0){
            targetVector = new UnityEngine.Vector3(1,-1);
        }
        else{
            targetVector = new UnityEngine.Vector3(-1,-1);
        }
        cont++;
        return targetVector;
    }


    // Update is called once per frame
    
    void Update()
    {
        transform.Translate(speed  * calcularDir() * Time.deltaTime);
    }
}
