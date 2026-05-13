using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private float DestroyDistance;

    [SerializeField]
    private int Damages;

    [SerializeField]
    private float Amplitude;

    [SerializeField]
    private float Frequence;

    private float ix = 0;
    private float iy = 0;
    //transform.position.z
    private float _startZ;
    private float _startX;
    private float _startY;
    private bool _isXSpecial = false;
    private bool _isYSpecial = false;

    [SerializeField]
    private GameObject ExplosionParticles;
    void Start()
    {
        _startZ = transform.position.z;
        _startX = transform.position.x;
        _startY = transform.position.y;
        _isXSpecial = Random.Range(0, 10) == 1;
        _isYSpecial = Random.Range(0, 10) == 1;
    }


    // Update is called once per frame
    void Update()
    {
        float x = 0;
        float y = 0;
        float z = -Speed * Time.deltaTime;
        
        if (_isXSpecial)
        {
            ix++;
            x = Mathf.Sin(Time.time * Frequence) * Amplitude;
            transform.position = new Vector3(_startX + x, transform.position.y, transform.position.z);
            Debug.Log("X Special : " + x);
        }
        if (_isYSpecial)
        {
            iy++;
            y = Mathf.Cos(Time.time * Frequence) * Amplitude;
            transform.position = new Vector3(transform.position.x, _startY + y, transform.position.z);
            Debug.Log("Y Special : " + y);
        }
        transform.position += new Vector3(0, 0, z);

        if (Mathf.Abs(transform.position.z - _startZ) > DestroyDistance)
        {
            Destroy(gameObject);
        }
    }

    public int Explode()
    {
        if(ExplosionParticles != null) {
            Instantiate(ExplosionParticles, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
        return Damages;
    }
}

