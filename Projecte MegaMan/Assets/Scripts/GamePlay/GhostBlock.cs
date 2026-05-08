using UnityEngine;

public class GhostBlock : MonoBehaviour
{
    public float activeTime = 2f;
    public float inactiveTime = 2f;
    public float startDelay = 0f;

    private SpriteRenderer sr;
    private Collider2D col;

    private bool active;
    private float timer;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        // 🔴 empieza apagado
        SetState(false);
    }

    void Update()
    {
        timer += Time.deltaTime;

        // 🔵 espera inicial
        if (timer < startDelay) return;

        if (active && timer >= startDelay + activeTime)
        {
            SetState(false);
            timer = startDelay;
        }
        else if (!active && timer >= startDelay + inactiveTime)
        {
            SetState(true);
            timer = startDelay;
        }
    }

    public void SetState(bool state)
    {
        active = state;

        sr.enabled = state;
        col.enabled = state;
    }
}