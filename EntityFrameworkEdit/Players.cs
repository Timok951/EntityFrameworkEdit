//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFrameworkEdit
{
    using System;
    using System.Collections.Generic;
    
    public partial class Players
    {
        public int IDPlayer { get; set; }
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }
        public int ID_Weapon { get; set; }
    
        public virtual Weapon Weapon { private get; set; }
    }
}