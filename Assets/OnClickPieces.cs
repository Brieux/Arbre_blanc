using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickPieces : MonoBehaviour
{
    private Vector3 mOffset;
    private float mzCoord;
    private bool movable = true;

    private void OnMouseDown()
    {
        if (movable)
        {
            mzCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
            mOffset = gameObject.transform.position - GetMouseWorldPos();
            mOffset.z = 0;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 0.587f;

        return Camera.main.ScreenToWorldPoint(mousePos);
    }

    private void OnMouseDrag()
    {
        if (movable)
        {
            transform.position = GetMouseWorldPos() + mOffset;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Placeholder")
        {
            transform.position = other.gameObject.transform.position;
            transform.rotation = other.gameObject.transform.rotation;
            transform.localScale = other.gameObject.transform.localScale;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            movable = false;
        }
    }
}
