using UnityEngine;
public class AnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    private void Update()
    {
        float dirX = 0;
        float dirY = 0;
        bool isWalking = false;

        if (Input.GetKey(KeyCode.W))
        {
            dirY = 1;
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dirY = -1;
            isWalking = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            dirX = -1;
            isWalking = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dirX = 1;
            isWalking = true;
        }
        animator.SetFloat("DirX", dirX);
        animator.SetFloat("DirY", dirY);
        animator.SetBool("Walk", isWalking);
    }
}
