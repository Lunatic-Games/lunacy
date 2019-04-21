using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private bool _isLocked;
    
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _isLocked = true;
    }

    // Update is called once per frame
    private void Update()
    {
        var movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        movement *= speed * Time.deltaTime;
        transform.Translate(movement);

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
