using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Track_Data_Card.lib.export;
using Track_Data_Card.lib.lib;
using Track_Data_Card.lib.lib.file;
using Track_Data_Card.lib.settings;

namespace Track_Data_Card.lib
{
    class Base
    {
        public ListView list_name_main { get; set; }
        public Label label_id { get; set; }
        public TextBox textBox_artist { get; set; }
        public TextBox textBox_title { get; set; }
        public TextBox textBox_album { get; set; }
        public TextBox textBox_genre { get; set; }
        public TextBox textBox_albumArtist { get; set; }
        public TextBox textBox_year { get; set; }
        public TextBox textBox_name_search { get; set; }
        
        public ComboBox comboBox_version { get; set; }
        public ComboBox comboBox_name_search { get; set; }
        public ComboBox comboBox_name_category { get; set; }
        public ComboBox comboBox_name_categoryExport { get; set; }

        public PopupPreloader popup { get; set; }
        public Settings settings { get; set; }

        public List<LoadFiles> files { get; set; }
        public List<string> cbeCategoryList;
        public void init()
        {
            List<string> cbeVersionList = new List<string>() { "01", "02", "03", "04", "05", "06", "07", "09", "10" };
            ComboBoxElements cbeVersion = new ComboBoxElements() { bindComboSearch = cbeVersionList };
            comboBox_version.DataContext = cbeVersion;

            List<string> cbeSList = new List<string>() { "Artist", "Title", "Album", "Genre", "Album Artist", "Year" };
            ComboBoxElements cbeS = new ComboBoxElements() { bindComboSearch = cbeSList };
            comboBox_name_search.DataContext = cbeS;

            loadAll();
            comboBox_name_category.SelectedValue = cbeCategoryList[0];
            setList();
        }
        public int idList;
        public void setList()
        {
            Object objCategory = comboBox_name_category.SelectedItem;
            if (objCategory != null)
            {
                idList = settings.editSettings.setElementsListView.data.FindIndex(x => x.name == objCategory.ToString());
                if(idList != -1)
                {
                    list_name_main.ItemsSource = files[idList].mainCopy; ;
                    list_name_main.Items.Refresh();
                }
            }
        }
        public void loadAll()
        {
            popup.displayBlock("Please wait ...");
            files = new List<LoadFiles>();
            cbeCategoryList = new List<string>();
            foreach (DataSettings ds in settings.editSettings.setElementsListView.data)
            {
                cbeCategoryList.Add(ds.name); //категории для комбобокса
                //читаем все папки
                LoadFiles fl = new LoadFiles();
                fl.load(ds.path);
                fl.updateNameFile();
                fl.copy();
                files.Add(fl);
            }
            //устанавливаем значения для комбобокса
            ComboBoxElements cbeCategory = new ComboBoxElements() { bindComboSearch = cbeCategoryList };
            comboBox_name_category.DataContext = cbeCategory;

            comboBox_name_categoryExport.DataContext = cbeCategory;
            popup.displayNan();
        }

        

        public int listSelectId;
        public void list_main()
        {
            try
            {
                int id = listViewSelectedItems(list_name_main);
                listSelectId = id;
                Console.WriteLine(listSelectId);
                AudioFiles af = files[idList].mainCopy[id];
                textBox_artist.Text = af.artist;
                textBox_title.Text = af.title;
                textBox_album.Text = af.album;
                textBox_genre.Text = af.genre;
                textBox_albumArtist.Text = af.albumArtist;
                textBox_year.Text = af.year;
                label_id.Content = af.fileName;

                comboBox_version.SelectedValue = af.version;
                setInputIsCapsLock(isCaps);
            }
            catch { }
        }
        public void button_export()
        {
            ExportFile ef = new ExportFile();

            Object objVersion = comboBox_name_categoryExport.SelectedItem;
            if(objVersion != null)
            {
                files[idList].main[listSelectId].category = objVersion.ToString();
            }
            ef.settings = settings;
            ef.filesExport = files[idList].main;
            ef.LoadFiles();

            ef.exportOne(listSelectId);
        }
        public void button_delete()
        {
            try
            {
                File.Delete(files[idList].mainCopy[listSelectId].path);

                //File.Delete(files.main[listSelectId].path);
                files[idList].main.Remove(files[idList].mainCopy[listSelectId]);
                files[idList].mainCopy.Remove(files[idList].mainCopy[listSelectId]);
                int i = 0;
                foreach (AudioFiles element in files[idList].main)
                {
                    element.id = i;
                    i++;
                }
                foreach (AudioFiles element in files[idList].mainCopy)
                    element.id = files[idList].main.Find(x => x == element).id;

                list_name_main.ItemsSource = files[idList].mainCopy;
                list_name_main.Items.Refresh();
            }
            catch
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "Not file";
                windowWarning.ShowDialog();
            }
        }
        public void button_save()
        {
            AudioFiles afMain = files[idList].main[files[idList].mainCopy[listSelectId].id];

            Object objVersion = comboBox_version.SelectedItem;
            bool isFileIs = true;
            foreach (AudioFiles element in files[idList].main)
            {
                if (element.artist == textBox_artist.Text &&
                    element.title == textBox_title.Text &&
                    element.album == textBox_album.Text &&
                    element.genre == textBox_genre.Text &&
                    element.albumArtist == textBox_albumArtist.Text &&
                    element.year == textBox_year.Text && element.version == objVersion.ToString())
                    isFileIs = false;
            }
            if (isFileIs)
            {
                save(afMain);
                list_name_main.Items.Refresh();
            }
            else
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "File already exists";
                windowWarning.ShowDialog();
            }
        }
        public void save(AudioFiles af)
        {
            af.artist = textBox_artist.Text;
            af.title = textBox_title.Text;
            af.album = textBox_album.Text;
            af.genre = textBox_genre.Text;
            af.albumArtist = textBox_albumArtist.Text;
            af.yearInt = Convert.ToUInt32(textBox_year.Text, 10);
            Object objVersion = comboBox_version.SelectedItem;
            if (objVersion != null)
                af.version = objVersion.ToString();
            af.tegs.Save();
            File.Move(af.path, Path.GetDirectoryName(af.path) + "\\" + af.fileName +"-"+ af.version + af.ext);

            loadAll();
            setList();
        }

        public bool isCaps;
        public void сheckBox_capsLock()
        {
            isCaps =! isCaps;
            setInputIsCapsLock(isCaps);
        }
        public void comboBox_search()
        {
            Object objSearch = comboBox_name_search.SelectedItem;
            if (objSearch != null)
                isStr = objSearch.ToString();
        }
        public void comboBox_category()
        {
            setList();
        }
        public string isStr = "";
        public void textBox_search()
        {
            files[idList].mainCopy = new List<AudioFiles>();
            foreach (AudioFiles element in files[idList].main)
            {
                switch (isStr)
                {
                    case "Artist":
                        if (element.artist.StartsWith(textBox_name_search.Text))
                            files[idList].mainCopy.Add(element);
                        break;
                    case "Title":
                        if (element.title.StartsWith(textBox_name_search.Text))
                            files[idList].mainCopy.Add(element);
                        break;
                    case "Album":
                        if (element.album.StartsWith(textBox_name_search.Text))
                            files[idList].mainCopy.Add(element);
                        break;
                    case "Genre":
                        if (element.genre.StartsWith(textBox_name_search.Text))
                            files[idList].mainCopy.Add(element);
                        break;
                    case "Album Artist":
                        if (element.albumArtist.StartsWith(textBox_name_search.Text))
                            files[idList].mainCopy.Add(element);
                        break;
                    case "Year":
                        if (element.year.StartsWith(textBox_name_search.Text))
                            files[idList].mainCopy.Add(element);
                        break;
                }
            }
            list_name_main.ItemsSource = files[idList].mainCopy;
            list_name_main.Items.Refresh();
        }
        public void button_refresh()
        {
            loadAll();
            setList();
        }

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
