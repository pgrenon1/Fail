using UnityEngine;

public class PlayerManager : OdinSerializedSingletonBehaviour<PlayerManager>
{
    public Player playerPrefab;
    
    public Player Player { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        //CreatePlayerController();
    }

    public void CreatePlayerController(Vector3 position, Quaternion rotation)
    {
        Player = Instantiate(playerPrefab, position, rotation);
    }

    public void TogglePlayerActive(bool active)
    {
        Player.gameObject.SetActive(active);
    }

    public void TeleportAndActivate(Vector3 position, Quaternion rotation)
    {
        TogglePlayerActive(true);
    }

    public void DestroyPlayer()
    {
        Destroy(Player.gameObject);
        Player = null;
    }
}
