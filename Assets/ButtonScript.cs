using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RotatePlus()
    {
        GameManager.Instance.numCam += 1;
        if (GameManager.Instance.numCam > 4)
        {
            GameManager.Instance.numCam = 1;
        } 
        GameManager.Instance.SwitchCam();
    }
    public void RotateMoins()
    {
        GameManager.Instance.numCam -= 1;
        if (GameManager.Instance.numCam < 1)
        {
            GameManager.Instance.numCam = 4;
        }
        GameManager.Instance.SwitchCam();
    }
}
