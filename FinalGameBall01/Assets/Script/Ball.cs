using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float clickingSpeed;

    private Rigidbody rb;
    private bool clicking;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicking = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicking = false;
        }
        if (clicking)
        {
            rb.velocity = Vector3.up * -clickingSpeed;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (clicking)
        {
            if (other.collider.gameObject.CompareTag("good"))
            {
                Destroy(other.collider.transform.parent.gameObject);
                FindObjectOfType<LevelGenerator>().ObjectDestroyed(); 
                FindObjectOfType<ScoreManager>().IncreaseScore();
            }
            else if (other.collider.gameObject.CompareTag("bad"))
            {
                SceneManager.LoadScene("GameOver"); 
            }
        }
        else
        {
            rb.velocity = Vector3.up * jumpSpeed;
        }
    }
}



