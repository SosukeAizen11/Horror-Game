using UnityEngine;

public class DrawerOpen : MonoBehaviour
{
    public Transform drawer;  // The drawer object to move
    public GameObject animeObject;  // Optional anime-themed object inside the drawer
    public GameObject triggerBox;  // The trigger zone for interaction

    private bool isPlayerNear = false;
    private bool isDrawerOpen = false;
    private Vector3 closedPosition;
    private Vector3 openPosition;
    public float slideDistance = 0.3f;  // How much the drawer moves when opening
    public float moveSpeed = 2f;  // Speed of movement

    void Start()
    {
        if (drawer == null)
        {
            Debug.LogError("Drawer not assigned!");
            return;
        }

        closedPosition = drawer.position;
        openPosition = closedPosition + drawer.transform.forward * slideDistance;

    }   

    void Update()
    {
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            ToggleDrawer();
        }
    }

    private void ToggleDrawer()
    {
        StopAllCoroutines();
        StartCoroutine(MoveDrawer(isDrawerOpen ? closedPosition : openPosition));
        isDrawerOpen = !isDrawerOpen;

        if (animeObject != null && isDrawerOpen)
            animeObject.SetActive(true);  // Reveal the object inside
    }

    private System.Collections.IEnumerator MoveDrawer(Vector3 targetPos)
    {
        while (Vector3.Distance(drawer.position, targetPos) > 0.01f)
        {
            drawer.position = Vector3.Lerp(drawer.position, targetPos, Time.deltaTime * moveSpeed);
            yield return null;
        }
        drawer.position = targetPos;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("Press 'E' to open the drawer.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
        }
    }
}
