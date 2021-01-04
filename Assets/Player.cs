using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //ジャンプ力
    public float jumpPower = 5;
    private Rigidbody rigidbody;
    private Vector3 jumpPos;
    public Score score;
    public GameObject gameover;

    private void OnTriggerEnter(Collider other)
    {
        score.score++;
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.transform.GetComponent<Rigidbody>();
        jumpPos = new Vector3(0, jumpPower, 0);
        gameover.SetActive(false);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        gameover.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody.velocity = jumpPos;
        }

    }

}
