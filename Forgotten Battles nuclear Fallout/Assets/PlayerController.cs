using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour{
    [SerializeField] private float speed = 10f;

    [SerializeField] private float lookSensitivity = 1.1f;

    private PlayerMotor motor;


    // Start is called before the first frame update
    void Start(){
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update(){
        
        //Update Movement

        float _xmove = Input.GetAxisRaw("Horizontal");
        float _ymove = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _xmove;
        Vector3 _moveVertical = transform.forward * _ymove;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;

        motor.Move(_velocity);


        //Update Rotation (Horizontal)
        float _yRot = Input.GetAxisRaw("Mouse X");

        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitivity;

        motor.Rotate(_rotation);


        //Update Rotation (Horizontal)
        float _xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 _updown = new Vector3(_xRot, 0f, 0f) * lookSensitivity;

        motor.UpDown(_updown);
    }
}