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

        [SerializeField] ButtonCustom button;
        List<ButtonCustom> buttons;

        [SerializeField] Transform container;

        public void Init()
        {
            SetButtons();
            Select(0);
        }
        public void SetButtons()
        {
            buttons = new List<ButtonCustom>();
            Utils.RemoveAllChildsIn(container);
            int id = 0;
            foreach (ListItemData data in all)
            {
                ButtonCustom b = Instantiate(button, container);                
               // b.Init(id, Select, Data.Instance.texts.Get(data.name));
                buttons.Add(b);
                id++;
            }
        }
        public void Select(int id)
        {
            foreach (ButtonCustom b in buttons)
                b.OnSelected(false);
            foreach (ListItemData data in all)
                data.content.SetActive(false);

            buttons[id].OnSelected(true);
            all[id].content.SetActive(true);
        }
    }
}