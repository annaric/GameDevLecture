using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitFaller : MonoBehaviour
{

    public GameObject fruit;
    public float minScale = 0.2f, maxScale = 1.2f;
    public float addScaleAmount  = 0.1f;
    bool hasAlreadyRig = false;
    //public GameObject characterController;

    // Start is called before the first frame update
    void Start()
    {
        float rand = Random.Range(minScale, maxScale);
        fruit.transform.localScale = new Vector3(rand,rand,rand);
        //characterController = GameObject.Find("Player");
    }



    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !hasAlreadyRig)
        {                
            fruit.AddComponent<Rigidbody>();
            hasAlreadyRig = true;  
        } else if(Input.GetKeyDown(KeyCode.F) && hasAlreadyRig) {
            fruit.transform.localScale += new Vector3(addScaleAmount,addScaleAmount,addScaleAmount);
        }
    }
}
