using UnityEngine;

public class PinchZoom : MonoBehaviour
{
    private float initialTouchDistance;
    private float zoomSpeed = 0.008f;

    // Zoom yapýlacak nesneyi tanýmlamak için
    public GameObject zoomTarget;

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            if (touch2.phase == TouchPhase.Began)
            {
                initialTouchDistance = Vector2.Distance(touch1.position, touch2.position);
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentTouchDistance = Vector2.Distance(touch1.position, touch2.position);
                float deltaDistance = currentTouchDistance - initialTouchDistance;

                Zoom(deltaDistance * zoomSpeed);

                initialTouchDistance = currentTouchDistance;
            }
        }
    }

    void Zoom(float delta)
    {
        if (zoomTarget == null)
        {
            Debug.LogWarning("Zoom hedefi belirtilmemiþ!");
            return;
        }

        // Zoom yapýlacak nesneyi belirle
        GameObject target = zoomTarget;

        // Zoom yap
        target.transform.localScale += new Vector3(delta, delta, delta);
    }
}
