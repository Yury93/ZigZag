using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Готовый скрипт zigzag для анимированого персонажа
/// </summary>
public class InputPlayer : MonoBehaviour
{
    [SerializeField] private float speedUp, timerSpeed, startTimer;
    public float SpeedUp => speedUp;
    private Animator anim;
    public Animator Anim => anim;
    [SerializeField]private LayerMask layerMask;
    [SerializeField] private Rigidbody rb;

    public enum Direction
    {
        right,
        left
    }
    Direction dir;

    private void Start()
    {
        startTimer = timerSpeed;
        anim = GetComponent<Animator>();
        TapToScreen.Instance.OnTap += InputState;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        timerSpeed -= Time.deltaTime;
        if (timerSpeed < 0)
        {
            anim.speed += speedUp;
            timerSpeed = startTimer;
        }
            if (Physics.OverlapSphere(transform.position, 0.1f, layerMask).Length == 0)
        {
            StartCoroutine(CorDeath());
        }
        InputKey();
    }
    IEnumerator cor()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            go.transform.localScale *= 1;
            go.transform.position = transform.position;
        }
    }
    private void InputKey()
    {
        if (dir == Direction.right )
        {
            rb.velocity = Vector3.right * (anim.speed/1.5f);
            print("right");
        }
        if (dir == Direction.left)
        {
            rb.velocity = Vector3.forward * (anim.speed/1.5f);
            print("left");
        }
        
    }

        private void InputState()
    {
        if (dir == Direction.right)
        {
            dir = Direction.left;
        }
        else if (dir == Direction.left)
        {
            dir = Direction.right;
        }
    }
    IEnumerator CorDeath()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
}
