using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Quaider.Component;

namespace AnyOffice.Core.Models.Security
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class User : EntityBase<Guid>
    {
        public User()
        {
            Id = CombHelper.NewComb();
        }

        [Required]
        [StringLength(15)]
        public string UserName { get; set; }

        [Required]
        [StringLength(30)]
        public string FullName { get; set; }
    }
}