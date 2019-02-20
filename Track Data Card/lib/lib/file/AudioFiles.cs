using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Track_Data_Card.lib.export
{
    public class AudioFiles//просто загружает файлы не увликайся 
    {
        public int id { get; set; }
        public string fileName { get; set; }
        public string ext { get; set; }
        public string path { get; set; }
        public TagLib.File tegs { get; set; }

        public string artist
        {
            get => string.Join("/", tegs.Tag.Performers);
            set
            {

                string[] vl = {value};
                tegs.Tag.Performers = vl;
            }
        }
        public string title
        {
            get => (tegs.Tag.Title == null) ? "" : tegs.Tag.Title;
            set => tegs.Tag.Title = value;
        }
        public string album
        {
            get => (tegs.Tag.Album == null) ? "" : tegs.Tag.Album;
            set => tegs.Tag.Album = value;
        }
        public string genre
        {
            get => string.Join("/", tegs.Tag.Genres);
            set
            {
                string[] vl = { value };
                tegs.Tag.Genres = vl;
            }
        }
        public string albumArtist
        {
            get => string.Join("/", tegs.Tag.AlbumArtists);
            set
            {
                string[] vl = { value };
                tegs.Tag.AlbumArtists = vl;
            }
        }

        public uint yearInt //year edit
        {
            get => tegs.Tag.Year;
            set => tegs.Tag.Year = value;
        }
        public string year
        {
            get => yearInt.ToString();
        }

        public string hz
        {
            get => tegs.Properties.AudioSampleRate.ToString() + "Hz";
        }
        public string bitrate
        {
            get => tegs.Properties.AudioBitrate.ToString()+" kbit/s";
        }
        public string version { get; set; }
        public string category { get; set; }

        //теги для очистки 
        public string comment
        {
            get => (tegs.Tag.Comment == null) ? "" : tegs.Tag.Comment;
            set => tegs.Tag.Comment = value;
        }
    }
}
