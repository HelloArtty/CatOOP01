using UnityEngine;
using Cinemachine;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    private GameObject mapBound;
    private CinemachineConfiner2D confiner;
    public CinemachineVirtualCamera vcam;
    private PolygonCollider2D tempBound;

    private bool teleportStatus;
    private GameObject destinationBound;

    private void Start()
    {
        teleportStatus = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {

                // set before teleport bound to disable
                SetBound();
                // set destination to disable
                //destinationBound = FindChildWithTag(currentTeleporter.GetComponent<Teleporter>().GetDestination().parent.gameObject, "Bound");
                //Debug.Log(destinationBound.name);
                //destinationBound.GetComponent<PolygonCollider2D>().enabled = false;
                //Debug.Log(destinationBound.GetComponent<PolygonCollider2D>().isActiveAndEnabled);

                //Debug.Log(currentTeleporter.GetComponent<Teleporter>().GetDestination().transform.parent.gameObject.name);

                if (teleportStatus == true)
                {
                    transform.position = CheckpointManager.checkpoint.position;
                    //Debug.Log("Back to : " + CheckpointManager.checkpoint.position);
                    teleportStatus = false;
                }
                else if (teleportStatus == false)
                {

                    CheckpointManager.checkpoint = transform;
                    //Debug.Log("Save Check point! : " + CheckpointManager.checkpoint.position);

                    // teleport
                    transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;

                    teleportStatus = true;
                }

                //tempBound.enabled = true;
                //SetBound();

                //// set before teleport bound to enable
                //if (tempBound != null)
                //{
                //    tempBound.enabled = true;
                //}

                // set after teleport bound to camera
                //GetComponent<Player>().SetBoundToCamera();

            }
        }
    }

    GameObject FindChildWithTag(GameObject parent, string tag)
    {
        
        GameObject child = null;

        foreach (Transform transform in parent.transform)
        {
            if (transform.CompareTag(tag))
            {
                child = transform.gameObject;
                break;
            }
        }

        return child;
    }

    void SetBound()
    {
        mapBound = this.gameObject.GetComponent<Player>().bound;
        PolygonCollider2D bound = mapBound.GetComponent<PolygonCollider2D>();
        tempBound = bound;

        if (bound.enabled == true) // if bound is eneble then set to disable
        {
            bound.enabled = false;
        }
        else // if bound is disable then set to enable
        {
            bound.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}