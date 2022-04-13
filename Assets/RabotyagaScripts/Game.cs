using AxGrid;
using AxGrid.Base;
using AxGrid.FSM;
using AxGrid.Model;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviourExtBind
{
    string BalanceField;
    [SerializeField] private Camera cam;

    private CameraColorChanger colorChanger;
    
    [OnAwake]
    private void AwakeGame()
    {
        
        Settings.Model.Set("Money", 0);
        colorChanger = new CameraColorChanger(cam);
    }

    [OnStart]
    private void StartGame()
    {
        Log.Debug("Game started");
        Settings.Fsm = new FSM();
        Settings.Fsm.Add(new HomeState());
        Settings.Fsm.Add(new WorkState());
        Settings.Fsm.Add(new ShopState());
        Settings.Fsm.Start(nameof(HomeState));
    }

    [OnRefresh(3f)]
    private void CheckMoney()
    {
        BalanceField = $"Balance : {Settings.Model.Get("Money")}";
        Settings.Model.EventManager.Invoke("OnBalanceFieldChanged");
    }

    [OnUpdate]
    private void UpdateGame()
    {
        CheckStateColor();
        Settings.Fsm.Update(Time.deltaTime);
    }

    private void CheckStateColor()
    {
        if (Settings.Fsm.ContainsState("HomeState"))
        {
            colorChanger.SetColor(Color.red);
        }
        else if (Settings.Fsm.ContainsState("WorkState"))
        {
            colorChanger.SetColor(Color.blue);
        }
        else
        {
            colorChanger.SetColor(Color.yellow);
        }
    }


}

public class CameraColorChanger
{
    private Camera camera;

    public CameraColorChanger(Camera cam)
    {
        this.camera = cam;
    }

    public void SetColor(Color color)
    {
        camera.backgroundColor = color;
    }
}