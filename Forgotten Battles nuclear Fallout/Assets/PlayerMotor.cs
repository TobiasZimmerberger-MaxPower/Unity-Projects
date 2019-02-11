﻿using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour{

    [SerializeField] private Camera cam;
    
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 updown = Vector3.zero;

    private Rigidbody rb;

    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity){
        velocity = _velocity;
    }
    
    public void Rotate(Vector3 _rotation){
        rotation = _rotation;
    }
    
    public void UpDown(Vector3 _updown){
        updown = _updown;
    }

    private void FixedUpdate(){
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement(){
        if (velocity != Vector3.zero){
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }
    
    private void PerformRotation(){
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));

        if (cam != null){
            
            cam.transform.Rotate(-updown);
        }
    }

    public Rigidbody GetRigidbody(){
        return rb;
    }
}