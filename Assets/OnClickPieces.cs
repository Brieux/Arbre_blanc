using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickPieces : MonoBehaviour
{
    private Vector3 mOffset;
    private float mzCoord;
    private bool movable = true;
    public bool isOk = false;
    public GameObject rightAnswer;
    private GameObject usingPlace = null;
    private bool passed = true;
    private bool snappable = false;
    private GameObject colldingGO;
    public Vector3 originalPos;
    public Vector3 originalScale;
    public Quaternion originalRot;

    private void OnMouseDown()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.rotation = rightAnswer.transform.rotation;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        mzCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mOffset = gameObject.transform.position - GetMouseWorldPos();
        movable = true;
        if (colldingGO != null)
        {
            colldingGO.SetActive(true);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            colldingGO = null;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mzCoord;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDrag()
    {
        if (movable)
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
    }

    private void OnMouseUp()
    {
        if (snappable)
        {
            transform.position = colldingGO.transform.position;
            transform.rotation = colldingGO.transform.rotation;
            transform.localScale = colldingGO.transform.localScale;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            usingPlace = colldingGO;
            colldingGO.SetActive(false);
            movable = false;
            if (usingPlace == rightAnswer)
            {
                isOk = true;
                foreach (OnClickPieces piece in GameObject.FindObjectsOfType<OnClickPieces>())
                {
                    passed = passed && piece.isOk;
                }
                GameManager.Instance.finished = passed;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
        originalRot = transform.rotation;
        originalScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Placeholder" && movable)
        {
            snappable = true;
            colldingGO = other.gameObject;
            /*
            transform.position = other.gameObject.transform.position;
            transform.rotation = other.gameObject.transform.rotation;
            transform.localScale = other.gameObject.transform.localScale;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            usingPlace = other.gameObject;
            other.gameObject.SetActive(false);
            movable = false;
            if (usingPlace == rightAnswer)
            {
                isOk = true;
                foreach (OnClickPieces piece in GameObject.FindObjectsOfType<OnClickPieces>())
                {
                    passed = passed && piece.isOk;
                }
                GameManager.Instance.finished = passed;
            }
        }*/
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Placeholder" && movable)
        {
            snappable = false;
            colldingGO = null;
        }
    }

    public void resetPiece()
    {
        if (!isOk)
        {
            Debug.Log("Reseting pieces");
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.rotation = originalRot; 
            transform.position = originalPos; 
            transform.localScale = originalScale;
        }
    }

}
