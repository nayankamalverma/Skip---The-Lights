using UnityEngine;

public class MoveBackground : MonoBehaviour
{ 
    [SerializeField] private float parallaxEffect;
    [SerializeField] private Transform BackgroundStart;
    [SerializeField] private Transform BackgroundEnd;

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.x <= BackgroundEnd.position.x)
        {
            transform.position = new Vector3( BackgroundStart.position.x , transform.position.y, transform.position.x);
        }
        transform.Translate(parallaxEffect * Time.deltaTime * Vector3.left);
    }
}
