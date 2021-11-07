using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] float lifeTimeAfterLanding = 2f;

    bool hasLanded;

    float deactivateTimer;

    System.Action<Gem> deactivateAction;

    void Update()
    {
        if (!hasLanded) return;

        deactivateTimer += Time.deltaTime;

        if (deactivateTimer >= lifeTimeAfterLanding)
        {
            deactivateTimer = 0f;
            deactivateAction.Invoke(this);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        hasLanded = true;
    }

    void OnDisable()
    {
        hasLanded = false;
    }

    public void SetDeactivateAction(System.Action<Gem> deactivateAction)
    {
        this.deactivateAction = deactivateAction;
    }
}