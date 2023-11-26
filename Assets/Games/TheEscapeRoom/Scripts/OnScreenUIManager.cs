using UnityEngine;

public class OnScreenUIManager : MonoBehaviour
{
    private GameManager _gm;
    
    private void Start()
    {
        _gm = GameManager.Instance;
    }

    public void OpenInventory()
    {
        if (!GameManager.IsGameEnd)
        {
            if (Input.touchCount > 0 && !GameManager.IsPaused)
            {
                if (GameManager.IsInventoryOpen)
                {
                    _gm.CloseInventory();
                }
                else
                {
                    _gm.OpenInventory();
                }
            }
           
        }
    }
    public void OpenPauseMenu()
    {
        
            if (Input.touchCount > 0)
            {
                if (GameManager.IsPaused)
                {
                    _gm.Resume();
                }
                else
                {
                    _gm.Pause();
                }
            }
        }
    


}