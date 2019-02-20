using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Track_Data_Card.lib.lib;

namespace Track_Data_Card.lib.settings
{
    class EditSettingJson
    {
        public SettingsJson settings { set; get; }
        public DataJson setElementsListView { set; get; } //текущий элемент для отображения

        public ComboBoxElements cbe() //станавливает все элементы комбоБокса
        {
            List<string> comboBoxList = new List<string>();
            foreach (DataJson element in settings.json.data)
                comboBoxList.Add(element.nameSettings);
            return new ComboBoxElements() { bindComboSearch = comboBoxList };
        }

        public bool addNew(string str)
        {
            bool isStr = true;
            foreach (DataJson element in settings.json.data)
            {
                if(element.nameSettings == str)
                    isStr = false;
            }
            if(isStr)
            {
                List<DataSettings> Lds = new List<DataSettings>();
                DataSettings ds = new DataSettings{
                    name = "MAIN",
                    prefix = "A",
                    path = "D:/",
                    startNumber = "A000"
                };
                Lds.Add(ds);
                DataJson dj = new DataJson
                {
                    nameSettings = str,
                    data = Lds
                };
                settings.json.data.Add(dj);
                settings.json.name = str;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void deleteSettings()
        {
            //возможно добавить проверку на длинну и запрт удаления последнего элемента
            try
            {
                settings.json.data.Remove(setElementsListView);
                setElementsListView = settings.json.data[0];
                settings.json.name = settings.json.data[0].nameSettings;
            }
            catch
            {
                setElementsListView = new DataJson();
            }
            
        }

        public void delete(int id)
        {
            setElementsListView.data.Remove(setElementsListView.data[id]);
        }

        public bool addNewElement(DataSettings element)
        {
            if (element.path != "" && element.prefix != "" && element.name != "" && element.startNumber != "")
            {
                int isElementName = setElementsListView.data.FindIndex(x => x.name == element.name);
                int isElementPrefix = setElementsListView.data.FindIndex(x => x.prefix == element.prefix);
                int isElementPath = setElementsListView.data.FindIndex(x => x.path == element.path);
                if (isElementName == -1 && isElementPrefix == -1 && isElementPath == -1)
                {
                    setElementsListView.data.Add(element);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            } 
        }

        public bool editElement(DataSettings element, int id)
        {
            Console.WriteLine(id);
            int isElementName = setElementsListView.data.FindIndex(x => x.name == element.name);
            int isElementPrefix = setElementsListView.data.FindIndex(x => x.prefix == element.prefix);
            int i = 0;
            bool isElement = true;
            foreach (DataSettings el in setElementsListView.data)
            {
                if(i != id && (el.name == element.name || el.prefix == element.prefix || el.path == element.path))
                {
                    isElement = false;
                    Console.WriteLine(id + " - " + i);
                }
                    
                i++;
            }
            if (isElement && element.path != "" && element.prefix != "" && element.name != "" && element.startNumber != "")
            {
                setElementsListView.data[id].name = element.name;
                setElementsListView.data[id].prefix = element.prefix;
                setElementsListView.data[id].path = element.path;
                setElementsListView.data[id].startNumber = element.startNumber;
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
