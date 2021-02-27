using UnityEngine;

public class LevelEndPickup : Interaction
{
    public override void MainInteract()
    {
        base.MainInteract();

        foreach (var levelEndCondition in LevelManager.Instance.CurrentLevel.LevelEndConditions)
        {
            var levelEndConditionCount = levelEndCondition as LevelEndConditionRuntime_Pickup;

            if (levelEndConditionCount != null)
            {
                levelEndConditionCount.IncrementCount();
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawIcon(transform.position, "gizmo_coin.png");
    }
}