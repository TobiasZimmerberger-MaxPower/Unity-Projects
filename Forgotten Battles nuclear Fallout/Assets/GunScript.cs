
using UnityEngine;

public class GunScript : MonoBehaviour{

    public float damage = 40f;
    public float range = 100f;

    [SerializeField] private Camera cam;
    [SerializeField] private ParticleSystem mf;
    [SerializeField] private ParticleSystem hitparticle;

    [SerializeField] private float firerate = 10f;
    [SerializeField] private float nextfire = 0f;
    
    // Update is called once per frame
    void Update(){

        if (Input.GetButton("Fire1") && Time.time >= nextfire){

            nextfire = Time.time + 1f / firerate;
            
            Shoot();
        }
    }

    void Shoot(){
        RaycastHit hit;

        mf.Play();
        
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit)){
            Debug.Log(hit.transform.name);

            HitScript target = hit.transform.GetComponent<HitScript>();
            if (target != null){
                target.takeDamage(damage);
            }
        }

        ParticleSystem hitter = Instantiate(hitparticle, hit.point, Quaternion.LookRotation(hit.normal));
    
        Destroy(hitter.gameObject, 2f);
    }
}
