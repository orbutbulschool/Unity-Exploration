using UnityEngine;

public class Assteroid : MonoBehaviour
{
    private SpriteRenderer _SpriteRenderer;
    private Rigidbody2D _Rigidbody;

    public float minSize = .5f;
    public float size = 1.0f;
    public float maxSize = 1.5f;

    public float speed = 10.0f;

    public float maxLifeTime = 20.0f;
    public Sprite[] sprites;
    private void Awake(){
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _Rigidbody = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        _SpriteRenderer.sprite= sprites[Random.Range(0,sprites.Length)];

        this.transform.eulerAngles = new Vector3(0.0f,0.0f,(Random.value *360.0f));
        this.transform.localScale = Vector3.one * this.size;

        _Rigidbody.mass = this.size;
    }

    public void setTrajectory(Vector2 Direction){
        _Rigidbody.AddForce(Direction * this.speed);

        Destroy(_Rigidbody,maxLifeTime);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Boolett"){
            if((this.size *0.5f)>=this.minSize){
                CreateSplit();
            }
            Destroy(this.gameObject);
        }
    }

    public void CreateSplit(){
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;

        Assteroid half = Instantiate(this,position, this.transform.rotation);
        half.size = this.size *0.5f;
        half.setTrajectory(Random.insideUnitCircle.normalized);
    }

}
