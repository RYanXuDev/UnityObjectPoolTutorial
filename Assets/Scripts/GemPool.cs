using UnityEngine;

public class GemPool : BasePool<Gem>
{
    void Awake()
    {
        Initialize();
    }

    protected override Gem OnCreatePoolItem()
    {
        var gem = base.OnCreatePoolItem();
        gem.SetDeactivateAction(delegate { Release(gem); });

        return gem;
    }

    protected override void OnGetPoolItem(Gem gem)
    {
        base.OnGetPoolItem(gem);
        gem.transform.position = transform.position + Random.insideUnitSphere * 2f;
    }

    public void SetPrefab(Gem prefab)
    {
        this.prefab = prefab;
    }
}