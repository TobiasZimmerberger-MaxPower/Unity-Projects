using UnityEngine;

public class HitScript : MonoBehaviour{

    public float health = 100f;

    public void takeDamage(float damage){
        health -= damage;

        if (health <= 0){
            Destroy(gameObject);
        }
    }
}