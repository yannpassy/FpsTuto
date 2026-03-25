using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty); // to make sure that the TMP is clear if the player interact with nothing
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo; // variable that store the collision information

        // if there is an collision with de Raycast and with an game object with the mask
        if(Physics.Raycast(ray, out hitInfo, distance, mask ))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null) // si l'objet touché contient un script héritant de Interactable
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);

                if (inputManager.onFoot.Interact.triggered) // si on utilise la commande lier à l'interact
                {
                    interactable.BaseInteract();
                }
            }
        }

    }
}
