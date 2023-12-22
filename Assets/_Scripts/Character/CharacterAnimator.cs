using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] List<Sprite> idleSprites = new List<Sprite>();
    [SerializeField] List<Sprite> jumpSprites = new List<Sprite>();
    [SerializeField] List<Sprite> runSprites = new List<Sprite>();

    // Parameters (On Animator)
    public float MoveX { get; set; }
    public float MoveY { get; set; }
    public bool IsMoving { get; set; }

    public bool IsJumping { get; set; }

    // States
    SpriteAnimator idle;
    SpriteAnimator jump;
    SpriteAnimator run;

    SpriteAnimator currentAnim;

    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        idle = new SpriteAnimator(spriteRenderer, idleSprites);
        jump = new SpriteAnimator(spriteRenderer, jumpSprites);
        run = new SpriteAnimator(spriteRenderer, runSprites);

        currentAnim = idle;
    }

    private void Update()
    {
        var prevAnim = currentAnim;

        if (MoveX == 1)
            currentAnim = run;
        else if (MoveX == -1)
            currentAnim = run;
        else
            currentAnim = idle;

        if (IsJumping)
            currentAnim = jump;

        if (currentAnim != prevAnim)
            currentAnim.Start();

        if (IsMoving)
            currentAnim.HandleUpdate();
        else
            spriteRenderer.sprite = currentAnim.Frames[0];
    }
}
