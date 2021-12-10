using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool openMenuBool = false;
    public GameObject Glisseur;
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

    public void resetPieces()
    {
        foreach (OnClickPieces piece in GameObject.FindObjectsOfType<OnClickPieces>())
        {
            piece.resetPiece();
        }
    }
    public void launchGame()
    {
        GameManager.Instance.LetsGo();
    }
    public void openMenu()
    {
        if (!openMenuBool)
        {
            Glisseur.GetComponent<Animator>().SetTrigger("OpenMenuAnim");
            openMenuBool = true;
        }
        else
        {
            Glisseur.GetComponent<Animator>().SetTrigger("CloseMenu");

            openMenuBool = false;
        }
    }

    public void quitthegame()
    {
        Debug.Log("Salut");
        Application.Quit();
    }
}
