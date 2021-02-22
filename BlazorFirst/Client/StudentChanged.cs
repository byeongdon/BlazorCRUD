using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BlazorFirst.Client
{
    class StudentChanged : INotifyPropertyChanged
    {
        private string gradeValue = String.Empty;
        private string cClassValue = String.Empty;
        private string noValue = String.Empty;
        private string nameValue = String.Empty;
        private string scoreValue = String.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public static StudentChanged CreateNewStudent(string grade, string cClass, string no, string name, string score)
        {

            StudentChanged stdChanged = new StudentChanged();

            stdChanged.gradeValue = grade;
            stdChanged.cClassValue = cClass;
            stdChanged.noValue = no;
            stdChanged.nameValue = name;
            stdChanged.scoreValue = score;

            return stdChanged;
        }

        public string Grade
        {
            get
            {
                return this.gradeValue;
            }

            set
            {
                if (value != this.gradeValue)
                {
                    this.gradeValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string CClass
        {
            get
            {
                return this.cClassValue;
            }

            set
            {
                if (value != this.cClassValue)
                {
                    this.cClassValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string NO
        {
            get
            {
                return this.noValue;
            }

            set
            {
                if (value != this.noValue)
                {
                    this.noValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get
            {
                return this.nameValue;
            }

            set
            {
                if (value != this.nameValue)
                {
                    this.nameValue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Score
        {
            get
            {
                return this.scoreValue;
            }

            set
            {
                if (value != this.scoreValue)
                {
                    this.scoreValue = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}

