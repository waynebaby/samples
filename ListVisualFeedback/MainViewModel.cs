//    THIS SAMPLE CODE IS PROVIDED FOR THE PURPOSE OF ILLUSTRATION ONLY
//    AND IS NOT INTENDED TO BE USED IN A PRODUCTION ENVIRONMENT.

//    THIS SAMPLE CODE AND ANY RELATED INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY
//    OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//    IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ListVisualFeedback.Models;

namespace ListVisualFeedback
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Categories = new List<Category>
            {
                new Category
                {
                    Name = "Windows",
                    Subcategories = new List<string>
                    {
                        "Desktop",
                        "Mobile",
                        "HoloLens",
                        "XBox",
                        "IoT"
                    }
                 },
                new Category
                {
                    Name = "Azure",
                    Subcategories = new List<string>
                    {
                       "Virtual machines",
                       "App Services",
                       "Machine Learning",
                       "IoT Hub" 
                    }
                },
                new Category
                {
                    Name = "Office",
                    Subcategories = new List<string>
                    {
                        "Office 365",
                        "Office 2016",
                        "Office for iPad",
                        "Office for Android"
                    }
                }
            };
        }

        private List<Category> _categories;

        public List<Category> Categories
        {
            get { return _categories; }
            set { SetProperty(ref _categories, value); }
        }

        private Category _selectedCategory;

        public Category SelectedCategory
        {
            get { return _selectedCategory; }
            set { SetProperty(ref _selectedCategory, value); }
        }


        #region INotifyPropertyChanged implementation details
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)
        {
            if (object.Equals(storage, value)) return false;

            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
