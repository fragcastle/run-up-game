using UnityEngine;
using System.Collections;

public class PlayerController : BaseBehavior
{

    public bool IsOnLeftSide = true;
    public float DistanceScale = 100;
    public int DistanceTraveled = 0;
    public int MoveForce = 1;
    public float JumpForce = 2;
    public float JumpDuration = 0.5f;
    public int RunSpeed = 5;
    public bool CanRun = false;
    public GameObject DeathPrefab;

    private float currentJumpForce = 0f;
    private float jumpTimer = 0f;
    private Animator _animator;
    private GravityController _gravity;
    private float _screenWidth;
    

    // Use this for initialization
    void Start()
    {
        _animator = GetComponent<Animator>();
        _gravity = GetComponent<GravityController>();
        _screenWidth = ScreenWidth();
    }

    // Update is called once per frame
    void Update()
    {
        var yPos = transform.position.y;
        var xPos = transform.position.x;

        if (yPos * DistanceScale > DistanceTraveled)
            DistanceTraveled = (int)(yPos * DistanceScale);

        if (IsBelowTheFold(1))
        {
            // AddHighScore(DistanceTraveled);

            Destroy(gameObject);
        }

        if (IsMobile())
        {

        }
        else
        {
            if (Input.GetButtonDown("Jump") && jumpTimer <= 0f)
                jumpTimer = JumpDuration;

            if (Input.GetButtonDown("Fire1"))
            {
                IsOnLeftSide = !IsOnLeftSide;
                if (!IsOnLeftSide)
                    _gravity.GravityBinding = GravityController.GravityType.BoundToRight;
                else
                    _gravity.GravityBinding = GravityController.GravityType.BoundToLeft;
            }
        }

        if (CanRun)
            yPos = transform.position.y + RateOfTravel();

        if (jumpTimer >= 0f)
        {
            var direction = IsOnLeftSide ? 1 : -1;
            xPos = xPos + (JumpForce * Time.deltaTime * direction);
            jumpTimer -= Time.deltaTime;
        }

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }

    void FixedUpdate()
    {
        if (IsOnLeftSide)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(1, -1, 1);
    }

    public float RateOfTravel()
    {
        return (MoveForce * Time.deltaTime * 1 * RunSpeed);
    }

    public void Die()
    {
        if (DeathPrefab != null)
            Instantiate(DeathPrefab, new Vector3(transform.position.x, transform.position.y + (RateOfTravel() * 2), -1f), Quaternion.identity);
        Destroy(gameObject);
    }
}
