using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    private Vector2 _mouseLook;
    private Vector2 _smoothV;

    public float sensitivity;
    public float smoothing;

    private GameObject _character;
    
    // Start is called before the first frame update
    private void Start() {
        _character = this.transform.parent.gameObject;
    }

    // Update is called once per frame
    private void Update() {
        var moveDirection = new Vector2(Input.GetAxisRaw("Mouse X"),
            Input.GetAxisRaw("Mouse Y"));
        moveDirection = Vector2.Scale(moveDirection, new Vector2(sensitivity * smoothing,
            sensitivity * smoothing));
        _smoothV.x = Mathf.Lerp(_smoothV.x, moveDirection.x, 1f / smoothing);
        _smoothV.y = Mathf.Lerp(_smoothV.y, moveDirection.y, 1f / smoothing);
        _mouseLook += _smoothV;
        
        if (_mouseLook.y > 90)
            _mouseLook.y = 90;
        if (_mouseLook.y < -90)
            _mouseLook.y = -90;

        transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
        _character.transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, _character.transform.up);
    }
}
