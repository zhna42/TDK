using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Track_Data_Card.lib.export;
using Track_Data_Card.lib.lib;
using Track_Data_Card.lib.lib.file;
using Track_Data_Card.lib.settings;

namespace Track_Data_Card.lib
{
    class Export
    {
        public Label label_pathOpen { get; set; }
        public ComboBox comboBox_name_search { get; set; }
        public TextBox textBox_name_search { get; set; }

        public ListView list_name_main { get; set; }
        public TextBox textBox_artist { get; set; }
        public TextBox textBox_title { get; set; }
        public TextBox textBox_album { get; set; }
        public TextBox textBox_genre { get; set; }
        public TextBox textBox_albumArtist { get; set; }
        public ComboBox comboBox_name_version { get; set; }
        public ComboBox comboBox_name_category { get; set; }
        public TextBox textBox_year { get; set; }

        public CheckBox checkBox_name_deleteAfterOnly { get; set; }
        public CheckBox checkBox_name_deleteAfter { get; set; }

        public PopupPreloader popup { get; set; }
        public Settings settings { get; set; }
        //Слушателе list_main
        public int listSelectId;
        public void list_main()
        {
            try
            {
                int id = listViewSelectedItems(list_name_main);
                listSelectId = id;
                AudioFiles af = files.mainCopy[id];
                textBox_artist.Text = af.artist;
                textBox_title.Text = af.title;
                textBox_album.Text = af.album;
                textBox_genre.Text = af.genre;
                textBox_albumArtist.Text = af.albumArtist;
                textBox_year.Text = af.year;

                comboBox_name_version.SelectedValue = af.version;
                comboBox_name_category.SelectedValue = af.category;
                setInputIsCapsLock(isCaps);
            }
            catch { }
            
        }
        public string isStr = "";
        public void textBox_search()
        {
            files.mainCopy = new List<AudioFiles>();
            foreach (AudioFiles element in files.main)
            {
                switch (isStr)
                {
                    case "Artist":
                        if (element.artist.StartsWith(textBox_name_search.Text))
                            files.mainCopy.Add(element);
                        break;
                    case "Title":
                        if (element.title.StartsWith(textBox_name_search.Text))
                            files.mainCopy.Add(element);
                        break;
                    case "Album":
                        if (element.album.StartsWith(textBox_name_search.Text))
                            files.mainCopy.Add(element);
                        break;
                    case "Genre":
                        if (element.genre.StartsWith(textBox_name_search.Text))
                            files.mainCopy.Add(element);
                        break;
                    case "Album Artist":
                        if (element.albumArtist.StartsWith(textBox_name_search.Text))
                            files.mainCopy.Add(element);
                        break;
                    case "Year":
                        if (element.year.StartsWith(textBox_name_search.Text))
                            files.mainCopy.Add(element);
                        break;
                }
            }
            list_name_main.ItemsSource = files.mainCopy;
            list_name_main.Items.Refresh();
        }

        //Старт работы 
        //Добавить окно ожидания 
        public LoadFiles files { get; set; }
        public EditFiles editFiles { get; set; }

        public void button_editSelection()
        {
            try
            {
                Console.WriteLine("------------------");
                List<int> listSelected = new List<int>();
                for(int i=0; i<= list_name_main.SelectedItems.Count-1; i++)
                {
                    listSelected.Add(list_name_main.Items.IndexOf(list_name_main.SelectedItems[i]));
                }
                
                EditSelectionWindow esw = new EditSelectionWindow(listSelected, files.main, files.mainCopy);
                

                List<string> cbeVersionList = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "09", "10" };
                ComboBoxElements cbeVersion = new ComboBoxElements() { bindComboSearch = cbeVersionList };
                esw.version.DataContext = cbeVersion;

                List<string> cbeCategoryList = new List<string>();
                foreach (DataSettings ds in settings.editSettings.setElementsListView.data)
                    cbeCategoryList.Add(ds.name);
                ComboBoxElements cbeCategory = new ComboBoxElements() { bindComboSearch = cbeCategoryList };
                esw.category.DataContext = cbeCategory;
                esw.ShowDialog();
                list_name_main.Items.Refresh();
            }
            catch
            {
            }
        }

        public void button_refresh()
        {
            popup.displayBlock("Refresh ...");
            files = new LoadFiles();
            files.load(label_pathOpen.Content.ToString());
            editFiles = new EditFiles();
            editFiles.main = files.main;
            editFiles.startEdit();
            files.copy();
            list_name_main.ItemsSource = files.mainCopy;
            list_name_main.Items.Refresh();
            popup.displayNan();
        }
        public void button_openPath()
        {
            popup.displayBlock("Loading file ...");
            OpenPath op = new OpenPath();
            string path = op.open();
            if (path != "")
            {
                label_pathOpen.Content = path;
                files = new LoadFiles();
                files.load(label_pathOpen.Content.ToString());
                editFiles = new EditFiles();
                editFiles.main = files.main;
                editFiles.startEdit();
                files.copy();
                list_name_main.ItemsSource = files.mainCopy;
                list_name_main.Items.Refresh();
                //подготовим комбобоксы взяв инфу из настроек
                List<string> cbeVersionList = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "09", "10" };
                ComboBoxElements cbeVersion = new ComboBoxElements() { bindComboSearch = cbeVersionList };
                comboBox_name_version.DataContext = cbeVersion;

                List<string> cbeCategoryList = new List<string>();
                cbeCategoryList.Add("");
                foreach (DataSettings ds in settings.editSettings.setElementsListView.data)
                    cbeCategoryList.Add(ds.name);
                ComboBoxElements cbeCategory = new ComboBoxElements() { bindComboSearch = cbeCategoryList };
                comboBox_name_category.DataContext = cbeCategory;

                //комбо для поиска
                List<string> cbeSList = new List<string>() { "Artist", "Title", "Album", "Genre", "Album Artist", "Year"};
                ComboBoxElements cbeS = new ComboBoxElements() { bindComboSearch = cbeSList };
                comboBox_name_search.DataContext = cbeS;
            }
            popup.displayNan();
        }
       

        public void button_exportAll()
        {
            popup.displayBlock("Please wait ...");
            ExportFile ef = new ExportFile();
            ef.settings = settings;
            ef.filesExport = files.mainCopy;
            ef.LoadFiles();
            List<AudioFiles> afDelete = ef.exportAll();

            
            //bool isDelete = false; bool isDeleteOnlyProgram = false;
            if (isDelete)
            {
                foreach (AudioFiles element in afDelete)//listSelectId
                    File.Delete(element.path);
                foreach (AudioFiles element in afDelete)
                {
                    files.mainCopy.Remove(element);
                    files.main.Remove(element);
                }
                int i = 0;
                foreach (AudioFiles element in files.main)
                {
                    element.id = i;
                    i++;
                }
                list_name_main.ItemsSource = files.mainCopy;
                list_name_main.Items.Refresh();
            }
            if (isDeleteOnlyProgram && isDelete != true)
            {
                foreach (AudioFiles element in afDelete)
                {
                    files.mainCopy.Remove(element);
                    files.main.Remove(element);
                }
                int i = 0;
                foreach (AudioFiles element in files.main)
                {
                    element.id = i;
                    i++;
                }
                list_name_main.ItemsSource = files.mainCopy;
                list_name_main.Items.Refresh();
            }
            popup.displayNan();

            checkBox_name_deleteAfterOnly.IsChecked = false;
            checkBox_name_deleteAfter.IsChecked = false;
            isDelete = false;
            isDeleteOnlyProgram = false;
        }
        public void button_export()
        {
            popup.displayBlock("Please wait ...");
            ExportFile ef = new ExportFile();
            ef.settings = settings;
            ef.filesExport = files.main;
            ef.LoadFiles();
            ef.exportOne(listSelectId);
            popup.displayNan();
        }
        public void button_capsLockAll()/////////////////////////////////////////////////////////////////////////
        {
            popup.displayBlock("Please wait ...");
            foreach (AudioFiles element in files.main)
            {
                if(element.artist != element.artist.ToUpper() ||
                    element.title != element.title.ToUpper() ||
                element.album != element.album.ToUpper() ||
                element.genre != element.genre.ToUpper() ||
                element.albumArtist != element.albumArtist.ToUpper())
                {
                    element.artist = element.artist.ToUpper();
                    element.title = element.title.ToUpper();
                    element.album = element.album.ToUpper();
                    element.genre = element.genre.ToUpper();
                    element.albumArtist = element.albumArtist.ToUpper();
                    element.tegs.Save();
                }
            }
            foreach (AudioFiles element in files.mainCopy)
            {
                element.artist = element.artist.ToUpper();
                element.title = element.title.ToUpper();
                element.album = element.album.ToUpper();
                element.genre = element.genre.ToUpper();
                element.albumArtist = element.albumArtist.ToUpper();
            }
            list_name_main.Items.Refresh();
            popup.displayNan();
        }
        public void comboBox_search()
        {
            Object objSearch = comboBox_name_search.SelectedItem;
            if (objSearch != null)
                isStr = objSearch.ToString();
        }
        bool isDelete = false;
        public void checkBox_deleteAfter()
        {
            isDelete = !isDelete;
        }
        bool isDeleteOnlyProgram = false;
        public void checkBox_deleteAfterOnly()
        {
            isDeleteOnlyProgram = !isDeleteOnlyProgram;
        }
        public void comboBox_version()
        {
            Console.WriteLine("Click export");
        }
        public void comboBox_category()
        {
            Console.WriteLine("Click export");
        }
        public void button_save()
        {
            /*AudioFiles afCopy = files.mainCopy[listSelectId].id;
            int afId = afCopy.id;
            //save(afCopy);
            Console.WriteLine(afId);*/
            AudioFiles afMain = files.main[files.mainCopy[listSelectId].id];
            save(afMain);
            list_name_main.Items.Refresh();
        }
        public void save(AudioFiles af)
        {
            af.artist = textBox_artist.Text;
            af.title = textBox_title.Text;
            af.album = textBox_album.Text;
            af.genre = textBox_genre.Text;
            af.albumArtist = textBox_albumArtist.Text;
            af.yearInt = Convert.ToUInt32(textBox_year.Text, 10);
            
            Object objVersion = comboBox_name_version.SelectedItem;
            Object objCategory = comboBox_name_category.SelectedItem;
            if (objVersion != null)
                af.version = objVersion.ToString();
            if (objCategory != null)
                af.category = objCategory.ToString();
            af.tegs.Save();
        }
        
        public void button_delete()
        {
            //foreach (AudioFiles element in afDelete)//listSelectId
            try
            {
                File.Delete(files.mainCopy[listSelectId].path);

                //File.Delete(files.main[listSelectId].path);
                files.main.Remove(files.mainCopy[listSelectId]);
                files.mainCopy.Remove(files.mainCopy[listSelectId]);
                int i = 0;
                foreach (AudioFiles element in files.main)
                {
                    element.id = i;                    
                    i++;
                }
                foreach (AudioFiles element in files.mainCopy)
                    element.id = files.main.Find(x => x == element).id;

                list_name_main.ItemsSource = files.mainCopy;
                list_name_main.Items.Refresh();
            }
            catch
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "Not file";
                windowWarning.ShowDialog();
            }
            
        }
        public bool isCaps = false;
        public void сheckBox_capsLock()
        {
            isCaps = !isCaps;
            setInputIsCapsLock(isCaps);
        }

        //вспомогательные методы
        private void toCapsLock()
        {
            textBox_artist.Text = textBox_artist.Text.ToUpper();
            textBox_title.Text = textBox_title.Text.ToUpper();
            textBox_album.Text = textBox_album.Text.ToUpper();
            textBox_genre.Text = textBox_genre.Text.ToUpper();
            textBox_albumArtist.Text = textBox_albumArtist.Text.ToUpper();
        }
        private void setInputIsCapsLock(bool isCaps)
        {
            if (isCaps)
            {
                textBox_artist.CharacterCasing = CharacterCasing.Upper;
                textBox_title.CharacterCasing = CharacterCasing.Upper;
                textBox_album.CharacterCasing = CharacterCasing.Upper;
                textBox_genre.CharacterCasing = CharacterCasing.Upper;
                textBox_albumArtist.CharacterCasing = CharacterCasing.Upper;
                toCapsLock();
            }
            else
            {
                textBox_artist.CharacterCasing = CharacterCasing.Normal;
                textBox_title.CharacterCasing = CharacterCasing.Normal;
                textBox_album.CharacterCasing = CharacterCasing.Normal;
                textBox_genre.CharacterCasing = CharacterCasing.Normal;
                textBox_albumArtist.CharacterCasing = CharacterCasing.Normal;
            }
        }

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
