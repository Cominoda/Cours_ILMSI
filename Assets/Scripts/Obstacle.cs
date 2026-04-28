
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private float DestroyDistance;

    [SerializeField]
    private int Damages;
    private float _startZ;
    private bool isStrange  = false;

    void Start()
    {
        _startZ = transform.position.z;
        //Random rnd = new Random();
        //isStrange = Random.n.next(0, 10) == 1;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Sin(Time.deltaTime);
        float y = Mathf.Cos(Time.deltaTime);
        transform.position += new Vector3(x, y, -Speed * Time.deltaTime);

        if(Mathf.Abs(transform.position.z - _startZ) < DestroyDistance)
        {
            Destroy(gameObject);
        }
    }
    public int Explode()
    {
        Destroy(gameObject);
        return Damages;
    }
}
