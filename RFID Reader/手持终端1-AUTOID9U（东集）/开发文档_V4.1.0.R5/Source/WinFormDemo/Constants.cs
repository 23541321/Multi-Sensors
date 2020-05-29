using System;

using System.Collections.Generic;
using System.Text;

namespace WinFormDemo
{
    class Constants
    {
        public static String DEFAULT_EPC_READ_WORD_COUNT = "12";
        public static String DEFAULT_EPC_READ_OFFSET = "0";

        public static String DEFAULT_TID_READ_WORD_COUNT = "6";
        public static String DEFAULT_TID_READ_OFFSET = "0";

        public static String DEFAULT_USER_READ_WORD_COUNT = "6";
        public static String DEFAULT_USER_READ_OFFSET = "0";

        public static String DEFAULT_RESERVED_READ_WORD_COUNT = "4";
        public static String DEFAULT_RESERVED_READ_OFFSET = "0";

        public static String INIT_ACCESS_PASSWORD = "00000000";

        public static int READ_COUNT = 10;//读次数
        public static int WRITE_COUNT = 20;//写次数
    }
}
