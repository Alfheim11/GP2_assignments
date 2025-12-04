using UnityEngine;

public class DonenCemberKod : MonoBehaviour
{
    

    public int hiz;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, hiz * Time.deltaTime, 0);
    }
}
