﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smEticaret.Data.Entities
{
    public class OrderEntity
    {
        public int id { get; set; }
        public int userid { get; set; }
        public UserEntity user { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DeliveryAdress { get; set; }
    }
}