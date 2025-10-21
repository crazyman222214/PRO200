using UnityEngine;
using static UnityEngine.GraphicsBuffer;

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
            
            if (Physics.Raycast(ray.origin, ray.direction, out hit, 500, tableLayerMask))
            {
                Rigidbody rb = GetComponent<Rigidbody>();
                Vector3 lerpPos = Vector3.Lerp(transform.position, hit.point, 0.4f);

                rb.MovePosition(lerpPos);
            }
            else
            {
                Debug.Log("AOOGA");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       
    }
}
