using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Track_Data_Card.lib.export;

namespace Track_Data_Card.lib.lib
{
    class LoadFiles
    {
        public List<AudioFiles> main { get; set; }
        public List<AudioFiles> mainCopy { get; set; }


        public bool isErrFile { get; set; }
        public List<string> isErrFileName { get; set; }

        public void copy()
        {
            mainCopy = new List<AudioFiles>();
            foreach (AudioFiles element in main)
                mainCopy.Add(element);
        }

        public void updateNameFile()
        {
            foreach (AudioFiles element in main)
            {
                string[] parts = element.fileName.Split('-');
                element.fileName = parts[0];
                element.version = parts[1];
            }
        }

        public void load(string pathLoad)
        {
            string[] files = Directory.GetFiles(pathLoad, "*");
            if (files.Length >= 0)
            {
                main = new List<AudioFiles>();
                int id = 0;
                isErrFile = false;
                foreach (string path in files)
                {
                    string fileName = Path.GetFileNameWithoutExtension(path);
                    string ext = Path.GetExtension(path);
                    if (ext == ".mp3" || ext == ".wav")
                    {
                        try
                        {
                            var tegs = TagLib.File.Create(path);
                            AudioFiles tegsAudio = new AudioFiles
                            {
                                id = id,
                                fileName = fileName,
                                ext = ext,
                                path = path,
                                tegs = tegs
                            };
                            main.Add(tegsAudio);
                            id++;
                        }
                        catch
                        {
                            //если ошибка загрузки 
                            isErrFile = true;
                            isErrFileName.Add(fileName);
                        }
                    }
                }
                //Загрузка успешна
            }
            else
            {
                WindowWarning windowWarning = new WindowWarning();
                windowWarning.warning_text.Content = "Catalog is empty";
                windowWarning.ShowDialog();
                //католог пуст
            }
        }
    }
}
