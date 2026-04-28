using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float Speed;

    [SerializeField]
    private float DestroyDistance;
    private float _startZ;

    void Start()
    {
        _startZ = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, Speed * Time.deltaTime);

        if (Mathf.Abs(transform.position.z - _startZ) > DestroyDistance)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("RENTR2E DANS TRIGGER !");
        Obstacle o = other.GetComponent<Obstacle>();
        if (o != null)
        {
            Debug.Log("Attaque déclenchée !");
            o.Explode();
            Explode();
        }
    }
    public void Explode()
    {
        Destroy(gameObject);
    }
}
