using UnityEngine;
using Cinemachine;
public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;
    public PolygonCollider2D map1Bounds;
    public PolygonCollider2D map2Bounds;

    private CinemachineConfiner2D confiner1;
    private CinemachineConfiner2D confiner2;


    private void Start()
    {
        // Initialize the cameras and bounds as needed
        if (vcam1 != null && vcam2 != null && map1Bounds != null && map2Bounds != null)
        {
            vcam1.gameObject.SetActive(true);
            vcam2.gameObject.SetActive(false);

            // Cache CinemachineConfiner2D components
            confiner1 = vcam1.GetComponent<CinemachineConfiner2D>();
            confiner2 = vcam2.GetComponent<CinemachineConfiner2D>();

            // Set the initial bounding shape
            confiner1.m_BoundingShape2D = map1Bounds;
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
                SwitchCameras();
            }
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
    private void SwitchCameras()
    {
        // Switch between cameras
        vcam1.gameObject.SetActive(!vcam1.gameObject.activeSelf);
        vcam2.gameObject.SetActive(!vcam2.gameObject.activeSelf);

        // Change Bounding Shape 2D based on the active camera
        if (vcam1.gameObject.activeSelf)
        {
            confiner1.m_BoundingShape2D = map1Bounds;
        }
        else
        {
            confiner2.m_BoundingShape2D = map2Bounds;
        }
    }
}
