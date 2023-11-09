using System;

namespace Tumakov
{
    class Song
    {
        public string name { get; private set; }
        public string author { get; private set; }
        public Song previousSong { get; private set; }
        public Song() {
            name = "unknown";
            author = "unknown";
            previousSong = null;
        }
        public Song(string name, string author)
        {
            this.name = name;
            this.author = author;
            previousSong = null;
        }
        public Song(string name, string author, Song previousSong)
        {
            this.name = name;
            this.author = author;
            this.previousSong = previousSong;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetPreviousSong(Song previousSong)
        {
            this.previousSong = previousSong;
        }
        public string Title()
        {
            return $"{name} - {author}";
        }

    }
}