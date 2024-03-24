using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 rawInput;

    Vector2 minBounds;
    Vector2 maxBounds;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float puddingLeft;
    [SerializeField] float puddingRight;
    [SerializeField] float puddingTop;
    [SerializeField] float puddingBottom;

    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    private void Move()
    {
        Vector2 delta = moveSpeed * Time.deltaTime * rawInput;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + puddingLeft, maxBounds.x - puddingRight);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + puddingBottom, maxBounds.y - puddingTop);

        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
