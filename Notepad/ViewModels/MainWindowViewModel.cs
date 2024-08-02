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

        private int _contentFontsize;

        public int ContentFontsize
        {
            get { return _contentFontsize; }
            set
            {
                _contentFontsize = value;
                RaisePropertyChanged(nameof(ContentFontsize));
            }
        }

        public DelegateCommand ZoomInCommand { get; set; }
        public DelegateCommand ZoomOutCommand { get; set; }
        public DelegateCommand ZoomDefaultCommand { get; set; }
        public DelegateCommand NewNoteCommand { get; set; }

        public MainWindowViewModel()
        {
            _content = string.Empty;
            _contentFontsize = 14;

            NewNoteCommand = new DelegateCommand((param) => { Content = string.Empty; });
            ZoomInCommand = new DelegateCommand((param) => 
            { 
                if (ContentFontsize <= 96)
                    ContentFontsize += 4; 
            });
            ZoomOutCommand = new DelegateCommand((param) => 
            { 
                if (ContentFontsize > 4)
                    ContentFontsize -= 4; 
            });
            ZoomDefaultCommand = new DelegateCommand((param) => { ContentFontsize = 14; });
        }


    }
}
