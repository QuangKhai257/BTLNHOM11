

using System.ComponentModel.DataAnnotations;

namespace BTLNHOM11.Models;
public class nhacungcap

{
    [Key]
    [Display(Name = "Mã nhà cung cấp")]
    public string mancc {get; set;}

    [Display(Name = "Tên nhà cung cấp")]
    public string tenncc {get; set;}

     [Display(Name = "Địa chỉ")]
    public string diachincc {get; set;}

     [DataType(DataType.PhoneNumber)]
     [Display(Name = "Số điện thoại")]
     [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                       ErrorMessage = "Phải nhập {0}")]
    public string sdtncc {get; set;}

     [EmailAddress(ErrorMessage = "Phải là địa chỉ email")]
     [Display(Name = "Email")]
    public string emailncc {get; set;}

}