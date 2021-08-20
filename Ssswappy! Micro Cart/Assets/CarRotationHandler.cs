using UnityEngine;

public class CarRotationHandler : MonoBehaviour
{
    [SerializeField] private float rotateSpeedModifier = 0.1f;
    private Touch touch;
    private Quaternion rotationY;   
       
    void Update()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Moved)
            {
                rotationY = Quaternion.Euler(
                    0f,
                    -touch.deltaPosition.x + rotateSpeedModifier,
                    0f);

                transform.rotation = rotationY * transform.rotation;
            }
        }
    }
}
