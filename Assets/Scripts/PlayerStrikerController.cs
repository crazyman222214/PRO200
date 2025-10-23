using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerStrikerController : MonoBehaviour
{

    public LayerMask tableLayerMask = -1;
    public MenuController menuController;

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
                Vector3 lerpPos = Vector3.Lerp(transform.position, hit.point, 0.05f);

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

    private void EndGame()
    {
        //after this, we can make it so that the player striker disappears and the game ends
        //make sure to call this when the player loses and re-enable the player on game start
        menuController.LoseGame();
        //gameObject.SetActive(false);
    }

    private void WinGame()
    {
        menuController.WinGame();
    }
}
