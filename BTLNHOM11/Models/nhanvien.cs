using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLNHOM11.Models;
public class nhanvien

{
    [Key]
    [Display(Name = "Mã nhân viên")]
    public string manv {get; set;}

     [Display(Name = "Tên nhân viên")]
    public string tennv {get; set;}

     [Display(Name = "Giới tính")]
    public string gtnv {get; set;}

    [DataType(DataType.Date)]
    [Display(Name = "Ngày sinh")]
    public string nsnv {get; set;}


     [DataType(DataType.PhoneNumber)]
     [Display(Name = "Số điện thoại")]
     [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                       ErrorMessage = "Phải nhập {0}")]
    public string sdtnv {get; set;}

    
     [Display(Name = "Địa chỉ")]
    public string diachinv {get; set;}

     [EmailAddress(ErrorMessage = "Phải là địa chỉ email")]
     [Display(Name = "Email")]
    public string emailnv {get; set;}


    [Display (Name = "Tên công việc")]
     public string  tencv {get; set;}
     [ForeignKey("tencv")]
     public chucvu? chucvu {get; set;}

     [DataType(DataType.Date)]
    [Display(Name = "Ngày vào làm")]
    public DateTime ngaylamnv { get; set; }



}