﻿using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DataBase
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int PersonID { get; set; }
        
        public string Name { get; set; }
    }
}
