using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Track_Data_Card.lib;

namespace Track_Data_Card
{
    public partial class MainWindow : Window
    {
        Settings settings;
        Export export;
        Base baseTab;
        public MainWindow()
        {
            InitializeComponent();
            

            settings = new Settings()
            {
                textBox_newSettingsName = settings_textBox_newSettingsName,
                textBox_name = settings_textBox_name,
                textBox_prefix = settings_textBox_prefix,
                textBox_startNumber = settings_textBox_startNumber,
                label_openPath = settings_label_openPath,
                comboBox_name_name = settings_comboBox_name_name,
                name_list = settings_name_list
            };
            settings.init();
            PopupPreloader popup = new PopupPreloader();
            popup.popup = popup_preloader;
            popup.label = popup_preloader_label;
            export = new Export()
            {
                label_pathOpen = export_label_pathOpen,
                comboBox_name_search = export_comboBox_name_search,
                textBox_name_search = export_textBox_name_search,

                list_name_main = export_list_name_main,
                textBox_artist = export_textBox_artist,
                textBox_title = export_textBox_title,
                textBox_album = export_textBox_album,
                textBox_genre = export_textBox_genre,
                textBox_albumArtist = export_textBox_albumArtist,
                comboBox_name_version = export_comboBox_name_version,
                comboBox_name_category = export_comboBox_name_category,
                textBox_year = export_textBox_year,

                popup = popup,
                settings = settings,

                checkBox_name_deleteAfterOnly = export_checkBox_name_deleteAfterOnly,
                checkBox_name_deleteAfter = export_checkBox_name_deleteAfter
            };
            //export.init();

            baseTab = new Base()
            {
                list_name_main = base_list_name_main,
                label_id = base_label_id,
                textBox_artist = base_textBox_artist,
                textBox_title = base_textBox_title,
                textBox_album = base_textBox_album,
                textBox_genre = base_textBox_genre,
                textBox_albumArtist = base_textBox_albumArtist,
                textBox_year = base_textBox_year,
                textBox_name_search = base_textBox_name_search,
                comboBox_version = base_comboBox_version,
                comboBox_name_categoryExport = base_comboBox_name_categoryExport,
                comboBox_name_search = base_comboBox_name_search,
                comboBox_name_category = base_comboBox_name_category,
                popup = popup,
                settings = settings
            };
            baseTab.init();

            
        }
        //export 
        private void export_button_openPath(object sender, RoutedEventArgs e) => export.button_openPath();
        private void export_button_exportAll(object sender, RoutedEventArgs e) => export.button_exportAll();
        private void export_button_capsLockAll(object sender, RoutedEventArgs e) => export.button_capsLockAll();
        private void export_comboBox_search(object sender, SelectionChangedEventArgs e) => export.comboBox_search();
        private void export_textBox_search(object sender, KeyEventArgs e) => export.textBox_search();
        private void export_checkBox_deleteAfter(object sender, RoutedEventArgs e) => export.checkBox_deleteAfter();
        private void export_checkBox_deleteAfterOnly(object sender, RoutedEventArgs e) => export.checkBox_deleteAfterOnly();
        private void export_list_main(object sender, SelectionChangedEventArgs e) => export.list_main();
        private void export_button_save(object sender, RoutedEventArgs e) => export.button_save();
        private void export_button_export(object sender, RoutedEventArgs e) => export.button_export();
        private void export_button_delete(object sender, RoutedEventArgs e) => export.button_delete();
        private void export_button_refresh(object sender, RoutedEventArgs e) => export.button_refresh();
        private void export_button_editSelection(object sender, RoutedEventArgs e) => export.button_editSelection();
        private void export_сheckBox_capsLock(object sender, RoutedEventArgs e) => export.сheckBox_capsLock();

        //base baseTab
        private void base_comboBox_search(object sender, SelectionChangedEventArgs e) => baseTab.comboBox_search();
        private void base_comboBox_category(object sender, SelectionChangedEventArgs e) => baseTab.comboBox_category();
        private void base_textBox_search(object sender, KeyEventArgs e) => baseTab.textBox_search();
        private void base_list_main(object sender, SelectionChangedEventArgs e) => baseTab.list_main();
        private void base_button_export(object sender, RoutedEventArgs e) => baseTab.button_export();
        private void base_button_refresh(object sender, RoutedEventArgs e) => baseTab.button_refresh();
        private void base_button_delete(object sender, RoutedEventArgs e) => baseTab.button_delete();
        private void base_button_save(object sender, RoutedEventArgs e) => baseTab.button_save();
        private void base_сheckBox_capsLock(object sender, RoutedEventArgs e) => baseTab.сheckBox_capsLock();

        //settings
        private void settings_comboBox_name(object sender, SelectionChangedEventArgs e) => settings.comboBox_name();
        private void settings_button_addNewSettings(object sender, RoutedEventArgs e) => settings.button_addNewSettings();
        private void settings_button_delete(object sender, RoutedEventArgs e) => settings.button_delete();
        private void settings_button_deleteSettings(object sender, RoutedEventArgs e) => settings.button_deleteSettings();
        private void settings_button_saveAllSettings(object sender, RoutedEventArgs e) => settings.button_saveAllSettings();
        private void settings_button_openPath(object sender, RoutedEventArgs e) => settings.button_openPath();
        private void settings_button_edit(object sender, RoutedEventArgs e) => settings.button_edit();
        private void settings_button_addNewElement(object sender, RoutedEventArgs e) => settings.button_addNewElement();
        private void settings_list(object sender, SelectionChangedEventArgs e) => settings.list();

        
        private void mainWinBtn(object sender, KeyEventArgs e)
        {
            if(e.Key.ToString() == "Escape")
            {
                this.WindowState = WindowState.Normal;
                full_name.Content = "Full";
                isFull = true;
            }
        }
        //методы - окна 
        private void move_window(object sender, MouseButtonEventArgs e)//передвижение окна
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }
        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //full
        public bool isFull = true;
        private void full(object sender, RoutedEventArgs e)
        {
            this.MaxWidth = System.Windows.SystemParameters.PrimaryScreenWidth+15;
            this.MaxHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            if (isFull)
            {
                this.WindowState = WindowState.Maximized;
                full_name.Content = "Normal";
            }
            else
            {
                this.WindowState = WindowState.Normal;
                full_name.Content = "Full";
            }
            isFull = !isFull;
        }
    }
}
