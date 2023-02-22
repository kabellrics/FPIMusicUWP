using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.System;

namespace FPIMusicUWP.Core.Model
{
    public class PlayerInfoChangedMessage : ValueChangedMessage<String>
    {
        public PlayerInfoChangedMessage(string value) : base(value)
        {
        }
    }
}
