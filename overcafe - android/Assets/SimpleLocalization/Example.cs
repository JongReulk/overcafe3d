using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.SimpleLocalization
{
	/// <summary>
	/// Asset usage example.
	/// </summary>
	public class Example : MonoBehaviour
	{
		public Text FormattedText;
        private string m_language;

		/// <summary>
		/// Called on app start.
		/// </summary>
		public void Awake()
		{
			LocalizationManager.Read();

            m_language = PlayerPrefs.GetString("m_language", "English");
            
            /*
			switch (Application.systemLanguage)
			{
				case SystemLanguage.German:
					LocalizationManager.Language = "German";
					break;
				case SystemLanguage.Japanese:
					LocalizationManager.Language = "Japanese";
					break;
                case SystemLanguage.Korean:
                    LocalizationManager.Language = "Korean";
                    break;
                default:
					LocalizationManager.Language = "English";
					break;
			}*/

			// This way you can insert values to localized strings.
			//FormattedText.text = LocalizationManager.Localize("Settings.PlayTime", TimeSpan.FromHours(10.5f).TotalHours);

			// This way you can subscribe to localization changed event.
			//LocalizationManager.LocalizationChanged += () => FormattedText.text = LocalizationManager.Localize("Settings.PlayTime", TimeSpan.FromHours(10.5f).TotalHours);
		}

		/// <summary>
		/// Change localization at runtime
		/// </summary>
		public void SetLocalization(string localization)
		{
			LocalizationManager.Language = localization;
            Debug.Log("언어 변경 !" + localization);
            PlayerPrefs.SetString("m_language", localization);
        }

        public void SetFungusLocalization()
        {
            String m_language = PlayerPrefs.GetString("m_language", "English");
            Debug.Log("m_language" + m_language);
            LocalizationManager.Language = m_language;
        }

		/// <summary>
		/// Write a review.
		/// </summary>
		public void Review()
		{
			Application.OpenURL("https://www.assetstore.unity3d.com/#!/content/120113");
		}
	}
}