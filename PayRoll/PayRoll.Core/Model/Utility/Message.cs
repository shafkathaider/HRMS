using System.Collections.Generic;

namespace PayRoll.Core.Model.Utility
{

    public enum MessageTypes
    {
        None = 0,
        Success = 1,
        Warning = 2,
        Error = 3,
        Info = 4
    }

    public class Message
    {
        public string CurrentMessage { get; set; }
        public MessageTypes MessageType { get; set; }
        public List<string> MessageList { get; set; }
        public string RedirectUrl { get; set; }

        public Message()
        {
            CurrentMessage = string.Empty;
            MessageType = MessageTypes.None;
            MessageList = new List<string>();
            RedirectUrl = string.Empty;
        }
    }

    public class SetMessages
    {
        //public static string CommonSaveMessage = "Data has been saved";
        //public static string CommonDeleteMessage = "Data has been deleted";
        //public static string CommonErrorMessage = "An error Occurred";

        public static Message SetSuccessMessage(string message = "Data has been saved", List<string> lst = null)
        {
            var ret = new Message();

            ret.CurrentMessage = message;
            ret.MessageType = MessageTypes.Success;
            if (lst != null)
            {
                ret.MessageList = lst;
            }

            return ret;
        }

        public static Message SetErrorMessage(string message = "An error Occurred", List<string> lst = null)
        {
            var ret = new Message();

            ret.CurrentMessage = message;
            ret.MessageType = MessageTypes.Error;
            if (lst != null)
            {
                ret.MessageList = lst;
            }

            return ret;
        }

        public static Message SetWarningMessage(string message = "An error Occurred", List<string> lst = null)
        {
            var ret = new Message();

            ret.CurrentMessage = message;
            ret.MessageType = MessageTypes.Warning;
            if (lst != null)
            {
                ret.MessageList = lst;
            }

            return ret;
        }
        public static Message SetInformationMessage(string message = "", List<string> lst = null)
        {
            var ret = new Message();

            ret.CurrentMessage = message;
            ret.MessageType = MessageTypes.Info;
            if (lst != null)
            {
                ret.MessageList = lst;
            }

            return ret;
        }
        public static Message SetNoPermissionMessage(string message = "You don't have any permission on this screen.", List<string> lst = null)
        {
            var ret = new Message();

            ret.CurrentMessage = message;
            ret.MessageType = MessageTypes.Info;
            if (lst != null)
            {
                ret.MessageList = lst;
            }

            return ret;
        }
    }
}
