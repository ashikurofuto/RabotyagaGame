using AxGrid.Model;
using AxGrid.FSM;
using AxGrid;



[State("HomeState")]
public class HomeState : FSMState
{
    

    [Enter]
    private void EnterHome()
    {   
        Log.Debug("Im in home");
        Settings.Model.EventManager.Invoke("OnGoingHomeEvent");
        
    }

    [Bind("GoingWork")]
    private void TakeWork()
    {
        Parent.Change("WorkState");
        Model.EventManager.Invoke("OnHomeButtonChanged");
    }
    [Bind("GoingShop")]
    private void TakeShop()
    {
        Parent.Change("ShopState");
        Model.EventManager.Invoke("OnHomeButtonChanged");
    }


    [Exit]
    private void ExitHome()
    {
        Log.Debug("Im going");
    }
}
