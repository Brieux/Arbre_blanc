using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool finished;
    public int gameState;
    [SerializeField] CinemachineVirtualCamera VCWest;
    [SerializeField] CinemachineVirtualCamera VCEast;
    [SerializeField] CinemachineVirtualCamera VCSouth;
    [SerializeField] CinemachineVirtualCamera VCNorth;
    public int numCam = 1;
    public List<GameObject> listPlaceHold;
    public List<GameObject> listJig;
    public GameObject finalAbre;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameMoment();
    }

    // Update is called once per frame
    void Update()
    {
        if (finished && gameState == 1)
        {
            gameState = 2;
            gameMoment();
            finished = false;
        }
        if (finished && gameState == 2)
        {
            gameState = 3;
            gameMoment();
            finished = false;
        }
        if(finished && gameState == 3)
        {
            finished = false;
            finalAbre.SetActive(true);
            finalAbre.GetComponent<Animator>().SetTrigger("Finished");
        }


    }
    public void gameMoment()
    {
        switch (gameState)
        {
            case 1:
                foreach (GameObject placeHolder in listPlaceHold)
                {
                    placeHolder.SetActive(false);
                    
                }
                listPlaceHold[10].SetActive(true);

                foreach (GameObject jigsawPiece in listJig)
                {
                    jigsawPiece.SetActive(false);
                }
                listJig[10].SetActive(true);
                break;

            case 2:
                foreach (GameObject jigsawPiece in listJig)
                {
                    jigsawPiece.SetActive(false);
                }
                listJig[10].SetActive(true);
                listJig[7].SetActive(true);
                listJig[0].SetActive(true);
                listJig[2].SetActive(true);

                foreach (GameObject placeHolder in listPlaceHold)
                {
                    placeHolder.SetActive(false);

                }
                listPlaceHold[7].SetActive(true);
                listPlaceHold[0].SetActive(true);
                listPlaceHold[2].SetActive(true);

                foreach (GameObject jigsawPiece in listJig)
                {
                    jigsawPiece.SetActive(false);
                }
                listJig[10].SetActive(true);
                listJig[7].SetActive(true);
                listJig[0].SetActive(true);
                listJig[2].SetActive(true);
                break;

            case 3:
                foreach (GameObject placeHolder in listPlaceHold)
                {
                    placeHolder.SetActive(true);

                }
                listPlaceHold[7].SetActive(false);
                listPlaceHold[10].SetActive(false);
                listPlaceHold[0].SetActive(false);
                listPlaceHold[2].SetActive(false);
                foreach (GameObject jigsawPiece in listJig)
                {
                    jigsawPiece.SetActive(true);
                }
                break;

            default:
                break;
        }
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
