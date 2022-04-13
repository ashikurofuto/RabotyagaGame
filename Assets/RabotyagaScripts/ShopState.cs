using AxGrid.FSM;
using AxGrid;
using AxGrid.Model;

[State("ShopState")]
public class ShopState : FSMState
{
    [Enter]
    private void EnterShop()
    {
        Log.Debug("Im in Shop");
        Settings.Model.EventManager.Invoke("OnGoingShopEvent");
        
    }

    [Loop(2f)]
    private void SoldMoney()
    {
        if (Settings.Model.GetInt("Money") <= 0)
            return;

        Settings.Model.Set("Money", Settings.Model.GetInt("Money") - 1);
    }

    [Bind("GoingWork")]
    private void TakeWork()
    {
        Parent.Change("WorkState");
        Model.EventManager.Invoke("OnShopButtonChanged");
    }
    [Bind("GoingHome")]
    private void TakeHome()
    {
        Parent.Change("HomeState");
        Model.EventManager.Invoke("OnShopButtonChanged");
    }

    [Exit]
    private void ExitShop()
    {
        Log.Debug("Im leave shop");
    }
}
