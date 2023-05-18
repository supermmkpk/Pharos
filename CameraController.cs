using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool doMovement = true;
    public float panSpeed = 30f;
    public float panBorderThickness = 10;
    public float scrollSpeed = 5f;
    public float minY = 2f;
    public float MaxY = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Est키를 눌렀을 때만, 카메라 이동 되도록 함.
            doMovement = !doMovement;
        if (!doMovement)
            return;
       
            if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThickness)
            {
                transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
            }
            if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
            {
                transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
            }
            if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThickness)
            {
                transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
            }
            if(Input.GetKey("s") || Input.mousePosition.x <= panBorderThickness)
            {
                transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
            }

            float scroll = Input.GetAxisRaw("Mouse ScrollWheel");
            Vector3 pos = transform.position;
            pos.y -= scroll * 100 * scrollSpeed * Time.deltaTime;
            pos.y = Mathf.Clamp(pos.y, minY, MaxY);
            transform.position = pos;
    }
}
