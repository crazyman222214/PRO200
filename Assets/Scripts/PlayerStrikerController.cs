using UnityEngine;

public class PlayerStrikerController : MonoBehaviour
{

    public LayerMask tableLayerMask = -1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            
            var ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            Debug.Log(ray.origin);

            Debug.DrawRay(ray.origin, ray.direction * 500, Color.red, 10.0f);
            if (Physics.Raycast(ray, out hit, 500, ~0))
            {
                transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            }
            else
            {
                Debug.Log("AOOGA");

            }
        }
    }
}
