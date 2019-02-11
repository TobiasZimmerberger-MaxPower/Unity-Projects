using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour{
    // Start is called before the first frame update

    [SerializeField] private float time = 0.0f;
    [SerializeField] private float bobbingSpeed = 1f;
    [SerializeField] private float bobbingAmount = 1f;
    [SerializeField] private float midpoint = 2f;
    [SerializeField] private Camera camera;
    
    private void Update(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        double currently = 0.0;
        float translateChange = 0.0f;
        double totalAxes = 0.0;


        if (Math.Abs(horizontal) == 0 && Math.Abs(vertical) == 0){
            time = 0.0f;
        }
        else{
            currently = Math.Sin(time);

            time = time + bobbingSpeed;

            if (time > Math.PI * 2){
                time = (float) (time - (2 * Math.PI));
            }
        }

        if (currently != 0){
            translateChange = (float) (currently * bobbingAmount);
            
            Vector3 bobvector = new Vector3(camera.transform.localPosition.x, midpoint + translateChange, camera.transform.localPosition.z);
            Vector3 currentvector = new Vector3(camera.transform.localPosition.x, camera.transform.localPosition.y, camera.transform.localPosition.z);
            
            camera.transform.localPosition = Vector3.Lerp(currentvector, bobvector, 1f);
        }
        else{
            camera.transform.localPosition = new Vector3(camera.transform.localPosition.x, midpoint, camera.transform.localPosition.z);
        }
    }
}