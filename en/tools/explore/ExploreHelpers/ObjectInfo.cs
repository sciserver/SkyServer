﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SkyServer.Tools.Explore
{
    public class ObjectInfo
    {
        public long? id = null;
        public string apid;
        public long? specId = null;

        public string objId = null;
        public string specObjId = null;

        public double? ra = null;
        public double? dec = null;
        
        public int? mjd = null;
        public short? plate = null;
        public string plateId = null;       
        public short? fiberId = null;
        public string fieldId = null;

        public int? run = null;
        public short? rerun = null;
        public short? camcol = null;
        public short? field = null;
    }
}