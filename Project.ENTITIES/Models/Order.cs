using Project.ENTITIES.CoreInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.ENTITIES.Models
{
    public class Order:BaseEntity,IEntity
    {
        public string ShippedAddress { get; set; }
        public int? AppUserID { get; set; }


        //Relatinoal Properties
        public virtual AppUser AppUser { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

    }
}
