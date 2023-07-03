using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
public float horizontalInput;
public float speed = 5f ;
public GameObject projectilePrefab;
private float xRange = 25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);


        // 防止玩家跑出左右边界。 keep player inbound
	  // if(-transform.position.x > xRange){ //dir * transform.position.x > xRange
        if(transform.position.x < -xRange){

		//transform.position = new Vector3(dir * xRange, transform.position.y, transform.position);
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);

        }
        if(transform.position.x > xRange){

            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);

        }

        if(Input.GetKeyDown(KeyCode.Space)){
            // launch a projectile from player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            //学习笔记：第一个方法，transform.position使用当前对象的位置，第二个方法projectilePrefab.transform.position使用预制体自身的位置。
            
        }
    }
}
