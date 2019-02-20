using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Track_Data_Card.lib.export;

namespace Track_Data_Card.lib.lib
{
    class EditFiles
    {
        public List<AudioFiles> main { get; set; }

        //принимает элемент для редактирования 
        //принимает флаг проверить ли элемент на дубли 
        public void editElement(AudioFiles element, bool flag)
        {

        }

        //Проверяет лист не пустые ли строки и если пустые заполняем их из названия 
        //Удаляем не нужнве коментарии 
        public void startEdit()
        {
            foreach(AudioFiles element in main)
            {
                bool isSave = element.artist == "" || element.title == "" || element.comment != "";
                if (element.artist == "")
                    element.artist = element.fileName;
                if (element.title == "")
                    element.title = element.fileName;
                if (element.comment != "")
                    element.comment = "";
                if (isSave)
                    element.tegs.Save();
            }
        }
    }
}
