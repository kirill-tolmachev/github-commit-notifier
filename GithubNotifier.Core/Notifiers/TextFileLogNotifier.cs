using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GithubNotifier.Core.Formatters;

namespace GithubNotifier.Core.Notifiers
{
    class TextFileLogNotifier : INotifier
    {
        private readonly string _path;
        private readonly IFormatter _formatter;

        public TextFileLogNotifier(string path, IFormatter formatter)
        {
            _path = path;
            _formatter = formatter;
        }


        public Task Notify(GithubPayload payload)
        {
            string text = _formatter.Format(payload);
            text += "\r\n\r\n";
            File.AppendAllText(_path, text);
            return Task.CompletedTask;
        }
    }
}
