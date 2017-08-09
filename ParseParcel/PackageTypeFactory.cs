﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseParcel
{
    public abstract class PackageTypeFactory
    {
        public abstract PackageTypeBase GetPackageType();
    }
}
