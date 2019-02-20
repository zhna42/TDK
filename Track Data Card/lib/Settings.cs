using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Track_Data_Card.lib.lib;
using Track_Data_Card.lib.settings;

namespace Track_Data_Card.lib
{
    class Settings
    {
        public SettingsJson settings { get; set; }
        public EditSettingJson editSettings { get; set; }
        //List<DataJson> Settings.editSettings.setElementsListView.data текущие настройки
        //

        //объекты редакторования 
        public TextBox textBox_newSettingsName { get; set; }
        public TextBox textBox_name { get; set; }
        public TextBox textBox_prefix { get; set; }
        public TextBox textBox_startNumber { get; set; }
        public Label label_openPath { get; set; }
        public ComboBox comboBox_name_name { get; set; }
        public ListView name_list { get; set; }
        //Слушателе
        
        public void init()
        {
            settings = new SettingsJson();
            editSettings = new EditSettingJson();
            settings.read(); //читаем json
            editSettings.settings = settings;
            comboBox_name_name.DataContext = editSettings.cbe();//вернет эелементы для comboBox
            comboBox_name_name.SelectedValue = settings.json.name;//начальный элемент для comboBox
            if(settings.json.name != "")
            {
                editSettings.setElementsListView = settings.json.data.Find(x => x.nameSettings == settings.json.name);
                name_list.ItemsSource = editSettings.setElementsListView.data; //текущий список
                name_list.Items.Refresh();
            }
        }

        public void list()
        {
            try
            {
                int id = listViewSelectedItems(name_list);
                DataJson dataListView = editSettings.setElementsListView;
                textBox_name.Text = dataListView.data[id].name;
                textBox_prefix.Text = dataListView.data[id].prefix;
                label_openPath.Content = dataListView.data[id].path;
                textBox_startNumber.Text = dataListView.data[id].startNumber;
            }
            catch { }
            
        }
        public void button_addNewSettings() 
        {
            //Добавить окно с предупри что рабочие листы будут очищены
            if (editSettings.addNew(textBox_newSettingsName.Text))
            {
                comboBox_name_name.DataContext = editSettings.cbe();//вернет эелементы для comboBox
                comboBox_name_name.SelectedValue = settings.json.name;
            }
            else
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "Name settings must be unique";
                windowWarning.ShowDialog();
            }
        }
        public void button_saveAllSettings()
        {
            settings.record();
        }
        public void button_openPath()
        {
            OpenPath op = new OpenPath();
            string path = op.open();
            if (path != "")
                label_openPath.Content = path;
        }
        public void button_edit()
        {
            //Добавить окно с предупри что рабочие листы будут очищены
            int id = listViewSelectedItems(name_list);
            DataSettings ds = new DataSettings
            {
                name = textBox_name.Text,
                prefix = textBox_prefix.Text,
                path = label_openPath.Content.ToString(),
                startNumber = textBox_startNumber.Text
            };
            if (editSettings.editElement(ds, id))
                name_list.Items.Refresh();
            else
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "Name, name, prefix must be unique";
                windowWarning.ShowDialog();
            }
        }
        public void button_addNewElement()
        {
            DataSettings ds = new DataSettings
            {
                name = textBox_name.Text,
                prefix = textBox_prefix.Text,
                path = label_openPath.Content.ToString(),
                startNumber = textBox_startNumber.Text
            };
            if (editSettings.addNewElement(ds))
                name_list.Items.Refresh();
            else
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "Name, name, prefix must be unique";
                windowWarning.ShowDialog();
            }
        }

        public void comboBox_name()
        {
            //Добавить окно с предупри что рабочие листы будут очищены
            try
            {
                Object selectedItem = comboBox_name_name.SelectedItem;
                settings.json.name = selectedItem.ToString();
                editSettings.setElementsListView = settings.json.data.Find(x => x.nameSettings == settings.json.name);
                name_list.ItemsSource = editSettings.setElementsListView.data; //текущий список
                name_list.Items.Refresh();
            }catch{}
        }
        public void button_delete()
        {
            //Добавить окно с предупри что рабочие листы будут очищены
            int id = listViewSelectedItems(name_list);
            editSettings.delete(id);
            name_list.Items.Refresh();
        }
        public void button_deleteSettings()
        {
            //Добавить окно с предупри что рабочие листы будут очищены
            editSettings.deleteSettings();
            name_list.ItemsSource = editSettings.setElementsListView.data; //текущий список
            name_list.Items.Refresh();
            comboBox_name_name.DataContext = editSettings.cbe();//вернет эелементы для comboBox
            comboBox_name_name.SelectedValue = settings.json.name;
        }
        
        //Вспомогательные методы
        private int listViewSelectedItems(ListView list)
        {
            try
            {
                int id = list.Items.IndexOf(list.SelectedItems[0]);
                if (id >= 0)
                    return id;
                else
                    return 0;
            }
            catch
            {
                return 0;
            }
        }
    }
}
