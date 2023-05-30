using UnityEngine;

public class OnDeathEvent : MonoBehaviour
{
    public delegate void playerDeathDelegate();
    public static event playerDeathDelegate playerDeathEvent;
    public static bool died = false;

    void Start()
    {
        //Debug.Log(playerDeathEvent);

        // Activate death menu
        playerDeathEvent+= new playerDeathDelegate(Health.Health.Die);	// Update Die method

        // Disable low health "filter"
        playerDeathEvent+= new playerDeathDelegate(postprocessing.ChangeBack);

        // Stop game mechanics
        playerDeathEvent+= new playerDeathDelegate(stopGame);

		// Make cursor visible
		playerDeathEvent+= new playerDeathDelegate(cursorsettings);
	}
	
	public static void invokeDeathEvent()
	{
		if (playerDeathEvent == null) return;
		playerDeathEvent.Invoke();
		died = true;
	}
	
	private static void stopGame()
	{
		Time.timeScale = 0;
	}
	
	private static void cursorsettings()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

}