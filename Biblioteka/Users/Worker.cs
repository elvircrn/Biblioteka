﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Users
{
    public class Worker : User, IWorker
    {
        public ImageData ImageData { get; set; }

        public string Occupation { get; set; }

        public string WorkerID { get; set; }

        public double Salary { get; set; }

        public override string ToString()
        {
            return base.ToString() + Occupation;
        }
    }
}
