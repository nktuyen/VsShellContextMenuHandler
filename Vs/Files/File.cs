using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Vs
{
    public class LineReadingEventArgs : EventArgs
    {
        internal string Path { get; set; }
        internal bool Cancel { get; set; }
        internal string Data { get; set; }
        internal long Line { get; set; }
        internal LineReadingEventArgs(string path = "")
        {
            this.Cancel = false;
            this.Data = string.Empty;
            this.Line = 0;
            this.Path = path;
        }
    }

    public class File
    {
        public delegate void FileLoadEventDelegator(object sender, LineReadingEventArgs e);
        public event FileLoadEventDelegator LoadStart;
        public event FileLoadEventDelegator LoadCompeleted;
        public event FileLoadEventDelegator LineReading;
        private System.IO.FileInfo Info { get; set; }
        public string Path {
            get
            {
                return this.Info.FullName;
            }
            set
            {
                this.Info = new System.IO.FileInfo(value);
            }
        }
        
        public bool Exist
        {
            get
            {
                return this.Info.Exists;
            }
        }

        public string DirectoryPath
        {
            get
            {
                return this.Info.DirectoryName;
            }
        }

        public string Name
        {
            get
            {
                return this.Info.Name;
            }
        }

        public string Extension
        {
            get
            {
                return this.Info.Extension;
            }
        }

        public long Size
        {
            get
            {
                return this.Info.Length;
            }
        }

        public File(string strPath = "")
        {
            this.Path = strPath;
            try
            {
                this.Info = new System.IO.FileInfo(this.Path);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
            }
        }
        protected virtual void OnFileLoadStart(LineReadingEventArgs e)
        {
            LoadStart?.Invoke(this, e);
        }
        protected virtual void OnFileLineReading(LineReadingEventArgs e)
        {
            LineReading?.Invoke(this, e);
        }

        protected virtual void OnFileLoadCompeleted(LineReadingEventArgs e)
        {
            LoadCompeleted?.Invoke(this, e);
        }
        public bool Load()
        {
            System.IO.StreamReader streamReader = null;
            try
            {
                streamReader = new System.IO.StreamReader(this.Path);
            }
            catch(Exception ex)
            {
                Debug.Print(ex.Message);
                streamReader = null;
            }

            if (streamReader == null)
            {
                return false;
            }

            LineReadingEventArgs e = new LineReadingEventArgs(this.Path);
            OnFileLoadStart(e);
            if (e.Cancel)
                return false;

            e.Line = 0;
            while((e.Data = streamReader.ReadLine()) != null)
            {
                e.Line++;
                e.Cancel = false;
                OnFileLineReading(e);
                if (e.Cancel)
                    break;
            }
            streamReader.Close();
            OnFileLoadCompeleted(e);
            return true;
        }
    }
}