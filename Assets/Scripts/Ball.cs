using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 500.0f;
    public AudioClip bounceSound; 

    private Rigidbody2D _rigidbody;
    private AudioSource _audioSource; 

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _audioSource = GetComponent<AudioSource>(); 
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void Start()
    {
        ResetPosition();
        AddStartingForce();
    }

    public void AddStartingForce()
    {
        float x = Random.value < 0.5f ? -1.0f : 1.0f;
        float y = Random.value < 0.5f ? Random.Range(-1.0f, -0.5f) :
                                        Random.Range(0.5f, 1.0f);

        Vector2 direction = new Vector2(x, y);
        _rigidbody.AddForce(direction * this.speed);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

    public void ResetPosition()
    {
        _rigidbody.position = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Paddle"))
        {
            if (bounceSound != null && _audioSource != null)
            {
                _audioSource.PlayOneShot(bounceSound); 
            }
        }
    }
}
