using DAL;
using MyNoteProcessor;
using NoteContracs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Wpf_UI.Infrastructure;
using Wpf_UI.Infrastructure.Commands;
using Wpf_UI.View;

namespace Wpf_UI.ViewModel.Elements
{
    class NoteViewModel:ViewModelBase
    {
        INoteProcessor _noteProcessor;
        private CreatorNotes _creatorNotes;
        public NoteViewModel(INoteProcessor noteProcessor, CreatorNotes creatorNotes)
        {
            _creatorNotes = creatorNotes;
            _noteProcessor = noteProcessor;
            #region Commands
             EditeCommand = new LambdaCommand(
                OnEditeCommand,
                CanOnEditeCommand
                );
            AddNoteCommand = new LambdaCommand(
               OnAddNoteCommand,
               CanOnAddNoteCommand
               );
            #endregion
        }
        private int _id;
        private string _name;
        private string _value;
        private int _priority;
        public MyNote myNote { get; set; }
        public int Id
        { get => _id; 
            set
            {
                _id = value;
                OnPropertyChanged();
            }   
        }
        public string Name
        {
            get => _name;
            set
            {
                _name = value; 
                OnPropertyChanged();
            }
        }
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }
        public int Priority
        {
            get => _priority;
            set
            {
                _priority = value;
                OnPropertyChanged();
            }
        }


        #region EditeCommand
        #region EditeCommand
        public ICommand EditeCommand { get; set; }

        private void OnEditeCommand(object p)
        {
            _noteProcessor.EditFromBD(
                 new MyNote()
                 {
                     Id = _id,
                     Name = _name,
                     Value = _value,
                     Priority = _priority
                 }
             );
        }
        private bool CanOnEditeCommand(object p) => true;
        #endregion
        #region AddNoteCommand
        public ICommand AddNoteCommand { get; set; }

        private void OnAddNoteCommand(object p)
        {
            var windowAdd = (Window)p;
            var newNote = new MyNote()
            {
                Name = _name,
                Value = _value,
                Priority = _priority
            };
            try
            {
                _noteProcessor.WriteToBD(newNote);
                _id = _noteProcessor.GetLastElement();
                _creatorNotes.ObsNoteViewModel.Add(this);
                windowAdd.Close();
            }
            catch (Exception ex) 
            {
            
            }           
        }
        private bool CanOnAddNoteCommand(object p) => true;
        #endregion
        #endregion
    }
}
