using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlCamara : MonoBehaviour
{
    Vector2 mouseMirar;
    Vector2 suavidadV;

    public float sensibilidad = 5.0f;
    public float suavizado = 2.0f;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        mouseInput = Vector2.Scale(mouseInput, new Vector2(sensibilidad * suavizado, sensibilidad * suavizado));

        suavidadV.x = Mathf.Lerp(suavidadV.x, mouseInput.x, 1f / suavizado);
        suavidadV.y = Mathf.Lerp(suavidadV.y, mouseInput.y, 1f / suavizado);

        mouseMirar += suavidadV;
        mouseMirar.y = Mathf.Clamp(mouseMirar.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(-mouseMirar.y, Vector3.right);
        player.transform.localRotation = Quaternion.AngleAxis(mouseMirar.x, player.transform.up);
    }
}
