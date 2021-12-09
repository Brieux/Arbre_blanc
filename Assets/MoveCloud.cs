using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Rigidbody>().velocity = new Vector3(0, 0,Random.Range(2,5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
