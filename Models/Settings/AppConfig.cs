using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Namada_Maui.Models.Settings
{
    public class AppConfig : INotifyPropertyChanged
    {
        private int id;
        private string? language;
        private byte theme;
        public static string Uri = "https://namada-rpc.palamar.io";

        #region Information

        private uint version;                   // Версия базы данных

        private bool firstStart;                // Первый запуск

        private bool whatNew;                   // Что нового?

        private bool warning;                   // Предупреждение

        private bool instruction;               // Инструкция

        #endregion

        [PrimaryKey]
        public int Id
        {
            get { return id; }
            set
            {
                if (id == value) { return; }
                id = value;
            }
        }

        #region URI

        public static string OverviewUri(uint? height = null)
        {
            if (height == null)
            {
                return Uri + "/header?height";
            }
            else
            {
                return Uri + "/header?height=" + height.Value;
            }
        }

        public static string ValidatorsUri(ushort page = 1, ushort quantity = 100)
        {
            return Uri + "/validators?height&page="+ page + "&per_page=" + quantity;
        }

        public static string BlockUri(uint? height = null)
        {
            return $"{Uri}/blockchain?minHeight={height}&maxHeight={height}";
        }

        public static string BlocksUri(uint? minHeight = null, uint? maxHeight = null)
        {
            if (minHeight == null && maxHeight == null)
            {
                return Uri + "/blockchain";
            }
            else
            {
                return $"{Uri}/blockchain?minHeight={minHeight}&maxHeight={maxHeight}";
            }
        }

        public static string SignaturesUri(uint? height = null)
        {
            if (height == null)
            {
                return Uri + "/commit?height";
            }
            else
            {
                return Uri + "/commit?height=" + height.Value;
            }
        }

        #endregion

        #region Language

        public string? Language
        {
            get { return language; }
            set
            {
                if (language == value) { return; }
                language = value;
                OnPropertyChanged(nameof(Language));
            }
        }

        #endregion

        #region Theme

        public byte Theme
        {
            get { return theme; }
            set
            {
                if (theme == value) { return; }
                theme = value;
                OnPropertyChanged(nameof(Theme));
            }
        }

        #endregion

        #region Information

        public uint Version
        {
            get => version; set
            {
                if (version == value) { return; }

                version = value;
            }
        }

        [Ignore]
        public bool FirstStart
        {
            get => firstStart; set
            {
                if (firstStart == value) { return; }

                firstStart = value;
            }
        }

        [Ignore]
        public bool WhatNew
        {
            get => whatNew; set
            {
                if (whatNew == value) { return; }

                whatNew = value;
            }
        }

        [Ignore]
        public bool Warning
        {
            get => warning; set
            {
                if (warning == value) { return; }

                warning = value;
            }
        }

        [Ignore]
        public bool Instruction
        {
            get => instruction; set
            {
                if (instruction == value) { return; }

                instruction = value;
            }
        }

        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = "") { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}