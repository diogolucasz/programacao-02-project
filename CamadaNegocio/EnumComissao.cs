using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio
{
    public enum EnumComissao
    {
        [Description("Available.")]
        Available,
        [Description("Not here right now.")]
        Away,
        [Description("I don't have time right now.")]
        Busy
    };
};
