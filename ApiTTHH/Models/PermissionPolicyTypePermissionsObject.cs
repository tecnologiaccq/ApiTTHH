//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTTHH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PermissionPolicyTypePermissionsObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermissionPolicyTypePermissionsObject()
        {
            this.PermissionPolicyMemberPermissionsObject = new HashSet<PermissionPolicyMemberPermissionsObject>();
            this.PermissionPolicyObjectPermissionsObject = new HashSet<PermissionPolicyObjectPermissionsObject>();
        }
    
        public System.Guid Oid { get; set; }
        public Nullable<System.Guid> Role { get; set; }
        public string TargetType { get; set; }
        public Nullable<int> ReadState { get; set; }
        public Nullable<int> WriteState { get; set; }
        public Nullable<int> CreateState { get; set; }
        public Nullable<int> DeleteState { get; set; }
        public Nullable<int> NavigateState { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
        public Nullable<int> GCRecord { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissionPolicyMemberPermissionsObject> PermissionPolicyMemberPermissionsObject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissionPolicyObjectPermissionsObject> PermissionPolicyObjectPermissionsObject { get; set; }
        public virtual PermissionPolicyRole PermissionPolicyRole { get; set; }
    }
}
