using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PianoForte.View;

namespace PianoForte.Interface
{
    interface FormInterface
    {
        void load(MainForm mainForm);
        void reload();
        void reset();
    }
}
