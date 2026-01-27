using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private float xRotation = 0f;

    [SerializeField] private float xSensitivity  = 30f;
    [SerializeField] private float ySensitivity  = 30f;

    public void ProcessLook(Vector2 _input)
    {
        float mouseX = _input.x;
        float mouseY = _input.y;

        // calcule camera rotation for looking up and down
        xRotation -= mouseY * Time.deltaTime * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0,0);
        //rotate player to look left or right
        transform.Rotate(Vector3.up * mouseX * Time.deltaTime * xSensitivity);
    }
}
