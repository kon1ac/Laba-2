//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practa1
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int order_id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public Nullable<System.DateTime> order_date { get; set; }
        public Nullable<decimal> total_amount { get; set; }
    
        public virtual Customers Customers { get; set; }
    }
}