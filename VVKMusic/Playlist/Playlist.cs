﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Status = Common.Common.Status;

namespace Playlist
{
    public class Playlist
    {
        private List<Song> _ListOfSongs;

        public Status MoveSong(int oldIndex, int newIndex)
        {
            Song songToMove = _ListOfSongs[oldIndex];
            _ListOfSongs.RemoveAt(oldIndex);
            _ListOfSongs.Insert(newIndex, songToMove);
            return Status.OK;
        }
        public Status UpdateList(Song[] songMas)
        {
            _ListOfSongs.Clear();
            _ListOfSongs.AddRange(songMas);
            return Status.OK;
        }
        public Status AddToList(Song[] songMas, int index)
        {
            _ListOfSongs.InsertRange(index, songMas);
            return Status.OK;
        }
        public Status AddToList(Song song, int index)
        {
            _ListOfSongs.Insert(index, song);
            return Status.OK;
        }
        Status RemoveFromList(int index)
        {
            _ListOfSongs.RemoveAt(index);
            return Status.OK;
        }
        public void MixPlaylist()
        {
            Random rng = new Random();
            int n = _ListOfSongs.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Song value = _ListOfSongs[k];
                _ListOfSongs[k] = _ListOfSongs[n];
                _ListOfSongs[n] = value;
            }
        }
        public void SortByDownloaded()
        {
            _ListOfSongs.Sort((song1,song2) => song1.Downloaded.CompareTo(song2.Downloaded));
        }
        public Song[] SearchSong(string pattern)
        {
            return _ListOfSongs.FindAll(x => x.Title == pattern).ToArray();
        }
        public Song[] GetList()
        {
            return _ListOfSongs.ToArray();
        }
    }
}
