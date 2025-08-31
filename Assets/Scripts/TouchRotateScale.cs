using UnityEngine;

public class TouchRotateScale : MonoBehaviour
{
    private float initialDistance;
    private Vector3 initialScale;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Moved)
                transform.Rotate(Vector3.up, -t.deltaPosition.x * 0.5f);
        }

        if (Input.touchCount == 2)
        {
            Touch t0 = Input.GetTouch(0);
            Touch t1 = Input.GetTouch(1);

            if (t0.phase == TouchPhase.Began || t1.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(t0.position, t1.position);
                initialScale = transform.localScale;
            }
            else
            {
                float currentDistance = Vector2.Distance(t0.position, t1.position);
                float factor = currentDistance / initialDistance;
                transform.localScale = initialScale * factor;
            }
        }
    }
}
