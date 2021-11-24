using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickPieces : MonoBehaviour
{
    private Vector3 RaycastPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool isHit = Physics.Raycast(raycast, out hit, 100);
        if (isHit)
        {
            RaycastPos = hit.point;
        }
    }
}
