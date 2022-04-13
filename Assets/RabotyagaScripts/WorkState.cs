using AxGrid.FSM;
using AxGrid;
using AxGrid.Model;

[State("WorkState")]
public class WorkState : FSMState
{
    [Enter]
    private void EnterWork()
    {
        Log.Debug("Im in the work");
        Settings.Model.EventManager.Invoke("OnGoingWorkEvent");
        
    }

    [Loop(2f)]
    private void LoopThis()
    {
       Settings.Model.Set("Money", Settings.Model.GetInt("Money") + 1);
    }

    [Bind("GoingHome")]
    private void TakeWork()
    {
        Parent.Change("HomeState");
        Model.EventManager.Invoke("OnWorkButtonChanged");
    }
    [Bind("GoingShop")]
    private void TakeShop()
    {
        Parent.Change("ShopState");
        Model.EventManager.Invoke("OnWorkButtonChanged");
    }

    [Exit]
    private void ExitWork()
    {
        Log.Debug("Im leaving work");
    }
}
