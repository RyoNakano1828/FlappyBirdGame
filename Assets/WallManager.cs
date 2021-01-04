using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject wall;

    public float sporntime;

    private float y;

    private float time;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > sporntime)
        {
            y = Random.Range(-500, 500);
            time = 0;
            Instantiate(wall, new Vector3(10, y / 100, 0), Quaternion.identity);
        }
        
    }
}
