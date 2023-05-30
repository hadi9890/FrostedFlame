using System.Collections;
using TMPro;
using UnityEngine;

namespace Timer
{
    public class TimerScript : MonoBehaviour
    {
        [Tooltip("The UI component representing the game timer")]
        [SerializeField] TextMeshProUGUI TimerUI;
        public static int loadedTime = 0;
        private static int currTime, currSeconds, currMinutes, currHours;
        static string seconds, minutes, hours;
        static bool canSetTime = false;
        public static bool loaded = false;
        
        private void Start()
        {
            // Start the game timer at the beginning of the game
            StartCoroutine(TimeGame());
        }
        private void Update()
        {
            if (canSetTime)
            {
                TimerUI.SetText(hours + ":" + minutes + ":" + seconds);
            }
        }

        private static IEnumerator TimeGame()
        {
            while (true)
            {
                //CALCULATE SECONDS, MINUTES, AND HOURS BASED ON THE NUMBER OF SECONDS THAT HAVE PASSED 
                if (loaded)
                {
                    currTime = (int)(loadedTime + Time.time);
                }
                else
                {
                    currTime = (int)Time.time;
                }

                currHours = currTime > 3600 ? (int)(currTime / 3600) : 0;
                currMinutes = (currTime % 3600) > 60 ? (int)((currTime - (currHours * 3600)) / 60) : 0;
                currSeconds = (int)currTime > 60 ? currTime - (currMinutes * 60) : (int)(currTime);

                //Debug.Log($"hours: {currHours} minutes: {currMinutes} seconds: {currSeconds} ");

                //SET THE HOUR TEXT BASED ON THE NUMBER OF HOURS THAT PASSED
                if (currHours == 0)
                    hours = "00";
                else if (currHours < 10)
                {
                    hours = "0" + currHours.ToString();
                }
                else
                {
                    hours = currHours.ToString();
                }
                
                //SET THE MINUTES TEXT BASED ON THE NUMBER OF MINUTES THAT PASSED
                if (currMinutes == 0)
                    minutes = "00";
                else if (currMinutes < 10)
                {
                    minutes = "0" + currMinutes.ToString();
                }
                else
                {
                    minutes = currMinutes.ToString();
                }
                
                //SET THE SECONDS TEXT BASED ON THE NUMBER OF SECONDS THAT PASSED
                if (currSeconds == 0)
                    seconds = "00";
                else if (currSeconds < 10)
                {
                    seconds = "0" + currSeconds.ToString();
                }
                else
                {
                    seconds = currSeconds.ToString();
                }
                canSetTime = true;
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
