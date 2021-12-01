using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool finished;
    [SerializeField] CinemachineVirtualCamera VCWest;
    [SerializeField] CinemachineVirtualCamera VCEast;
    [SerializeField] CinemachineVirtualCamera VCSouth;
    [SerializeField] CinemachineVirtualCamera VCNorth;
    public int numCam = 1;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {



    }
    public void SwitchCam()
    {
        switch (numCam)
        {
            case 1:
                VCWest.enabled = true;
                VCSouth.enabled = false;
                VCEast.enabled = false;
                VCNorth.enabled = false;
                break;

            case 2:
                VCWest.enabled = false;
                VCSouth.enabled = true;
                VCEast.enabled = false;
                VCNorth.enabled = false;
                break;

            case 3:
                VCWest.enabled = false;
                VCSouth.enabled = false;
                VCEast.enabled = true;
                VCNorth.enabled = false;
                break;

            case 4:
                VCWest.enabled = false;
                VCSouth.enabled = false;
                VCEast.enabled = false;
                VCNorth.enabled = true;
                break;

            default:
                VCWest.enabled = false;
                VCSouth.enabled = true;
                VCEast.enabled = false;
                VCNorth.enabled = false;
                break;
        }
    }
}
