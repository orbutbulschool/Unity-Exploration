using UnityEngine;

public class Boolett : MonoBehaviour
{
    private Rigidbody2D _rigidBody;

    public float bulletSpeed = 250.0f;
    public float maxLifeTime = 10.0f;

    private void Awake(){
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    public void project(Vector2 direction){
        _rigidBody.AddForce(direction * this.bulletSpeed);
    
        Destroy(this.gameObject,maxLifeTime);    
    }
    public void OnCollisionEnter2D(Collision2D collision){
        Destroy(this.gameObject);
    }
}
