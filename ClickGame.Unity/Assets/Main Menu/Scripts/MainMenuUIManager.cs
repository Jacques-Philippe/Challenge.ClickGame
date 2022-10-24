using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class MainMenuUIManager : MonoBehaviour
    {
        public void EasyButton_OnClick()
        {
            string preference = "easy";
            this.WritePreferenceToFile(preference);
            this.LoadGame();
        }
        public void MediumButton_OnClick()
        {
            string preference = "medium";
            this.WritePreferenceToFile(preference);
            this.LoadGame();
        }
        public void HardButton_OnClick()
        {
            string preference = "hard";
            this.WritePreferenceToFile(preference);
            this.LoadGame();
        }

        private void WritePreferenceToFile(string preference)
        {
            PlayerPrefs.SetString("preference", preference);
            PlayerPrefs.Save();
        }

        private void LoadGame()
        {
            SceneManager.LoadScene("Scenes/Game");        
        }
    }
}
