using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Tumba.UI
{
    public class TabsManager : MonoBehaviour
    {
        [SerializeField] ListItemData[] all;

        [Serializable]
        class ListItemData
        {
            public string name;
            public GameObject content;
        }

        [SerializeField] ButtonUI button;
        List<ButtonUI> buttons;

        [SerializeField] Transform container;

        public void Init()
        {
            SetButtons();
            Select(0);
        }
        public void SetButtons()
        {
            buttons = new List<ButtonUI>();
            Utils.RemoveAllChildsIn(container);
            int id = 0;
            foreach (ListItemData data in all)
            {
                ButtonUI b = Instantiate(button, container);                
               // b.Init(id, Select, Data.Instance.texts.Get(data.name));
                buttons.Add(b);
                id++;
            }
        }
        public void Select(int id)
        {
            foreach (ButtonUI b in buttons)
                b.OnSelected(false);
            foreach (ListItemData data in all)
                data.content.SetActive(false);

            buttons[id].OnSelected(true);
            all[id].content.SetActive(true);
        }
    }
}