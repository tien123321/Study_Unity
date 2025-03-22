using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody rb;
    private bool isGroud=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Chạy tại chỗ");
    }

    // Update is called once per frame
    void Update()
    {
        handleMove();
    }
    public void handleMove(){
        float iphozi= Input.GetAxis("Horizontal");
         float ipvehical= Input.GetAxis("Vertical");
        Vector3 movement=new Vector3(iphozi,0,ipvehical);
        rb.MovePosition(transform.position+ movement*3*Time.fixedDeltaTime);
        if(movement.magnitude>1){
            movement.Normalize();
        }
        if(isGroud){
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(new Vector3(0,1,0)*5,ForceMode.Impulse);
            isGroud=false;
        }
        }
    }
    public void OnCollisionEnter(Collision other) {
        if(other.gameObject.CompareTag("Ground")){
            isGroud=true;
        }
    }
}
