using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFood : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(5.0f,5.0f,5.0f);
    public float speed = 1.0f;
    public bool isThrown = false;
    public float reloadTime = 7f;
    private float currentTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isThrown && Input.GetKeyDown(KeyCode.X)){
            isThrown = true;
            currentTime = Time.time;
            Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
        }
        if(isThrown && Time.time - currentTime >= reloadTime){
            isThrown = false;
            currentTime = 0;
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            if (rigidbody != null)
            {
                Destroy(rigidbody);
            }
        }
        if(isThrown){
            Throw();
        }
        else{
            Follow();
        }
    }

    // Make food follow player
    void Follow()
    {

        transform.position = player.transform.position + offset;

    }

    void Throw()
    {

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }
}
