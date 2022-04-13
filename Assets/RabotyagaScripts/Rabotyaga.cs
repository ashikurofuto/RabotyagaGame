using AxGrid;
using AxGrid.Base;
using AxGrid.Path;
using UnityEngine;

public class Rabotyaga : MonoBehaviourExt
{
    [SerializeField] private float homePos = -7.4f;
    [SerializeField] private float workPos = 0f;
    [SerializeField] private float shopPos = 7.4f;
    [SerializeField] private float animTime = 2f;

    [OnAwake]
    private void AwakePerson()
    {
        Path = new CPath();
        Model.EventManager.AddAction("OnGoingHomeEvent", GoingToHome);
        Model.EventManager.AddAction("OnGoingWorkEvent", GoingToWork);
        Model.EventManager.AddAction("OnGoingShopEvent", GoingToShop);
    }

    [OnDestroy]
    private void DisablePerson()
    {
        Model.EventManager.RemoveAction(GoingToHome);
        Model.EventManager.RemoveAction(GoingToWork);
        Model.EventManager.RemoveAction(GoingToShop);
    }

    
    private void GoingToHome()
    {
        MakeGiong(homePos);
        Log.Debug("going home");
    }
    private void GoingToWork()
    {
        MakeGiong(workPos);
        Log.Debug("going work");
    }
    private void GoingToShop()
    {
        MakeGiong(shopPos);
        Log.Debug("going shop");
    }

    private void MakeGiong(float endPos)
    {
        Path.EasingLinear(animTime, transform.position.x, endPos, (value) =>
        {
            transform.position = new Vector3(value, transform.position.y, transform.position.z);
        });
        
    }


}
