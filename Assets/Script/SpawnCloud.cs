using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{

    public float RandomDelay;
    public GameObject CloudPrefab;
    public float posMin;
    public float posMax;
    public float scaleMin;
    public float scaleMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RandomDelay -= Time.deltaTime;
        if (RandomDelay < 0)
        {
            RandomDelay = Random.Range(1, 10);
            Vector3 pos = new Vector3(Random.Range(posMin, posMax),transform.position.y,transform.position.z);
            Vector3 scle = new Vector3(Random.Range(scaleMin, scaleMax),1,Random.Range(scaleMin, scaleMax)*2);
            GameObject cloud = Instantiate(CloudPrefab);
            cloud.transform.position = pos;
            cloud.transform.localScale = scle;
        }
    }
}
