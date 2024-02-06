using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float _speed;
    private Target _target;

    private void Start()
    {
        _speed = 20f;
    }

    public void Update()
    {
        Move();
    }

    public void SetDirection(Target target)
    {
        _target = target;
    }

    public void Move()
    {
        float step = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);

        if(transform.position == _target.transform.position)
            Destroy(this.gameObject);
    }
}
