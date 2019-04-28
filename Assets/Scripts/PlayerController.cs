using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private bool _isLocked;
    private bool _isGrounded = true;
    private Rigidbody _rb;
    private Vector3 _jumpVector;
    private RaycastHit _groundRayCast;
    
    // Start is called before the first frame update
    private void Start() {
        _rb = GetComponent<Rigidbody>();
        _jumpVector = new Vector3(0.0f, jumpForce, 0.0f);
        Cursor.lockState = CursorLockMode.Locked;
        _isLocked = true;
    }

    private void OnCollisionEnter(Collision other) {
        if (_isGrounded == false && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out _groundRayCast,
                Mathf.Infinity)) 
        {
            
            if (_groundRayCast.transform.tag == "Ground" && _groundRayCast.distance <= 2.6){
                _isGrounded = true;
            }
        }
    }

    // Update is called once per frame
    private void Update() {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        movement *= speed * Time.deltaTime;
        transform.Translate(movement);

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) {
            _rb.AddForce(_jumpVector, ForceMode.Impulse);
            _isGrounded = false;
        }
        if (_isLocked && Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            _isLocked = false;
        } else if (!_isLocked && Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            _isLocked = true;
        }

        
    }
}
