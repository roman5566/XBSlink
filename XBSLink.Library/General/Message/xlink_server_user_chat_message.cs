﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace XBSLink.General
{
    public class xlink_server_user_chat_message:xlink_msg
    {

        public string _message { get; set; }
        public string _username { get; set; }

        public void Assign(string parameters_msg)
        {
            var parameters = GetParameters();
            _username = parameters[0];
            _message = parameters[1];
            
        }

        public xlink_server_user_chat_message(xlink_msg msg)
            : base(msg)
        {
            Assign(parameters_msg);
        }

        public xlink_server_user_chat_message(string ipAddress, int port, string msgText)
            : base(ipAddress, port, msgText)
        {
            Assign(parameters_msg);
        }

        public xlink_server_user_chat_message(IPAddress ipAddress, int port, string msgText)
            : base(ipAddress, port, msgText)
        {
            Assign(parameters_msg);
        }

        void RefreshContent()
        {
            Data = getUTF8BytesFromString(XBSLink.General.xlink_client_messages_clouds_helper.ServerUserChatMessage(_username,_message));
        }


    }
}