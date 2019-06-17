using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float RotationSpeed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, RotationSpeed * Time.deltaTime);
    }
}
