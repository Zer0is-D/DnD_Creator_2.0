//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DnD_Creator_2._0
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chosable
    {
        public int ID { get; set; }
        public int ClassID { get; set; }
        public int SpecID { get; set; }
    
        public virtual Classes Classes { get; set; }
    }
}
