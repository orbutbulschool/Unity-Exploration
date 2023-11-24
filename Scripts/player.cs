using UnityEngine;

public class player : MonoBehaviour
{
    public Boolett bulletPrefab; 


    public float _thrustSpeed = 1.0f;
    
    public float _boostSpeed = 200.0f;
    public float _turnSpeed = 1.0f;
    private Rigidbody2D _rigidBody;
    private bool _thrusting;
    private float _turnDirection;

    private void Awake(){
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    private void Update(){
        _thrusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)){
            _turnDirection = 1.0f;
        } else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)){
            _turnDirection = -1.0f;
        } else{
            _turnDirection = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            Boost();
        }
       
    }
    private void FixedUpdate(){
        if(_thrusting){
            _rigidBody.AddForce(this.transform.up * this._thrustSpeed);
        }
        if(_turnDirection != 0.0f){
            _rigidBody.AddTorque(_turnDirection * _turnSpeed);
        }
    }

    private void Shoot(){
        Boolett bullet= Instantiate(this.bulletPrefab,this.transform.position,this.transform.rotation);
        bullet.project(this.transform.up);
    }

    private void Boost(){
        _rigidBody.AddForce(this.transform.up * _boostSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Assteroid"){
            _rigidBody.velocity= Vector3.zero;
            _rigidBody.angularVelocity= 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();

        }


    }
}
