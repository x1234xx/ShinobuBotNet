﻿using System.Text.RegularExpressions;

namespace ShinobuBotNet
{
    class cmd
    {
        public string ComType { get; private set; }
        public string ComContent { get; private set; }

        public cmd(string input_content)
        {
            string[] cmd_cnt = Regex.Split(input_content, config.spliter);

            ComType = cmd_cnt[0];
            ComContent = cmd_cnt[1];
        }
    }
}
