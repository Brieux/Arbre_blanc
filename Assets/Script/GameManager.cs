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
    [SerializeField] CinemachineVirtualCamera VCRotate;
    public int numCam = 1;
    public List<GameObject> listPlaceHold;
    public List<GameObject> listJig;
    public GameObject finalAbre;
    public GameObject TransparantTree;
    public GameObject JigsawTree;
    public List<GameObject> ListUI;


    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameMoment();
    }

    public void LetsGo()
    {
        if (gameState == 6)
        {
            
                gameState = 1;
                numCam = 4;
                gameMoment();
                SwitchCam();
                ListUI[1].SetActive(false);
                ListUI[0].SetActive(true);
        }
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
        if (finished && gameState == 3)
        {
            gameState = 4;
            gameMoment();
            finished = false;
        }
        if (finished && gameState == 4)
        {
            gameState = 5;
            gameMoment();
            finished = false;
        }
        if (finished && gameState == 5)
        {
            finished = false;
            TransparantTree.SetActive(false);
            JigsawTree.SetActive(false);
            finalAbre.SetActive(true);
            finalAbre.GetComponent<Animator>().SetTrigger("Finished");
            numCam = 5;
            SwitchCam();
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
                listPlaceHold[1].SetActive(true);
                listPlaceHold[3].SetActive(true);
                listPlaceHold[4].SetActive(true);
                listPlaceHold[6].SetActive(true);
                listPlaceHold[8].SetActive(true);
                listJig[1].SetActive(true);
                listJig[3].SetActive(true);
                listJig[4].SetActive(true);
                listJig[6].SetActive(true);
                listJig[8].SetActive(true);
                break;
            case 4:
                listPlaceHold[5].SetActive(true);
                listPlaceHold[9].SetActive(true);
                listPlaceHold[11].SetActive(true);
                listPlaceHold[12].SetActive(true);
                listPlaceHold[13].SetActive(true);
                listJig[5].SetActive(true);
                listJig[9].SetActive(true);
                listJig[11].SetActive(true);
                listJig[12].SetActive(true);
                listJig[13].SetActive(true);
                break;
            case 5:
                listPlaceHold[14].SetActive(true);
                listPlaceHold[15].SetActive(true);
                listPlaceHold[16].SetActive(true);
                listPlaceHold[17].SetActive(true);

                listJig[14].SetActive(true);
                listJig[15].SetActive(true);
                listJig[16].SetActive(true);
                listJig[17].SetActive(true);

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
                VCRotate.enabled = false;
                break;

            case 2:
                VCWest.enabled = false;
                VCSouth.enabled = true;
                VCEast.enabled = false;
                VCNorth.enabled = false;
                VCRotate.enabled = false;
                break;

            case 3:
                VCWest.enabled = false;
                VCSouth.enabled = false;
                VCEast.enabled = true;
                VCNorth.enabled = false;
                VCRotate.enabled = false;
                break;

            case 4:
                VCWest.enabled = false;
                VCSouth.enabled = false;
                VCEast.enabled = false;
                VCNorth.enabled = true;
                VCRotate.enabled = false;
                break;

            case 5:
                VCWest.enabled = false;
                VCSouth.enabled = false;
                VCEast.enabled = false;
                VCNorth.enabled = false;
                VCRotate.enabled = true;
                break;

            default:
                VCWest.enabled = false;
                VCSouth.enabled = true;
                VCEast.enabled = false;
                VCNorth.enabled = false;
                VCRotate.enabled = false;
                break;
        }
    }
}
