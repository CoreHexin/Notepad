using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notepad.ViewModels
{
    class MainWindowViewModel : NotificationObject
    {
		private string _content;

		public string Content
		{
			get { return _content; }
			set 
			{ 
				_content = value;
				RaisePropertyChanged(nameof(Content));
			}
		}

        public DelegateCommand NewNoteCommand { get; set; }

        public MainWindowViewModel()
        {
			_content = string.Empty;

			NewNoteCommand = new DelegateCommand(NewNoteCommandExecute);
        }

		private void NewNoteCommandExecute(object? parameter)
		{
			Content = string.Empty;
		}

    }
}
