
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
namespace QuadTreeSolution
{
    public class UIMenuController : MonoBehaviour
    {
        public TMP_InputField inptFldNumberOfEntities;
        public TMP_InputField inptFldInitialHealth;
        public Button btnTopToPlay;


        public void InptFld_OnValueChanged(string aNewValue)
        {
            if (inptFldNumberOfEntities.text.Length > 0 && int.Parse(inptFldNumberOfEntities.text) > 0 && inptFldInitialHealth.text.Length > 0)
            {
                btnTopToPlay.interactable = true;
            }
        }

        public void BtnTopToStartClicked()
        {
            PlayerPrefs.SetInt("NumberOfEntities", int.Parse(inptFldNumberOfEntities.text));
            PlayerPrefs.SetInt("InitialHealth", int.Parse(inptFldInitialHealth.text));
            SceneManager.LoadScene("SceneDemo", LoadSceneMode.Single);
        }
    }
}
