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
    
    public partial class RaceParam
    {
        public int ID { get; set; }
        public int RaceID { get; set; }
        public string Param { get; set; }
        public int Bonus { get; set; }
        public bool IsChoosable { get; set; }
    
        public virtual Races Races { get; set; }
    }
}
