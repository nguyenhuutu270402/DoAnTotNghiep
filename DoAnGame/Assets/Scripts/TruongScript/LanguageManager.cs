using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager : MonoBehaviour
{
    public TMP_Dropdown dropdown_language;
    public TextMeshProUGUI[] MenuMain;
    public TextMeshProUGUI[] MenuPlay;
    public TextMeshProUGUI[] MenuCredits;
    public TextMeshProUGUI[] MenuSetting;
    public TextMeshProUGUI[] BtnBack;

    public ScrollRect credits;
    public RectTransform[] textCredits;
    public GameObject[] textCreditsDisplay;


    public int index;
    int IndexLanguage;
    int IndexBefor;
    void Start()
    {
        IndexLanguage = JsonManager.Instance.getLanguage();
        dropdown_language.value = IndexLanguage;
        IndexBefor = IndexLanguage;
    }

   
    void Update()
    {
        IndexLanguage = dropdown_language.value;
        if(IndexLanguage != IndexBefor)
        {
            JsonManager.Instance.updateLanguage(IndexLanguage);
        }
        if(index == 0)
        {
            if (IndexLanguage == 0)
            {
                MenuMain[0].text = "play";
                MenuMain[1].text = "character";
                MenuMain[2].text = "settings";
                MenuMain[3].text = "credits";
                MenuMain[4].text = "quit";

                MenuPlay[0].text = "state";
                MenuPlay[1].text = "High score:";
                MenuPlay[2].text = "LES'T GO";

                MenuCredits[0].text = "Credits";
                credits.content = textCredits[0];
                textCreditsDisplay[0].SetActive(true);
                textCreditsDisplay[1].SetActive(false);

                MenuSetting[0].text = "settings";
                MenuSetting[1].text = "SFX Volume";
                MenuSetting[2].text = "BGM Volume";
                MenuSetting[3].text = "Language";
                MenuSetting[4].text = "Full Scene";

                for(int i = 0; i < BtnBack.Length; i++)
                {
                    BtnBack[i].text = "Back to title";
                }

            }
            else if (IndexLanguage == 1)
            {
                MenuMain[0].text = "chơi";
                MenuMain[1].text = "trang phục";
                MenuMain[2].text = "cài đặt";
                MenuMain[3].text = "thông tin";
                MenuMain[4].text = "thoát";

                MenuPlay[0].text = "màn chơi";
                MenuPlay[1].text = "Điểm cao:";
                MenuPlay[2].text = "đi thôi";

                MenuCredits[0].text = "Thông tin";
                credits.content = textCredits[1];
                textCreditsDisplay[0].SetActive(false);
                textCreditsDisplay[1].SetActive(true);

                MenuSetting[0].text = "cài đặt";
                MenuSetting[1].text = "Hiệu ứng";
                MenuSetting[2].text = "Nhạc nền";
                MenuSetting[3].text = "Ngôn ngữ";
                MenuSetting[4].text = "Màn hình";

                for (int i = 0; i < BtnBack.Length; i++)
                {
                    BtnBack[i].text = "Trở lại tiêu đề";
                }
            }
        }
        else if(index == 1)
        {
            if (IndexLanguage == 0)
            {

            }
            else if (IndexLanguage == 1)
            {
                
            }
        }




    }
}
