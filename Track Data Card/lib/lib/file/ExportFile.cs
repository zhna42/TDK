using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Track_Data_Card.lib.export;
using Track_Data_Card.lib.settings;

namespace Track_Data_Card.lib.lib.file
{
    class ExportFile
    {
        public List<LoadFiles> files { get; set; }
        public Settings settings { get; set; }

        public List<AudioFiles> filesExport { get; set; }
        public bool isDelete { get; set; }//додлеать удаление
        List<DataSettings> ds;
        public void LoadFiles()//загружаем все файлы из директорий экспорта
        {
            files = new List<LoadFiles>();
            ds = settings.editSettings.setElementsListView.data; //берем эти данные токо при копировании
            foreach(DataSettings path in ds)
            {
                LoadFiles lf = new LoadFiles();
                lf.load(path.path);
                files.Add(lf);
            }
        }

        public List<AudioFiles> exportAll()
        {
            ParserName parser = new ParserName();
            //filesExport //Что экспортить
            filesNumber();//получаем пропущеные элементы
            bool isExportAllFiles = false;
            bool isExportAllFiles2 = false;

            //удалени
            List<AudioFiles> deleteFiles = new List<AudioFiles>();
            //exportFile текущий файл для экспорта 

            foreach (AudioFiles exportFile in filesExport)
            {
                DataSettings dataSet = ds.Find(x => x.name == exportFile.category);//путь и категория для экспорта 
                int idCategory = ds.FindIndex(x => x.name == exportFile.category);//id экспорта
                if(idCategory != -1)
                {
                    bool isFile = fileIsFile(files[idCategory], exportFile);
                    if (isFile)
                    {
                        int fileNameInt;
                        if (listNumberName[idCategory].Count > 0)
                        {
                            fileNameInt = listNumberName[idCategory][0];
                        }
                        else
                        {
                            fileNameInt = listNumberMaxName[idCategory];
                        }
                        if (exportFile.version != null)
                        {
                            //
                            bool isFileis = true;
                            string name2 = "";
                            foreach (AudioFiles element in files[idCategory].main)
                            {
                                if (element.artist == exportFile.artist && element.title.Split('(')[0] == exportFile.title.Split('(')[0] && element.album == exportFile.album && element.genre == exportFile.genre && element.albumArtist == exportFile.albumArtist && element.year == exportFile.year)
                                {
                                    isFileis = false;//файл совпадает
                                    name2 = element.fileName;
                                }
                            }

                            if (isFileis)
                            {
                                if (listNumberName[idCategory].Count > 0)
                                    listNumberName[idCategory].Remove(fileNameInt);
                                else
                                    listNumberMaxName[idCategory]++;
                                string nameFile = dataSet.prefix + parser.IntToName(fileNameInt) + "-" + exportFile.version + exportFile.ext;
                                File.Copy(exportFile.path, dataSet.path + "\\" + nameFile);
                                deleteFiles.Add(exportFile);
                                LoadFiles();
                            }
                            else
                            {
                                char[] cF = name2.ToString().ToCharArray();
                                name2 = cF[0].ToString() + cF[1].ToString() + cF[2].ToString() + cF[3].ToString() + cF[4].ToString();
                                //////////////////////////////
                                string nameFile = name2 + "-" + exportFile.version + exportFile.ext;
                                File.Copy(exportFile.path, dataSet.path + "\\" + nameFile);
                                deleteFiles.Add(exportFile);
                                LoadFiles();
                            }
                        }
                        else
                        {
                            isExportAllFiles2 = true; //версия не задана
                        }
                    }
                    else
                    {
                        isExportAllFiles = true;
                        //такой файл уже есть
                    }
                }
                else
                {
                    //категория не задана
                }
            }
            if (isExportAllFiles)
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "Some files match";
                windowWarning.ShowDialog();
            }
            if (isExportAllFiles2)
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "Not all files have a version.";
                windowWarning.ShowDialog();
            }

            //удаление
            return deleteFiles;
        }

        public void exportOne(int idFileExport)
        {
            Console.WriteLine(idFileExport);
            ParserName parser = new ParserName();
            AudioFiles fileExport = filesExport[idFileExport];//Что экспортить
            DataSettings dataSet = ds.Find(x => x.name == fileExport.category);//куда экспортить 
            int idCategory = ds.FindIndex(x => x.name == fileExport.category);//id для экспорта и проверок 
            bool isFile=false;
            if (idCategory != -1)
            {
                LoadFiles testElements = files[idCategory]; //элементы для проверки

                //Узнаем несовпвдвет ли файл
                isFile = fileIsFile(testElements, fileExport);
                //получаем доступные значения для нумерации
                filesNumber();
                //listNumberName[idCategory] лист с доступными намерами
                //listNumberMaxName[idCategory] масимальное значение
                int fileNameInt;
                if (isFile)
                {
                    if (listNumberName[idCategory].Count > 0)
                    {
                        fileNameInt = listNumberName[idCategory][0];
                    }
                    else
                    {
                        fileNameInt = listNumberMaxName[idCategory];
                    }
                    if(fileExport.version != null)
                    {
                        bool isFileis = true;
                        string name2 = "";
                        foreach (AudioFiles element in files[idCategory].main)
                        {
                            if (element.artist == fileExport.artist && element.title.Split('(')[0] == fileExport.title.Split('(')[0] && element.album == fileExport.album && element.genre == fileExport.genre && element.albumArtist == fileExport.albumArtist && element.year == fileExport.year)
                            {
                                isFileis = false;//файл совпадает
                                name2 = element.fileName;
                            }
                        }

                        if (isFileis)
                        {
                            if (listNumberName[idCategory].Count > 0)
                                listNumberName[idCategory].Remove(fileNameInt);
                            else
                                listNumberMaxName[idCategory]++;
                            string nameFile = dataSet.prefix + parser.IntToName(fileNameInt) + "-" + fileExport.version + fileExport.ext;
                            File.Copy(fileExport.path, dataSet.path + "\\" + nameFile);
                        }
                        else
                        {
                            char[] cF = name2.ToString().ToCharArray();
                            name2 = cF[0].ToString() + cF[1].ToString() + cF[2].ToString() + cF[3].ToString() + cF[4].ToString();
                            string nameFile = name2 + "-" + fileExport.version + fileExport.ext;
                            File.Copy(fileExport.path, dataSet.path + "\\" + nameFile);
                        }
                        
                    }
                    else
                    {
                        WindowWarning windowWarning = new WindowWarning();
                        windowWarning.warning_text.Content = "No version selected";
                        windowWarning.ShowDialog();
                    }
                }
                else
                {
                    WindowWarning windowWarning = new WindowWarning();
                    windowWarning.warning_text.Content = "This file already exists";
                    windowWarning.ShowDialog();
                }
            }
            else
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "Category not selected";
                windowWarning.ShowDialog();
            }
            
        }

        //получаем пропущенные цифры для директорий
        public List<int>[] listNumberName; 
        public List<int> listNumberMaxName; 
        public void filesNumber()
        {
            ParserName parser = new ParserName();
            listNumberMaxName = new List<int>();
            listNumberName = new List<int>[ds.Count];
            int ii = 0;
            foreach (LoadFiles element in files)
            {
                listNumberName[ii] = new List<int>();
                int startNumber = parser.NameToInt("0"+ds[ii].startNumber)-1;
                foreach (AudioFiles el in element.main)
                {
                    int num = parser.NameToInt(el.fileName);
                    int isNum = num - startNumber;
                    if (isNum > 1) //значит элемент пропущен и нам надо понять сколько пропустили элементов
                        for (int i = startNumber + 1; i <= num - 1; i++)
                            listNumberName[ii].Add(i);
                    if (num > startNumber)
                        startNumber = num;
                }
                listNumberMaxName.Add(startNumber + 1);
                ii++;
            }
        }

        //Узнаем несовпвдвет ли файл c уже имеющимися в базе
        public bool fileIsFile(LoadFiles lf, AudioFiles fx)
        {
            bool isFile = true;
            foreach (AudioFiles element in lf.main)
            {
                char[] characters = element.fileName.ToCharArray();
                string versionBase = characters[6].ToString() + characters[7].ToString();
                if (element.artist == fx.artist && element.title.Split('(')[0] == fx.title.Split('(')[0] && element.album == fx.album && element.genre == fx.genre && element.albumArtist == fx.albumArtist && element.year == fx.year && versionBase == fx.version)
                    isFile = false;//файл совпадает
            }
            return isFile;
        }

    }
}
