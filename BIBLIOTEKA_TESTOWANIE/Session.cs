using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIBLIOTEKA_TESTOWANIE
{
    public static class Session
    {
        public static int LoggedInUserId { get; set; }
        public static List<string> UprawnieniaUzytkownika { get; set; } = new List<string>();
    }
}
