using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8Group1MVVM
{
    class Section : INotifyPropertyChanged
    {
        #region PROPERTIES AND CONSTANTS
        const string DATA_FILE_SECTION1 = "Section1.txt";
        const string DATA_FILE_SECTION2 = "Section2.txt";
        const string DATA_FILE_SECTION3 = "Section3.txt";
        string[][] sectionMarks = new string[3][];
        public System.Collections.ObjectModel.ObservableCollection<string> Section1Marks
        {
            get { return _Section1Marks; }
            set { _Section1Marks = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _Section1Marks;
        public System.Collections.ObjectModel.ObservableCollection<string> Section2Marks
        {
            get { return _Section2Marks; }
            set { _Section2Marks = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _Section2Marks;
        public System.Collections.ObjectModel.ObservableCollection<string> Section3Marks
        {
            get { return _Section3Marks; }
            set { _Section3Marks = value; OnPropertyChanged(); }
        }
        private ObservableCollection<string> _Section3Marks;
        public double Section1Average
        {
            get { return _Section1Average; }
            set { _Section1Average = value; OnPropertyChanged(); }
        }
        private double _Section1Average;
        public double Section2Average
        {
            get { return _Section2Average; }
            set { _Section2Average = value; OnPropertyChanged(); }
        }
        private double _Section2Average;
        public double Section3Average
        {
            get { return _Section3Average; }
            set { _Section3Average = value; OnPropertyChanged(); }
        }
        private double _Section3Average;
        public double AllSectionMax
        {
            get { return _AllSectionMax; }
            set { _AllSectionMax = value; OnPropertyChanged(); }
        }
        private double _AllSectionMax;
        public double AllSectionLow
        {
            get { return _AllSectionLow; }
            set { _AllSectionLow = value; OnPropertyChanged(); }
        }
        private double _AllSectionLow;
        #endregion

        public void SetData()
        {
            sectionMarks[0] = new string[12];
            sectionMarks[1] = new string[8];
            sectionMarks[2] = new string[10];

            sectionMarks[0] = File.ReadAllLines(DATA_FILE_SECTION1);
            List<string> section1MarksList = sectionMarks[0].ToList();
            _Section1Marks = new ObservableCollection<string>(section1MarksList);
            Section1Marks = _Section1Marks;

            sectionMarks[1] = File.ReadAllLines(DATA_FILE_SECTION2);
            List<string> section2MarksList = sectionMarks[1].ToList();
            _Section2Marks = new ObservableCollection<string>(section2MarksList);
            Section2Marks = _Section2Marks;

            sectionMarks[2] = File.ReadAllLines(DATA_FILE_SECTION3);
            List<string> section3MarksList = sectionMarks[2].ToList();
            _Section3Marks = new ObservableCollection<string>(section3MarksList);
            Section3Marks = _Section3Marks;

            _Section1Average = GetAverage(section1MarksList);
            Section1Average = _Section1Average;
            _Section2Average = GetAverage(section2MarksList);
            Section2Average = _Section2Average;
            _Section3Average = GetAverage(section3MarksList);
            Section3Average = _Section3Average;

            int[] sectionMaxMarks = new int[] { int.Parse(sectionMarks[0].Max()),
                                                int.Parse(sectionMarks[1].Max()),
                                                int.Parse(sectionMarks[2].Max())};
            _AllSectionMax = sectionMaxMarks.Max();
            AllSectionMax = _AllSectionMax;

            int[] sectionLowMarks = new int[] { int.Parse(sectionMarks[0].Min()),
                                                int.Parse(sectionMarks[1].Min()),
                                                int.Parse(sectionMarks[2].Min())};
            _AllSectionLow = sectionLowMarks.Min();
            AllSectionLow = _AllSectionLow;
        }
        public double GetAverage(List<string> sectionMarkList)
        {
            double average = 0;
            double total = 0;
            for(int i =0; i< sectionMarkList.Count(); i++)
            {
                total = total + int.Parse(sectionMarkList[i]);
            }
            average = total / sectionMarkList.Count();
            return average;
        }

        #region PROPERTY CHANGES
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
